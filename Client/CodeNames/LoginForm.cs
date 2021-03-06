﻿using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeNames
{
    public partial class LoginForm : Form
    {
        NetworkStream clientStream;
        bool methodIsLogin;

        public LoginForm()
        {
            InitializeComponent();

            methodIsLogin = true;
        }

        private void ConnectToServer()
        {
            TcpClient client = new TcpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(Consts.SERVER_IP), Consts.SERVER_PORT);
            Task.Run(() =>
            {
                try
                {

                    client.Connect(serverEndPoint);
                    clientStream = client.GetStream();
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            LoginSignup_Panel.Enabled = true;
                            ConnectionFailed_Label.Visible = false;
                            ReloadConnect_Timer.Enabled = false;
                        });
                    }
                    catch { }
                }
                catch (SocketException)
                {
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            ConnectionFailed_Label.Visible = true;
                            ReloadConnect_Timer.Enabled = true;
                        });
                    }
                    catch { }
                }
            });

        }

        private void Signup()
        {
            string username = SignupUsername_TextBox.Text;
            string password = SignupPassword_TextBox.Text;
            SignupMessage signup = new SignupMessage(username, password);
            Message signupResponse = new Message();
            try
            {
                signupResponse = StreamHelper.Communicate(clientStream, RequestCodes.SIGNUP, signup);
            }
            catch (IOException)
            {
                Utils.ConnectionAbortMessageBox();
                Close();
            }

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
            Message loginResponse = new Message();
            try
            {
                loginResponse = StreamHelper.Communicate(clientStream, RequestCodes.LOGIN, login);
            }
            catch (IOException)
            {
                Utils.ConnectionAbortMessageBox();
                Close();
            }
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
                case ResponseCodes.LOGIN_USER_ACTIVE:
                    LoginErrorMessage_Label.Text = Properties.Resources.LOGIN_USER_ACTIVE;
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
            Close();
        }

        private void SwitchSigninMethod()
        {
            methodIsLogin = !methodIsLogin;
            SwitchMethod_Button.Text = methodIsLogin ? "<" : ">";
            ClearErrors();

            if (methodIsLogin)
            {
                CheckLoginCredentials();
                Signup_Button.Enabled = false;
                foreach (Label vertificationLabel in CredentialsVerify_Panel.Controls)
                {
                    vertificationLabel.ForeColor = SystemColors.ControlText;
                }
            }
            else
            {
                Login_Button.Enabled = false;
                RefreshCredentialsVerify();
            }

            Login_Panel.Enabled = methodIsLogin;
            SignUp_Panel.Enabled = !methodIsLogin;
            CredentialsVerify_Panel.Enabled = !methodIsLogin;
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

            if (password.Length >= 5 && password.Length <= 16)
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

        private void ReloadConnect_Timer_Tick(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            ConnectToServer();
        }
    }
}
