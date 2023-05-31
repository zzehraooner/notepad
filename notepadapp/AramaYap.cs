using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepadapp
{
    public partial class AramaYap : Form
    {
        public AramaYap()
        {
            InitializeComponent();
        }
        public string bul;
        public int Buyuk_Kucuk_Esle = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            bul = textBox1.Text;
            if (checkBox1.CheckState == CheckState.Checked)
                Buyuk_Kucuk_Esle = 1;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
