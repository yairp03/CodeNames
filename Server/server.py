from consts import ResponseCodes
import socket
from _thread import start_new_thread
from locks import server_print
import sys
import json
from client import Message, Client
from _utils import parse_message

PRINT_ACTIVE_USERS = "active"
STOP_COMMANDS = "stop", "quit", "exit"

CODE_LEN = 3
LENGTH_LEN = 5


class Server:
    def __init__(self, port):
        self.port = port
        self.active_users = []

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
        client = Client(sock, self)
        while msg := Server.recv(sock):
            if msg.code == 0:
                break
            if msg.code == ResponseCodes.BAD_MESSAGE:
                res = Message(ResponseCodes.BAD_MESSAGE, msg.data)
            else:
                res = client.handle_request(msg)
            Server.send(sock, res)
        if client.username:
            self.active_users.remove(client.username)
        server_print("Disconnected", client.sock.getpeername())
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
            str(res.code).rjust(CODE_LEN, "0")
            + str(len(json_data)).rjust(LENGTH_LEN, "0")
            + json_data
        )

        sock.send(msg.encode())
        server_print(f"Sent:     {res}", sock.getpeername())

    def handle_console(self):
        while s := input().lower():
            if s in STOP_COMMANDS:
                sys.exit(1)
            elif s == PRINT_ACTIVE_USERS:
                print("Active users:", self.active_users)
