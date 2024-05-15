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
    public partial class Form1 : Form
    {
        Functions Con;
        public Form1()
        {
            InitializeComponent();
            Con = new Functions();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public static int EmpId;
        public static string EmpName = "";
        private void LoginTb_Click(object sender, EventArgs e)
        {
            String UserName = UserNameTb.Text;
            String Password = PasswordTb.Text;
            if(UserNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Info!!!");
            }
            else{
                if(UserNameTb.Text == "Admin" || PasswordTb.Text == "Pass123")
                {
                    Employees Obj = new Employees();
                    Obj.Show();
                    this.Hide();
                }
                else
                {
                    try
                    {
                        string Query = "Select * from EmployeeTbl where EmpName ='{0}' and EmpPassword ='{1}'";
                        Query = string.Format(Query,UserName,Password);
                        DataTable dt = Con.GetData(Query);
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Incorrect Password!!!");
                            UserNameTb.Text = "";
                            PasswordTb.Text = "";
                        }
                        else
                        {
                            EmpId = Convert.ToInt32(dt.Rows[0][0].ToString());
                            EmpName = dt.Rows[0][1].ToString();
                            ViewLeaves Obj = new ViewLeaves();
                            Obj.Show();
                            this.Hide();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);    
                    }
                   
                }
            }
        }

        private void CloseLbl_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
