using System.Configuration;
using System.Drawing;

namespace CodeNames
{
    class Consts
    {
        public static string SERVER_IP = ConfigurationManager.AppSettings["IpAddress"];
        public static int SERVER_PORT = int.Parse(ConfigurationManager.AppSettings["Port"]);

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
        public const int NOT_ROOM_HOST = 242;
        public const int NOT_ENOUGH_PLAYERS = 243;
        public const int LEAVE_ROOM_SUCCESS = 251;
        public const int LOBBY_UPDATE = 261;
        public const int LOBBY_STARTED = 262;
        public const int LOBBY_DELETED = 263;

        // Game
        public const int GAME_STATE = 311;
        public const int REVEAL_SUCCESS = 321;
        public const int REVEAL_NOT_YOUR_TURN = 322;
        public const int WAIT_FOR_WORD = 323;
        public const int CARD_ALREADY_REVEALED = 324;
        public const int SEND_WORD_SUCCESS = 331;
        public const int WORD_NOT_YOUR_TURN = 332;
        public const int WORD_ALREADY_SENT = 333;
        public const int INVALID_WORD = 334;
        public const int INVALID_CARDS_AMOUNT = 335;

        public const int BAD_MESSAGE = 999;
    }

    public class CardColor
    {
        public static Color BLANK = Color.OldLace;
        public static Color REVEALED_BLANK = Color.NavajoWhite;
        public static Color RED = Color.MistyRose;
        public static Color REVEALED_RED = Color.Tomato;
        public static Color BLUE = Color.Lavender;
        public static Color REVEALED_BLUE = Color.RoyalBlue;
        public static Color BOMB = Color.LightGray;
        public static Color REVEALED_BOMB = Color.DimGray;

        public static Color GetColor(CardType type, bool revealed)
        {
            switch (type)
            {
                case CardType.NONE:
                    return BLANK;
                case CardType.BLANK:
                    return revealed ? REVEALED_BLANK : BLANK;
                case CardType.RED:
                    return revealed ? REVEALED_RED : RED;
                case CardType.BLUE:
                    return revealed ? REVEALED_BLUE : BLUE;
                case CardType.BOMB:
                    return revealed ? REVEALED_BOMB : BOMB;
                default:
                    break;
            }
            return BLANK;
        }
    }

    public enum CardType
    {
        NONE,
        BLANK,
        RED,
        BLUE,
        BOMB
    }
}
