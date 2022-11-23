using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace CITO_FSIN
{
    public partial class FormPrisoners : Form
    {
        public FormPrisoners()
        {
            InitializeComponent();
            ShowPrisoners();
            DoubleBuffered = true;
        }

        private void buttonAd_Click(object sender, EventArgs e)
        {

        }
        void ShowPrisoners()
        {



        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {



        }

        private void listViewPrisoners_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {


        }

        private void FormPrisoners_Load(object sender, EventArgs e)
        {

            GetAllPrisoners();
        }


        private void GetAllPrisoners()
        {
            flowLayoutPanel1.Controls.Clear();
            Models.PrisonersModel.PrisonersController pc = new Models.PrisonersModel.PrisonersController();
            List<Models.PrisonersModel.Prisoners> prisoners = new List<Models.PrisonersModel.Prisoners>();
            prisoners = pc.GetPrisoners();
            foreach (Models.PrisonersModel.Prisoners prisoner in prisoners)
            {
                Models.PrisonersModel.PrisionerUserControl controll = new Models.PrisonersModel.PrisionerUserControl(prisoner);
                flowLayoutPanel1.Controls.Add(controll);
                controll.deleteButton.Click += DeleteButton_Click;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Clear();
            GetAllPrisoners();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAllPrisoners();
        }

        private void prisonersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {



        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

            if (e.TabPageIndex == 1)
            {
                Refresh1();
            }
            else
            {
                GetAllPrisoners();
            }
        }

        private void Refresh1()
        {
            Models.PrisonersModel.PrisonersController pc = new Models.PrisonersModel.PrisonersController();
            dataGridView1.Rows.Clear();
            foreach (string[] s in pc.LoadData())
            {
                dataGridView1.Rows.Add(s);
            }
        }
        string filePath = string.Empty;
        private void button3_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;


            using (FileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Picture files (*.png)|*.jpg|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    try
                    {
                        flag = false;
                        pictureBox1.Image = Image.FromFile(filePath);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, можно устанавливать только картинки png и jpg форматов");
                    }
                }
            }
        }
        int choosedId = 0;
        bool flag;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Models.PrisonersModel.PrisonersController pc = new Models.PrisonersModel.PrisonersController();
                choosedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                label5.Text = "Выбранное ID для удаления: " + choosedId;
                textBox1.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                textBox2.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                textBox3.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                richTextBox1.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                Models.PrisonersModel.Prisoners prisoner = pc.GetPrisoners().Where(prisonId => prisonId.Id == choosedId).FirstOrDefault();
                pictureBox1.Image = prisoner.Photo;
                flag = true;
                button3.Enabled = true;

            }
            catch
            {
                flag = false;
                Console.WriteLine("Ничего не выбрано");
                label5.Text = "Выбранное ID для удаления: ";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                richTextBox1.Text = "";
                pictureBox1.Image = null;

            }
            button1.Enabled = !flag;
            button2.Enabled = flag;
            button3.Enabled = true;
            button4.Enabled = flag;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Models.PrisonersModel.PrisonersController pc = new Models.PrisonersModel.PrisonersController();
                Models.PrisonersModel.Prisoners prisoner = new Models.PrisonersModel.Prisoners();
                prisoner.Name = textBox1.Text;
                prisoner.Surname = textBox2.Text;
                prisoner.Midname = textBox3.Text;
                prisoner.Article = richTextBox1.Text;
                prisoner.photoPath = filePath;
                if (pictureBox1.Image != null)
                {
                    prisoner.Photo = pictureBox1.Image;
                }
                pc.CreatePrisoner(prisoner);
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
                Models.PrisonersModel.PrisonersController pc = new Models.PrisonersModel.PrisonersController();
                Models.PrisonersModel.Prisoners prisoner = new Models.PrisonersModel.Prisoners();
                prisoner.Id = choosedId;
                prisoner.Name = textBox1.Text;
                prisoner.Surname = textBox2.Text;
                prisoner.Midname = textBox3.Text;
                prisoner.Article = richTextBox1.Text;
                if (flag != true)
                {
                    prisoner.photoPath = filePath;
                    if (pictureBox1.Image != null)
                    {
                        prisoner.Photo = pictureBox1.Image;
                    }
                }
                else
                {
                    prisoner.Photo = null;
                }

                pc.ChangePrisoner(prisoner);
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
                Models.PrisonersModel.PrisonersController pc = new Models.PrisonersModel.PrisonersController();
                Models.PrisonersModel.Prisoners prisoner = new Models.PrisonersModel.Prisoners();
                prisoner.Id = choosedId;
                prisoner.Name = textBox1.Text;
                prisoner.Surname = textBox2.Text;
                prisoner.Midname = textBox3.Text;
                prisoner.Article = richTextBox1.Text;
                prisoner.photoPath = filePath;
                if (pictureBox1.Image != null)
                {
                    prisoner.Photo = pictureBox1.Image;
                }
                pc.DeletePrisoner(prisoner);
                Refresh1();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int ready = 0;
            int notready = 0;
            button6.Visible = true;
            label8.Text = $"Статистика за {DateTime.UtcNow.Month} месяц {DateTime.UtcNow.Year} года";
            

            Models.PrisonersModel.PrisonersController pc = new Models.PrisonersModel.PrisonersController();
            Models.PrisonersModel.Prisoners prisoner = new Models.PrisonersModel.Prisoners();
            Models.MedCheckModel.MedicalCheckupController mc = new Models.MedCheckModel.MedicalCheckupController();
            Models.MedCheckModel.MedicalCheckup medicalcheck = new Models.MedCheckModel.MedicalCheckup();
            bool cleared = false;
            foreach (Models.PrisonersModel.Prisoners prison in pc.GetPrisoners())
            {
                foreach (Models.MedCheckModel.MedicalCheckup Medcheck in mc.GetStaff())
                {
                    if (prison.Id == Medcheck.Idprisoner)
                    {
                        cleared = true;
                    }
                }
                if (cleared)
                {
                    ready++;
                }
                else
                {
                    notready++;
                }
                cleared = false;
            }
            label6.Text = $"Заключенных прошло медицинскую проверку: {ready}";
            label7.Text = $"Заключенных не прошло медицинскую проверку: {notready}";
        }



        private Excel.Application _application = null;
        private Excel.Workbook _workBook = null;
        private Excel.Worksheet _workSheet = null;
        private object _missingObj = System.Reflection.Missing.Value;


        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                _application = new Excel.Application();
                _application.Visible = true;


                int month = DateTime.UtcNow.Month;



                Models.PrisonersModel.PrisonersController pc = new Models.PrisonersModel.PrisonersController();
                Models.PrisonersModel.Prisoners prisoner = new Models.PrisonersModel.Prisoners();
                Models.MedCheckModel.MedicalCheckupController mc = new Models.MedCheckModel.MedicalCheckupController();
                Models.MedCheckModel.MedicalCheckup medicalcheck = new Models.MedCheckModel.MedicalCheckup();
                _workBook = _application.Workbooks.Add(_missingObj);
                int item = 1;
                foreach (Models.PrisonersModel.Prisoners proc in pc.GetPrisoners())
                {
                    try
                    {
                        _workSheet = _application.Worksheets.Add(System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

                        _workSheet.Name = $"Мед. Проверки {proc.Name} ID {proc.Id}";

                        SetCellValue("ID", 1, 1);
                        SetCellValue("ID заключенного", 1, 2);
                        SetCellValue("Статус", 1, 3);
                        SetCellValue("Тип", 1, 4);
                        SetCellValue("ID работника", 1, 5);
                        int i = 2;
                        foreach (Models.MedCheckModel.MedicalCheckup med in mc.GetStaff())
                        {
                            if (proc.Id == med.Idprisoner)
                            {
                                SetCellValue(med.Id.ToString(), i, 1);
                                SetCellValue(med.Idprisoner.ToString(), i, 2);
                                SetCellValue(med.Prs, i, 3);
                                SetCellValue(med.Prvmedexm, i, 4);
                                SetCellValue(med.Idemployee.ToString(), i, 5);
                                i++;
                            }
                        }
                        item++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка проверьте доступность Excel\n" + ex.Message);
                        break;
                    }
                }



                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка проверьте доступность Excel\n" + ex.Message);
            }
        }

        public void SetCellValue(string cellValue, int rowIndex, int columnIndex)
        {
            _workSheet.Cells[rowIndex, columnIndex] = cellValue;
        }
    }
}
