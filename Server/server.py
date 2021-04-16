from database import Database
from game import GameRoom
from consts import ResponseCodes, Consts
import socket
from _thread import start_new_thread
from locks import server_print
import sys
import json
from message import Message
from client import Client
from _utils import parse_message


class Server:
    def __init__(self, port):
        self.port = port
        self.active_users = []
        self.game_rooms = []

    def run(self):
        start_new_thread(self.listen, ())
        self.handle_console()

    def listen(self):
        sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        sock.bind(("", self.port))
        server_print(f"Socket binded to port {self.port}")

        sock.listen(5)
        server_print("Socket is listening")

        while True:
            c, addr = sock.accept()
            server_print(f"Connected to: {addr[0]}:{addr[1]}")
            start_new_thread(self.handle_user, (c,))

    def handle_user(self, sock: socket.socket):
        client = Client(self)
        while msg := Server.recv(sock):
            if msg.code == ResponseCodes.BAD_MESSAGE:
                res = Message(ResponseCodes.BAD_MESSAGE, msg.data)
            else:
                res = client.handle_request(msg)
            Server.send(sock, res)
        client.disconnect()
        server_print("Disconnected", sock.getpeername())
        sock.close()

    @staticmethod
    def recv(sock: socket.socket) -> Message:
        try:
            req = sock.recv(1024).decode()
        except ConnectionResetError:
            return Message()
        if req:
            try:
                msg = parse_message(req)
            except ValueError as e:
                server_print(f"Bad received: {req.encode()}", sock.getpeername())
                msg = Message(ResponseCodes.BAD_MESSAGE, str(e))
            else:
                server_print(f"Received: {msg}", sock.getpeername())
            return msg
        else:
            return Message()

    @staticmethod
    def send(sock: socket.socket, res: Message):
        json_data = json.dumps(res.data)
        msg = (
            str(res.code).rjust(Consts.CODE_LEN, "0")
            + str(len(json_data)).rjust(Consts.LENGTH_LEN, "0")
            + json_data
        )

        sock.send(msg.encode())
        server_print(f"Sent:     {res}", sock.getpeername())

    def handle_console(self):
        while s := input().lower().split():
            if s[0] in ("stop", "quit", "exit"):
                sys.exit()
            elif s[0] == "help":
                print(
                    """\
active - print active users
games - print active games
words add|show - add or print words
stop|quit|exit - stop the server
help - print this message"""
                )
            elif s[0] == "active":
                print("Active users:", self.active_users)
            elif s[0] == "words" and len(s) >= 2:
                if s[1] == "add":
                    Database.add_words(*s[2:])
                elif s[1] == "show":
                    print(Database.get_words())
            elif s[0] == "games":
                print(
                    "Active games:",
                    *(game.players for game in self.game_rooms),
                    sep="\n",
                )

    def create_game(self, host_username: str, max_players: int) -> GameRoom:
        game_room = GameRoom(host_username, max_players)
        self.game_rooms.append(game_room)
        return game_room

    def remove_game(self, game_room):
        self.game_rooms.remove(game_room)
