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
    public partial class FormUsers : Form
    {
        public static Users users = new Users();

        public FormUsers()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            if (textBoxLogin.Text == " " && textBoxPassword.Text == " ")
            {
                MessageBox.Show("Введите данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else
            {
                bool key = false;

                foreach (Users user in Program.wftDb.Users)
                {
                    if (textBoxLogin.Text == user.Login && textBoxPassword.Text == user.Password)
                    {
                        key = true;
                        users.Login = user.Login;
                        users.Password = user.Password;
                        users.Type = user.Type;

                        
                    }
                }

                if (!key)
                {
                    MessageBox.Show("Проверьте данные", "Пользователь не найден", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxLogin.Text = " ";
                    textBoxPassword.Text = " ";
                }

                else
                {

                    CITO_FSIN menu = new CITO_FSIN();
                    menu.Show();
                    this.Hide();
                }
            }
            }
    }
}
