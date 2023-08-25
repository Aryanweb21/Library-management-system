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
    public partial class Reset_Your_Password : Form
    {
        public Reset_Your_Password()
        {
            InitializeComponent();
        }
        String usrname;
        String ScID;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String scID = txtScID.Text;

            usrname = username;
            ScID = scID;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS; database = library; integrated security = true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from login_table where id = '"+scID+"' and username = '"+username+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                label1.Text = "Create new Password";
                pictureBox1.Image = Image.FromFile("D:\\College Project Final\\College Project Final\\Images\\pngwing.com (1).png");
                pictureBox2.Image = Image.FromFile("D:\\College Project Final\\College Project Final\\Images\\pngwing.com (1).png");
                txtUsername.Text = "New Password";
                txtScID.Text = "Confirm new Password";
                btnSubmit2.Show();
                btnSubmit.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or scholar ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUsername.Text == "Username" || txtUsername.Text == "New Password")
                txtUsername.Clear();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 LF = new Form1();
            LF.Show();
        }

        private void txtScID_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtScID.Text == "Scholar ID" || txtScID.Text == "Confirm new Password")
                txtScID.Clear();
        }

        private void Reset_Your_Password_Load(object sender, EventArgs e)
        {
            btnSubmit2.Hide();
        }

        private void btnSubmit2_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "New Password" || txtScID.Text== "Confirm new Password" || txtUsername.Text == "" || txtScID.Text == "")
            {
                MessageBox.Show("Both fields are mandatory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String nP = txtUsername.Text;
                String cNP = txtScID.Text;
                if(nP != cNP)
                {
                    MessageBox.Show("New password and confirm new password must be same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS; database = library; integrated security = true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "update login_table set password = '" + cNP + "' where id = '" + ScID + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Form1 LF = new Form1();
                    LF.Show();
                }
            }
        }
    }
}
