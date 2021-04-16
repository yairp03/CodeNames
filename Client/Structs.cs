using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
}
