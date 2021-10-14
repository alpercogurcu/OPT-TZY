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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace DXOptimak.satinalma
{
    public partial class Satinalma_MalzemeListesi : DevExpress.XtraEditors.XtraForm
    {
        public Satinalma_MalzemeListesi()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);
        DataTable dt;

        private void Satinalma_MalzemeListesi_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            helper.ProjeSecim projesec = new helper.ProjeSecim();

       


            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            SqlCommand cmdMalzemeListesi;

            if (projesec.ShowDialog() == DialogResult.OK)
            {
                this.Text = projesec.uretimKodu + " -- " + projesec.hesapAdi;
                cmdMalzemeListesi = new SqlCommand("GET_SatinalmaMalzemeListesi", baglanti);
                cmdMalzemeListesi.Parameters.AddWithValue("@sip_DetayID", projesec.sip_DetayID);
            }
            else
            {
                this.Text = "Genel Malzeme Listesi";
                cmdMalzemeListesi = new SqlCommand("GET_SatinalmaMalzemeListesiAll", baglanti);
            }
            cmdMalzemeListesi.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmdMalzemeListesi);
            da.Fill(dt);

            gridControl1.DataSource = dt;
            gridView1.Columns["parcaAdi"].Caption = "Parça Adı";
            gridView1.OptionsBehavior.Editable = false;
            helper.ayar.SutunAdiMethod(dt, ref gridView1, this);


        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;


            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                //      MessageBox.Show(gridView1.GetFocusedValue().ToString() + " " + gridView1.FocusedColumn.FieldName.ToString());

                //   gridView1.GetSelectedCells()
                sutunagoresec.Caption = "Bütün " + gridView1.GetFocusedValue().ToString() + " değerlerini seç";
                popupMenu1.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
            }
            else
            {
                popupMenu1.HidePopup();
            }

            /*
            var rowH = gridView1.FocusedRowHandle;
            var focusRowView = (DataRowView)gridView1.GetFocusedRow();

            if (focusRowView == null || focusRowView.IsNew)
                return;

            if (rowH > 0)
                popupMenu1.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
            else
                popupMenu1.HidePopup(); */
        }
        GridColumnSummaryItem sumItem;

        private void sutunagoresec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //    MessageBox.Show(gridView1.GetFocusedValue().ToString() + " " + gridView1.FocusedColumn.FieldName.ToString());
            string deger = gridView1.GetFocusedValue().ToString();
            string sutun = gridView1.FocusedColumn.FieldName.ToString();



            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, sutun).ToString() == deger)
                {
                    gridView1.SelectRow(i);
                }

            }


        }

        private async void tabloAyarlarınıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ayar.SutunSiralamasiEkle(this, gridView1);
            await helper.ayar.sutunSiralamalarini_yukle();
        }






        private void popupSecilenleriAktar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {



            Satinalma_IrsaliyeOlustur irsaliyeForm = (Satinalma_IrsaliyeOlustur)Application.OpenForms["Satinalma_IrsaliyeOlustur"];
 
            if(irsaliyeForm == null)
            {

                MessageBox.Show("İrsaliye Formunuz Kapalı!");
            }
            else
            {
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    int rowHandle = gridView1.GetSelectedRows()[i];


                    irsaliyeForm.gridView1.AddNewRow();

                    irsaliyeForm.gridView1.SetFocusedRowCellValue("stok_id", gridView1.GetRowCellValue(rowHandle, "stok_id").ToString());
                    irsaliyeForm.gridView1.SetFocusedRowCellValue("miktar", gridView1.GetRowCellValue(rowHandle, "ihtiyacMiktari").ToString());
                    irsaliyeForm.gridView1.SetFocusedRowCellValue("uzunluk", gridView1.GetRowCellValue(rowHandle, "uzunluk").ToString());
                    irsaliyeForm.gridView1.SetFocusedRowCellValue("birim", "ADET");
                    irsaliyeForm.gridView1.SetFocusedRowCellValue("sip_DetayID", gridView1.GetRowCellValue(rowHandle, "sip_DetayID").ToString());

                    irsaliyeForm.gridView1.UpdateCurrentRow();

                    gridView1.GetRow(rowHandle);


                    //     irsaliyeForm.gridView1.SetFocusedRowCellValue()
                    //        MessageBox.Show(gridView1.GetSelectedRows()[i].ToString());

                }
               
            }


        }
    }
}