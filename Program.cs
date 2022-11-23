using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CITO_FSIN
{
    public struct User
    {
        public string login;
        public string password;
        public string type;


    }
    static class Program
    { 
        public static FSINEntities1 wftDb = new FSINEntities1();

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormTitul first = new FormTitul ();
            DateTime end = DateTime.Now + TimeSpan.FromSeconds(5);
            first.Show();
            while (end>DateTime.Now)
            {
                Application.DoEvents();

            }
            first.Close();
            first.Dispose();
            Application.Run(new FormUsers());
        }
    }
}
