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
    public partial class xmlIslem : Form
    {
        public xmlIslem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();
            XmlElement root = xdoc.CreateElement("Reçeteler");

            SqlConnection baglanti = new SqlConnection("server=316-11\\SQLEXPRESS; uid=sa; pwd=I$kur2022#!;database=EczaneSistemi2Kasım");
            SqlCommand tedkom = new SqlCommand("select * from EczaneRecete", baglanti);
            baglanti.Open();
            SqlDataReader oku = tedkom.ExecuteReader();
            while (oku.Read())
            {
                XmlElement tedarikci = xdoc.CreateElement("EczaneRecete");
                XmlAttribute receteno = xdoc.CreateAttribute("ReceteNo");
                receteno.Value = oku["ReceteNo"].ToString();
                XmlAttribute hastano = xdoc.CreateAttribute("HastaNo");
                hastano.Value = oku["HastaNo"].ToString();
                XmlAttribute ilacno = xdoc.CreateAttribute("ilacNo");
                ilacno.Value = oku["ilacNo"].ToString();

                XmlAttribute tarih = xdoc.CreateAttribute("Tarih");
                tarih.Value = oku["Tarih"].ToString();

                tedarikci.Attributes.Append(receteno);
                tedarikci.Attributes.Append(hastano);
                tedarikci.Attributes.Append(ilacno);
                tedarikci.Attributes.Append(tarih);
                root.AppendChild(tedarikci);
            }
            baglanti.Close();
            xdoc.AppendChild(root); //tedarikçilerin altına ekliyor
            xdoc.Save("recete.xml");

            MessageBox.Show("Proje Klasörü içerisindeki Debug Klasöründe recete.xml dosyasına bakınız");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DepoXML frm = new DepoXML();
            frm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaEkranForm frm = new AnaEkranForm();
            frm.Show();
            this.Hide();
        }
    }
}
