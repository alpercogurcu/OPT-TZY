using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace DXOptimak.proje
{
    public partial class projeUretimKodlariListele : DevExpress.XtraEditors.XtraForm
    {
        public projeUretimKodlariListele()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);
        private void projeUretimKodlariListele_Load(object sender, EventArgs e)
        {

            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            SqlCommand cmdUretimKodlariGetir = new SqlCommand("select *, (select hesap_adi from hesapBilgileri where id = siparis.musteri_id) musteri_adi, (select adsoyad from kullaniciBilgileri where kullaniciadi = siparis.olusturan)olusturan_personel from proje_siparisBaslik as siparis", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(cmdUretimKodlariGetir);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["musteri_id"].Visible = false;
            gridView1.Columns["olusturan"].Visible = false;


            helper.ayar.SutunAdiMethod(dt, ref gridView1, this);
            /*

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                DataRow[] dr = helper.ayar.dtSutunAdlari.Select("sutunAdi = '" + dt.Columns[i].ColumnName + "'");

                if (dr.Length > 0)
                {

                    if (!dr[0].IsNull("caption"))
                        gridView1.Columns[dt.Columns[i].ColumnName].Caption = dr[0]["caption"].ToString();
                }                
            }        */
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

        }

        projeUretimKoduOlustur frmUretimKoduOlustur;
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                string id = gridView1.GetRowCellValue(info.RowHandle, "id").ToString();
                frmUretimKoduOlustur = new projeUretimKoduOlustur(id);
      
                frmUretimKoduOlustur.MdiParent = this.MdiParent;
                frmUretimKoduOlustur.Text = gridView1.GetRowCellValue(info.RowHandle, "musteri_adi").ToString() + " Sipariş Bilgileri";
                frmUretimKoduOlustur.Show();
        /*
                string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                MessageBox.Show(string.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption));*/
            }
        }
    }
}