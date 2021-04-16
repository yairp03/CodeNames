from __future__ import annotations
from message import Message
from consts import *
from database import Database
from _utils import validate_username, validate_password, extract_data
from typing import TYPE_CHECKING

if TYPE_CHECKING:
    from server import Server


BAD_MESSAGE_CODE = Message(ResponseCodes.BAD_MESSAGE, "Bad message code")
BAD_MESSAGE_DATA = Message(ResponseCodes.BAD_MESSAGE, "Bad message data")


class Client:
    def __init__(self, server: Server):
        self.server = server
        self.state = States.NOT_AUTHORIZED
        self.username = ""
        self.game_room = None
        self.manager = False
        self.team = None

    def handle_request(self, req: Message) -> Message:
        if self.state == States.NOT_AUTHORIZED:
            if req.code == RequestCodes.LOGIN:
                return self.login(req.data)
            elif req.code == RequestCodes.SIGNUP:
                return self.signup(req.data)
        else:
            if req.code == RequestCodes.LOGOUT:
                return self.logout()

            elif self.state == States.MAIN:
                if req.code == RequestCodes.CREATE_ROOM:
                    return self.create_room(req.data)
                elif req.code == RequestCodes.JOIN_ROOM:
                    return self.join_room(req.data)
                elif req.code == RequestCodes.LIST_ROOMS:
                    return self.list_rooms()
                elif req.code == RequestCodes.DELETE_USER:
                    res = self.delete_user()
                    self.logout()
                    return res

            elif self.state == States.LOBBY:
                if req.code == RequestCodes.START_GAME:
                    return self.start_game()
                elif req.code == RequestCodes.LEAVE_ROOM:
                    return self.leave_room()
                elif req.code == RequestCodes.LOBBY_UPDATES:
                    return self.lobby_updates()

            elif self.state == States.GAME:
                if req.code == RequestCodes.GAME_STATE:
                    return self.game_state()
                elif req.code == RequestCodes.REVEAL_CARD:
                    return self.reveal_card()
                elif req.code == RequestCodes.LEAVE_ROOM:
                    return self.leave_room()

        return BAD_MESSAGE_CODE

    def login(self, data: dict) -> Message:
        if not (data_list := extract_data(data, "username", "password")):
            return BAD_MESSAGE_DATA
        username, password = data_list
        if Database.user_exists(username):
            if Database.user_exists(username, password):
                if username in self.server.active_users:
                    return Message(ResponseCodes.LOGIN_USER_ACTIVE)
                self.login_success(username)
                return Message(ResponseCodes.LOGIN_SUCCESS)
            else:
                return Message(ResponseCodes.LOGIN_WRONG_PASSWORD)
        else:
            return Message(ResponseCodes.LOGIN_USERNAME_DOESNT_EXISTS)

    def signup(self, data: dict) -> Message:
        if not (data_list := extract_data(data, "username", "password")):
            return BAD_MESSAGE_DATA
        username, password = data_list
        if Database.user_exists(username):
            return Message(ResponseCodes.SIGNUP_USERNAME_EXISTS)
        elif not validate_username(username):
            return Message(ResponseCodes.SIGNUP_INVALID_USERNAME)
        elif not validate_password(password):
            return Message(ResponseCodes.SIGNUP_INVALID_PASSWORD)
        else:
            Database.create_user(username, password)
            self.login_success(username)
            return Message(ResponseCodes.SIGNUP_SUCCESS)

    def login_success(self, username: str):
        self.state = States.MAIN
        self.username = username
        self.server.active_users.append(username)

    def logout(self) -> Message:
        if self.game_room:
            self.leave_room()
        self.state = States.NOT_AUTHORIZED
        self.server.active_users.remove(self.username)
        self.username = ""
        return Message(ResponseCodes.LOGOUT_SUCCESS)

    def delete_user(self) -> Message:
        Database.delete_user(self.username)
        return Message(ResponseCodes.DELETE_USER_SUCCESS)

    def disconnect(self):
        if self.username:
            self.logout()

    def create_room(self, data: dict) -> Message:
        if not (data_list := extract_data(data, "max_players")):
            return BAD_MESSAGE_DATA
        max_players = data_list[0]
        if max_players > Consts.MAX_ROOM_PLAYERS:
            return Message(ResponseCodes.BAD_MAX_PLAYERS)
        game_room = self.server.create_game(self.username, max_players)
        self.game_room = game_room
        self.state = States.LOBBY
        return Message(ResponseCodes.CREATE_ROOM_SUCCESS)

    def join_room(self, data: dict) -> Message:
        if not (data_list := extract_data(data, "admin")):
            return BAD_MESSAGE_DATA
        admin = data_list[0]
        if (
            room := next((r for r in self.server.game_rooms if r.admin == admin), None)
        ) and room.is_joinable():
            room.add_user(self.username)
            self.game_room = room
            self.state = States.LOBBY
            return Message(ResponseCodes.JOIN_ROOM_SUCCESS)
        else:
            return Message(ResponseCodes.JOIN_ROOM_FAILED)

    def list_rooms(self) -> Message:
        rooms = [
            {
                "admin": room.admin,
                "curr_players": len(room.players),
                "max_players": room.max_players,
            }
            for room in self.server.game_rooms
            if not room.started and room.is_joinable()
        ]
        return Message(ResponseCodes.ROOMS_LIST, rooms)

    def start_game(self) -> Message:
        if self.username != self.game_room.admin:
            return Message(ResponseCodes.NOT_ROOM_ADMIN)
        elif not self.game_room.can_start():
            return Message(ResponseCodes.NOT_ENOUGH_PLAYERS)

        self.state = States.GAME
        self.game_room.start()

        return Message(ResponseCodes.GAME_START_SUCCESS)

    def leave_room(self) -> Message:
        if self.game_room.admin == self.username or self.game_room.started:
            self.game_room.deleted = True
            self.server.remove_game(self.game_room)
        self.game_room.players.remove(self.username)
        self.game_room = None
        self.manager = False
        self.team = None
        self.state = States.MAIN
        return Message(ResponseCodes.LEAVE_ROOM_SUCCESS)

    def lobby_updates(self) -> Message:
        if self.game_room.deleted:
            self.leave_room()
            return Message(ResponseCodes.LOBBY_DELETED)
        elif self.game_room.started:
            self.state = States.GAME
            return Message(ResponseCodes.LOBBY_STARTED)
        else:
            return Message(
                ResponseCodes.LOBBY_UPDATE, self.game_room.get_players_list()
            )

    def game_state(self) -> Message:
        return Message(
            ResponseCodes.GAME_STATE,
            self.game_room.get_state(self.game_room.admin == self.username),
        )

    def reveal_card(self) -> Message:
        return Message(ResponseCodes.REVEAL_SUCCESS)
