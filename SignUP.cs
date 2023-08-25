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
    public partial class SignUP : Form
    {
        public SignUP()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?","Confirm exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Form1 LF = new Form1();
                LF.Show();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtConfirmPass.Clear();
            txtCreatePass.Clear();
            txtEmail.Clear();
            txtName.Clear();
            txtScID.Clear();
            txtUsername.Clear();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            String StName = txtName.Text;
            String StEmail = txtEmail.Text;
            String StUsername = txtUsername.Text;
            String CrPass = txtCreatePass.Text;
            String CnfPass = txtConfirmPass.Text;
            String ScID = txtScID.Text;

            if(StName =="" || StEmail=="" || StUsername=="" || CrPass=="" || CnfPass=="" || ScID=="")
            {
                MessageBox.Show("All fields are mandatory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(CrPass != CnfPass)
            {
                MessageBox.Show("Password and confirm passwords must be same", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS; database = library; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select id from login_table";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                int count = 0;
                for(int i=0;i< ds.Tables[0].Rows.Count; i++)
                {
                   if ((ds.Tables[0].Rows[i][0].ToString()) == ScID)
                    {
                        count++;
                    }
                }
                if(count != 0)
                {
                    MessageBox.Show("Scholar ID already exists in our database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection con1 = new SqlConnection();
                    con1.ConnectionString = "data source =LAPTOP-7CJHOJ2B\\SQLEXPRESS; database = library; integrated security = True";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con1;
                    con1.Open();
                    cmd1.CommandText = "insert into login_table (id,username,password,stName,stEmail) values('"+ScID+"','"+StUsername+"','"+CnfPass+"','"+StName+"','"+StEmail+"')";
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form1 LF = new Form1();
                    LF.Show();
                }
            }
        }
    }
}
