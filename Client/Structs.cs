using System.Collections.Generic;
using System.Net.Sockets;

namespace Client
{
    struct Message
    {
        public int code;
        public string data;

        public Message(int code, string data)
        {
            this.code = code;
            this.data = data;
        }

        public override string ToString()
        {
            return code.ToString().PadLeft(Consts.CODE_PART_LENGTH, '0') +
                data.Length.ToString().PadLeft(Consts.LENGTH_PART_LENGTH, '0') +
                data;
        }
    }

    struct LoginMessage
    {
        public string username;
        public string password;

        public LoginMessage(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }

    struct SignupMessage
    {
        public string username;
        public string password;

        public SignupMessage(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }

    public struct User
    {
        public NetworkStream clientStream;
        public string username;

        public User(NetworkStream clientStream, string username)
        {
            this.clientStream = clientStream;
            this.username = username;
        }
    }

    struct GameRoom
    {
        public string host;
        public int curr_players;
        public int max_players;
    }

    struct CreateRoomRequest
    {
        public int max_players;

        public CreateRoomRequest(int maxPlayers)
        {
            max_players = maxPlayers;
        }
    }

    struct JoinRoomRequest
    {
        public string host;

        public JoinRoomRequest(string host)
        {
            this.host = host;
        }
    }

    public struct StartGameResponse
    {
        public List<string> reds;
        public List<string> blues;
    }

    public struct WordCard
    {
        public string word;
        public CardType type;
        public bool revealed;
    }

    public struct GameState
    {
        public bool deleted;
        public bool ended;
        public CardType winner;
        public CardType turn;
        public string curr_word;
        public int curr_revealed;
        public int curr_cards;
        public List<List<WordCard>> board;

        public static bool operator ==(GameState a, GameState b) => a.Equals(b);
        public static bool operator !=(GameState a, GameState b) => !(a == b);
    }

    public struct SendWordRequest
    {
        public string word;
        public int amount;

        public SendWordRequest(string word, int amount)
        {
            this.word = word;
            this.amount = amount;
        }
    }

    public struct GuessWordRequest
    {
        public int row;
        public int column;

        public GuessWordRequest(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
    }
}
