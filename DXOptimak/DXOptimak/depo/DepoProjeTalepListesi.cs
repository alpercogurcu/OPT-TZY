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

namespace DXOptimak.depo
{
    public partial class DepoProjeTalepListesi : DevExpress.XtraEditors.XtraForm
    {
        public DepoProjeTalepListesi()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);
        private void DepoProjeTalepListesi_Load(object sender, EventArgs e)
        {
            try
            {
           

                SqlCommand GET_ProjeTalepListesi = new SqlCommand("GET_ProjeTalepListesiHeader", baglanti);
                GET_ProjeTalepListesi.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(GET_ProjeTalepListesi);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;

                gridView1.OptionsBehavior.Editable = false;

                gridView1.Columns["id"].Visible = false;
                gridView1.Columns["id"].OptionsColumn.AllowEdit = false;

                gridView1.Columns["sip_DetayID"].Visible = false;
                gridView1.Columns["sip_DetayID"].OptionsColumn.AllowEdit = false;

                gridView1.Columns["parcaAdi"].Caption = "Tasarım Adı";
                gridView1.Columns["uretim_kodu"].Caption = "Üretim Kodu";
                gridView1.Columns["hesap_adi"].Caption = "Müşteri";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n"+ex.StackTrace);
            }
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
               
                string id = gridView1.GetRowCellValue(info.RowHandle, "id").ToString();
                string sip_DetayID = gridView1.GetRowCellValue(info.RowHandle, "sip_DetayID").ToString();
                DepoProjeTalepDetayListesi detayListe = new DepoProjeTalepDetayListesi(id,sip_DetayID);
          
                detayListe.MdiParent = this.MdiParent;
                detayListe.Text = gridView1.GetRowCellValue(info.RowHandle, "hesap_adi").ToString() + " " + gridView1.GetRowCellValue(info.RowHandle, "uretim_kodu").ToString();
                detayListe.Show();
             
            }
        }

        private void navbarDepoIslemBitir_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                string sip_DetayID = gridView1.GetFocusedRowCellValue("sip_DetayID").ToString();

                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                SqlCommand cmd_UpdateDurumTakipBilgileri = new SqlCommand("UPDATE proje_siparisDetay set durumTakipID=5", baglanti);
                cmd_UpdateDurumTakipBilgileri.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }

        }
    }
}