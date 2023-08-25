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
    public partial class View_Student : Form
    {
        public View_Student()
        {
            InitializeComponent();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String id = txtSearch.Text;
            if(txtSearch.Text!="")
            {
                lblView.Text = "Searching";
                Image img = Image.FromFile("C:\\Users\\91910\\Downloads\\search.gif");
                pictureBox1.Image = img;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LENOVOI3-0031M9\\SQLEXPRESS;database = add_student;integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from addStudent where stERP LIKE '"+id+"%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                lblView.Text = "View";
                Image img = Image.FromFile("C:\\Users\\91910\\Downloads\\search-26280.png");
                pictureBox1.Image = img;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LENOVOI3-0031M9\\SQLEXPRESS;database = add_student;integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from addStudent";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void txtRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?","Confirm Exit",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void View_Student_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS;database = library;integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from addStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        Int64 rID;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Show();
            btnClose1.Hide();
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS; database= library; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from addStudent where stID = " + rID + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rID = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            //           stName,stERP,stDept,stSem,stCont,stEmail
            txtStName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtStEnroll.Text = ds.Tables[0].Rows[0][2].ToString();
            txtStDept.Text = ds.Tables[0].Rows[0][3].ToString();
            txtStSem.Text = ds.Tables[0].Rows[0][4].ToString();
            txtStCont.Text= ds.Tables[0].Rows[0][5].ToString();
            txtStEmail.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?","Confirm exit",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Data will be updated","Confirm?",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                String StName = txtStName.Text;
                String StERP = txtStEnroll.Text;
                String StDept = txtStDept.Text;
                String StEmail = txtStEmail.Text;
                String StSem = txtStSem.Text;
                Int64 StCont = Int64.Parse(txtStCont.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source =LAPTOP-7CJHOJ2B\\SQLEXPRESS; database= library; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update addStudent set stName = '" + StName + "',stERP = '" + StERP + "',stDept = '" + StDept + "',stSem = '" + StSem + "',stCont = " + StCont + ",stEmail='" + StEmail + "' where stID = " + rID + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Data saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be deleted.", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS; database= library; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from addStudent where stID = " + rID + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Data deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
