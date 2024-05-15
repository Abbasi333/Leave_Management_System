using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaveMS
{
    public partial class ViewLeaves : Form
    {
        Functions Con;
        public ViewLeaves()
        {
            InitializeComponent();
            Con = new Functions();
            EmpIdLbl.Text = Form1.EmpId + "";
            EmpNameLbl.Text = Form1.EmpName;
            ShowLeaves();
        }
        private void ShowLeaves()
        {
            string Query = "select * from LeaveTbl where Employee = {0}";
            Query = string.Format(Query, Form1.EmpId);
            LeavesList.DataSource = Con.GetData(Query);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void EmpNameLbl_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            //Logout
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            //category
            Categorie Obj = new Categorie();
            Obj.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            //Employee file
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void LeavesLbl_Click(object sender, EventArgs e)
        {
            LeavesLbl Obj = new LeavesLbl();
            Obj.Show();
            this.Hide();
        }
    }
}
