using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Consts
    {
        public const string SERVER_IP = "127.0.0.1";
        public const int SERVER_PORT = 1234;

        public const int CODE_PART_LENGTH = 3;
        public const int LENGTH_PART_LENGTH = 5;

        public const int GAME_MIN_PLAYERS = 4;
    }

    class RequestCodes
    {
        // Authentication
        public const int LOGIN = 110;
        public const int SIGNUP = 120;
        public const int LOGOUT = 130;
        public const int DELETE_USER = 140;

        // Rooms
        public const int CREATE_ROOM = 210;
        public const int JOIN_ROOM = 220;
        public const int LIST_ROOMS = 230;
        public const int START_GAME = 240;
        public const int LEAVE_ROOM = 250;
        public const int LOBBY_UPDATES = 260;

        // Game
        public const int GAME_STATE = 310;
        public const int REVEAL_CARD = 320;
        public const int SEND_WORD = 330;

        // Statistics
        public const int GET_STATISTICS = 410;
    }

    class ResponseCodes
    {
        // Authentication
        // Login
        public const int LOGIN_SUCCESS = 111;
        public const int LOGIN_USERNAME_DOESNT_EXISTS = 112;
        public const int LOGIN_WRONG_PASSWORD = 113;
        public const int LOGIN_USER_ACTIVE = 114;
        // Signup
        public const int SIGNUP_SUCCESS = 121;
        public const int SIGNUP_USERNAME_EXISTS = 122;
        public const int SIGNUP_INVALID_USERNAME = 123;
        public const int SIGNUP_INVALID_PASSWORD = 124;

        public const int LOGOUT_SUCCESS = 131;
        public const int DELETE_USER_SUCCESS = 141;

        // Rooms
        public const int CREATE_ROOM_SUCCESS = 211;
        public const int BAD_MAX_PLAYERS = 212;
        public const int JOIN_ROOM_SUCCESS = 221;
        public const int JOIN_ROOM_FAILED = 222;
        public const int ROOMS_LIST = 231;
        public const int GAME_START_SUCCESS = 241;
        public const int NOT_ROOM_ADMIN = 242;
        public const int NOT_ENOUGH_PLAYERS = 243;
        public const int LEAVE_ROOM_SUCCESS = 251;
        public const int LOBBY_UPDATE = 261;
        public const int LOBBY_STARTED = 262;
        public const int LOBBY_DELETED = 263;

        // Game
        public const int GAME_STATE = 311;
        public const int REVEAL_SUCCESS = 321;
        public const int REVEAL_FAILED = 322;

        // Statistics
        public const int STATISTICS_DATA = 411;

        public const int BAD_MESSAGE = 999;
    }
}
