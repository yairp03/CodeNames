using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class GameForm : Form
    {
        public GameForm(StartGameResponse teams)
        {
            InitializeComponent();

            Utils.AddTextsToPanel(RedPlayers_Panel, teams.reds);
            Utils.AddTextsToPanel(BluePlayers_Panel, teams.blues);
        }
    }
}
