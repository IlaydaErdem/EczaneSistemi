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
    public class FRecete
    {
        public static int Ekleme(ERecete veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("ReceteEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if(komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("HastaNo", veri.HastaNo);
                komut.Parameters.AddWithValue("ilacNo", veri.ilacNo);
                komut.Parameters.AddWithValue("Tarih", veri.Tarih);
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
            SqlDataAdapter adp = new SqlDataAdapter("ReceteListele", Baglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static bool Guncelle(ERecete islem)
        {
            SqlCommand komut = new SqlCommand("ReceteYenile", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("ReceteNo", islem.ReceteNo);
            komut.Parameters.AddWithValue("HastaNo", islem.HastaNo);
            komut.Parameters.AddWithValue("ilacNo", islem.ilacNo);
            komut.Parameters.AddWithValue("Tarih", islem.Tarih);
            return DBaglanti.ExecuteNonQuery(komut);
        }
        public static bool Sil(ERecete islem)
        {
            SqlCommand komut = new SqlCommand("ReceteSil", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("ReceteNo", islem.ReceteNo);
            return DBaglanti.ExecuteNonQuery(komut);
        }
        public static DataTable Depol()
        {
            SqlDataAdapter adp = new SqlDataAdapter("getir", DBaglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static DataTable Ara(ERecete islem)
        {
            SqlCommand komut = new SqlCommand("ReceteAra", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("ReceteNo", islem.ReceteNo);
            DBaglanti.ExecuteNonQuery(komut);

            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }
    }
}
