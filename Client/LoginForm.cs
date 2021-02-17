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
        bool methodIsLogin;

        public LoginForm()
        {
            InitializeComponent();

            methodIsLogin = true;
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            TcpClient client = new TcpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(Consts.SERVER_IP), Consts.SERVER_PORT);
            client.Connect(serverEndPoint);
            clientStream = client.GetStream();
        }

        private void Signup()
        {
            string username = SignupUsername_TextBox.Text;
            string password = SignupPassword_TextBox.Text;
            SignupMessage signup = new SignupMessage(username, password);
            Message signupResponse = StreamHelper.Communicate(clientStream, RequestCodes.SIGNUP, signup);

            switch (signupResponse.code)
            {
                case ResponseCodes.SIGNUP_SUCCESS:
                    LoginToApp(username);
                    break;
                case ResponseCodes.SIGNUP_USERNAME_EXISTS:
                    SignupErrorMessage_Label.Text = Properties.Resources.USERNAME_ALREADY_EXISTS;
                    break;
                case ResponseCodes.SIGNUP_INVALID_USERNAME:
                    SignupErrorMessage_Label.Text = Properties.Resources.INVALID_USERNAME;
                    break;
                case ResponseCodes.SIGNUP_INVALID_PASSWORD:
                    SignupErrorMessage_Label.Text = Properties.Resources.INVALID_PASSWORD;
                    break;
                default:
                    break;
            }
        }

        private void Login()
        {
            string username = LoginUsername_TextBox.Text;
            string password = LoginPassword_TextBox.Text;
            LoginMessage login = new LoginMessage(username, password);
            Message loginResponse = StreamHelper.Communicate(clientStream, RequestCodes.LOGIN, login);

            switch (loginResponse.code)
            {
                case ResponseCodes.LOGIN_SUCCESS:
                    LoginToApp(username);
                    break;
                case ResponseCodes.LOGIN_USERNAME_DOESNT_EXISTS:
                    LoginErrorMessage_Label.Text = Properties.Resources.USERNAME_DOESNT_EXISTS;
                    break;
                case ResponseCodes.LOGIN_WRONG_PASSWORD:
                    LoginErrorMessage_Label.Text = Properties.Resources.WRONG_PASSWORD;
                    break;
                default:
                    break;
            }
        }

        private void LoginToApp(string username)
        {
            ClearErrors();
            Hide();
            User user = new User(clientStream, username);
            MainForm mainForm = new MainForm(user);
            mainForm.ShowDialog();
            Show();
        }

        private void SwitchSigninMethod()
        {
            Control[] loginElements = { LoginUsername_TextBox, LoginPassword_TextBox };
            Control[] signupElements = { SignupUsername_TextBox, SignupPassword_TextBox, CredentialsVerify_Panel };
            methodIsLogin = !methodIsLogin;
            SwitchMethod_Button.Text = methodIsLogin ? "<" : ">";
            ClearErrors();

            if (!methodIsLogin)
            {
                RefreshCredentialsVerify();
            }
            else
            {
                CheckLoginCredentials();
                foreach(Label vertificationLabel in CredentialsVerify_Panel.Controls)
                {
                    vertificationLabel.ForeColor = System.Drawing.SystemColors.ControlText;
                }
            }
            
            foreach (var loginElement in loginElements)
            {
                loginElement.Enabled = methodIsLogin;
            }
            foreach (var signupElement in signupElements)
            {
                signupElement.Enabled = !methodIsLogin;
            }
        }

        private void ClearErrors()
        {
            Label[] errorsTextBoxes = { LoginErrorMessage_Label, SignupErrorMessage_Label };
            foreach (var errorTextBox in errorsTextBoxes)
            {
                errorTextBox.Text = "";
            }
        }

        private void RefreshCredentialsVerify()
        {
            bool totalBad = false;


            bool usernameBad = false;

            string username = SignupUsername_TextBox.Text;
            bool badUsernameCharacters = false;
            for (int i = 0; i < username.Length && !badUsernameCharacters; i++)
            {
                if (!(char.IsLetterOrDigit(username[i]) || username[i] == '_'))
                {
                    badUsernameCharacters = true;
                }
            }
            if (badUsernameCharacters)
            {
                usernameBad = true;
                UsernameLegalChars_Label.ForeColor = Color.Red;
            }
            else
            {
                UsernameLegalChars_Label.ForeColor = Color.Green;
            }

            if (username.Length >= 3 && username.Length <= 20)
            {
                UsernameLegalLength_Label.ForeColor = Color.Green;
            }
            else
            {
                usernameBad = true;
                UsernameLegalLength_Label.ForeColor = Color.Red;
            }

            if (usernameBad)
            {
                totalBad = true;
                UsernameVerifyLabel_Label.ForeColor = Color.Red;
            }
            else
            {
                UsernameVerifyLabel_Label.ForeColor = Color.Green;
            }

            
            bool passwordBad = false;

            string password = SignupPassword_TextBox.Text;
            bool badPasswordCharacters = false;
            for (int i = 0; i < password.Length && !badPasswordCharacters; i++)
            {
                if (!(char.IsLetterOrDigit(password[i]) || char.IsPunctuation(password[i]))) 
                {
                    badPasswordCharacters = true;
                }
            }
            if (badPasswordCharacters)
            {
                passwordBad = true;
                PasswordLegalChars_Label.ForeColor = Color.Red;
            }
            else
            {
                PasswordLegalChars_Label.ForeColor = Color.Green;
            }

            if (password.Length >= 8 && password.Length <= 16)
            {
                PasswordLegalLength_Label.ForeColor = Color.Green;
            }
            else
            {
                passwordBad = true;
                PasswordLegalLength_Label.ForeColor = Color.Red;
            }

            if (passwordBad)
            {
                totalBad = true;
                PasswordVerifyLabel_Label.ForeColor = Color.Red;
            }
            else
            {
                PasswordVerifyLabel_Label.ForeColor = Color.Green;
            }

            Signup_Button.Enabled = !totalBad;
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Signup_Button_Click(object sender, EventArgs e)
        {
            Signup();
        }

        private void SwitchMethod_Button_Click(object sender, EventArgs e)
        {
            SwitchSigninMethod();
        }

        private void SignupUsername_TextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshCredentialsVerify();
        }

        private void SignupPassword_TextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshCredentialsVerify();
        }

        private void LoginUsername_TextBox_TextChanged(object sender, EventArgs e)
        {
            CheckLoginCredentials();
        }

        private void CheckLoginCredentials()
        {
            Login_Button.Enabled = LoginUsername_TextBox.Text != "" && LoginPassword_TextBox.Text != "";
        }

        private void LoginPassword_TextBox_TextChanged(object sender, EventArgs e)
        {
            CheckLoginCredentials();
        }
    }
}
