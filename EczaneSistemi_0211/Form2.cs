using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facade;
using Entity;

namespace EczaneSistemi_0211
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Liste()
        {
            dataGridView1.DataSource = FDepo.Listele();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EDepo ekleme = new EDepo();
            ekleme.Depoil = textBox1.Text;
            ekleme.Depoilce = textBox2.Text;
            ekleme.DepoTel = maskedTextBox1.Text;
            FDepo.Ekleme(ekleme);
            Liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EDepo yenile = new EDepo();
            yenile.DepoNo = Convert.ToInt32(textBox1.Tag);
            yenile.Depoil = textBox1.Text;
            yenile.Depoilce = textBox2.Text;
            yenile.DepoTel = maskedTextBox1.Text;
            FDepo.Guncelle(yenile);
            Liste();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EDepo sil = new EDepo();
            sil.DepoNo = Convert.ToInt32(textBox1.Tag);
            FDepo.Sil(sil);
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["DepoNo"].Value.ToString();
            textBox1.Text = satir.Cells["Depoil"].Value.ToString();
            textBox2.Text = satir.Cells["Depoilce"].Value.ToString();
            maskedTextBox1.Text = satir.Cells["DepoTel"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EDepo ara = new EDepo();
            ara.Depoil = textBox3.Text;
            dataGridView1.DataSource = FDepo.Rapor(ara);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaEkranForm frm = new AnaEkranForm();
            frm.Show();
            this.Hide();
        }
    }
}
