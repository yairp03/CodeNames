from codes import BAD_MESSAGE
import socket
import threading
from _thread import *
from locks import server_print
import sys
import json
from client import Message, Client
from _utils import parse_message

STOP = "stop"
CODE_LEN = 3
LENGTH_LEN = 5


class Server:
    def __init__(self, port):
        self.port = port

    def run(self):
        start_new_thread(self.listen, ())
        Server.handle_console()

    def listen(self):
        sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        sock.bind(("", self.port))
        server_print(f"Socket binded to port {self.port}")

        sock.listen(5)
        server_print("Socket is listening")

        while True:
            c, addr = sock.accept()
            server_print(f"Connected to: {addr[0]}:{addr[1]}")
            start_new_thread(Server.handle_user, (c,))

    @staticmethod
    def handle_user(sock: socket.socket):
        client = Client(sock)
        while msg := Server.recv(sock):
            if msg.code == 0:
                break
            if msg.code == BAD_MESSAGE:
                res = Message(BAD_MESSAGE, msg.data)
            else:
                res = client.handle_request(msg)
            Server.send(sock, res)
        server_print("Disconnected", client.peername)
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
                msg = Message(BAD_MESSAGE, str(e))
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

    @staticmethod
    def handle_console():
        while s := input():
            if s == STOP:
                sys.exit(1)
