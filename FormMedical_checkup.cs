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
    public partial class FormMedical_checkup : Form
    {
        public FormMedical_checkup()
        {
            InitializeComponent();

            ShowMedical_checkup();
            ShowMedical_checkup2();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void FormMedical_checkup_Load(object sender, EventArgs e)
        {
            RefreshComboboxes();
            RefreshData();
        }
        void RefreshData()
        {
            dataGridView1.Rows.Clear();
            Models.MedCheckModel.MedicalCheckupController mc = new Models.MedCheckModel.MedicalCheckupController();

            foreach (string[] s in mc.LoadData())
            {
                dataGridView1.Rows.Add(s);
            }

        }
        void RefreshComboboxes()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            Models.PrisonersModel.PrisonersController mc = new Models.PrisonersModel.PrisonersController();
            List<Models.PrisonersModel.Prisoners> medicalCheckups;
            medicalCheckups = mc.GetPrisoners();
            foreach (Models.PrisonersModel.Prisoners medcheck in medicalCheckups)
            {
                comboBox1.Items.Add(medcheck.Id);
            }
            Models.StaffModel.StaffController mc1 = new Models.StaffModel.StaffController();
            List<Models.StaffModel.Staff> medicalCheckups1;
            medicalCheckups1 = mc1.GetStaff();
            foreach (Models.StaffModel.Staff medcheck in medicalCheckups1)
            {
                comboBox2.Items.Add(medcheck.Id);
            }
        }

        private void comboBoPrs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAd_Click(object sender, EventArgs e)
        {



        }
        void ShowMedical_checkup()
        {



        }






        void ShowMedical_checkup2()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Models.MedCheckModel.MedicalCheckupController sc = new Models.MedCheckModel.MedicalCheckupController();
                Models.MedCheckModel.MedicalCheckup staff = new Models.MedCheckModel.MedicalCheckup();
                staff.Idprisoner = Convert.ToInt32(comboBox1.Text);
                staff.Idemployee = Convert.ToInt32(comboBox2.Text);
                staff.Prs = textBox3.Text;
                staff.Prvmedexm = textBox4.Text;
                sc.CreateStaff(staff);
                RefreshData();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
        bool flag = false;
        int choosedId = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                Models.StaffModel.StaffController sc = new Models.StaffModel.StaffController();
                choosedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                label5.Text = "Выбранное ID для удаления: " + choosedId;
                comboBox1.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                comboBox2.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                textBox3.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                textBox4.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                Models.StaffModel.Staff staff = sc.GetStaff().Where(staffId => staffId.Id == choosedId).FirstOrDefault();

                flag = true;

            }
            catch
            {
                flag = false;
                Console.WriteLine("Ничего не выбрано");
                label5.Text = "Выбранное ID для удаления: ";
                comboBox1.Text = "";
                comboBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Models.MedCheckModel.MedicalCheckupController sc = new Models.MedCheckModel.MedicalCheckupController();
                Models.MedCheckModel.MedicalCheckup staff = new Models.MedCheckModel.MedicalCheckup();
                staff.Id = choosedId;
                staff.Idprisoner = Convert.ToInt32(comboBox1.Text);
                staff.Idemployee = Convert.ToInt32(comboBox2.Text);
                staff.Prs = textBox3.Text;
                staff.Prvmedexm = textBox4.Text;
                sc.ChangeStaff(staff);
                RefreshData();
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
                Models.MedCheckModel.MedicalCheckupController sc = new Models.MedCheckModel.MedicalCheckupController();
                Models.MedCheckModel.MedicalCheckup staff = new Models.MedCheckModel.MedicalCheckup();
                staff.Id = choosedId;
                staff.Idprisoner = Convert.ToInt32(comboBox1.Text);
                staff.Idemployee = Convert.ToInt32(comboBox2.Text);
                staff.Prs = textBox3.Text;
                staff.Prvmedexm = textBox4.Text;
                sc.DeleteStaff(staff);
                RefreshData();
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


