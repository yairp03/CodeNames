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
    }

    class RequestCodes
    {
        // Authentication
        public const int LOGIN = 110;
        public const int SIGNUP = 120;
        public const int LOGOUT = 130;
        public const int DELETE_USER = 140;

        // Rooms
        public const int LIST_ROOMS = 210;
        public const int JOIN_ROOM = 220;
        public const int CREATE_ROOM = 230;

        // Statistics
        public const int GET_STATISTICS = 310;
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
        public const int ROOMS_LIST = 211;
        public const int JOIN_ROOM_SUCCESS = 221;
        public const int JOIN_ROOM_FAILED = 222;
        public const int CREATE_ROOM_SUCCESS = 231;
        public const int CREATE_ROOM_FAILED = 232;

        // Statistics
        public const int STATISTICS_DATA = 311;

        public const int BAD_MESSAGE = 999;
    }
}
