using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Facade
{
    public class FDepo
    {
        public static int Ekleme(EDepo veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("DepoEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("Depoil", veri.Depoil);
                komut.Parameters.AddWithValue("Depoilce", veri.Depoilce);
                komut.Parameters.AddWithValue("DepoTel", veri.DepoTel);
                komut.ExecuteNonQuery();

            }
            catch
            {
                islem = -1;
            }
            return islem;

        }

        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("DepoListele", Baglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static bool Guncelle(EDepo islem)
        {
            SqlCommand komut = new SqlCommand("DepoYenile", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("DepoNo", islem.DepoNo);
            komut.Parameters.AddWithValue("Depoil", islem.Depoil);
            komut.Parameters.AddWithValue("Depoilce", islem.Depoilce);
            komut.Parameters.AddWithValue("DepoTel", islem.DepoTel);
            return DBaglanti.ExecuteNonQuery(komut);
        }

        public static bool Sil(EDepo islem)
        {
            SqlCommand komut = new SqlCommand("DepoSil", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("DepoNo", islem.DepoNo);
            return DBaglanti.ExecuteNonQuery(komut);
        }

        public static DataTable Rapor(EDepo islem)
        {
            SqlCommand komut = new SqlCommand("DepoAra", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("Depoil", islem.Depoil);
            DBaglanti.ExecuteNonQuery(komut);

            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
    }
}
