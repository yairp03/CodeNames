class RequestCodes:
    # Authentication
    LOGIN = 110
    SIGNUP = 120
    LOGOUT = 130
    DELETE_USER = 140

    # Rooms
    LIST_ROOMS = 210
    JOIN_ROOM = 220
    CREATE_ROOM = 230

    # Statistics
    GET_STATISTICS = 310


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
    ROOMS_LIST = 211
    JOIN_ROOM_SUCCESS = 221
    JOIN_ROOM_FAILED = 222
    CREATE_ROOM_SUCCESS = 231
    CREATE_ROOM_FAILED = 232

    # Statistics
    STATISTICS_DATA = 311

    BAD_MESSAGE = 999


class States:
    NOT_AUTHORIZED = 0
    MAIN = 1
    LOBBY = 2
    GAME = 3


_string_codes = {
    # Requests
    RequestCodes.LOGIN: "Login",
    RequestCodes.SIGNUP: "Signup",
    RequestCodes.LOGOUT: "Logout",
    RequestCodes.DELETE_USER: "Delete User",
    RequestCodes.LIST_ROOMS: "List Rooms",
    RequestCodes.JOIN_ROOM: "Join Room",
    RequestCodes.CREATE_ROOM: "Create Room",
    RequestCodes.GET_STATISTICS: "Get Statistics",
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
    ResponseCodes.ROOMS_LIST: "Rooms List",
    ResponseCodes.JOIN_ROOM_SUCCESS: "Join Room Success",
    ResponseCodes.JOIN_ROOM_FAILED: "Join Room Failed",
    ResponseCodes.CREATE_ROOM_SUCCESS: "Create Room Success",
    ResponseCodes.CREATE_ROOM_FAILED: "Create Room Failed",
    ResponseCodes.STATISTICS_DATA: "Statistics Data",
    ResponseCodes.BAD_MESSAGE: "Bad Message",
}


def to_string(code: int) -> str:
    return _string_codes[code]