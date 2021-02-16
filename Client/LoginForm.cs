using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class LoginForm : Form
    {
        NetworkStream clientStream;

        public LoginForm()
        {
            InitializeComponent();

            ConnectToServer();
        }

        private void ConnectToServer()
        {
            TcpClient client = new TcpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(Consts.SERVER_IP), Consts.SERVER_PORT);
            client.Connect(serverEndPoint);
            clientStream = client.GetStream();
        }

        private void Signup(object sender, EventArgs e)
        {
            string username = username_textBox.Text;
            string password = password_textBox.Text;
            SignupMessage signup = new SignupMessage(username, password);
            Message signupResponse = StreamHelper.Communicate(clientStream, RequestCodes.SIGNUP, signup);

            switch (signupResponse.code)
            {
                case ResponseCodes.SIGNUP_SUCCESS:
                    LoginToApp(username);
                    break;
                case ResponseCodes.SIGNUP_USERNAME_EXISTS:
                    errorMessage_label.Text = Properties.Resources.USERNAME_ALREADY_EXISTS;
                    break;
                default:
                    break;
            }
        }

        private void Login(object sender, EventArgs e)
        {
            string username = username_textBox.Text;
            string password = password_textBox.Text;
            LoginMessage login = new LoginMessage(username, password);
            Message loginResponse = StreamHelper.Communicate(clientStream, RequestCodes.LOGIN, login);

            switch (loginResponse.code)
            {
                case ResponseCodes.LOGIN_SUCCESS:
                    LoginToApp(username);
                    break;
                case ResponseCodes.LOGIN_USERNAME_DOESNT_EXISTS:
                    errorMessage_label.Text = Properties.Resources.USERNAME_DOESNT_EXISTS;
                    break;
                case ResponseCodes.LOGIN_WRONG_PASSWORD:
                    errorMessage_label.Text = Properties.Resources.WRONG_PASSWORD;
                    break;
                default:
                    break;
            }
        }

        private void LoginToApp(string username)
        {
            Hide();
            User user = new User(clientStream, username);
            MainForm mainForm = new MainForm(user);
            mainForm.ShowDialog();
            Show();
        }
    }
}
