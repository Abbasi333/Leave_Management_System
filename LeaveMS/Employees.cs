using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace LeaveMS
{
    public partial class Employees : Form
    {
        Functions Con;
        public Employees()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmployees();
        }
        private void ShowEmployees()
        {
            string Query = "select * from EmployeeTbl";
            EmployeeList.DataSource = Con.GetData(Query);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        //SaveBtn
        private void button3_Click(object sender, EventArgs e)
        {
            //saveBtn Functinality
            try
            {
                if (EmpNameTb.Text == "" || EmpPhoneTb.Text =="" ||EmpGenderCb.SelectedIndex == -1 ||EmpPasswordTb.Text =="" ||EmpAddressTb.Text =="")
                {
                    MessageBox.Show("Missing Data!!!!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = EmpGenderCb.SelectedItem.ToString();
                    string Phone = EmpPhoneTb.Text;
                    string Password = EmpPasswordTb.Text;
                    string Address = EmpAddressTb.Text;
                    string Query = "insert into EmployeeTbl  values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, Name,Gender,Phone,Password,Address);
                    Con.SetData(Query);
                    ShowEmployees();
                    MessageBox.Show("Employee Added!!!");
                    EmpNameTb.Text = "";
                    EmpPhoneTb.Text = "";
                    EmpPasswordTb.Text = "";
                    EmpAddressTb.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //SaveBtn
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Employees_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            //employee
            Employees Obj = new Employees();
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

        private void label10_Click(object sender, EventArgs e)
        {
            //LEAVES
            LeavesLbl Obj =new LeavesLbl();
            Obj.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            //logout
            Form1 Obj = new Form1();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        int Key = 0;
        private void EmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeList.SelectedRows[0].Cells[1].Value.ToString();
            EmpGenderCb.Text = EmployeeList.SelectedRows[0].Cells[2].Value.ToString();
            EmpPhoneTb.Text = EmployeeList.SelectedRows[0].Cells[3].Value.ToString();
            EmpPasswordTb.Text = EmployeeList.SelectedRows[0].Cells[4].Value.ToString();
            EmpAddressTb.Text = EmployeeList.SelectedRows[0].Cells[5].Value.ToString();
            if (EmpNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmployeeList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpGenderCb.SelectedIndex == -1 || EmpPasswordTb.Text == "" || EmpAddressTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = EmpGenderCb.SelectedItem.ToString();
                    string Phone = EmpPhoneTb.Text;
                    string Password = EmpPasswordTb.Text;
                    string Address = EmpAddressTb.Text;
                    string Query = "update  EmployeeTbl  set EmpName ='{0}',EmpGender='{1}',EmpPhone='{2}',EmpPassword='{3}',EmpAddress='{4}' where EmpId={5}";
                    Query = string.Format(Query, Name, Gender, Phone, Password, Address,Key);
                    Con.SetData(Query);
                    ShowEmployees();
                    MessageBox.Show("Employee Updated!!!");
                    EmpNameTb.Text = "";
                    EmpPhoneTb.Text = "";
                    EmpPasswordTb.Text = "";
                    EmpAddressTb.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpGenderCb.SelectedIndex == -1 || EmpPasswordTb.Text == "" || EmpAddressTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!!");
                }
                else
                {
                   
                    string Query = "delete from  EmployeeTbl   where EmpId={0}";
                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    ShowEmployees();
                    MessageBox.Show("Employee Deleted Successfully!!!");
                    EmpNameTb.Text = "";
                    EmpPhoneTb.Text = "";
                    EmpPasswordTb.Text = "";
                    EmpAddressTb.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
