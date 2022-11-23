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
    public partial class HolidaysForm : Form
    {
        public HolidaysForm()
        {
            InitializeComponent();
        }

        private void HolidaysForm_Load(object sender, EventArgs e)
        {
            RefreshCombo();
            Refresh1();
        }
        void Refresh1()
        {
            dataGridView1.Rows.Clear();
            Models.HolidaysModel.HolidaysController sc = new Models.HolidaysModel.HolidaysController();

            foreach (string[] s in sc.LoadData())
            {
                dataGridView1.Rows.Add(s);
            }
        }
        void RefreshCombo()
        {
            comboBox1.Items.Clear();
            Models.StaffModel.StaffController mc = new Models.StaffModel.StaffController();
            List<Models.StaffModel.Staff> medicalCheckups;
            medicalCheckups = mc.GetStaff();
            foreach (Models.StaffModel.Staff medcheck in medicalCheckups)
            {
                comboBox1.Items.Add(medcheck.Id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                Models.HolidaysModel.HolidaysController sc = new Models.HolidaysModel.HolidaysController();
                Models.HolidaysModel.Holidays staff = new Models.HolidaysModel.Holidays();
                staff.Idstaff = Convert.ToInt32(comboBox1.Text);
                staff.Datef = Convert.ToDateTime(dateTimePicker1.Value);
                staff.Datet = Convert.ToDateTime(dateTimePicker2.Value);

                sc.CreateStaff(staff);
                Refresh1();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
        int choosedId = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Models.HolidaysModel.HolidaysController sc = new Models.HolidaysModel.HolidaysController();
                Models.HolidaysModel.Holidays staff = new Models.HolidaysModel.Holidays();
                staff.Id = choosedId;
                staff.Idstaff = Convert.ToInt32(comboBox1.Text);
                staff.Datef = Convert.ToDateTime(dateTimePicker1.Value);
                staff.Datet = Convert.ToDateTime(dateTimePicker2.Value);
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
                Models.HolidaysModel.HolidaysController sc = new Models.HolidaysModel.HolidaysController();
                Models.HolidaysModel.Holidays staff = new Models.HolidaysModel.Holidays();
                staff.Id = choosedId;
                staff.Idstaff = Convert.ToInt32(comboBox1.Text);
                staff.Datef = Convert.ToDateTime(dateTimePicker1.Value);
                staff.Datet = Convert.ToDateTime(dateTimePicker2.Value);
                sc.DeleteStaff(staff);
                Refresh1();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
        bool flag = true;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                choosedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                label5.Text = "Выбранное ID для удаления: " + choosedId;
                comboBox1.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                flag = true;

            }
            catch
            {
                flag = false;
                Console.WriteLine("Ничего не выбрано");
                label5.Text = "Выбранное ID для удаления: ";
                comboBox1.Text = "";
                dateTimePicker1.Value = DateTime.UtcNow;
                dateTimePicker2.Value = DateTime.UtcNow.AddDays(1);

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
    }
}
