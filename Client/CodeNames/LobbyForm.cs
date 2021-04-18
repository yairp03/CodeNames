using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeNames
{
    public partial class LobbyForm : Form
    {
        User user;
        int currPlayers;
        readonly int maxPlayers;
        public bool enterGame;
        public StartGameResponse teams;

        public LobbyForm(User user, string host, int maxPlayers)
        {
            InitializeComponent();

            this.user = user;
            this.maxPlayers = maxPlayers;
            OnlyHost_Label.Enabled = !(user.username == host);
            enterGame = false;
        }

        private void PlayersListReload_Timer_Tick(object sender, EventArgs e)
        {
            PlayersListReload_Timer.Enabled = false;
            ReloadPlayersList();
        }

        private void ReloadPlayersList()
        {
            Task.Run(() =>
            {
                Message res = new Message();
                try
                {
                    res = StreamHelper.Communicate(user.clientStream, RequestCodes.LOBBY_UPDATES);
                }
                catch (IOException)
                {
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            Utils.ConnectionAbortMessageBox();
                            Close();
                        });
                    }
                    catch { }
                }
                switch (res.code)
                {
                    case ResponseCodes.LOBBY_DELETED:
                        Invoke((MethodInvoker)delegate
                        {
                            Close();
                        });
                        break;
                    case ResponseCodes.LOBBY_STARTED:
                        enterGame = true;
                        teams = JsonConvert.DeserializeObject<StartGameResponse>(res.data);
                        Invoke((MethodInvoker)delegate
                        {
                            Close();
                        });
                        break;
                    case ResponseCodes.LOBBY_UPDATE:
                        List<string> players = JsonConvert.DeserializeObject<List<string>>(res.data);
                        try
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                UpdatePlayersPanel(players);
                                PlayersListReload_Timer.Enabled = true;
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
            currPlayers = players.Count;
            PlayersAmount_Label.Text = currPlayers.ToString() + "/" + maxPlayers.ToString();
            Utils.AddTextsToPanel(Players_Panel, players);
            NotEnoughPlayers_Label.Enabled = !CanStart();
            StartGame_Button.Enabled = !NotEnoughPlayers_Label.Enabled && !OnlyHost_Label.Enabled;
        }

        private bool CanStart()
        {
            return currPlayers >= Consts.GAME_MIN_PLAYERS;
        }

        private void ExitLobby_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LobbyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PlayersListReload_Timer.Enabled = false;
            if (!enterGame)
            {
                try
                {
                    StreamHelper.Communicate(user.clientStream, RequestCodes.LEAVE_ROOM);
                }
                catch (IOException)
                {
                    Utils.ConnectionAbortMessageBox();
                    Close();
                }
            }
        }

        private void StartGame_Button_Click(object sender, EventArgs e)
        {
            StartGame_Button.Enabled = false;
            try
            {
                StreamHelper.Communicate(user.clientStream, RequestCodes.START_GAME);
            }
            catch (IOException)
            {
                Utils.ConnectionAbortMessageBox();
                Close();
            }
        }

        private void LobbyForm_Shown(object sender, EventArgs e)
        {
            ReloadPlayersList();
        }
    }
}
