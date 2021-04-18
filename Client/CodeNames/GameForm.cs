using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeNames
{
    public partial class GameForm : Form
    {
        User user;
        readonly bool manager;
        readonly CardType team;
        private readonly List<List<CardLabel>> board;
        CardLabel chosedWord;

        public GameForm(User user, StartGameResponse teams)
        {
            InitializeComponent();

            this.user = user;
            Text = user.username;
            chosedWord = null;
            board = new List<List<CardLabel>>();
            for (int r = 0; r < 5; r++)
            {
                board.Add(new List<CardLabel>());
                for (int c = 0; c < 5; c++)
                {
                    CardLabel cardLabel = new CardLabel(r, c)
                    {
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(3),
                        Size = new Size(104, 61),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(202 + 110 * c, 13 + 67 * r)
                    };
                    cardLabel.Click += CardLabel_Click;
                    board[r].Add(cardLabel);
                    Game_Panel.Controls.Add(cardLabel);
                }
            }
            Utils.AddTextsToPanel(RedPlayers_Panel, teams.reds);
            Utils.AddTextsToPanel(BluePlayers_Panel, teams.blues);
            team = teams.reds.Contains(user.username) ? CardType.RED : CardType.BLUE;
            manager = (team == CardType.RED ? teams.reds : teams.blues)[0] == user.username;
        }

        private void CardLabel_Click(object sender, EventArgs e)
        {
            CardLabel cardLabel = sender as CardLabel;
            if (GuessWord_Panel.Visible && !cardLabel.revealed)
            {
                if (chosedWord != null)
                {
                    chosedWord.BorderStyle = BorderStyle.FixedSingle;
                }
                else
                {
                    GuessWord_Button.Visible = true;
                }
                cardLabel.BorderStyle = BorderStyle.Fixed3D;
                ChosenWord_Label.Text = cardLabel.Text;
                chosedWord = cardLabel;
            }
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameUpdates_Timer.Enabled = false;

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

        private void GameUpdates_Timer_Tick(object sender, EventArgs e)
        {
            ReloadGameState();
        }

        private void ReloadGameState()
        {
            Task.Run(() =>
            {
                GameState gameState = new GameState();
                try
                {
                    gameState = StreamHelper.Communicate<GameState>(user.clientStream, RequestCodes.GAME_STATE);
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
                if (gameState.winner != CardType.NONE)
                {
                    GameUpdates_Timer.Enabled = false;
                    Utils.RtlMessageBox("המשחק הסתיים! הקבוצה ה" + (gameState.winner == CardType.RED ? "אדומה" : "כחולה") + " ניצחה!", "סוף המשחק", MessageBoxIcon.Information);
                    Game_Panel.Enabled = false;
                }
                else if (gameState.deleted)
                {
                    GameUpdates_Timer.Enabled = false;
                    MessageBox.Show("המשחק נמחק");
                    Game_Panel.Enabled = false;
                }
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        if (gameState.turn == CardType.RED)
                        {
                            CurrTurn_Label.Text = "אדום";
                            CurrTurn_Label.ForeColor = CardColor.REVEALED_RED;
                        }
                        else
                        {
                            CurrTurn_Label.Text = "כחול";
                            CurrTurn_Label.ForeColor = CardColor.REVEALED_BLUE;
                        }
                        CurrWord_Label.Text = Utils.Base64Decode(gameState.curr_word);
                        CurrAmount_Label.Text = gameState.curr_revealed.ToString() + "/" + gameState.curr_cards.ToString();
                        for (int r = 0; r < gameState.board.Count; r++)
                        {
                            for (int c = 0; c < gameState.board[r].Count; c++)
                            {
                                board[r][c].Text = Utils.Base64Decode(gameState.board[r][c].word);
                                board[r][c].revealed = gameState.board[r][c].revealed;
                                board[r][c].BackColor = CardColor.GetColor(gameState.board[r][c].type, gameState.board[r][c].revealed);
                            }
                        }
                        CurrWord_TextBox.Visible = gameState.turn == team && gameState.curr_word == "" && manager;
                        CurrWord_Label.Visible = !CurrWord_TextBox.Visible;
                        CurrAmount_NumericUpDown.Visible = CurrWord_TextBox.Visible;
                        CurrAmount_Label.Visible = !CurrAmount_NumericUpDown.Visible;
                        SendWord_Button.Visible = CurrWord_TextBox.Visible;
                        GuessWord_Panel.Visible = gameState.turn == team && gameState.curr_word != "" && !manager;
                        if (!CurrWord_TextBox.Visible)
                        {
                            CurrWord_TextBox.Text = "";
                            CurrAmount_NumericUpDown.Value = 1;
                        }
                    });
                }
                catch { }
            });
        }

        private void ExitLobby_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SendWord_Button_Click(object sender, EventArgs e)
        {
            SendWordRequest request = new SendWordRequest(Utils.Base64Encode(CurrWord_TextBox.Text), Convert.ToInt32(CurrAmount_NumericUpDown.Value));
            Message res = new Message();
            try
            {
                res = StreamHelper.Communicate(user.clientStream, RequestCodes.SEND_WORD, request);
            }
            catch (IOException)
            {
                Utils.ConnectionAbortMessageBox();
                Close();
            }
            switch (res.code)
            {
                case ResponseCodes.SEND_WORD_SUCCESS:
                    SendWord_Button.Visible = false;
                    break;
                case ResponseCodes.INVALID_WORD:
                    Utils.ErrorMessageBox("מילה לא חוקית!");
                    break;
                case ResponseCodes.INVALID_CARDS_AMOUNT:
                    Utils.ErrorMessageBox("כמות לא חוקית!");
                    break;
                default:
                    break;
            }
        }

        private void GuessWord_Button_Click(object sender, EventArgs e)
        {
            GuessWordRequest request = new GuessWordRequest(chosedWord.r, chosedWord.c);
            chosedWord.BorderStyle = BorderStyle.FixedSingle;
            ChosenWord_Label.Text = "";
            GuessWord_Panel.Visible = false;
            GuessWord_Button.Visible = false;
            chosedWord = null;
            try
            {
                StreamHelper.Communicate(user.clientStream, RequestCodes.REVEAL_CARD, request);
            }
            catch (IOException)
            {
                Utils.ConnectionAbortMessageBox();
                Close();
            }
        }
    }
}
