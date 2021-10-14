using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DXOptimak.helper
{
    class GenelVeri
    {
        static private SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);

        public static DataTable IrsaiyeKodlariListele()
        {

            DataTable dt = new DataTable();

            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            SqlCommand cmdTedarikListele = new SqlCommand("Select * from irsaliye_KodBilgileri where goster!=0", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(cmdTedarikListele);

            da.Fill(dt);

            baglanti.Close();
            return dt;
        }

        public static DataTable StokKartlariListele()
        {
            DataTable dt = new DataTable();

            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            SqlCommand cmdTedarikListele = new SqlCommand("Select * from stok_stokKartlari", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(cmdTedarikListele);

            da.Fill(dt);

            baglanti.Close();
            return dt;
        }


        public static DataTable TedarikciListele()
        {
          
            DataTable dt = new DataTable();

            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            SqlCommand cmdTedarikListele = new SqlCommand("Select id, hesap_adi from HesapBilgileri", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(cmdTedarikListele);

            da.Fill(dt);

            baglanti.Close();
            return dt;
        }

        public static DataTable DepoListele()
        {
            DataTable dt = new DataTable();

            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            SqlCommand cmdTedarikListele = new SqlCommand("select * from Depo_DepoBilgileri", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(cmdTedarikListele);

            da.Fill(dt);

            baglanti.Close();
            return dt;
        }

        public static DataTable KullaniciListele()
        {
            DataTable dt = new DataTable();

            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            SqlCommand cmdTedarikListele = new SqlCommand("select * from kullaniciBilgileri", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(cmdTedarikListele);

            da.Fill(dt);

            baglanti.Close();
            return dt;
        }



    }
}
