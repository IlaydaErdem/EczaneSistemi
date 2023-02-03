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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void Liste()
        {
            dataGridView1.DataSource = Filac.Listele();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Eilac ekleme = new Eilac();
            ekleme.ilacAdi = textBox1.Text;
            ekleme.UreticiFirma = textBox2.Text;
            ekleme.Tarih = dateTimePicker1.Text;
            ekleme.Fiyat = Convert.ToInt32(textBox3.Text);
            ekleme.DepoNo = Convert.ToInt32(comboBox1.Text);
            Filac.Ekleme(ekleme);
            Liste();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eilac yenile = new Eilac();
            yenile.ilacNo = Convert.ToInt32(textBox1.Tag);
            yenile.ilacAdi = textBox1.Text;
            yenile.UreticiFirma = textBox2.Text;
            yenile.Tarih = dateTimePicker1.Text;
            yenile.Fiyat = Convert.ToInt32(textBox3.Text);
            yenile.DepoNo = Convert.ToInt32(comboBox1.Text);
            Filac.Guncelle(yenile);
            Liste();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Eilac sil = new Eilac();
            sil.DepoNo = Convert.ToInt32(textBox1.Tag);
            Filac.Sil(sil);
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["ilacNo"].Value.ToString();
            textBox1.Text = satir.Cells["ilacAdi"].Value.ToString();
            textBox2.Text = satir.Cells["UreticiFirma"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["Tarih"].Value.ToString();
            textBox3.Text = satir.Cells["Fiyat"].Value.ToString();
            comboBox1.Text = satir.Cells["DepoNo"].Value.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var Gorev1 = FDepo.Listele();
            comboBox1.DataSource = Gorev1;
            comboBox1.DisplayMember = "DepoNo";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Eilac ara = new Eilac();
            ara.ilacAdi = textBox4.Text;
            dataGridView1.DataSource = Filac.Rapor(ara);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaEkranForm frm = new AnaEkranForm();
            frm.Show();
            this.Hide();
        }
    }
}
