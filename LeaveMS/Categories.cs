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
    public partial class Categorie : Form
    {
        Functions Con;
        public Categorie()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCategories();
        }
        private void ShowCategories()
        {
            string Query = "select * from CategoryTbl";
            CategoriesList.DataSource = Con.GetData(Query);
        }
        private void Categories_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void EmpNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(CatNameTb.Text  == "")
                {
                    MessageBox.Show("Missing Data!!!!");
                }
                else
                {
                    string Category = CatNameTb.Text;
                    string Query = "insert into CategoryTbl  values('{0}')";
                    Query = string.Format(Query , Category);
                    Con.SetData(Query);
                    ShowCategories();
                    CatNameTb.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int Key = 0;
        private void CategoriesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatNameTb.Text = CategoriesList.SelectedRows[0].Cells[1].Value.ToString();
            if(CatNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CategoriesList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!!!");
                }
                else
                {
                    string Category = CatNameTb.Text;
                    string Query = "Update CategoryTbl set CateName = '{0}' where CatId = {1}";
                    Query = string.Format(Query, Category,Key);
                    Con.SetData(Query);
                    ShowCategories();
                    CatNameTb.Text = "";
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
                if (Key == 0)
                {
                    MessageBox.Show("Missing Data!!!!");
                }
                else
                {
                    string Category = CatNameTb.Text;
                    string Query = "delete from CategoryTbl  where CatId = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetData(Query);
                    ShowCategories();
                    CatNameTb.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EmpLbl_Click(object sender, EventArgs e)
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

        private void LeaveLbl_Click(object sender, EventArgs e)
        {
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
