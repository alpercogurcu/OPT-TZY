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

namespace DXOptimak.tasarim
{
    public partial class urunAgaciListeleForm : DevExpress.XtraEditors.XtraForm
    {
        public urunAgaciListeleForm()
        {
            InitializeComponent();

        }
        bool uretimUA;
        public urunAgaciListeleForm(Boolean uretimurunagaclari)
        {
            InitializeComponent();
            uretimUA = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);
        private void urunAgaciListeleForm_Load(object sender, EventArgs e)
        {
            SqlCommand mamulGetir;
            if (uretimUA)
            {
                mamulGetir = new SqlCommand("GET_UretimUrunAgaciListele", baglanti);
                mamulGetir.CommandType = CommandType.StoredProcedure;

                navBtnTasarimdanKopyala.Visible = true;
            }
            else
                mamulGetir = new SqlCommand("select id, parcaAdi from tasarim_urunagaci where mamul_id IS NULL", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(mamulGetir);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["parcaAdi"].Caption = "Mamül Adı";

            if(uretimUA)
            {
                gridView1.Columns["hatkodu"].Caption = "Hat Kodu";
                gridView1.Columns["uretim_kodu"].Caption = "Üretim Kodu";
                gridView1.Columns["hesap_adi"].Caption = "Müşteri";


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //    urunAgaciGosterForm frmUrunAgaciGoster;
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                int mamul_id = Convert.ToInt32(gridView1.GetRowCellValue(info.RowHandle, "id").ToString());
                SqlCommand cmdUrunAgaci = new SqlCommand("GET_UrunAgaci", baglanti);
                cmdUrunAgaci.Parameters.AddWithValue("@mamul_id", mamul_id);
                cmdUrunAgaci.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmdUrunAgaci);
                DataTable dt = new DataTable();
                da.Fill(dt);
                tasarim.urunAgaciGosterForm frmUrunAgaciGoster = new tasarim.urunAgaciGosterForm(dt);
                frmUrunAgaciGoster.MdiParent = this.MdiParent;
                frmUrunAgaciGoster.Text = gridView1.GetFocusedRowCellValue("parcaAdi").ToString() + " | Ürün Ağacı Görünümü";
                frmUrunAgaciGoster.Tag = gridView1.GetFocusedRowCellValue("parcaAdi").ToString();
                frmUrunAgaciGoster.Show();
            }
        }

        private void navBtnDosyaYukle_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            MessageBox.Show(gridView1.GetFocusedRowCellValue("parcaAdi").ToString());

            if (ClassDosyaIslemleri.tasarimPDFYukle(gridView1.GetFocusedRowCellValue("parcaAdi").ToString(), openFileDialog1.FileNames, openFileDialog1.SafeFileNames))
            {

                MessageBox.Show("PDF'ler başarıyla yüklendi.");
            }
            //   MessageBox.Show("Test");
        }

        private void navBtnTasarimdanKopyala_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            MessageBox.Show("Tasarımdan dosyaları kopyalarken, lütfen bekleyin.");

            if (ClassDosyaIslemleri.uretimDosyaKopyala(gridView1.GetFocusedRowCellValue("parcaAdi").ToString(), gridView1.GetFocusedRowCellValue("hesap_adi").ToString(), gridView1.GetFocusedRowCellValue("uretim_kodu").ToString(), gridView1.GetFocusedRowCellValue("hatkodu").ToString(), gridView1.GetFocusedRowCellValue("siparisDetay_id").ToString()))
            {

                MessageBox.Show("PDF'ler başarıyla yüklendi.");
            }
        }
    }
}