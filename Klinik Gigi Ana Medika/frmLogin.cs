using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klinik_Gigi_Ana_Medika
{
    public partial class frmLogin : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        public frmMain parent;
        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }
        
        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                login();
            }
        }

        void login()
        {
            if (txtUName.Text == "")
            {
                MessageBox.Show("Username is empty");
            }
            else if (txtPwd.Text == "")
            {
                MessageBox.Show("Password is empty");
            }
            else {
                var getUserPass = (from msUser in conn.msUsers
                                   where (msUser.Username.Equals(txtUName.Text) && msUser.Password.Equals(txtPwd.Text))
                                   select msUser).ToList();
                if (getUserPass.Count == 0)
                {
                    MessageBox.Show("Invalid Username or Password");
                }
                else
                {
                    parent.setLogin(getUserPass[0].Username, getUserPass[0].Role);
                    if (getUserPass[0].Role=="ADM")
                    {
                        parent.setAdminMenu(true);
                    }
                    else
                    {
                        parent.setCashierMenu(true);
                    }
                    MessageBox.Show("Welcome, " + getUserPass[0].Username);
                    this.Close();
                }
            }
        }

    }
}
