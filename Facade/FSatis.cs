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
    public class FSatis
    {
        public static int Ekleme(ESatis veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("SatisEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if (komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("HastaNo", veri.HastaNo);
                komut.Parameters.AddWithValue("ilacNo", veri.ilacNo);
                komut.Parameters.AddWithValue("Adet", veri.Adet);
                komut.Parameters.AddWithValue("Tarih", veri.Tarih);
                komut.Parameters.AddWithValue("Fiyat", veri.Fiyat);
                komut.Parameters.AddWithValue("SatisSorumlusu", veri.SatisSorumlusu);
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
            SqlDataAdapter adp = new SqlDataAdapter("SatisListele", Baglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static bool Guncelle(ESatis islem)
        {
            SqlCommand komut = new SqlCommand("SatisYenile", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("SatisNo", islem.SatisNo);
            komut.Parameters.AddWithValue("HastaNo", islem.HastaNo);
            komut.Parameters.AddWithValue("ilacNo", islem.ilacNo);
            komut.Parameters.AddWithValue("Adet", islem.Adet);
            komut.Parameters.AddWithValue("Tarih", islem.Tarih);
            komut.Parameters.AddWithValue("Fiyat", islem.Fiyat);
            komut.Parameters.AddWithValue("SatisSorumlusu", islem.SatisSorumlusu);
            return DBaglanti.ExecuteNonQuery(komut);
        }
        public static bool Sil(ESatis islem)
        {
            SqlCommand komut = new SqlCommand("SatisSil", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("SatisNo", islem.SatisNo);
            return DBaglanti.ExecuteNonQuery(komut);
        }

        public static DataTable Ara(ESatis islem)
        {
            SqlCommand komut = new SqlCommand("SatisAra", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("SatisNo", islem.SatisNo);
            DBaglanti.ExecuteNonQuery(komut);

            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }
        public static DataTable Depol()
        {
            SqlDataAdapter adp = new SqlDataAdapter("TarihKontrol", DBaglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static DataTable yapma(ESatis islem)
        {
            SqlCommand komut = new SqlCommand("EncokSatisYapanKim", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("SatisSorumlusu", islem.SatisSorumlusu);
            DBaglanti.ExecuteNonQuery(komut);

            SqlDataAdapter adp = new SqlDataAdapter(komut);
            komut.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable rapor(ESatis islem)
        {
            SqlCommand komut = new SqlCommand("Giris", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("SatisSorumlusu", islem.SatisSorumlusu);
            DBaglanti.ExecuteNonQuery(komut);

            SqlDataAdapter adp = new SqlDataAdapter(komut);
            komut.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
    }
}
