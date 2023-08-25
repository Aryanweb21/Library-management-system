using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College_Project_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void txtUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUserName.Text == "Username")
            {
                txtUserName.Clear();
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUP SU = new SignUP();
            SU.Show();
        }

        private void pbLinkedIn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https:/www.linkedin.com/in/aryan-diwakar-191961220");
        }

        private void pbInstagram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/imhryan/");
        }

        private void pbYouTube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://youtube.com/@GuitarHabitsWithAryan7900");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection db_Connection = new SqlConnection();
            db_Connection.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS ; database= library; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db_Connection;

            cmd.CommandText = "select * from login_table where username= '" + txtUserName.Text + "' and password= '" + txtPassword.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                DashBoard db = new DashBoard();
                db.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reset_Your_Password resetPassword = new Reset_Your_Password();
            resetPassword.Show();
        }

        private void lblResetPass_Click(object sender, EventArgs e)
        {

        }
    }
}
