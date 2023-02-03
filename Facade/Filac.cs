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
    public class Filac
    {
        public static int Ekleme(Eilac veri)
        {
            int islem = 0;
            try
            {
                SqlCommand komut = new SqlCommand("ilacEkle", Baglanti.con);
                komut.CommandType = CommandType.StoredProcedure;
                if(komut.Connection.State != ConnectionState.Open)
                {
                    komut.Connection.Open();
                }
                komut.Parameters.AddWithValue("ilacAdi", veri.ilacAdi ).Value.ToString();
                komut.Parameters.AddWithValue("UreticiFirma", veri.UreticiFirma).Value.ToString();
                komut.Parameters.AddWithValue("Tarih", veri.Tarih).Value.ToString();
                komut.Parameters.AddWithValue("Fiyat", veri.Fiyat).Value.ToString();
                komut.Parameters.AddWithValue("DepoNo", veri.DepoNo).Value.ToString();
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
            SqlDataAdapter adp = new SqlDataAdapter("ilacListele", Baglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static bool Guncelle(Eilac islem)
        {
            SqlCommand komut = new SqlCommand("ilacYenile", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("ilacNo", islem.ilacNo);
            komut.Parameters.AddWithValue("ilacAdi", islem.ilacAdi);
            komut.Parameters.AddWithValue("UreticiFirma", islem.UreticiFirma);
            komut.Parameters.AddWithValue("Tarih", islem.Tarih);
            komut.Parameters.AddWithValue("Fiyat", islem.Fiyat);
            komut.Parameters.AddWithValue("DepoNo", islem.DepoNo);
            return DBaglanti.ExecuteNonQuery(komut);
        }

        public static bool Sil(Eilac islem)
        {
            SqlCommand komut = new SqlCommand("ilacSil", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("ilacNo", islem.ilacNo);
            return DBaglanti.ExecuteNonQuery(komut);
        }

        public static DataTable Depol()
        {
            SqlDataAdapter adp = new SqlDataAdapter("ilacFiyatSiralama", DBaglanti.con);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static DataTable Rapor(Eilac islem)
        {
            SqlCommand komut = new SqlCommand("ilacAra", DBaglanti.con);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("ilacAdi", islem.ilacAdi);
            DBaglanti.ExecuteNonQuery(komut);

            SqlDataAdapter adp = new SqlDataAdapter(komut);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
    }
}
