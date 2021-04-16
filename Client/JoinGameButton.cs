using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class JoinGameButton : Button
    {
        public string gameHost;
        public int maxPlayers;

        public JoinGameButton(string gameHost, int maxPlayers)
        {
            InitializeComponent();
            this.gameHost = gameHost;
            this.maxPlayers = maxPlayers;
        }

        public JoinGameButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
