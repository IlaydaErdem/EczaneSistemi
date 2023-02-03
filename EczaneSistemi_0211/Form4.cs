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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void Liste()
        {
            dataGridView1.DataSource = FRecete.Listele();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ERecete ekleme = new ERecete();
            ekleme.HastaNo = Convert.ToInt32(comboBox1.Text);
            ekleme.ilacNo = Convert.ToInt32(comboBox2.Text);
            ekleme.Tarih = dateTimePicker1.Text;
            FRecete.Ekleme(ekleme);
            Liste();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ERecete yenile = new ERecete();
            yenile.ReceteNo = Convert.ToInt32(comboBox1.Tag);
            yenile.HastaNo = Convert.ToInt32(comboBox1.Text);
            yenile.ilacNo = Convert.ToInt32(comboBox2.Text);
            yenile.Tarih = dateTimePicker1.Text;
        
            FRecete.Guncelle(yenile);
            Liste();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ERecete sil = new ERecete();
            sil.ReceteNo = Convert.ToInt32(comboBox1.Tag);
            FRecete.Sil(sil);
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Tag = satir.Cells["ReceteNo"].Value.ToString();
            comboBox1.Text = satir.Cells["HastaNo"].Value.ToString();
            comboBox2.Text = satir.Cells["ilacNo"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["Tarih"].Value.ToString();
         
        }

        private void Form4_Load(object sender, EventArgs e)
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
            ERecete ara = new ERecete();
            ara.ReceteNo = Convert.ToInt32(textBox2.Text);
            dataGridView1.DataSource = FRecete.Ara(ara);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaEkranForm frm = new AnaEkranForm();
            frm.Show();
            this.Hide();
        }
    }
}
