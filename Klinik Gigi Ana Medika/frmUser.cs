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
    public partial class frmUser : Form
    {
        AnaMedikaDBDataClassDataContext conn = new AnaMedikaDBDataClassDataContext();
        public frmUser()
        {
            InitializeComponent();
            loadUser();
        }
        void loadUser()
        {
            var users = from msUser in conn.msUsers select new
            {
                ID = msUser.Id,
                Username = msUser.Username,
                Name = msUser.Name,
                Role = msUser.Role
            };
            dgUser.DataSource = users;
        }
        void insUser()
        {
            if (txtPass.Text == "")
            {
                MessageBox.Show("Password must be filled");
            }
            else if (txtConfirmPass.Text == "")
            {
                MessageBox.Show("Confirm Password must be filled");
            }
            else if (!txtPass.Text.Equals(txtConfirmPass.Text))
            {
                MessageBox.Show("Password mismatch");
            }
            else
            {
                var newUser = new msUser
                {
                    Id = getMaxId(),
                    Username = txtUName.Text,
                    Password = txtPass.Text,
                    Name = txtName.Text,
                    Role = cbRole.SelectedItem.ToString()
                };

                conn.msUsers.InsertOnSubmit(newUser);

                try
                {
                    conn.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        void updUser()
        {
            var queryUpd = (from msUser in conn.msUsers
                            where (msUser.Id == Int32.Parse(dgUser.CurrentRow.Cells[0].Value.ToString()))
                            select msUser).ToList().First();
            queryUpd.Id = Int32.Parse(txtId.Text);
            queryUpd.Username = txtUName.Text;
            queryUpd.Password = txtPass.Text;
            queryUpd.Name = txtName.Text;
            queryUpd.Role = cbRole.SelectedItem.ToString();
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void selectUser()
        {
            txtId.Text = dgUser.CurrentRow.Cells[0].Value.ToString();
            txtUName.Text = dgUser.CurrentRow.Cells[1].Value.ToString();
            txtName.Text = dgUser.CurrentRow.Cells[2].Value.ToString();
            cbRole.SelectedItem = dgUser.CurrentRow.Cells[3].Value;
        }

        void delUser()
        {
            var delQuery = (from msUser in conn.msUsers
                            where (msUser.Id == Int32.Parse(dgUser.CurrentRow.Cells[0].Value.ToString()))
                            select msUser).ToList().First();
            conn.msUsers.DeleteOnSubmit(delQuery);
            try
            {
                conn.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void searchUser()
        {
            var scrQuery = from msUser in conn.msUsers
                           where (msUser.Username.Contains(sUName.Text) && msUser.Name.Contains(sName.Text) 
                           && msUser.Role == sRole.SelectedItem.ToString())
                           select new
                           {
                               ID = msUser.Id,
                               Username = msUser.Username,
                               Name = msUser.Name,
                               Role = msUser.Role
                           };
            dgUser.DataSource = scrQuery;
        }
        int getMaxId()
        {
            var query = (from msUser in conn.msUsers select msUser).ToList();
            return query.Max(q => q.Id) + 1;
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            insUser();
            loadUser();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            updUser();
            loadUser();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            delUser();
            loadUser();
        }

        private void btnScr_Click(object sender, EventArgs e)
        {
            searchUser();
        }

        private void btnRld_Click(object sender, EventArgs e)
        {
            loadUser();
        }

        private void sUName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                searchUser();
            }
        }

        private void sName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                searchUser();
            }
        }

        private void sRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                searchUser();
            }
        }

        private void dgUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgUser.CurrentCell != null)
            {
                selectUser();
            }
        }

        private void dgUser_SelectionChanged(object sender, EventArgs e)
        {
            if (dgUser.CurrentCell != null)
            {
                selectUser();
            }
        }
    }
}
