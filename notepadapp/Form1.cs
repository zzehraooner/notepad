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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using Org.BouncyCastle.Asn1.Cms;

namespace notepadapp
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NotGetir();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çıkToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yAZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fnt = new FontDialog();
            if(fnt.ShowDialog() == DialogResult.OK)
                richTextBox1.Font= fnt.Font;

        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into tbnot (not, date) values (@not, @datee)";
            komut = new SqlCommand(sorgu, conn);
            komut.Parameters.AddWithValue("@not", textBox2.Text);
            komut.Parameters.AddWithValue("@datee", textBox3.Text);
            connOpen();
            komut.ExecuteNonQuery();
            conn.Close();
            NotGetir();
        }

        void NotGetir()
        {
            conn = new SqlConnection(“Data Source = localhost; Initial Catalog = notepadd; Integrated Security = True”);
            conn.Open();
            da = new SqlDataAdapter("Select *From tbnot", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            dataGridView1.DataSource = tb;
            conn.Close();
        }
        private void kaydetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tarihSaatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = System.DateTime.Now.ToString();

        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void yazıRengiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog fnt = new ColorDialog();
            if (fnt.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = fnt.Color;
        }

        private void temizleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yenidenYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AramaTemizle();
            AramaYap fr = new AramaYap();
            fr.ShowDialog();
            string kelime = fr.bul;

         
            Regex reg;
            if (fr.Buyuk_Kucuk_Esle == 1)
                reg = new Regex(kelime);
            else
                reg = new Regex(kelime, RegexOptions.IgnoreCase);

            int sayac = 0;
            foreach (Match find in reg.Matches(richTextBox1.Text))
            {
                richTextBox1.Select(find.Index, find.Length);
                richTextBox1.SelectionBackColor = Color.Thistle; 
                sayac++;
            }
            if (sayac == 0)
            {
                MessageBox.Show("Metin içerisinde ( " + kelime + " ) bulunamadı.");
            }
            else
            {
                MessageBox.Show("Metin içerisinde ( " + kelime + " )  " + sayac + " adet bulundu.");
            }
        }
        public string bul;
        public int Buyuk_Kucuk_Esle = 0;
        void AramaTemizle()
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = Color.White;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_MarginChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
    }

