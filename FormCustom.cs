using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CITO_FSIN
{
    public partial class FormCustom : Form
    {
        public FormCustom()
        {
            InitializeComponent();
            ShowCustom();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAd_Click(object sender, EventArgs e)
        {

        }
        void ShowCustom()
        {



        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {


        }

        private void buttonDel_Click(object sender, EventArgs e)
        {

        }

        private void FormCustom_Load(object sender, EventArgs e)
        {
            Refresh1();
        }

        private void Refresh1()
        {
            Models.CustomModel.CustomController sc = new Models.CustomModel.CustomController();
            dataGridView1.Rows.Clear();
            foreach (string[] s in sc.LoadData())
            {
                dataGridView1.Rows.Add(s);
            }
        }


        int choosedId = 0;
        bool flag = false;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                choosedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                label5.Text = "Выбранное ID для удаления: " + choosedId;
                comboBoxDepartment.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                comboBoxProduct.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);

                flag = true;

            }
            catch
            {
                flag = false;
                Console.WriteLine("Ничего не выбрано");
                label5.Text = "Выбранное ID для удаления: ";
                comboBoxDepartment.Text = "";
                comboBoxProduct.Text = "";
                numericUpDown1.Value = 0;

            }
            button1.Enabled = !flag;
            button2.Enabled = flag;
            button4.Enabled = flag;
            if (choosedId == 0)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Models.CustomModel.CustomController sc = new Models.CustomModel.CustomController();
                Models.CustomModel.Custom staff = new Models.CustomModel.Custom();
                staff.Department = comboBoxDepartment.Text;
                staff.Product = comboBoxProduct.Text;
                staff.Quantity = Convert.ToInt32(numericUpDown1.Value);
                staff.Date = DateTime.UtcNow.Date;
                sc.CreateStaff(staff);
                Refresh1();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Models.CustomModel.CustomController sc = new Models.CustomModel.CustomController();
                Models.CustomModel.Custom staff = new Models.CustomModel.Custom();
                staff.Id = choosedId;
                staff.Department = comboBoxDepartment.Text;
                staff.Product = comboBoxProduct.Text;
                staff.Quantity = Convert.ToInt32(numericUpDown1.Value);
                staff.Date = DateTime.UtcNow.Date;
                sc.ChangeStaff(staff);
                Refresh1();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Models.CustomModel.CustomController sc = new Models.CustomModel.CustomController();
                Models.CustomModel.Custom staff = new Models.CustomModel.Custom();
                staff.Id = choosedId;
                staff.Department = comboBoxDepartment.Text;
                staff.Product = comboBoxProduct.Text;
                staff.Quantity = Convert.ToInt32(numericUpDown1.Value);
                sc.DeleteStaff(staff);
                Refresh1();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
