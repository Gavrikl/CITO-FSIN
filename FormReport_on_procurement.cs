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
    public partial class FormReport_on_procurement : Form
    {
        public FormReport_on_procurement()
        {
            InitializeComponent();
            ShowStaffofemployees2();
            ShowStaffofemployees();
        }

        void Refresh1()
        {
            dataGridView1.Rows.Clear();
            Models.ProcurementModel.ProcurementController mc = new Models.ProcurementModel.ProcurementController();

            foreach (string[] s in mc.LoadData())
            {
                dataGridView1.Rows.Add(s);
            }

        }
        void Refresh2()
        {
            dataGridView2.Rows.Clear();
            Models.ExprensesModel.ExprensesController mc = new Models.ExprensesModel.ExprensesController();

            foreach (string[] s in mc.LoadData())
            {
                dataGridView2.Rows.Add(s);
            }

        }
        private void buttonAd_Click(object sender, EventArgs e)
        {

        }
        void ShowStaffofemployees2()
        {


        }
        void ShowStaffofemployees()
        {

        }


        private void listViewReport_on_procurement_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {

        }

        private void FormReport_on_procurement_Load(object sender, EventArgs e)
        {
            RefreshCombo();
            Refresh1();
            Refresh2();
        }
        void RefreshCombo()
        {
            comboBox1.Items.Clear();
            Models.CustomModel.CustomController mc = new Models.CustomModel.CustomController();
            List<Models.CustomModel.Custom> medicalCheckups;
            medicalCheckups = mc.GetStaff();
            foreach (Models.CustomModel.Custom medcheck in medicalCheckups)
            {
                comboBox1.Items.Add(medcheck.Id);
            }
        }
        bool flag = false;
        int choosedId = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                choosedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                label5.Text = "Выбранное ID для удаления: " + choosedId;
                comboBox1.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                textBox3.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                flag = true;

            }
            catch
            {
                flag = false;
                Console.WriteLine("Ничего не выбрано");
                label5.Text = "Выбранное ID для удаления: ";
                comboBox1.Text = "";
                textBox3.Text = "";

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
                Models.ProcurementModel.ProcurementController sc = new Models.ProcurementModel.ProcurementController();
                Models.ProcurementModel.Procurement staff = new Models.ProcurementModel.Procurement();
                staff.Idorder = Convert.ToInt32(comboBox1.Text);
                staff.Price = Convert.ToDouble(textBox3.Text);
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
                Models.ProcurementModel.ProcurementController sc = new Models.ProcurementModel.ProcurementController();
                Models.ProcurementModel.Procurement staff = new Models.ProcurementModel.Procurement();
                staff.Id = choosedId;
                staff.Idorder = Convert.ToInt32(comboBox1.Text);
                staff.Price = Convert.ToDouble(textBox3.Text);
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
                Models.ProcurementModel.ProcurementController sc = new Models.ProcurementModel.ProcurementController();
                Models.ProcurementModel.Procurement staff = new Models.ProcurementModel.Procurement();
                staff.Id = choosedId;
                staff.Idorder = Convert.ToInt32(comboBox1.Text);
                staff.Price = Convert.ToDouble(textBox3.Text);
                staff.Date = DateTime.UtcNow.Date;
                sc.DeleteStaff(staff);
                Refresh1();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Models.ExprensesModel.ExprensesController sc = new Models.ExprensesModel.ExprensesController();
                Models.ExprensesModel.Exprenses staff = new Models.ExprensesModel.Exprenses();
                staff.Price = Convert.ToDouble(textBox1.Text);
                staff.Date = DateTime.UtcNow.Date;

                sc.CreateStaff(staff);
                Refresh2();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Models.ExprensesModel.ExprensesController sc = new Models.ExprensesModel.ExprensesController();
                Models.ExprensesModel.Exprenses staff = new Models.ExprensesModel.Exprenses();
                staff.Id = choosedId;
                staff.Price = Convert.ToDouble(textBox1.Text);
                staff.Date = DateTime.UtcNow.Date;
                sc.ChangeStaff(staff);
                Refresh2();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Models.ExprensesModel.ExprensesController sc = new Models.ExprensesModel.ExprensesController();
                Models.ExprensesModel.Exprenses staff = new Models.ExprensesModel.Exprenses();
                staff.Id = choosedId;
                staff.Price = Convert.ToDouble(textBox1.Text);
                staff.Date = DateTime.UtcNow.Date;
                sc.DeleteStaff(staff);
                Refresh2();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                choosedId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                label5.Text = "Выбранное ID для удаления: " + choosedId;
                textBox1.Text = (string)dataGridView2.Rows[e.RowIndex].Cells[1].Value;
                flag = true;

            }
            catch
            {
                flag = false;
                Console.WriteLine("Ничего не выбрано");
                label5.Text = "Выбранное ID для удаления: ";
                textBox1.Text = "";

            }
            button6.Enabled = !flag;
            button5.Enabled = flag;
            button3.Enabled = flag;
            if (choosedId == 0)
            {
                button6.Enabled = true;
                button5.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int month = DateTime.UtcNow.Month;
                label7.Text = $"Статистика за {DateTime.UtcNow.Month} месяц {DateTime.UtcNow.Year} года";


                Models.ProcurementModel.ProcurementController sc = new Models.ProcurementModel.ProcurementController();
                List<Models.ProcurementModel.Procurement> staff;

                Models.ExprensesModel.ExprensesController sc1 = new Models.ExprensesModel.ExprensesController();
                List<Models.ExprensesModel.Exprenses> staff1;


                staff = sc.GetStaff();
                staff1 = sc1.GetStaff();
                double sum = 0;
                double sum1 = 0;
                foreach (Models.ProcurementModel.Procurement proc in staff)
                {
                    if (proc.Date.Month == month)
                    {
                        AppendText1(richTextBox1, "Траты " + proc.ToString(), Color.Red, true);
                        sum += proc.Price;
                    }
                }
                foreach (Models.ExprensesModel.Exprenses proc in staff1)
                {
                    if (proc.Date.Month == month)
                    {
                        AppendText1(richTextBox1, "Доходы " + proc.ToString(), Color.Green, true);
                        sum1 += proc.Price;
                    }
                }
                label6.Text = Convert.ToString(sum1 - sum);
                if (Convert.ToDouble(label6.Text) > 0)
                {
                    label6.ForeColor = Color.Green;
                }
                else if (Convert.ToDouble(label6.Text) < 0)
                {
                    label6.ForeColor = Color.Red;
                }
                else
                {
                    label6.ForeColor = Color.Black;
                }
                button8.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка генерации отчета\n" + ex.Message);
            }
        }

        public void AppendText1(RichTextBox box, string text, Color color, bool AddNewLine = false)
        {
            if (AddNewLine)
            {
                text += Environment.NewLine;
            }

            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private Excel.Application _application = null;
        private Excel.Workbook _workBook = null;
        private Excel.Worksheet _workSheet = null;
        private object _missingObj = System.Reflection.Missing.Value;


        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                _application = new Excel.Application();
                _application.Visible = true;
                _workBook = _application.Workbooks.Add(_missingObj);
                _workSheet = (Excel.Worksheet)_workBook.Worksheets.get_Item(1);

                int month = DateTime.UtcNow.Month;
                label7.Text = $"Статистика за {DateTime.UtcNow.Month} месяц {DateTime.UtcNow.Year} года";


                Models.ProcurementModel.ProcurementController sc = new Models.ProcurementModel.ProcurementController();
                List<Models.ProcurementModel.Procurement> staff;

                Models.ExprensesModel.ExprensesController sc1 = new Models.ExprensesModel.ExprensesController();
                List<Models.ExprensesModel.Exprenses> staff1;


                staff = sc.GetStaff();
                staff1 = sc1.GetStaff();
                double sum = 0;
                double sum1 = 0;
                int i = 2;
                int ii = 0;
                SetCellValue("ID", 1, 1);
                SetCellValue("ID покупки", 1, 2);
                SetCellValue("Цена", 1, 3);
                SetCellValue("Дата", 1, 4);
                foreach (Models.ProcurementModel.Procurement proc in staff)
                {
                    if (proc.Date.Month == month)
                    {
                        SetCellValue(proc.Id.ToString(), i, 1);
                        SetCellValue(proc.Idorder.ToString(), i, 2);
                        SetCellValue(proc.Price.ToString(), i, 3);
                        SetCellValue(proc.Date.ToString(), i, 4);
                        i++;


                    }
                }
                i = 2;
                ii = 6;
                SetCellValue("ID", 1, 6);
                SetCellValue("Бюджет", 1, 7);
                SetCellValue("Дата", 1, 8);
                foreach (Models.ExprensesModel.Exprenses proc in staff1)
                {
                    if (proc.Date.Month == month)
                    {
                        SetCellValue(proc.Id.ToString(), i, 6);
                        SetCellValue(proc.Price.ToString(), i, 7);
                        SetCellValue(proc.Date.ToString(), i, 8);
                        i++;

                    }
                }


                SetCellValue("Итого: " + label6.Text, 2, 10);
            }
            catch(Exception ex)
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

