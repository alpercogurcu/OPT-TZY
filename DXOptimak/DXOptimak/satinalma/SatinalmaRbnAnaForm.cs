using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace DXOptimak.satinalma
{
    public partial class SatinalmaRbnAnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public SatinalmaRbnAnaForm()
        {
            InitializeComponent();
        }
        Satinalma_MalzemeListesi frmMalzemeListesi;
        Satinalma_IrsaliyeOlustur frmIrsaliyeOlustur;
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMalzemeListesi = new Satinalma_MalzemeListesi();
            frmMalzemeListesi.MdiParent = this;
            frmMalzemeListesi.Show();
        }

        private void barBtnSatinalmaSiparisiOlustur_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmIrsaliyeOlustur == null || frmIrsaliyeOlustur.IsDisposed)
            {
                frmIrsaliyeOlustur = new Satinalma_IrsaliyeOlustur();
                frmIrsaliyeOlustur.MdiParent = this;
                frmIrsaliyeOlustur.Show();
            }
        }

        private void barBtnIrsaliyeListesi_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}