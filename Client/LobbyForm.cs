using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class LobbyForm : Form
    {
        User user;
        string admin;
        int currPlayers;
        int maxPlayers;
        public bool deleted;

        public LobbyForm(User user, string admin, int maxPlayers)
        {
            InitializeComponent();

            this.user = user;
            this.admin = admin;
            this.maxPlayers = maxPlayers;
            OnlyAdmin_Label.Enabled = !(user.username == admin);
        }

        private void PlayersListReload_Timer_Tick(object sender, EventArgs e)
        {
            ReloadPlayersList();
        }

        private void ReloadPlayersList()
        {
            Task.Run(() =>
            {
                Message res = StreamHelper.Communicate(user.clientStream, RequestCodes.LOBBY_UPDATES);
                switch (res.code)
                {
                    case ResponseCodes.LOBBY_DELETED:
                        deleted = true;
                        Close();
                        break;
                    case ResponseCodes.LOBBY_STARTED:
                        // Game
                        break;
                    case ResponseCodes.LOBBY_UPDATE:
                        List<string> players = JsonConvert.DeserializeObject<List<string>>(res.data);
                        try
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                UpdatePlayersPanel(players);
                            });
                        }
                        catch { }
                        break;
                    default:
                        break;
                }
            });
        }

        private void UpdatePlayersPanel(List<string> players)
        {
            Players_Panel.Controls.Clear();
            currPlayers = players.Count;
            PlayersAmount_Label.Text = currPlayers.ToString() + "/" + maxPlayers.ToString();
            int y = 20;
            foreach (string player in players)
            {
                Label Player_Label = new Label() { Text = player, Location = new Point(20, y) };
                Players_Panel.Controls.Add(Player_Label);
                y += 20;
            }
            NotEnoughPlayers_Label.Enabled = !CanStart();
            StartGame_Button.Enabled = !NotEnoughPlayers_Label.Enabled && !OnlyAdmin_Label.Enabled;
        }

        private bool CanStart()
        {
            return currPlayers >= Consts.GAME_MIN_PLAYERS;
        }

        private void Logout_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LobbyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PlayersListReload_Timer.Enabled = false;
            StreamHelper.Communicate(user.clientStream, RequestCodes.LEAVE_ROOM);
        }
    }
}
