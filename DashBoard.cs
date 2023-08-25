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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to exit","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Book add_Book = new Add_Book();
            add_Book.Show();
        }

        private void viewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook vb = new ViewBook();
            vb.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Student aSt = new Add_Student();
            aSt.Show();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Student VS = new View_Student();
            VS.Show();
        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBook IB = new IssueBook();
            IB.Show();
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook RB = new ReturnBook();
            RB.Show();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void AvailableBooks_Click(object sender, EventArgs e)
        {
            AvailableBooks AB = new AvailableBooks();
            AB.Show();
        }

        private void IssuedBooks_Click(object sender, EventArgs e)
        {
            IssuedBooks ib = new IssuedBooks();
            ib.Show();
        }

        private void returnedBooks_Click(object sender, EventArgs e)
        {
            ReturnedBooks rb = new ReturnedBooks();
            rb.Show();
        }
    }
}
