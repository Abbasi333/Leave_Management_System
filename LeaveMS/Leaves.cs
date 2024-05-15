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
    public partial class LeavesLbl : Form
    {
        Functions Con;
        public LeavesLbl()
        {
            InitializeComponent();
            Con = new Functions();
            ShowLeaves();
            GetEmployee();
            GetCategories();
        }
        private void ShowLeaves()
        {
            string Query = "select * from LeaveTbl";
            LeavesList.DataSource = Con.GetData(Query);
        }
        private void FilterLeaves()
        {
            string Query = "select * from LeaveTbl where Status = '{0}'";
            Query = string.Format(Query,LeaveMCb.SelectedIndex.ToString());
            LeavesList.DataSource = Con.GetData(Query);
        }
        private void GetEmployee()
        {
            string Query = "select * from EmployeeTbl";
            EmpNameCb.DisplayMember = Con.GetData(Query).Columns["EmpName"].ToString();
            EmpNameCb.ValueMember = Con.GetData(Query).Columns["EmpId"].ToString();
            EmpNameCb.DataSource = Con.GetData(Query);

        }
        private void GetCategories()
        {
            string Query = "select * from CategoryTbl";
            CatNameCb.DisplayMember = Con.GetData(Query).Columns["CateName"].ToString();
            CatNameCb.ValueMember = Con.GetData(Query).Columns["CatId"].ToString();
            CatNameCb.DataSource = Con.GetData(Query);

        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameCb.SelectedIndex == -1 || CatNameCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!!");
                }
                else
                {
                    int Employee = Convert.ToInt32(EmpNameCb.SelectedValue.ToString());
                    int Category = Convert.ToInt32(CatNameCb.SelectedValue.ToString());
                    string DateStart = DateStartTb.Value.Date.ToString();
                    string DateEnd = DateEndTb.Value.Date.ToString();
                    string AppliedDate = DateTime.Today.Date.ToString();
                    string Status = StatusCb.SelectedItem.ToString();
                    string Query = "update LeaveTbl  set Employee = {0},Category = {1},DateStart = '{2}',DateEnd = '{3}',Status = '{4}' where LId ={5}";
                    Query = string.Format(Query, Employee, Category, DateStart, DateEnd,Status,Key);
                    Con.SetData(Query);
                    ShowLeaves();
                    MessageBox.Show("Leaves Updated Successfully!!!");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameCb.SelectedIndex == -1 || CatNameCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!!");
                }
                else
                {
                    int Employee = Convert.ToInt32(EmpNameCb.SelectedValue.ToString());
                    int Category = Convert.ToInt32(CatNameCb.SelectedValue.ToString());
                    string DateStart = DateStartTb.Value.Date.ToString();
                   string DateEnd = DateEndTb.Value.Date.ToString();
                    string AppliedDate = DateTime.Today.Date.ToString();
                   // string Status = "Pending";
                   string Status = StatusCb.SelectedItem.ToString();
                    string Query = "insert into LeaveTbl  values({0},{1},'{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query,Employee,Category,DateStart,DateEnd,AppliedDate,Status);
                    Con.SetData(Query);
                    ShowLeaves();
                    MessageBox.Show("Leaves Added Successfully!!!");
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int Key = 0;
        private void LeavesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameCb.Text = LeavesList.SelectedRows[0].Cells[1].Value.ToString();
            CatNameCb.Text = LeavesList.SelectedRows[0].Cells[2].Value.ToString();
            DateStartTb.Text = LeavesList.SelectedRows[0].Cells[3].Value.ToString();
            DateEndTb.Text = LeavesList.SelectedRows[0].Cells[4].Value.ToString();
            StatusCb.Text = LeavesList.SelectedRows[0].Cells[6].Value.ToString();
            if (EmpNameCb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(LeavesList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameCb.SelectedIndex == -1 || CatNameCb.SelectedIndex == -1 || StatusCb.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Data!!!!");
                }
                else
                {
                    string Status = StatusCb.SelectedItem.ToString();
                    string Query = "Delete from LeaveTbl where LId ={0}";
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    ShowLeaves();
                    MessageBox.Show("Leaves Deleted Successfully!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            ShowLeaves();
        }

        private void LeaveMCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterLeaves();
        }

        private void Leaves_Load(object sender, EventArgs e)
        {

        }

        private void EmployeeLbl_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void CategoryLbl_Click(object sender, EventArgs e)
        {
            Categorie Obj = new Categorie();
            Obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            //leaves
            LeavesLbl Obj = new LeavesLbl();
            Obj.Show();
            this.Hide();
        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }
    }
}
