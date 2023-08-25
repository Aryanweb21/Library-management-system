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
    public partial class Add_Book : Form
    {
        public Add_Book()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtBookAuth.Text != "" && txtBookPrice.Text != "" && txtBookPub.Text != "" && txtBookQuan.Text != "")
            {
                String bName = txtBookName.Text;
                String bAuth = txtBookAuth.Text;
                String bPubl = txtBookPub.Text;
                String bpDate = dateTimePicker1.Text;
                Int64 bPrice = Int64.Parse(txtBookPrice.Text);
                Int64 bQuan = Int64.Parse(txtBookQuan.Text);


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-7CJHOJ2B\\SQLEXPRESS ; database= library; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into newBook (bName,bAuthor,bPubl,bpDate,bPrice,bQuan) values('" + bName + "','" + bAuth + "','" + bPubl + "','" + bpDate + "'," + bPrice + "," + bQuan + ") ";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookAuth.Clear();
                txtBookName.Clear();
                txtBookPrice.Clear();
                txtBookPub.Clear();
                txtBookQuan.Clear();
            }
            else
                MessageBox.Show("All fields are mandatory.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" || txtBookAuth.Text != "" || txtBookPrice.Text != "" || txtBookPub.Text != "" || txtBookQuan.Text != "")
            {
                if (MessageBox.Show("This will delete the unsaved data.", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
                this.Close();
        }
    }
}
