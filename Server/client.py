from server import Server
from consts import *
from database import db, User
from hashlib import md5
import string
import socket


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

    def handle_request(self, req: Message) -> Message:
        if self.state == States.NOT_AUTHORIZED:
            if req.code == RequestCodes.LOGIN:
                return self.login(req.data)
            elif req.code == RequestCodes.SIGNUP:
                return self.signup(req.data)
        elif self.state == States.MAIN:
            if req.code == RequestCodes.LOGOUT:
                return self.logout()
            elif req.code == RequestCodes.DELETE_USER:
                self.logout()
                return self.delete_user()
        return BAD_MESSAGE_CODE

    def login(self, data: dict) -> Message:
        try:
            username = data["username"]
            password = data["password"]
        except (KeyError, TypeError):
            return BAD_MESSAGE_DATA
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
        try:
            username = data["username"]
            password = data["password"]
        except (KeyError, TypeError):
            return BAD_MESSAGE_DATA
        if len(db.query(User).filter(User.username == username).all()) == 1:
            return Message(ResponseCodes.SIGNUP_USERNAME_EXISTS)
        elif not self._validate_username(username):
            return Message(ResponseCodes.SIGNUP_INVALID_USERNAME)
        elif not self._validate_password(password):
            return Message(ResponseCodes.SIGNUP_INVALID_PASSWORD)
        else:
            user = User(username=username, password=md5(password.encode()).hexdigest())
            db.add(user)
            db.commit()
            self.login_success(username)
            return Message(ResponseCodes.SIGNUP_SUCCESS)

    @staticmethod
    def _validate_username(username: str) -> bool:
        for c in username:
            if not (c.isalnum() or c == "_"):
                return False
        return True

    @staticmethod
    def _validate_password(password: str) -> bool:
        for c in password:
            if not (c.isalnum() or c in string.punctuation):
                return False
        return True

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
