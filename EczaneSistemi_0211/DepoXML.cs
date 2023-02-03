using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

using System.Data.SqlClient;

namespace EczaneSistemi_0211
{
    public partial class DepoXML : Form
    {
        public DepoXML()
        {
            InitializeComponent();
        }

        private void DepoXML_Load(object sender, EventArgs e)
        {

        }
        void Yukle()
        {
            XmlDocument i = new XmlDocument();
            //var olan bir dosya ile çalışacaksam nesne böyle üretilir.
            //<personel id="10"> attribute deniliyor

            DataSet ds = new DataSet();
            //xml dosyamızı okumak için bir reader oluşturuyoruz
            XmlReader xmlFile;
            xmlFile = XmlReader.Create(@"recetelerim.xml", new XmlReaderSettings());
            //içeriği datasete aktarıyoruz
            ds.ReadXml(xmlFile);
            //datagridview ın kaynağı olarak dataseti gösteriyoruz
            dataGridView1.DataSource = ds.Tables[0];
            xmlFile.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Yukle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"recetelerim.xml");
            x.Element("Eczane").Add(new XElement("Recete", new XElement("ReceteNo", textBox1.Text), new XElement("HastaNo", textBox2.Text),
                new XElement("ilacNo", textBox3.Text), new XElement("Tarih", textBox4.Text)));
            x.Save(@"recetelerim.xml");
            Yukle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"recetelerim.xml");
            //ürünıd=textboxa girilen numaralı ögeyi sil

            x.Root.Elements().Where(a => a.Element("ReceteNo").Value == textBox1.Text).Remove(); //=> lambada işareti? a değişken aslında
            x.Save(@"recetelerim.xml");
            Yukle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XDocument x = XDocument.Load(@"recetelerim.xml");
            XElement node = x.Element("Eczane").Elements("Recete").FirstOrDefault(a => a.Element
            ("ReceteNo").Value.Trim() == textBox1.Text);
            //trim boşluk hassasiyetini ortadan kaldırır. İlk bulduğu boşta çalışır 
            if (node != null)
            {
                node.SetElementValue("HastaNo", textBox2.Text);
                node.SetElementValue("ilacNo", textBox3.Text);
                node.SetElementValue("Tarih", textBox4.Text);
                x.Save(@"recetelerim.xml");
                Yukle();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            
            textBox1.Text = satir.Cells["ReceteNo"].Value.ToString();
            textBox2.Text = satir.Cells["HastaNo"].Value.ToString();
            textBox3.Text = satir.Cells["ilacNo"].Value.ToString();
            textBox4.Text = satir.Cells["Tarih"].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaEkranForm frm = new AnaEkranForm();
            frm.Show();
            this.Hide();
        }
    }
}
