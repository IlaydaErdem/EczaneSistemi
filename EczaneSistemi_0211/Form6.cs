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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FRecete.Depol();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FSatis.Depol();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FHasta.Depol();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Filac.Depol();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ESatis satis = new ESatis();
            satis.SatisSorumlusu = Convert.ToString(textBox1.Text);
            dataGridView1.DataSource = FSatis.yapma(satis);

        }

        private void Form6_Load(object sender, EventArgs e)
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
