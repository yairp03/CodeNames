from enum import Enum, auto

__all__ = ["Consts", "RequestCodes", "ResponseCodes", "States"]


class Consts:
    SERVER_PORT = 1234

    CODE_LEN = 3
    LENGTH_LEN = 5

    MAX_ROOM_PLAYERS = 8
    GAME_MIN_PLAYERS = 4

    BOARD_LENGTH = 5
    BOARD_WIDTH = 5
    CARDS_AMOUNT = BOARD_LENGTH * BOARD_WIDTH
    BASE_TEAM_AMOUNT = 8
    BOMBS_AMOUNT = 1
    BLANK_AMOUNT = CARDS_AMOUNT - BASE_TEAM_AMOUNT * 2 - 1 - BOMBS_AMOUNT


class RequestCodes:
    # Authentication
    LOGIN = 110
    SIGNUP = 120
    LOGOUT = 130
    DELETE_USER = 140

    # Rooms
    CREATE_ROOM = 210
    JOIN_ROOM = 220
    LIST_ROOMS = 230
    START_GAME = 240
    LEAVE_ROOM = 250
    LOBBY_UPDATES = 260

    # Game
    GAME_STATE = 310
    REVEAL_CARD = 320
    SEND_WORD = 330


class ResponseCodes:
    # Authentication
    # Login
    LOGIN_SUCCESS = 111
    LOGIN_USERNAME_DOESNT_EXISTS = 112
    LOGIN_WRONG_PASSWORD = 113
    LOGIN_USER_ACTIVE = 114
    # Signup
    SIGNUP_SUCCESS = 121
    SIGNUP_USERNAME_EXISTS = 122
    SIGNUP_INVALID_USERNAME = 123
    SIGNUP_INVALID_PASSWORD = 124

    LOGOUT_SUCCESS = 131
    DELETE_USER_SUCCESS = 141

    # Rooms
    CREATE_ROOM_SUCCESS = 211
    BAD_MAX_PLAYERS = 212
    JOIN_ROOM_SUCCESS = 221
    JOIN_ROOM_FAILED = 222
    ROOMS_LIST = 231
    GAME_START_SUCCESS = 241
    NOT_ROOM_HOST = 242
    NOT_ENOUGH_PLAYERS = 243
    LEAVE_ROOM_SUCCESS = 251
    LOBBY_UPDATE = 261
    LOBBY_STARTED = 262
    LOBBY_DELETED = 263

    # Game
    GAME_STATE = 311
    REVEAL_SUCCESS = 321
    REVEAL_NOT_YOUR_TURN = 322
    WAIT_FOR_WORD = 323
    CARD_ALREADY_REVEALED = 324
    SEND_WORD_SUCCESS = 331
    WORD_NOT_YOUR_TURN = 332
    WORD_ALREADY_SENT = 333
    INVALID_WORD = 334
    INVALID_CARDS_AMOUNT = 335

    BAD_MESSAGE = 999


class States(Enum):
    NOT_AUTHORIZED = auto()
    MAIN = auto()
    LOBBY = auto()
    GAME = auto()


_string_codes = {
    # Requests
    RequestCodes.LOGIN: "Login",
    RequestCodes.SIGNUP: "Signup",
    RequestCodes.LOGOUT: "Logout",
    RequestCodes.DELETE_USER: "Delete User",
    RequestCodes.CREATE_ROOM: "Create Room",
    RequestCodes.JOIN_ROOM: "Join Room",
    RequestCodes.LIST_ROOMS: "List Rooms",
    RequestCodes.START_GAME: "Start game",
    RequestCodes.LEAVE_ROOM: "Leave room",
    RequestCodes.LOBBY_UPDATES: "Lobby updates",
    # Responses
    ResponseCodes.LOGIN_SUCCESS: "Login Success",
    ResponseCodes.LOGIN_USERNAME_DOESNT_EXISTS: "Login username doesn't exists",
    ResponseCodes.LOGIN_WRONG_PASSWORD: "Login wrong password",
    ResponseCodes.LOGIN_USER_ACTIVE: "Login username active",
    ResponseCodes.SIGNUP_SUCCESS: "Signup success",
    ResponseCodes.SIGNUP_USERNAME_EXISTS: "Signup username exists",
    ResponseCodes.SIGNUP_INVALID_USERNAME: "Signup invalid username",
    ResponseCodes.SIGNUP_INVALID_PASSWORD: "Signup invalid password",
    ResponseCodes.LOGOUT_SUCCESS: "Logout Success",
    ResponseCodes.DELETE_USER_SUCCESS: "Delete User Success",
    ResponseCodes.CREATE_ROOM_SUCCESS: "Create Room Success",
    ResponseCodes.BAD_MAX_PLAYERS: "Bad max players",
    ResponseCodes.JOIN_ROOM_SUCCESS: "Join Room Success",
    ResponseCodes.JOIN_ROOM_FAILED: "Join Room Failed",
    ResponseCodes.ROOMS_LIST: "Rooms List",
    ResponseCodes.GAME_START_SUCCESS: "Game start success",
    ResponseCodes.NOT_ROOM_HOST: "Not room admin",
    ResponseCodes.NOT_ENOUGH_PLAYERS: "Not enough players",
    ResponseCodes.LEAVE_ROOM_SUCCESS: "Leave room success",
    ResponseCodes.LOBBY_UPDATE: "Lobby update",
    ResponseCodes.LOBBY_STARTED: "Lobby started",
    ResponseCodes.LOBBY_DELETED: "Lobby deleted",
    ResponseCodes.GAME_STATE: "Game State",
    ResponseCodes.REVEAL_SUCCESS: "Reveal Card",
    ResponseCodes.REVEAL_NOT_YOUR_TURN: "Reveal not your turn",
    ResponseCodes.WAIT_FOR_WORD: "Wait for word",
    ResponseCodes.CARD_ALREADY_REVEALED: "Card already revealed",
    ResponseCodes.SEND_WORD_SUCCESS: "Send word success",
    ResponseCodes.WORD_NOT_YOUR_TURN: "Word not your turn",
    ResponseCodes.WORD_ALREADY_SENT: "Word already sent",
    ResponseCodes.INVALID_WORD: "Invalid word",
    ResponseCodes.INVALID_CARDS_AMOUNT: "Invalid cards amount",
    ResponseCodes.BAD_MESSAGE: "Bad Message",
}


def code_to_string(code: int) -> str:
    return _string_codes[code] if code in _string_codes else str(code)