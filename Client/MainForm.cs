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
    public partial class MainForm : Form
    {
        public User user;
        private bool loggedIn;

        public MainForm(User user)
        {
            InitializeComponent();

            this.user = user;
            this.loggedIn = true;
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
    }
}
