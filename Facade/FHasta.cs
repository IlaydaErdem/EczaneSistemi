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
    public class FHasta
    {
        public static int Ekleme(EHasta veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("HastaEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if(komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("AdSoyad", veri.AdSoyad);
                komut.Parameters.AddWithValue("HastaTC", veri.HastaTC);
                komut.Parameters.AddWithValue("Cinsiyet", veri.Cinsiyet);
                komut.Parameters.AddWithValue("DogumYeri", veri.DogumYeri);
                komut.Parameters.AddWithValue("DogumTarihi", veri.DogumTarihi);
                komut.Parameters.AddWithValue("Adres", veri.Adres);
                komut.Parameters.AddWithValue("Tel", veri.Tel);
                komut.Parameters.AddWithValue("Guvence", veri.Guvence);
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
            SqlDataAdapter adp = new SqlDataAdapter("HastaListele", Baglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static bool Guncelle(EHasta islem)
        {
            SqlCommand komut = new SqlCommand("HastaYenile", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("HastaNo", islem.HastaNo);
            komut.Parameters.AddWithValue("AdSoyad", islem.AdSoyad);
            komut.Parameters.AddWithValue("HastaTC", islem.HastaTC);
            komut.Parameters.AddWithValue("Cinsiyet", islem.Cinsiyet);
            komut.Parameters.AddWithValue("DogumYeri", islem.DogumYeri);
            komut.Parameters.AddWithValue("DogumTarihi", islem.DogumTarihi);
            komut.Parameters.AddWithValue("Adres", islem.Adres);
            komut.Parameters.AddWithValue("Tel", islem.Tel);
            komut.Parameters.AddWithValue("Guvence", islem.Guvence);
            return DBaglanti.ExecuteNonQuery(komut);
        }

        public static bool Sil(EHasta islem)
        {
            SqlCommand komut = new SqlCommand("HastaSil", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("HastaNo", islem.HastaNo);
            return DBaglanti.ExecuteNonQuery(komut);
        }

        public static DataTable Depol()
        {
            SqlDataAdapter adp = new SqlDataAdapter("ReceteHasta", DBaglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Rapor(EHasta islem)
        {
            SqlCommand komut = new SqlCommand("HastaAra", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("AdSoyad", islem.AdSoyad);
            DBaglanti.ExecuteNonQuery(komut);

            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

    }
}
