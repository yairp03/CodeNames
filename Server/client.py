from typing import List
from game import GameRoom
from server import PRINT_ACTIVE_USERS, Server
from consts import *
from database import db, User
from hashlib import md5
import socket
from _utils import validate_username, validate_password, extract_data


class Message:
    def __init__(self, code=0, data=""):
        self.code = code
        self.data = data

    def __str__(self):
        return f"{to_string(self.code)}: {str(str(self.data).encode())[1:]}"

    def __bool__(self):
        return self.code != 0


BAD_MESSAGE_CODE = Message(ResponseCodes.BAD_MESSAGE, "Bad message code")
BAD_MESSAGE_DATA = Message(ResponseCodes.BAD_MESSAGE, "Bad message data")


class Client:
    def __init__(self, sock: socket.socket, server: Server):
        self.server = server
        self.sock = sock
        self.state = States.NOT_AUTHORIZED
        self.username = ""
        self.game_room = None

    def handle_request(self, req: Message) -> Message:
        if self.state == States.NOT_AUTHORIZED:
            if req.code == RequestCodes.LOGIN:
                return self.login(req.data)
            elif req.code == RequestCodes.SIGNUP:
                return self.signup(req.data)

        elif self.state == States.MAIN:
            if req.code == RequestCodes.CREATE_ROOM:
                return self.create_room(req.data)
            elif req.code == RequestCodes.JOIN_ROOM:
                return self.join_room(req.data)
            elif req.code == RequestCodes.LIST_ROOMS:
                return self.list_rooms()
            elif req.code == RequestCodes.START_GAME:
                return self.start_game()
            elif req.code == RequestCodes.LEAVE_ROOM:
                return self.leave_room()
            elif req.code == RequestCodes.LOGOUT:
                return self.logout()
            elif req.code == RequestCodes.DELETE_USER:
                self.logout()
                return self.delete_user()

        return BAD_MESSAGE_CODE

    def login(self, data: dict) -> Message:
        if not (data_list := extract_data(data, "username", "password")):
            return BAD_MESSAGE_DATA
        username, password = data_list
        user_rows = db.query(User).filter(User.username == username)
        if len(user_rows.all()) == 1:
            user_pass_rows = user_rows.filter(
                User.password == md5(password.encode()).hexdigest()
            )
            if len(user_pass_rows.all()) == 1:
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
        if len(db.query(User).filter(User.username == username).all()) == 1:
            return Message(ResponseCodes.SIGNUP_USERNAME_EXISTS)
        elif not validate_username(username):
            return Message(ResponseCodes.SIGNUP_INVALID_USERNAME)
        elif not validate_password(password):
            return Message(ResponseCodes.SIGNUP_INVALID_PASSWORD)
        else:
            user = User(username=username, password=md5(password.encode()).hexdigest())
            db.add(user)
            db.commit()
            self.login_success(username)
            return Message(ResponseCodes.SIGNUP_SUCCESS)

    def login_success(self, username: str):
        self.state = States.MAIN
        self.username = username
        self.server.active_users.append(username)

    def logout(self) -> Message:
        self.state = States.NOT_AUTHORIZED
        self.server.active_users.remove(self.username)
        self.username = ""
        return Message(ResponseCodes.LOGOUT_SUCCESS)

    def delete_user(self) -> Message:
        db.query(User).filter(User.username == self.username).delete()
        db.commit()
        return Message(ResponseCodes.DELETE_USER_SUCCESS)

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
        if not (data_list := extract_data(data, "room_id")):
            return BAD_MESSAGE_DATA
        room_id = data_list[0]
        if self.server.game_rooms[room_id].is_joinable():
            self.server.game_rooms[room_id].add_user(self.username)
            self.game_room = self.server.game_rooms[room_id]
            self.state = States.LOBBY
            return Message(ResponseCodes.JOIN_ROOM_SUCCESS)
        else:
            return Message(ResponseCodes.JOIN_ROOM_FAILED)

    def list_rooms(self) -> Message:
        rooms = [
            {"game_id": i, "admin": room.admin, "max_players": room.max_players}
            for i, room in enumerate(self.server.game_rooms)
            if not room.started
        ]
        return Message(ResponseCodes.ROOMS_LIST, rooms)

    def start_game(self) -> Message:
        if self.username != self.game_room.admin:
            return Message(ResponseCodes.NOT_ROOM_ADMIN)
        elif not self.game_room.can_start():
            return Message(ResponseCodes.NOT_ENOUGH_PLAYERS)

        # TODO: implement game

        return Message(ResponseCodes.GAME_START_SUCCESS)

    def leave_room(self) -> Message:
        if self.game_room.admin == self.username:
            self.server.remove_game(self.game_room)
        self.game_room = None
        self.state = States.MAIN
        return Message(ResponseCodes.LEAVE_ROOM_SUCCESS)
