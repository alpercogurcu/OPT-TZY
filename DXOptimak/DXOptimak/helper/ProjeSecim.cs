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

namespace DXOptimak.helper
{
    public partial class ProjeSecim : DevExpress.XtraEditors.XtraForm
    {
        public ProjeSecim()
        {
            InitializeComponent();
        }

        public string sip_DetayID { get; set; }
        public string uretimKodu { get; set; }
        public string hesapAdi { get; set; }


        SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);
        DataTable dt;
        private void ProjeSecim_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                SqlCommand cmdProjeTalepListesiHeader = new SqlCommand("GET_ProjeTalepListesiHeader", baglanti);
                cmdProjeTalepListesiHeader.CommandType = CommandType.StoredProcedure;

                dt = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(cmdProjeTalepListesiHeader);
                da.Fill(dt);

                gridControl1.DataSource = dt;
                gridView1.Columns["id"].Visible = false;
                gridView1.Columns["sip_DetayID"].Visible = false;

                gridView1.Columns["pyp_adi"].Caption = "PYP ADI";
                gridView1.Columns["parcaAdi"].Caption = "Tasarım Adı";
                gridView1.Columns["uretim_kodu"].Caption = "Üretim Kodu";
                gridView1.Columns["hesap_adi"].Caption = "Müşteri Adı";

                gridView1.Columns["pyp_adi"].VisibleIndex = 1;
                gridView1.Columns["parcaAdi"].VisibleIndex = 2;
                gridView1.Columns["uretim_kodu"].VisibleIndex = 0;
                gridView1.Columns["hesap_adi"].VisibleIndex = 3;
                gridView1.OptionsBehavior.Editable = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sip_DetayID = gridView1.GetFocusedRowCellValue("sip_DetayID").ToString();
            uretimKodu = gridView1.GetFocusedRowCellValue("uretim_kodu").ToString();
            hesapAdi = gridView1.GetFocusedRowCellValue("hesap_adi").ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                sip_DetayID = gridView1.GetRowCellValue(info.RowHandle, "sip_DetayID").ToString();
                uretimKodu = gridView1.GetRowCellValue(info.RowHandle, "uretim_kodu").ToString();
                hesapAdi = gridView1.GetRowCellValue(info.RowHandle, "hesap_adi").ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }
    }
}