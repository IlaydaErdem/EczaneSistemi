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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void Liste()
        {
            dataGridView1.DataSource = FSatis.Listele();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ESatis ekleme = new ESatis();
            ekleme.HastaNo = Convert.ToInt32(comboBox1.Text);
            ekleme.ilacNo = Convert.ToInt32(comboBox2.Text);
            ekleme.Adet = Convert.ToInt32(textBox3.Text);
            ekleme.Tarih = dateTimePicker1.Text;
            
            ekleme.Fiyat = Convert.ToInt32(textBox4.Text);
            ekleme.SatisSorumlusu = textBox5.Text;
            FSatis.Ekleme(ekleme);
            Liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ESatis yenile = new ESatis();
            yenile.SatisNo = Convert.ToInt32(comboBox1.Tag);
            yenile.HastaNo = Convert.ToInt32(comboBox1.Text);
            yenile.ilacNo = Convert.ToInt32(comboBox2.Text);
            yenile.Adet = Convert.ToInt32(textBox3.Text);
            yenile.Tarih = dateTimePicker1.Text;
            yenile.Fiyat = Convert.ToInt32(textBox4.Text);
            yenile.SatisSorumlusu = textBox5.Text;
            FSatis.Guncelle(yenile);
            Liste();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ESatis sil = new ESatis();
            sil.SatisNo = Convert.ToInt32(comboBox1.Tag);
            FSatis.Sil(sil);
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Tag = satir.Cells["SatisNo"].Value.ToString();
            comboBox1.Text = satir.Cells["HastaNo"].Value.ToString();
            comboBox2.Text = satir.Cells["ilacNo"].Value.ToString();
            textBox3.Text = satir.Cells["Adet"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["Tarih"].Value.ToString();
            textBox4.Text = satir.Cells["Fiyat"].Value.ToString();
            textBox5.Text = satir.Cells["SatisSorumlusu"].Value.ToString();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            var Gorev1 = FHasta.Listele();
            comboBox1.DataSource = Gorev1;
            comboBox1.DisplayMember = "HastaNo";

            var Gorev2 = Filac.Listele();
            comboBox2.DataSource = Gorev2;
            comboBox2.DisplayMember = "ilacNo";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ESatis ara = new ESatis();
            ara.SatisNo = Convert.ToInt32(textBox7.Text);
           dataGridView1.DataSource=FSatis.Ara(ara);
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaEkranForm frm = new AnaEkranForm();
            frm.Show();
            this.Hide();
        }
    }
}
