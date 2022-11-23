using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CITO_FSIN
{
    public partial class CITO_FSIN : Form
    {
        private SoundPlayer soundPlayer;

        public CITO_FSIN()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer("sovremennyiy-gimn-rosssii.wav");




        }

        private void Custom_Click(object sender, EventArgs e)
        {
            Form formCustom = new FormCustom();
            formCustom.Show();
        }

        private void CITO_FSIN_Load(object sender, EventArgs e)
        {

        }

        private void Report_on_procurement_Click(object sender, EventArgs e)
        {
            Form formReport_on_procurement = new FormReport_on_procurement();
            formReport_on_procurement.Show();
        }

        private void Staff_headquarters_Click(object sender, EventArgs e)
        {
            Form formStaff_headquarters = new FormStaff_headquarters();
            formStaff_headquarters.Show();
        }

        private void Prisoners_Click(object sender, EventArgs e)
        {
            Form formPrisoners = new FormPrisoners();
            formPrisoners.Show();

        }

        private void Medical_checkup_Click(object sender, EventArgs e)
        {
            Form formMedical_checkup = new FormMedical_checkup();
            formMedical_checkup.Show ();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HolidaysForm frm = new HolidaysForm();
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Стоп";
                soundPlayer.Play();

            }
            else
            {
                checkBox1.Text = "Старт";
                soundPlayer.Stop();
            }
        }
    }
}
