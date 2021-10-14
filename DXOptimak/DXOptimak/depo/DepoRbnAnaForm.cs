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
using DevExpress.XtraReports.Parameters;

namespace DXOptimak.depo
{
    public partial class DepoRbnAnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DepoRbnAnaForm()
        {
            InitializeComponent();
        }

        DepoProjeTalepListesi projeTalep;
        private void barBtnProjeTalepListesiGoster_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(projeTalep == null || projeTalep.IsDisposed )
            {
                projeTalep = new DepoProjeTalepListesi();
                projeTalep.MdiParent = this;
                projeTalep.Show();
            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[projeTalep];
                // MessageBox.Show(xtraTabbedMdiManager1.Pages[frmUretimKodlariListele].Text.ToString());
            }
        }

        private void barBtnIrsaliyeOlustur_ItemClick(object sender, ItemClickEventArgs e)
        {
            satinalma.Satinalma_IrsaliyeOlustur irsaliyeolustur = new satinalma.Satinalma_IrsaliyeOlustur();
            irsaliyeolustur.MdiParent = this;
            irsaliyeolustur.Text = "İrsaliye Oluştur";
            irsaliyeolustur.Show();

   
            
        }
    }
}