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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid;

namespace DXOptimak.depo
{
    public partial class DepoProjeTalepDetayListesi : DevExpress.XtraEditors.XtraForm
    {
        string mamul_id, sip_DetayID;
        public DepoProjeTalepDetayListesi(string _mamul_id, string _sip_DetayID)
        {
            InitializeComponent();
            mamul_id = _mamul_id;
            sip_DetayID = _sip_DetayID;
        }

        SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);

        private void repositoryItemTextEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            string gerekenMiktar = gridView1.GetFocusedRowCellValue("gerekenMiktar").ToString();

            try
            {


                if (Convert.ToDouble(e.NewValue.ToString()) <= Convert.ToDouble(gerekenMiktar) && Convert.ToDouble(e.NewValue.ToString()) != 0)
                {
                    gridView1.SetFocusedRowCellValue("kalanMiktar", Convert.ToDouble(gerekenMiktar) - Convert.ToDouble(e.NewValue.ToString()));

                }
                else
                {
                    gridView1.SetFocusedRowCellValue("kalanMiktar", null);

                }
            }
            catch
            {

            }
        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (gridControl1.FocusedView as ColumnView).FocusedRowHandle++;
                e.Handled = true;
            }
        }

        private void navbarSatinalma_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DataTable dt = satinalma.IrsaliyeClass.dtIrsaliyeDetayBosTablo();





          
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    if(!String.IsNullOrWhiteSpace(gridView1.GetRowCellValue(i, "mevcutMiktar").ToString()))
                {
                    if (Convert.ToDouble(gridView1.GetRowCellValue(i, "mevcutMiktar").ToString()) > 0)
                    {
                        MessageBox.Show(gridView1.GetRowCellValue(i, "mevcutMiktar").ToString() + " - " + gridView1.GetRowCellValue(i, "parcaStokAdi").ToString());
                        DataRow dr = dt.NewRow();


                        dr["stok_id"] = gridView1.GetRowCellValue(i, "stok_id");
                        //dr["kategori"] = gridView1.GetRowCellValue(i, "kategori");
                        //dr["parcaAdi"] = gridView1.GetRowCellValue(i, "parcaAdi");
                        //dr["parcaStokAdi"] = gridView1.GetRowCellValue(i, "parcaStokAdi");
                        //dr["malzeme"] = gridView1.GetRowCellValue(i, "malzeme");
                        //dr["uzunluk"] = gridView1.GetRowCellValue(i, "uzunluk");
                        //dr["prosesGrubu"] = gridView1.GetRowCellValue(i, "prosesGrubu");
                        //dr["grubuAdi"] = gridView1.GetRowCellValue(i, "grubuAdi");
                        //dr["altGrubuAdi"] = gridView1.GetRowCellValue(i, "altGrubuAdi");
                        //dr["seriNumarasi"] = gridView1.GetRowCellValue(i, "seriNumarasi");
                        //dr["tip"] = gridView1.GetRowCellValue(i, "tip");
                        dr["miktar"] = gridView1.GetRowCellValue(i, "mevcutMiktar");
                        dr["sip_DetayID"] = gridView1.GetRowCellValue(i, "sip_DetayID");
                        dr["mamul_id"] = gridView1.GetRowCellValue(i, "mamul_id");
                        dt.Rows.Add(dr);

                    }
                }
                 
                }

 
            satinalma.Satinalma_IrsaliyeOlustur irsaliye = new satinalma.Satinalma_IrsaliyeOlustur(dt, true);
           irsaliye.ShowDialog();
            irsaliye.Dispose();


            dt.Clear();
            dt.Dispose();

        }

        private void DepoProjeTalepDetayListesi_Load(object sender, EventArgs e)
        {
            SqlCommand GET_SatinalmaMalzemeListesi = new SqlCommand("GET_SatinalmaMalzemeListesi", baglanti);
            GET_SatinalmaMalzemeListesi.Parameters.AddWithValue("@Mamul_ID", mamul_id);
            GET_SatinalmaMalzemeListesi.Parameters.AddWithValue("@sip_DetayID", sip_DetayID);
            GET_SatinalmaMalzemeListesi.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(GET_SatinalmaMalzemeListesi);
            da.Fill(dt);
            dt.Columns.Add("mevcutMiktar");
         //   dt.Columns.Add("kalanMiktar");

            gridControl1.DataSource = dt;

            gridView1.Columns["stok_id"].Visible = false;
            gridView1.Columns["sip_DetayID"].Visible = false;
            gridView1.Columns["mamul_id"].Visible = false;
            gridView1.Columns["kirimAdet"].Visible = false;
            gridView1.Columns["MusteriID"].Visible = false;
            gridView1.Columns["MusteriAdi"].Visible = false;

            gridView1.Columns["kategori"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["stok_id"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["parcaAdi"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["parcaStokAdi"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["malzeme"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["uzunluk"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["prosesGrubu"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["grubuAdi"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["altGrubuAdi"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["seriNumarasi"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["sip_DetayID"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["tip"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["mamul_id"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["gerekenMiktar"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["kirimAdet"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["MusteriID"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["projeyeAtananMiktar"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["ihtiyacMiktari"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["projeyeAtananMiktar"].OptionsColumn.AllowEdit = false;


            gridView1.Columns["kategori"].Caption = "Kategori";
            gridView1.Columns["stok_id"].Caption = "Stok No";
            gridView1.Columns["parcaAdi"].Caption = "Parça Adı";
            gridView1.Columns["parcaStokAdi"].Caption = "Parça Stok Adı";
            gridView1.Columns["malzeme"].Caption = "Malzeme";
            gridView1.Columns["uzunluk"].Caption = "Uzunluk";
            gridView1.Columns["prosesGrubu"].Caption = "Proses Grubu";
            gridView1.Columns["grubuAdi"].Caption = "Grubu adı";
            gridView1.Columns["altGrubuAdi"].Caption = "Alt Grubu Adı";
            gridView1.Columns["seriNumarasi"].Caption = "Seri Numarası";
            gridView1.Columns["sip_DetayID"].Caption = "Sipariş Detay Numarası";
            gridView1.Columns["tip"].Caption = "Tip";
            gridView1.Columns["mamul_id"].Caption = "Mamul Numarası";
            gridView1.Columns["gerekenMiktar"].Caption = "Gereken Miktar";
            gridView1.Columns["kirimAdet"].Caption = "Kırım Adedi";
            gridView1.Columns["MusteriID"].Caption = "Müşteri Numarası";
            gridView1.Columns["ihtiyacMiktari"].Caption = "İhtiyaç Miktarı";
            gridView1.Columns["projeyeAtananMiktar"].Caption = "Projeye Atanan Miktar";


            gridView1.Columns["mevcutMiktar"].Caption = "Mevcut Miktar";
            gridView1.Columns["mevcutMiktar"].ColumnEdit = repositoryItemTextEdit1;



            GridColumnSummaryItem item1 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "gerekenMiktar", "Toplam={0}");
            gridView1.Columns["gerekenMiktar"].Summary.Add(item1);

            /*GridColumn colMevcutMiktar = new GridColumn();
            colMevcutMiktar.FieldName = "kalanMiktar";
            colMevcutMiktar.Caption = "Kalan S. Miktarı";
            colMevcutMiktar.Visible = true;
            gridView1.Columns.Add(colMevcutMiktar);
         //   gridView1.Columns["kalanMiktar"].OptionsColumn.AllowEdit = false;
            //gridView1.Columns["mevcutMiktar"].ColumnEdit = repositoryItemTextEdit1;

    */


        }
    }
}