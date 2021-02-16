# Request codes

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

##############################

# Response codes

# Authentication
# Login
LOGIN_SUCCESS = 111
LOGIN_USERNAME_DOESNT_EXISTS = 112
LOGIN_WRONG_PASSWORD = 113
# Signup
SIGNUP_SUCCESS = 121
SIGNUP_USERNAME_EXISTS = 122

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

_string_codes = {
    # Requests
    LOGIN: "Login",
    SIGNUP: "Signup",
    LOGOUT: "Logout",
    DELETE_USER: "Delete User",
    LIST_ROOMS: "List Rooms",
    JOIN_ROOM: "Join Room",
    CREATE_ROOM: "Create Room",
    GET_STATISTICS: "Get Statistics",
    # Responses
    LOGIN_SUCCESS: "Login Success",
    LOGIN_USERNAME_DOESNT_EXISTS: "Login username doesn't exists",
    LOGIN_WRONG_PASSWORD: "Login wrong password",
    SIGNUP_SUCCESS: "Signup success",
    SIGNUP_USERNAME_EXISTS: "Signup username exists",
    LOGOUT_SUCCESS: "Logout Success",
    DELETE_USER_SUCCESS: "Delete User Success",
    ROOMS_LIST: "Rooms List",
    JOIN_ROOM_SUCCESS: "Join Room Success",
    JOIN_ROOM_FAILED: "Join Room Failed",
    CREATE_ROOM_SUCCESS: "Create Room Success",
    CREATE_ROOM_FAILED: "Create Room Failed",
    STATISTICS_DATA: "Statistics Data",
    BAD_MESSAGE: "Bad Message",
}


def to_string(code):
    return _string_codes[code]