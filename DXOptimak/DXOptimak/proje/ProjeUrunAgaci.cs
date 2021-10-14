using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DXOptimak.proje
{
    class ProjeUrunAgaci
    {
        static SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);


        static public void durumDegistir(int durumId, string siparisDetayID)
        {
            SqlConnection baglanti2 = new SqlConnection(SQLProcess.connectionstring);

              

            SqlCommand durumdegistir = new SqlCommand("SET_ProjeSiparisDetayDurumTakipID", baglanti2);
            durumdegistir.CommandType = CommandType.StoredProcedure;
            durumdegistir.Parameters.AddWithValue("@durumTakipID", durumId);
            durumdegistir.Parameters.AddWithValue("siparis_DetayID", siparisDetayID);

            if (baglanti2.State != ConnectionState.Open)
                baglanti2.Open();

            durumdegistir.ExecuteNonQuery();
            baglanti2.Close();
        }

        public static Task<Boolean> urunAgaciAktar(DataTable dt, string siparis_DetayID, string musteri_ID)
        {
          //  SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);



            int mamul_id = -1;
            bool durum = false;
            Task<Boolean> basarili = Task.Run<Boolean>(() =>

            {//(@ogeno,@parcaAdi,@resimNo,@prosesGrubu,@grubuAdi,@altGrubuAdi,@parcaStokAdi,@malzeme,@uzunluk,@agirlik,@rota,@miktar,@seriNumarasi,@ParentID,@ID1,@ParentID1,@tip,@carpim,@kategori,@kullaniciadi)
                try
                {

                    // MAMÜL KONTROL ( Tamamlanmadı / Test Edilmedi )
                    /*    bool mamulvarmi = false;
                        SqlCommand mamulkontrol = new SqlCommand("Select count(id) from uretim_UrunAgaci where tasarim_id = @tasarim_id and sip_DetayID = @sip_DetayID and musteri_ID=@musteri_ID", baglanti);
                        mamulkontrol.Parameters.AddWithValue("@tasarim_id", tasarim_ID);
                        mamulkontrol.Parameters.AddWithValue("@sip_DetayID", siparis_ID);
                        mamulkontrol.Parameters.AddWithValue("@musteri_ID", musteri_ID);


                        int mCount = (int)mamulkontrol.ExecuteScalar();
                        if (mCount > 0 )
                        {
                            mamulvarmi = true;
                            if(MessageBox.Show("Bu mamül ürün ağacına zaten eklenmiş, görmek ister misiniz?", "Ürün Ağacı Görüntüle", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                SqlCommand mamulGetir = new SqlCommand("GET_UrunAgaci", baglanti);
                                mamulGetir.Parameters.AddWithValue("@mamul_adi", dt.Rows[0]["Parça Adı"].ToString());
                                mamulGetir.CommandType = CommandType.StoredProcedure;

                                DataTable mamuldt = new DataTable();
                                SqlDataAdapter da = new SqlDataAdapter(mamulGetir);
                                da.Fill(mamuldt);

                                urunAgaciGosterForm urunagaciF = new urunAgaciGosterForm(mamuldt);
                                urunagaciF.ShowDialog();

                            }
                        }

                        if (mamulvarmi)
                            return false;

        */
                    if (baglanti.State != ConnectionState.Open)
                        baglanti.Open();

                    SqlCommand mamulekle = new SqlCommand("INSERT INTO uretim_urunagaci (tasarim_id,ogeno, parcaAdi,resimNo,prosesGrubu,grubuAdi,altGrubuAdi,parcaStokAdi,malzeme,uzunluk,agirlik,rota,miktar,seriNumarasi,gerekenMiktar,ParentID,ID1,ParentID1,tip,carpim,kategori,kullaniciadi,sip_DetayID) output INSERTED.id VALUES (@tasarim_id, @ogeno,@parcaAdi,@resimNo,@prosesGrubu,@grubuAdi,@altGrubuAdi,@parcaStokAdi,@malzeme,@uzunluk,@agirlik,@rota,@miktar,@seriNumarasi,@gerekenMiktar,@ParentID,@ID1,@ParentID1,@tip,@carpim,@kategori,@kullaniciadi, @sip_DetayID) ", baglanti);

                    mamulekle.Parameters.AddWithValue("@tasarim_id", dt.Rows[0]["id"].ToString()); // Tasarım MAMÜL ID.
                    mamulekle.Parameters.AddWithValue("@ogeno", dt.Rows[0]["ogeno"].ToString());
                    mamulekle.Parameters.AddWithValue("@parcaAdi", dt.Rows[0]["parcaAdi"].ToString());
                    mamulekle.Parameters.AddWithValue("@resimNo", dt.Rows[0]["resimNo"].ToString());
                    mamulekle.Parameters.AddWithValue("@prosesGrubu", dt.Rows[0]["prosesGrubu"].ToString());
                    mamulekle.Parameters.AddWithValue("@grubuAdi", dt.Rows[0]["grubuAdi"].ToString());
                    mamulekle.Parameters.AddWithValue("@altGrubuAdi", dt.Rows[0]["altGrubuAdi"].ToString());
                    mamulekle.Parameters.AddWithValue("@parcaStokAdi", dt.Rows[0]["parcaStokAdi"].ToString());
                    mamulekle.Parameters.AddWithValue("@malzeme", dt.Rows[0]["malzeme"].ToString());
                    mamulekle.Parameters.AddWithValue("@uzunluk", dt.Rows[0]["uzunluk"].ToString());
                    mamulekle.Parameters.AddWithValue("@agirlik", dt.Rows[0]["agirlik"].ToString());
                    mamulekle.Parameters.AddWithValue("@rota", dt.Rows[0]["Rota"].ToString());
                    mamulekle.Parameters.AddWithValue("@miktar", dt.Rows[0]["miktar"].ToString());
                    mamulekle.Parameters.AddWithValue("@seriNumarasi", dt.Rows[0]["seriNumarasi"].ToString());
                    mamulekle.Parameters.AddWithValue("@gerekenMiktar", dt.Rows[0]["gerekenMiktar"].ToString());
                    mamulekle.Parameters.AddWithValue("@ParentID", dt.Rows[0]["ParentID"].ToString());
                    mamulekle.Parameters.AddWithValue("@ID1", dt.Rows[0]["ID1"].ToString());
                    mamulekle.Parameters.AddWithValue("@ParentID1", dt.Rows[0]["ParentID1"].ToString());
                    mamulekle.Parameters.AddWithValue("@tip", dt.Rows[0]["Tip"].ToString());
                    mamulekle.Parameters.AddWithValue("@carpim", dt.Rows[0]["carpim"].ToString());
                    mamulekle.Parameters.AddWithValue("@kategori", dt.Rows[0]["Kategori"].ToString());
                    mamulekle.Parameters.AddWithValue("@kullaniciadi", kullanicibilgileri.kullaniciadi);
                    mamulekle.Parameters.AddWithValue("@sip_DetayID",siparis_DetayID);
                 //   mamulekle.Parameters.AddWithValue("@musteri_ID", musteri_ID);


                    mamul_id = (int)mamulekle.ExecuteScalar();




                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        SqlCommand kirimekle = new SqlCommand("INSERT INTO uretim_urunagaci (tasarim_id, mamul_id, ogeno,parcaAdi,resimNo,prosesGrubu,grubuAdi,altGrubuAdi,parcaStokAdi,malzeme,uzunluk,agirlik,rota,miktar,seriNumarasi,gerekenMiktar,ParentID,ID1,ParentID1,tip,carpim,kategori,kullaniciadi,sip_DetayID ) VALUES (@tasarim_id, @mamul_id, @ogeno,@parcaAdi,@resimNo,@prosesGrubu,@grubuAdi,@altGrubuAdi,@parcaStokAdi,@malzeme,@uzunluk,@agirlik,@rota,@miktar,@seriNumarasi,@gerekenMiktar,@ParentID,@ID1,@ParentID1,@tip,@carpim,@kategori,@kullaniciadi,@sip_DetayID) ", baglanti);
                        kirimekle.Parameters.AddWithValue("@tasarim_id", dt.Rows[i]["id"].ToString()); // Tasarım MAMÜL ID.
                        kirimekle.Parameters.AddWithValue("@mamul_id", mamul_id);
                        kirimekle.Parameters.AddWithValue("@ogeno", dt.Rows[i]["ogeno"].ToString());
                        kirimekle.Parameters.AddWithValue("@parcaAdi", dt.Rows[i]["parcaAdi"].ToString());
                        kirimekle.Parameters.AddWithValue("@resimNo", dt.Rows[i]["resimNo"].ToString());
                        kirimekle.Parameters.AddWithValue("@prosesGrubu", dt.Rows[i]["prosesGrubu"].ToString());
                        kirimekle.Parameters.AddWithValue("@grubuAdi", dt.Rows[i]["grubuAdi"].ToString());
                        kirimekle.Parameters.AddWithValue("@altGrubuAdi", dt.Rows[i]["altGrubuAdi"].ToString());
                        kirimekle.Parameters.AddWithValue("@parcaStokAdi", dt.Rows[i]["parcaStokAdi"].ToString());
                        kirimekle.Parameters.AddWithValue("@malzeme", dt.Rows[i]["malzeme"].ToString());
                        kirimekle.Parameters.AddWithValue("@uzunluk", dt.Rows[i]["uzunluk"].ToString());
                        kirimekle.Parameters.AddWithValue("@agirlik", dt.Rows[i]["agirlik"].ToString());
                        kirimekle.Parameters.AddWithValue("@rota", dt.Rows[i]["Rota"].ToString());
                        kirimekle.Parameters.AddWithValue("@miktar", dt.Rows[i]["miktar"].ToString());
                        kirimekle.Parameters.AddWithValue("@seriNumarasi", dt.Rows[i]["seriNumarasi"].ToString());
                        kirimekle.Parameters.AddWithValue("@gerekenMiktar", dt.Rows[i]["gerekenMiktar"].ToString());
                        kirimekle.Parameters.AddWithValue("@ParentID", dt.Rows[i]["ParentID"].ToString());
                        kirimekle.Parameters.AddWithValue("@ID1", dt.Rows[i]["ID1"].ToString());
                        kirimekle.Parameters.AddWithValue("@ParentID1", dt.Rows[i]["ParentID1"].ToString());
                        kirimekle.Parameters.AddWithValue("@tip", dt.Rows[i]["Tip"].ToString());
                        kirimekle.Parameters.AddWithValue("@carpim", dt.Rows[i]["carpim"].ToString());
                        kirimekle.Parameters.AddWithValue("@kategori", dt.Rows[i]["Kategori"].ToString());
                        kirimekle.Parameters.AddWithValue("@kullaniciadi", kullanicibilgileri.kullaniciadi);
                        kirimekle.Parameters.AddWithValue("@sip_DetayID", siparis_DetayID);
                    //    kirimekle.Parameters.AddWithValue("@musteri_ID", musteri_ID);
                        if (kirimekle.ExecuteNonQuery() > 0)
                            durum = true;
                        else
                            durum = false;
                    }
                    durum = true;

                    // Durum Update
                    /*
                     1	Sipariş Oluşturuldu	Sipariş Oluşturulduğu an aldığı durumdur
                     2	Ürün Ağacı Bekleniyor	Tasarıma iş emri oluşturulduğu an aldığı durumdur
                     3	Fason Satınalma	Fason satınalma emri oluşturulduğu an aldığı durumdur
                     4	Depo Talep - Bekleme	Satınalma iş emri oluşturulduğunda, depo talebi beklediği an
                     5	Satınalma / Tedarik Süreci	Satınalma / tedarik sürecine girdiği an ( depo işlemi tamamladığı an )
                     NULL	NULL	NULL
                     */
                    durumDegistir(4, siparis_DetayID);

                    baglanti.Close();
                    baglanti.Dispose();

                }
                catch (Exception ex)
                {
                    try
                    {
                        SqlCommand HepsiniSil = new SqlCommand("Delete from uretim_urunAgaci where mamul_id=@mamul_id or id= @mamul_id", baglanti);
                        HepsiniSil.Parameters.AddWithValue("@mamul_id", mamul_id);
                        HepsiniSil.ExecuteNonQuery();

                    }
                    catch(Exception ex2)
                    {
                        MessageBox.Show("Eklenen veriler silinemedi. Yazılım Birimine ulaşın. \nHata Mesajı:" +ex2.Message.ToString()+"\n\nBu hata mesajının fotoğrafını çekip iletin.");
                    }


                    baglanti.Close();
                    baglanti.Dispose();
                    durum = false;
                    MessageBox.Show(ex.Message.ToString());
                }
                return durum;
            });

            return basarili;
        }
    }
}
 