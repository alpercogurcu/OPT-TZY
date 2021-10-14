using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DXOptimak.tasarim
{
    class ClassUrunAgaci
    {


        public static Task<Boolean> urunAgaciYukle(DataTable dt)
        {
            SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);

            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            int mamul_id = -1;
            bool durum = false;
            Task<Boolean> basarili = Task.Run<Boolean>(() =>
            {//(@ogeno,@parcaAdi,@resimNo,@prosesGrubu,@grubuAdi,@altGrubuAdi,@parcaStokAdi,@malzeme,@uzunluk,@agirlik,@rota,@miktar,@seriNumarasi,@ParentID,@ID1,@ParentID1,@tip,@carpim,@kategori,@kullaniciadi)
                try
                {
                    bool mamulvarmi = false;
                    SqlCommand mamulkontrol = new SqlCommand("Select count(id) from tasarim_urunagaci where parcaAdi = @mamulParcaAdi", baglanti);
                    mamulkontrol.Parameters.AddWithValue("@mamulParcaAdi", dt.Rows[0]["Parça Adı"].ToString());
            
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



                    //  SqlCommand mamulekle = new SqlCommand("INSERT INTO tasarim_urunagaci (ogeno,parcaAdi,resimNo,prosesGrubu,grubuAdi,altGrubuAdi,parcaStokAdi,malzeme,uzunluk,agirlik,rota,miktar,seriNumarasi,gerekenMiktar,ParentID,ID1,ParentID1,tip,carpim,kategori,kullaniciadi) output INSERTED.id VALUES(@ogeno,@parcaAdi,@resimNo,@prosesGrubu,@grubuAdi,@altGrubuAdi,@parcaStokAdi,@malzeme,@uzunluk,@agirlik,@rota,@miktar,@seriNumarasi,@gerekenMiktar,@ParentID,@ID1,@ParentID1,@tip,@carpim,@kategori,@kullaniciadi) ", baglanti);

                    SqlCommand mamulekle = new SqlCommand("INSERT_TasarimUrunAgaci", baglanti);
                    mamulekle.CommandType = CommandType.StoredProcedure;
                    mamulekle.Parameters.AddWithValue("@eklemetipi", 0);
                    mamulekle.Parameters.AddWithValue("@ogeno", dt.Rows[0]["ÖĞE NO."].ToString());
                    mamulekle.Parameters.AddWithValue("@parcaAdi", dt.Rows[0]["Parça Adı"].ToString());
                    mamulekle.Parameters.AddWithValue("@resimNo", dt.Rows[0]["Resim No"].ToString());
                    mamulekle.Parameters.AddWithValue("@prosesGrubu", dt.Rows[0]["Proses Grubu"].ToString());
                    mamulekle.Parameters.AddWithValue("@grubuAdi", dt.Rows[0]["Grubu Adı"].ToString());
                    mamulekle.Parameters.AddWithValue("@altGrubuAdi", dt.Rows[0]["Alt Grubu Adı"].ToString());
                    mamulekle.Parameters.AddWithValue("@parcaStokAdi", dt.Rows[0]["Parça Stok Adı"].ToString());
                    mamulekle.Parameters.AddWithValue("@malzeme", dt.Rows[0]["Malzeme Cinsi"].ToString());
                    mamulekle.Parameters.AddWithValue("@uzunluk", dt.Rows[0]["Uzunluk"].ToString());
                    mamulekle.Parameters.AddWithValue("@agirlik", dt.Rows[0]["Ağırlık"].ToString());
                    mamulekle.Parameters.AddWithValue("@rota", dt.Rows[0]["Rota"].ToString());
                    mamulekle.Parameters.AddWithValue("@miktar", dt.Rows[0]["MİKT."].ToString());
                    mamulekle.Parameters.AddWithValue("@seriNumarasi", dt.Rows[0]["SeriNumarasi"].ToString());
                    mamulekle.Parameters.AddWithValue("@gerekenMiktar", dt.Rows[0]["GerekenMik"].ToString());
                    mamulekle.Parameters.AddWithValue("@ParentID", dt.Rows[0]["ParentID"].ToString());
                    mamulekle.Parameters.AddWithValue("@ID1", dt.Rows[0]["ID1"].ToString());
                    mamulekle.Parameters.AddWithValue("@ParentID1", dt.Rows[0]["ParentID1"].ToString());
                    mamulekle.Parameters.AddWithValue("@tip", dt.Rows[0]["Tip"].ToString());
                    mamulekle.Parameters.AddWithValue("@carpim", dt.Rows[0]["carpim"].ToString());
                    mamulekle.Parameters.AddWithValue("@kategori", dt.Rows[0]["Kategori"].ToString());
                    mamulekle.Parameters.AddWithValue("@kullaniciadi", kullanicibilgileri.kullaniciadi);

                    mamul_id = (int)mamulekle.ExecuteScalar();


                   


                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        //  SqlCommand kirimekle = new SqlCommand("INSERT INTO tasarim_urunagaci (mamul_id, ogeno,parcaAdi,resimNo,prosesGrubu,grubuAdi,altGrubuAdi,parcaStokAdi,malzeme,uzunluk,agirlik,rota,miktar,seriNumarasi,gerekenMiktar,ParentID,ID1,ParentID1,tip,carpim,kategori,kullaniciadi) VALUES(@mamulid, @ogeno,@parcaAdi,@resimNo,@prosesGrubu,@grubuAdi,@altGrubuAdi,@parcaStokAdi,@malzeme,@uzunluk,@agirlik,@rota,@miktar,@seriNumarasi,@gerekenMiktar,@ParentID,@ID1,@ParentID1,@tip,@carpim,@kategori,@kullaniciadi) ", baglanti);
                        SqlCommand kirimekle = new SqlCommand("INSERT_TasarimUrunAgaci", baglanti);
                        kirimekle.CommandType = CommandType.StoredProcedure;
                        kirimekle.Parameters.AddWithValue("@eklemetipi", 1);
                        kirimekle.Parameters.AddWithValue("@mamul_id", mamul_id);
                        kirimekle.Parameters.AddWithValue("@ogeno", dt.Rows[i]["ÖĞE NO."].ToString());
                        kirimekle.Parameters.AddWithValue("@parcaAdi", dt.Rows[i]["Parça Adı"].ToString());
                        kirimekle.Parameters.AddWithValue("@resimNo", dt.Rows[i]["Resim No"].ToString());
                        kirimekle.Parameters.AddWithValue("@prosesGrubu", dt.Rows[i]["Proses Grubu"].ToString());
                        kirimekle.Parameters.AddWithValue("@grubuAdi", dt.Rows[i]["Grubu Adı"].ToString());
                        kirimekle.Parameters.AddWithValue("@altGrubuAdi", dt.Rows[i]["Alt Grubu Adı"].ToString());
                        kirimekle.Parameters.AddWithValue("@parcaStokAdi", dt.Rows[i]["Parça Stok Adı"].ToString());
                        kirimekle.Parameters.AddWithValue("@malzeme", dt.Rows[i]["Malzeme Cinsi"].ToString());
                        kirimekle.Parameters.AddWithValue("@uzunluk", dt.Rows[i]["Uzunluk"].ToString());
                        kirimekle.Parameters.AddWithValue("@agirlik", dt.Rows[i]["Ağırlık"].ToString());
                        kirimekle.Parameters.AddWithValue("@rota", dt.Rows[i]["Rota"].ToString());
                        kirimekle.Parameters.AddWithValue("@miktar", dt.Rows[i]["MİKT."].ToString());
                        kirimekle.Parameters.AddWithValue("@seriNumarasi", dt.Rows[i]["SeriNumarasi"].ToString());
                        kirimekle.Parameters.AddWithValue("@gerekenMiktar", dt.Rows[i]["GerekenMik"].ToString());
                        kirimekle.Parameters.AddWithValue("@ParentID", dt.Rows[i]["ParentID"].ToString());
                        kirimekle.Parameters.AddWithValue("@ID1", dt.Rows[i]["ID1"].ToString());
                        kirimekle.Parameters.AddWithValue("@ParentID1", dt.Rows[i]["ParentID1"].ToString());
                        kirimekle.Parameters.AddWithValue("@tip", dt.Rows[i]["Tip"].ToString());
                        kirimekle.Parameters.AddWithValue("@carpim", dt.Rows[i]["carpim"].ToString());
                        kirimekle.Parameters.AddWithValue("@kategori", dt.Rows[i]["Kategori"].ToString());
                        kirimekle.Parameters.AddWithValue("@kullaniciadi", kullanicibilgileri.kullaniciadi);
                        if (kirimekle.ExecuteNonQuery() > 0)
                            durum = true;
                        else
                            durum = false;
                    }
                    durum = true;
                    baglanti.Close();
                    baglanti.Dispose();

                }
                catch (Exception ex)
                {
                    try
                    {
                        SqlCommand HepsiniSil = new SqlCommand("Delete from tasarim_urunAgaci where mamul_id=@mamul_id or id=@mamul_id", baglanti);
                        HepsiniSil.Parameters.AddWithValue("@mamul_id", mamul_id);
                        HepsiniSil.ExecuteNonQuery();

                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show("Eklenen veriler silinemedi. Yazılım Birimine ulaşın. \nHata Mesajı:" + ex2.Message.ToString() + "\n\nBu hata mesajının fotoğrafını çekip iletin.");
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