using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College_Project_Final
{
    public partial class newPassword : Form
    {
        public newPassword()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNP_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtNP.Text == "New Password")
                txtNP.Clear();
        }

        private void txtCnfNP_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtCnfNP.Text == "Confirm New Password")
                txtCnfNP.Clear();
        }
    }
}
