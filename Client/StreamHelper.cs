using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class StreamHelper
    {
        private static byte[] GetPartFromSocket(NetworkStream socket, int bytesAmount)
        {
            byte[] data = new byte[bytesAmount];
            socket.Read(data, 0, bytesAmount);
            return data;
        }

        private static string GetStringFromSocket(NetworkStream socket, int bytesAmount)
        {
            byte[] data = GetPartFromSocket(socket, bytesAmount);
            return Encoding.Default.GetString(data);
        }

        private static int GetIntFromSocket(NetworkStream socket, int bytesAmount)
        {
            string data = GetStringFromSocket(socket, bytesAmount);
            return int.Parse(data);
        }

        private static Message GetMessage(NetworkStream socket)
        {
            int code = GetIntFromSocket(socket, Consts.CODE_PART_LENGTH);
            int dataLength = GetIntFromSocket(socket, Consts.LENGTH_PART_LENGTH);
            string data = GetStringFromSocket(socket, dataLength);
            return new Message(code, data);
        }

        private static T GetMessage<T>(NetworkStream socket)
        {
            Message msg = GetMessage(socket);
            T data = JsonConvert.DeserializeObject<T>(msg.data);
            return data;
        }

        private static void SendMessage(NetworkStream socket, Message msg)
        {
            byte[] data = new ASCIIEncoding().GetBytes(msg.ToString());
            socket.Write(data, 0, data.Length);
            socket.Flush();
        }

        private static void SendMessage<T>(NetworkStream socket, int code, T data)
        {
            string jsonString = JsonConvert.SerializeObject(data);
            Message msg = new Message(code, jsonString);
            SendMessage(socket, msg);
        }

        public static Message Communicate<Req>(NetworkStream socket, int code, Req data)
        {
            SendMessage(socket, code, data);
            Message msg = GetMessage(socket);
            return msg;
        }

        public static Res Communicate<Req, Res>(NetworkStream socket, int code, Req data)
        {
            SendMessage(socket, code, data);
            Res msg = GetMessage<Res>(socket);
            return msg;
        }

        public static Message Communicate(NetworkStream socket, int code)
        {
            return Communicate(socket, code, "");
        }

        public static Res Communicate<Res>(NetworkStream socket, int code)
        {
            return Communicate<string, Res>(socket, code, "");
        }
    }
}
