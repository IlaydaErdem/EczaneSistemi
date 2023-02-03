using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Facade;

namespace EczaneSistemi_0211
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Liste()
        {
            dataGridView1.DataSource = FHasta.Listele();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EHasta ekleme = new EHasta();
            ekleme.AdSoyad = textBox1.Text;
            ekleme.HastaTC = maskedTextBox1.Text;
            ekleme.Cinsiyet = textBox3.Text;
            ekleme.DogumYeri = textBox4.Text;
            ekleme.DogumTarihi = dateTimePicker1.Text;
            ekleme.Adres = textBox6.Text;
            ekleme.Tel = maskedTextBox2.Text;
            ekleme.Guvence = textBox7.Text;
            FHasta.Ekleme(ekleme);
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["HastaNo"].Value.ToString();
            textBox1.Text = satir.Cells["AdSoyad"].Value.ToString();
            maskedTextBox1.Text = satir.Cells["HastaTC"].Value.ToString();
            textBox3.Text = satir.Cells["Cinsiyet"].Value.ToString();
            textBox4.Text = satir.Cells["DogumYeri"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["DogumTarihi"].Value.ToString();
            textBox6.Text = satir.Cells["Adres"].Value.ToString();
            maskedTextBox2.Text = satir.Cells["Tel"].Value.ToString();
            textBox7.Text = satir.Cells["Guvence"].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EHasta yenile = new EHasta();
            yenile.HastaNo = Convert.ToInt32(textBox1.Tag);
            yenile.AdSoyad = textBox1.Text;
            yenile.HastaTC = maskedTextBox1.Text;
            yenile.Cinsiyet = textBox3.Text;
            yenile.DogumYeri = textBox4.Text;
            yenile.DogumTarihi = dateTimePicker1.Text;
            yenile.Adres = textBox6.Text;
            yenile.Tel = maskedTextBox2.Text;
            yenile.Guvence = textBox7.Text;
            FHasta.Guncelle(yenile);
            Liste();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EHasta sil = new EHasta();
            sil.HastaNo = Convert.ToInt32(textBox1.Tag);
            FHasta.Sil(sil);
            Liste();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EHasta ara = new EHasta();
            ara.AdSoyad = textBox2.Text;
            dataGridView1.DataSource = FHasta.Rapor(ara);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaEkranForm frm = new AnaEkranForm();
            frm.Show();
            this.Hide();
        }
    }
}
