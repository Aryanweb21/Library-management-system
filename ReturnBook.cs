using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College_Project_Final
{
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                dataGridView1.DataSource = null;
            }
        }

        String search;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.ReadOnly = true;
            String stID = txtSearch.Text;
            if(stID != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LENOVOI3-0031M9\\SQLEXPRESS; database = add_book; integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from issue_return_Book where stERP = '" + stID + "' and bkReturnDate is null";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("No record found!", "No record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Enter a valid enrollment number!", "Invalid ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            txtIssueDate.Clear();
            txtSearch.Clear();
            txtSearch.ReadOnly = false;
            panel2.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are your sure?","Confirm exit",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }
        Int64 rID;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Show();
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS; database= library; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select bkName,bkIssueDate from issue_return_Book where id = "+rID+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            txtBookName.Text = ds.Tables[0].Rows[0][0].ToString();
            txtIssueDate.Text = ds.Tables[0].Rows[0][1].ToString();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Return this book?","Confirm Return",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String brDate = dateTimePicker1.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS; database= library; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "update issue_return_Book set bkReturnDate = '" + brDate + "' where id = " + rID + "";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Book Returned.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRefresh_Click(this,null);
            }
        }
    }
}
