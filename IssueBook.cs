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
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS; database = library; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select bName from newBook", con);
            SqlDataReader Dr = cmd.ExecuteReader();

            while(Dr.Read())
            {
                for(int i=0;i<Dr.FieldCount;i++)
                {
                    comboBox1.Items.Add(Dr.GetString(i));
                }
            }
            Dr.Close();
            con.Close();
        }

        int count;
        String search;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            {
                String eID = txtSearch.Text;
                search = txtSearch.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS; database = library; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                
                cmd.CommandText = "select * from addStudent where stERP = '"+eID+"'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS; database = library; integrated security = True";
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con1;

                cmd1.CommandText = "select count(stERP) from issue_return_Book where stERP = '" + eID + "' and bkReturnDate is null";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);

                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());

                if (ds.Tables[0].Rows.Count != 0)
                {
                    //stName,stERP,stDept,stSem,stCont,stEmail
                    txtStName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtStDept.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtStSem.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtStCont.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtStEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    MessageBox.Show("Please enter a valid ERP ID.", "No matches", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtStCont.Clear();
                txtStDept.Clear();
                txtStEmail.Clear();
                txtStName.Clear();
                txtStSem.Clear();
                MessageBox.Show("Enter a student ERP!", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?","Confirm exit",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(txtStName.Text != "")
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Select a book to issue.", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (count >= 3)
                {
                    MessageBox.Show("Maximum Books are already issued to the student.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    String stERP = txtSearch.Text;
                    String stName = txtStName.Text;
                    String stDept = txtStDept.Text;
                    String stSem = txtStSem.Text;
                    Int64 stCont = Int64.Parse(txtStCont.Text);
                    String stEmail = txtStEmail.Text;
                    String bName = comboBox1.SelectedItem.ToString();
                    String bIssueDate = dateTimePicker1.Text;
                    String eID = txtSearch.Text;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS; database = library;integrated security = True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into issue_return_Book (stERP,stName,stDept,stSem,stCont,stEmail,bkName,bkIssueDate) values('" + stERP + "','" + stName + "','"+stDept+"','"+stSem+"',"+stCont+",'"+stEmail+"','"+bName+"','"+bIssueDate+"')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    /*SqlConnection con1 = new SqlConnection();
                    con1.ConnectionString = "data source = LENOVOI3-0031M9\\SQLEXPRESS; database = add_book;integrated security = True";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con1;
                    con1.Open();
                    cmd1.CommandText = "update newBook set Issued = Issued+1, Available = Available-1 where bid = ";
                    cmd1.ExecuteNonQuery();
                    con1.Close();*/

                    MessageBox.Show("Book issued.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtStName.Clear();
                    txtSearch.Clear();
                    txtStCont.Clear();
                    txtStSem.Clear();
                    txtStEmail.Clear();
                    txtStDept.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter a valid Enrollment no!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text!= search)
            {
                txtStCont.Text = "";
               // txtStCont.Clear();
                txtStDept.Clear();
                txtStEmail.Clear();
                txtStName.Clear();
                txtStSem.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();      
        }
    }
}
