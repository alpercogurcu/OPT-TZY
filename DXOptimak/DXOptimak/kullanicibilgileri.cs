
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DXOptimak
{
    class kullanicibilgileri
    {

        public static string kullaniciadi, adsoyad, birim, bolum, gorev, token;



        public static string connectionstring = SQLProcess.connectionstring;
        private static SqlConnection Bağlan()
        {
            SqlConnection baglanti = new SqlConnection(connectionstring);

            if (baglanti.State != ConnectionState.Open)
            {
                try
                {
                    baglanti.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            return baglanti;
        }


        //Token Check

        public static bool tokenCheck(string kullaniciadi, string token)
        {
            bool basarili = false;
            DataTable dt = new DataTable();
            SqlCommand tokenCmd = new SqlCommand("tokenCheck", Bağlan());
            tokenCmd.CommandType = CommandType.StoredProcedure;
            tokenCmd.Parameters.AddWithValue("@token", token);
            tokenCmd.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);

            SqlDataAdapter da = new SqlDataAdapter(tokenCmd);
            da.Fill(dt);

         
            if(dt.Rows[0]["tokenState"].ToString() == "1")
            {
             if(MessageBox.Show(dt.Rows[0]["adsoyad"].ToString() + " hesabı ile giriş yapmak ister misiniz?","Giriş Yap",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                  basarili = Login(dt.Rows[0]["kullaniciadi"].ToString(), dt.Rows[0]["parola"].ToString(), true);
                        
                }
            }
            

           return basarili;
        }

        // Kullanıcı İşlemleri

        public static bool Login(string _kullaniciadi, string parola, bool benihatirla)
        {
            bool basarili = false;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("kullaniciLogin", Bağlan());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@username", _kullaniciadi);
                da.SelectCommand.Parameters.AddWithValue("@password", parola);
                da.Fill(dt);

                if (benihatirla)
                {
                    Properties.Settings.Default["kullaniciadi"] = dt.Rows[0]["kullaniciadi"].ToString();
                    Properties.Settings.Default["token"] = dt.Rows[0]["token"].ToString();
                    Properties.Settings.Default.Save();

                }

                kullaniciadi = dt.Rows[0]["kullaniciadi"].ToString();
                adsoyad = dt.Rows[0]["adsoyad"].ToString();
                birim = dt.Rows[0]["birim"].ToString();
                bolum = dt.Rows[0]["bolum"].ToString();
                gorev = dt.Rows[0]["gorev"].ToString();
                token = dt.Rows[0]["token"].ToString();
                basarili = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


            return basarili;
        }
    }
}
