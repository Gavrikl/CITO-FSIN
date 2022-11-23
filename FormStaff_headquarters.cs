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
    public partial class FormStaff_headquarters : Form
    {
        public FormStaff_headquarters()
        {
            InitializeComponent();
            
            Refresh1();
        }

        private void buttonAd_Click(object sender, EventArgs e)
        {

        }
       
        private void buttonEdit_Click(object sender, EventArgs e)
        {


        }

        private void listViewStaff_headquarters_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void buttonDel_Click(object sender, EventArgs e)
        {


        }

        private void FormStaff_headquarters_Load(object sender, EventArgs e)
        {
        }
        private void Refresh1()
        {
            Models.StaffModel.StaffController sc = new Models.StaffModel.StaffController();
            dataGridView1.Rows.Clear();
            foreach (string[] s in sc.LoadData())
            {
                dataGridView1.Rows.Add(s);
            }
        }

        int choosedId = 0;
        bool flag;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                Models.StaffModel.StaffController sc = new Models.StaffModel.StaffController();
                choosedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                label5.Text = "Выбранное ID для удаления: " + choosedId;
                textBox1.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                textBox2.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                textBox3.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                comboBoxDepartment.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                textBox4.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
                Models.StaffModel.Staff staff = sc.GetStaff().Where(staffId => staffId.Id == choosedId).FirstOrDefault();

                flag = true;

            }
            catch
            {
                flag = false;
                Console.WriteLine("Ничего не выбрано");
                label5.Text = "Выбранное ID для удаления: ";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBoxDepartment.Text = "";
                textBox4.Text = "";

            }
            button1.Enabled = !flag;
            button2.Enabled = flag;
            button4.Enabled = flag;
            if(choosedId == 0)
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
                Models.StaffModel.StaffController sc = new Models.StaffModel.StaffController();
                Models.StaffModel.Staff staff = new Models.StaffModel.Staff();
                staff.Name = textBox1.Text;
                staff.Surname = textBox2.Text;
                staff.Midname = textBox3.Text;
                staff.Department = comboBoxDepartment.Text;
                staff.Position = textBox4.Text;

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
                Models.StaffModel.StaffController sc = new Models.StaffModel.StaffController();
                Models.StaffModel.Staff staff = new Models.StaffModel.Staff();
                staff.Id = choosedId;
                staff.Name = textBox1.Text;
                staff.Surname = textBox2.Text;
                staff.Midname = textBox3.Text;
                staff.Department = comboBoxDepartment.Text;
                staff.Position = textBox4.Text;
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
                Models.StaffModel.StaffController sc = new Models.StaffModel.StaffController();
                Models.StaffModel.Staff staff = new Models.StaffModel.Staff();
                staff.Id = choosedId;
                staff.Name = textBox1.Text;
                staff.Surname = textBox2.Text;
                staff.Midname = textBox3.Text;
                staff.Department = comboBoxDepartment.Text;
                staff.Position = textBox4.Text;
                sc.DeleteStaff(staff);
                Refresh1();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}