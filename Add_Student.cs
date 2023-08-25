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
    public partial class Add_Student : Form
    {
        public Add_Student()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm Exit!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStCont.Clear();
            txtStDep.Clear();
            txtStEmail.Clear();
            txtStID.Clear();
            txtStName.Clear();
            txtStSem.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtStName.Text== "" || txtStDep.Text == "" || txtStEmail.Text == "" || txtStID.Text == "" || txtStSem.Text == "" || txtStCont.Text == "")
            {
                MessageBox.Show("All fields are mandatory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String stName = txtStName.Text;
                String stERP = txtStID.Text;
                String stDep = txtStDep.Text;
                String stSem = txtStSem.Text;
                String stEmail = txtStEmail.Text;
                Int64 stContact = Int64.Parse(txtStCont.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS; database= library; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into addStudent (stName,stERP,stDept,stSem,stCont,stEmail) values ('" + stName + "','" + stERP + "','" + stDep + "','" + stSem + "','" + stContact + "','" + stEmail + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data saved.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStCont.Clear();
                txtStDep.Clear();
                txtStEmail.Clear();
                txtStID.Clear();
                txtStName.Clear();
                txtStSem.Clear();
            }
        }
    }
}
