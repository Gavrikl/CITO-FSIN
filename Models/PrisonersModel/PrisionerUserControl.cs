using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace CITO_FSIN.Models.PrisonersModel
{
    public partial class PrisionerUserControl : UserControl
    {
        Prisoners prisonerTemp;
        string filePath = string.Empty;
        public Button deleteButton;
        public PrisionerUserControl(Prisoners prisoner)
        {
            InitializeComponent();
            DoubleBuffered = true;
            deleteButton = button2;
            this.Tag = prisoner.Id;
            textBox1.Text = prisoner.Name;
            textBox2.Text = prisoner.Midname;
            textBox3.Text = prisoner.Surname;
            richTextBox1.Text = prisoner.Article;
            pictureBox1.Image = prisoner.Photo;
            prisonerTemp = prisoner;
            textBox4.Text = "ID: " + prisoner.Id.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrisonersController pc = new PrisonersController();
            try
            {
                pc.DeletePrisoner(prisonerTemp);
                MessageBox.Show("Удаление завершено");
            }
            catch
            {
                MessageBox.Show("Не удалось удалить");
            }

        }

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

                        pictureBox1.Image = Image.FromFile(filePath);
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, можно устанавливать только картинки png и jpg форматов");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrisonersController pc = new PrisonersController();


            try
            {
                Prisoners prisoner = new Prisoners();
                prisoner.Id = (int)Tag;
                prisoner.Name = textBox1.Text;
                prisoner.Midname = textBox2.Text;
                prisoner.Surname = textBox3.Text;
                prisoner.Article = richTextBox1.Text;
                //prisoner.Photo = null;
                if (pictureBox1.Image != null && filePath != string.Empty)
                {
                    prisoner.photoPath = filePath;
                    prisoner.Photo = pictureBox1.Image;
                }
                pc.ChangePrisoner(prisoner);
                MessageBox.Show("Изменение завершено");
            }
            catch
            {
                MessageBox.Show("Не удалось изменить");
            }
        }

        private void PrisionerUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
