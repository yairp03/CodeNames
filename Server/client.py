import states
import codes
from database import db, User
from hashlib import md5


class Message:
    def __init__(self, code=0, data=""):
        self.code = code
        self.data = data

    def __str__(self):
        return f"{self.code}: {str(self.data).encode()}"

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
    ),
}


class Client:
    def __init__(self, sock):
        self.sock = sock
        self.peername = sock.getpeername()
        self.state = states.NOT_AUTHORIZED

    def handle_request(self, req: Message):
        if req.code not in POSSIBLE_CODES[self.state]:
            return BAD_MESSAGE_CODE

        if req.code == codes.LOGIN:
            return self.login(req.data)
        elif req.code == codes.SIGNUP:
            return self.signup(req.data)
        elif req.code == codes.LOGOUT:
            return self.logout()

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
                self.state = states.MAIN
                return Message(codes.LOGIN_SUCCESS)
            else:
                return Message(codes.LOGIN_FAILED, "Wrong password")
        else:
            return Message(codes.LOGIN_FAILED, "User doesn't exist")

    def signup(self, data):
        try:
            username = data["username"]
            password = data["password"]
        except (KeyError, TypeError):
            return BAD_MESSAGE_DATA
        if len(db.query(User).filter(User.username == username).all()) == 1:
            return Message(codes.SIGNUP_FAILED, "User already exists")
        else:
            user = User(username=username, password=md5(password.encode()).hexdigest())
            db.add(user)
            db.commit()
            self.state = states.MAIN
            return Message(codes.SIGNUP_SUCCESS)

    def logout(self):
        self.state = states.NOT_AUTHORIZED
        return Message(codes.LOGOUT_SUCCESS)
