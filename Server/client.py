from sqlalchemy.sql.functions import user
import states
import codes
from database import db, User
from hashlib import md5
import string


class Message:
    def __init__(self, code=0, data=""):
        self.code = code
        self.data = data

    def __str__(self):
        return f"{codes.to_string(self.code)}: {str(self.data).encode()}"

    def __bool__(self):
        return self.code != 0


BAD_MESSAGE_CODE = Message(codes.BAD_MESSAGE, "Bad message code")
BAD_MESSAGE_DATA = Message(codes.BAD_MESSAGE, "Bad message data")


POSSIBLE_CODES = {
    states.NOT_AUTHORIZED: (codes.LOGIN, codes.SIGNUP),
    states.MAIN: (
        codes.LIST_ROOMS,
        codes.JOIN_ROOM,
        codes.CREATE_ROOM,
        codes.GET_STATISTICS,
        codes.LOGOUT,
        codes.DELETE_USER,
    ),
}


class Client:
    def __init__(self, sock):
        self.sock = sock
        self.state = states.NOT_AUTHORIZED
        self.username = ""

    def handle_request(self, req: Message):
        if req.code not in POSSIBLE_CODES[self.state]:
            return BAD_MESSAGE_CODE

        if req.code == codes.LOGIN:
            return self.login(req.data)
        elif req.code == codes.SIGNUP:
            return self.signup(req.data)
        elif req.code == codes.LOGOUT:
            return self.logout()
        elif req.code == codes.DELETE_USER:
            return self.delete_user()

    def login(self, data):
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
                self.login_success(username)
                return Message(codes.LOGIN_SUCCESS)
            else:
                return Message(codes.LOGIN_WRONG_PASSWORD)
        else:
            return Message(codes.LOGIN_USERNAME_DOESNT_EXISTS)

    def signup(self, data):
        try:
            username = data["username"]
            password = data["password"]
        except (KeyError, TypeError):
            return BAD_MESSAGE_DATA
        if len(db.query(User).filter(User.username == username).all()) == 1:
            return Message(codes.SIGNUP_USERNAME_EXISTS)
        elif not self._validate_username(username):
            return Message(codes.SIGNUP_INVALID_USERNAME)
        elif not self._validate_password(password):
            return Message(codes.SIGNUP_INVALID_PASSWORD)
        else:
            user = User(username=username, password=md5(password.encode()).hexdigest())
            db.add(user)
            db.commit()
            self.login_success(username)
            return Message(codes.SIGNUP_SUCCESS)

    @staticmethod
    def _validate_username(username: str):
        for c in username:
            if not (c.isalnum() or c == "_"):
                return False
        return True

    @staticmethod
    def _validate_password(password: str):
        for c in password:
            if not (c.isalnum() or c in string.punctuation):
                return False
        return True

    def login_success(self, username):
        self.state = states.MAIN
        self.username = username

    def logout(self):
        self.state = states.NOT_AUTHORIZED
        return Message(codes.LOGOUT_SUCCESS)

    def delete_user(self):
        self.logout()
        db.query(User).filter(User.username == self.username).delete()
        db.commit()
        return Message(codes.DELETE_USER_SUCCESS)
