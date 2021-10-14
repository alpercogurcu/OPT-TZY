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

namespace DXOptimak.satinalma
{
    public partial class Satinalma_Talepler : DevExpress.XtraEditors.XtraForm
    {
        public Satinalma_Talepler()
        {
            InitializeComponent();
        }

   

        private void txtDepolarArasi_Toggled(object sender, EventArgs e)
        {
            if(txtDepolarArasi.IsOn)
            {
                lblTedarik.Text = "Çıkış Depo"; 

            }
            else
            {
                lblTedarik.Text = "Tedarikçi";
            }
        }

        private void btnHeaderKaydet_Click(object sender, EventArgs e)
        {

        }

        private void Satinalma_Talepler_Load(object sender, EventArgs e)
        {
            TxtTedarik.Properties.DataSource = helper.GenelVeri.TedarikciListele();
            TxtTedarik.Properties.ValueMember = "id";
            TxtTedarik.Properties.KeyMember = "Hesap_adi";
            TxtTedarik.Properties.DisplayMember = "hesap_adi";
            TxtTedarik.Properties.PopulateViewColumns();
            txtTedarikView.Columns["id"].Visible = false;
            txtTedarikView.Columns["hesap_adi"].Caption = "Hesap Adı";
        }
    }
}