using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES_Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        AES_Class aesSifreleCoz = new AES_Class();

        private void Metni_Coz_Button_Click(object sender, EventArgs e)
        {

            if (rtbSifreliMetin.Text == string.Empty)
            {
                MessageBox.Show("Boş Metnin Neresini Şifrelicem ?");
            }
            else
            {
                rtbSifreCiktisi.Text = aesSifreleCoz.AesSifresiniCoz(rtbSifreliMetin.Text);
            }
            
        }

        private void Metni_Sifrele_Click(object sender, EventArgs e)
        {
            rtbSifreliMetin.Text = aesSifreleCoz.AesSifrele(inputTextBox.Text);
            rtbSifreCiktisi.Text = "";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
