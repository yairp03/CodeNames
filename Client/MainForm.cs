using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        public User user;
        private bool loggedIn;

        public MainForm(User user)
        {
            InitializeComponent();

            this.user = user;
            loggedIn = true;
            Welcome_Label.Text = "ברוך הבא " + user.username + "!";
            ReloadLobbies();
        }

        private void Logout()
        {
            StreamHelper.Communicate(user.clientStream, RequestCodes.LOGOUT);
        }

        private void DeleteUser()
        {
            StreamHelper.Communicate(user.clientStream, RequestCodes.DELETE_USER);
        }

        private void Logout_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteUser_Button_Click(object sender, EventArgs e)
        {
            DeleteUser();
            loggedIn = false;
            Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (loggedIn)
            {
                Logout();
            }
        }

        private void ReloadLobbies_Button_Click(object sender, EventArgs e)
        {
            ReloadLobbies();
        }

        private void ReloadLobbies()
        {
            ReloadLobbies_Button.Enabled = false;
            Lobbies_Panel.AutoScroll = false;
            Lobbies_Panel.Controls.Clear();
            Task.Run(() =>
            {
                List<GameRoom> lobbies = StreamHelper.Communicate<List<GameRoom>>(user.clientStream, RequestCodes.LIST_ROOMS);
                int y = 20;
                foreach (GameRoom room in lobbies)
                {
                    Label host_TextBox = new Label() { Text = room.host, Location = new Point(20, y) };
                    Label players_TextBox = new Label() { Text = room.curr_players.ToString() + "/" + room.max_players.ToString(), Location = new Point(150, y) };
                    JoinGameButton joinRoom_Button = new JoinGameButton(room.host, room.max_players) { Text = "Join", Location = new Point(290, y) };
                    joinRoom_Button.Click += JoinRoom_Button_Click;
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            Lobbies_Panel.Controls.Add(host_TextBox);
                            Lobbies_Panel.Controls.Add(players_TextBox);
                            Lobbies_Panel.Controls.Add(joinRoom_Button);
                        });
                    }
                    catch { }
                    y += 40;
                }
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        Lobbies_Panel.AutoScroll = true;
                        ReloadLobbies_Button.Enabled = true;
                    });
                }
                catch { }
            });
        }

        private void JoinRoom_Button_Click(object sender, EventArgs e)
        {
            JoinGameButton button = sender as JoinGameButton;
            JoinLobby(button.gameHost, button.maxPlayers);
        }

        private void CreateLobby_Button_Click(object sender, EventArgs e)
        {
            CreateLobby();
        }

        private void CreateLobby()
        {
            int maxPlayers = Convert.ToInt32(MaxPlayers_NumericUpDown.Value);
            StreamHelper.Communicate(user.clientStream, RequestCodes.CREATE_ROOM, new CreateRoomRequest(maxPlayers));
            OpenLobby(user.username, maxPlayers);
        }

        private void JoinLobby(string host, int maxPlayers)
        {
            Message res = StreamHelper.Communicate(user.clientStream, RequestCodes.JOIN_ROOM, new JoinRoomRequest(host));
            switch (res.code)
            {
                case ResponseCodes.JOIN_ROOM_SUCCESS:
                    OpenLobby(host, maxPlayers);
                    break;
                case ResponseCodes.JOIN_ROOM_FAILED:
                    ReloadLobbies();
                    break;
                default:
                    break;
            }
        }

        private void OpenLobby(string host, int maxPlayers)
        {
            LobbyForm lobby = new LobbyForm(user, host, maxPlayers);
            Hide();
            lobby.ShowDialog();
            if (lobby.enterGame)
            {
                GameForm game = new GameForm(user, lobby.teams);
                game.ShowDialog();
            }
            ReloadLobbies();
            Show();
        }
    }
}
