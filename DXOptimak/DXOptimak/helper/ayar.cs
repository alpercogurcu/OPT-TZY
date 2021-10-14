using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;

namespace DXOptimak.helper
{
    class ayar
    {

        public static DataTable dtSutunAdlari = new DataTable();

        public static DataTable dtSutunSiralamalari = new DataTable();

        private static SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);
        private static SqlDataAdapter da = new SqlDataAdapter();



        public static Task<Boolean> ayar_yukle()
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            bool durum;
            Task<Boolean> yukle = Task.Run<Boolean>(() =>
           {
               durum = sutunAdlariGetir().Result;
               return durum;
           });

            return yukle;
        }


 

        private static Task<Boolean> sutunAdlariGetir()
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            bool durum = false;
            Task<Boolean> islem = Task.Run<Boolean>(() =>
             {
                 try
                 {
                     SqlCommand cmdSutunAdlariGetir = new SqlCommand("Select * from AYAR_SutunBaslik", baglanti);
                     da.SelectCommand = cmdSutunAdlariGetir;

                     da.Fill(dtSutunAdlari);
                     durum = true;
                 }
                 catch (Exception ex)
                 {
                     durum = false;
                     MessageBox.Show(ex.Message);
                 }

                 return durum;
             });

            return islem;
        }



        public static Task<Boolean> sutunSiralamalarini_yukle()
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            bool durum = false;
            Task<Boolean> islem = Task.Run<Boolean>(() =>
            {
                try
                {
                    dtSutunSiralamalari.Clear();
                    SqlCommand cmdSutunAdlariGetir = new SqlCommand("Select * from AYAR_SutunSiralamasi where kullaniciadi = @kullaniciadi", baglanti);
                    cmdSutunAdlariGetir.Parameters.AddWithValue("@kullaniciadi", kullanicibilgileri.kullaniciadi);
                    da.SelectCommand = cmdSutunAdlariGetir;

                    da.Fill(dtSutunSiralamalari);
                    durum = true;
                 
                }
                catch (Exception ex)
                {
                    durum = false;
                    MessageBox.Show(ex.Message);
                }

                return durum;
            });

            return islem;
        }


        public static void SutunAdiMethod(DataTable dt, ref GridView grid, Form frm)
        {
            try
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {

                    DataRow[] dr = dtSutunAdlari.Select("sutunAdi = '" + dt.Columns[i].ColumnName + "'");
           //         DataRow[] dr2 = dtSutunSiralamalari.Select("sutunAdi = '" + dt.Columns[i].ColumnName + "' AND formadi ='" + frm.Name + "'");


                    if (dr.Length > 0)
                    {

                        if (!dr[0].IsNull("caption"))
                            grid.Columns[dt.Columns[i].ColumnName].Caption = dr[0]["caption"].ToString();
                    }

                  /*  if (dr2.Length > 0)
                    {
                        if (!dr2[0].IsNull("siralama"))
                            grid.Columns[dt.Columns[i].ColumnName].VisibleIndex = Convert.ToInt32(dr2[0]["siralama"].ToString());
                    }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public static void SutunAdiMethodUrunAgaci(DataTable dt, ref TreeList grid, Form frm)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {

                DataRow[] dr = dtSutunAdlari.Select("sutunAdi = '" + dt.Columns[i].ColumnName + "'");
                DataRow[] dr2 = dtSutunSiralamalari.Select("sutunAdi = '" + dt.Columns[i].ColumnName + "' AND formadi ='" + frm.Name + "'");


                if (dr.Length > 0)
                {

                    if (!dr[0].IsNull("caption"))
                        grid.Columns[dt.Columns[i].ColumnName].Caption = dr[0]["caption"].ToString();
                }

                if (dr2.Length > 0)
                {
                    if (!dr2[0].IsNull("siralama"))
                        grid.Columns[dt.Columns[i].ColumnName].VisibleIndex = Convert.ToInt32(dr2[0]["siralama"].ToString());
                }
            }
        }


        public static void SutunSiralamasiEkle(Form form, GridView grid)
        {
            try
            {

                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    SqlCommand cmdSutunEkle = new SqlCommand("INSERT_AyarSutunSiralamasi", baglanti);
                    cmdSutunEkle.CommandType = CommandType.StoredProcedure;
                    cmdSutunEkle.Parameters.AddWithValue("@kullaniciadi", kullanicibilgileri.kullaniciadi);
                    cmdSutunEkle.Parameters.AddWithValue("@formadi", form.Name);
                    cmdSutunEkle.Parameters.AddWithValue("@sutunadi", grid.Columns[i].FieldName);
                    cmdSutunEkle.Parameters.AddWithValue("@siralama", grid.Columns[i].VisibleIndex);
                    cmdSutunEkle.ExecuteNonQuery();
                    cmdSutunEkle.Dispose();

                }
              

               
                MessageBox.Show("Başarıyla kaydedildi.");
             
               
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " \n" + ex.StackTrace);
            }
        }



        #region #ShowResultForm
      public static  Form ShowResult(DataTable dt)
        {
            Form newForm = new Form();
            newForm.Width = 600;
            newForm.Height = 300;

            //     dt = Tabloyap(dt);




            DevExpress.XtraGrid.GridControl grid = new DevExpress.XtraGrid.GridControl();
            grid.Dock = DockStyle.Fill;
            grid.DataSource = dt;

            newForm.Controls.Add(grid);
            grid.ForceInitialize();
            ((DevExpress.XtraGrid.Views.Grid.GridView)grid.FocusedView).OptionsView.ShowGroupPanel = false;



            newForm.ShowDialog();
            return newForm;
        }
        #endregion #ShowResultForm


    }
}
