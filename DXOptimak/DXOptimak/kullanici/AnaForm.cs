using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXOptimak.kullanici
{
    public partial class AnaForm : DevExpress.XtraEditors.XtraForm
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            satinalma.SatinalmaRbnAnaForm stnanaform = new satinalma.SatinalmaRbnAnaForm();
            stnanaform.MdiParent = this;
            stnanaform.Show();
        }

        private void btnIrsaliyeOlustur_Click(object sender, EventArgs e)
        {
           satinalma.Satinalma_IrsaliyeOlustur frmIrsaliyeOlustur = new satinalma.Satinalma_IrsaliyeOlustur();
            frmIrsaliyeOlustur.MdiParent = this;
            frmIrsaliyeOlustur.Show();
        }

        private void btnProjeSatinalmaTalepListesi_Click(object sender, EventArgs e)
        {
            satinalma.Satinalma_MalzemeListesi frmMalzemeListesi = new satinalma.Satinalma_MalzemeListesi();
            frmMalzemeListesi.MdiParent = this;
            frmMalzemeListesi.Show();
        }
    }
}
