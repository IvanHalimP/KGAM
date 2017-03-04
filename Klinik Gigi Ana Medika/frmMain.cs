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
    public partial class frmMain : Form
    {
        public static string username = "";
        public static string role = "";
        bool isLoggedIn = false;

        public void setUsername(string user)
        {
            username = user;
        }
        public void setRole(string r)
        {
            role = r;
        }
        public void setLogin(string user=null, string r=null)
        {
            if (!isLoggedIn)
            {
                loginToolStripMenuItem.Text = "Logout";
                username = user;
                role = r;
                isLoggedIn = true;
            }
            else
            {
                loginToolStripMenuItem.Text = "Login";
                username = "";
                role = "";
                isLoggedIn = false;
                hideAllMenu();
            }
        }
        public void setCashierMenu(bool isVisible)
        {
            patientsToolStripMenuItem.Visible = isVisible;
            labToolStripMenuItem.Visible = isVisible;
            transactionsToolStripMenuItem.Visible = isVisible;
            reportToolStripMenuItem.Visible = isVisible;
        }
        public void setAdminMenu(bool isVisible)
        {
            setCashierMenu(isVisible);
            treatmentToolStripMenuItem.Visible = isVisible;
            doctorsToolStripMenuItem.Visible = isVisible;
            taxToolStripMenuItem.Visible = isVisible;
            honorToolStripMenuItem.Visible = isVisible;
            expensesToolStripMenuItem.Visible = isVisible;
            userToolStripMenuItem.Visible = isVisible;
        }
        void hideAllMenu()
        {
            setAdminMenu(false);
        }

        public frmMain()
        {
            InitializeComponent();
            hideAllMenu();
        }

        private void treatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMasterTreatment frmTrt = new frmMasterTreatment();
            frmTrt.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                frmLogin frmIn = new frmLogin();
                frmIn.parent = this;
                frmIn.Show();
            }
            else
            {
                setLogin();
            }
        }

        private void patientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMasterPatient frmPtn = new frmMasterPatient();
            frmPtn.Show();
        }

        private void doctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMasterDoctor frmDoc = new frmMasterDoctor();
            frmDoc.Show();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrx frmTran = new frmTrx();
            frmTran.Show();
        }

        private void taxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTax frmPajak = new frmTax();
            frmPajak.Show();
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClinicExpenses frmExp = new frmClinicExpenses();
            frmExp.Show();
        }

        private void honorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHonor frmHnr = new frmHonor();
            frmHnr.Show();
        }

        private void dailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDailyReport frmDaily = new frmDailyReport();
            frmDaily.Show();
        }

        private void incomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlyIncomeReport frmIncome = new frmMonthlyIncomeReport();
            frmIncome.Show();
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlyDoctorReport frmDoctor = new frmMonthlyDoctorReport();
            frmDoctor.Show();
        }

        private void recapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlyRecap frmRecap = new frmMonthlyRecap();
            frmRecap.Show();
        }

        private void expenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonthlyExpenses frmExpenses = new frmMonthlyExpenses();
            frmExpenses.Show();
        }

        private void labToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLab frmLab = new frmLab();
            frmLab.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser frmUser = new frmUser();
            frmUser.Show();
        }
    }
}
