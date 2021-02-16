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

        public MainForm(User user)
        {
            InitializeComponent();

            this.user = user;
        }

        private void ReturnToLogin()
        {
            Close();
        }

        private void Logout(object sender, EventArgs e)
        {
            StreamHelper.Communicate(user.clientStream, RequestCodes.LOGOUT);
            ReturnToLogin();
        }

        private void DeleteUser(object sender, EventArgs e)
        {
            StreamHelper.Communicate(user.clientStream, RequestCodes.DELETE_USER);
            ReturnToLogin();
        }
    }
}
