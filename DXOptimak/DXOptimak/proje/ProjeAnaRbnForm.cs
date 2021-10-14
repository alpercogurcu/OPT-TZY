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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace DXOptimak.proje
{
    public partial class ProjeAnaRbnForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public ProjeAnaRbnForm()
        {
            InitializeComponent();
        }

        projeUretimKoduOlustur frmUretimKoduOlustur;
        projeUretimKodlariListele frmUretimKodlariListele;
        private void barBtnUretimKoduOlustur_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          if(frmUretimKoduOlustur == null || frmUretimKoduOlustur.IsDisposed)
            {
                frmUretimKoduOlustur = new projeUretimKoduOlustur("");
                frmUretimKoduOlustur.MdiParent = this;
                frmUretimKoduOlustur.Text = "Üretim Kodu Oluştur";
                frmUretimKoduOlustur.Show();
                
            }
        }
        
        private void ProjeAnaRbnForm_Load(object sender, EventArgs e)
        {
            if (frmUretimKodlariListele == null || frmUretimKodlariListele.IsDisposed)
            {
                frmUretimKodlariListele = new projeUretimKodlariListele();
                frmUretimKodlariListele.MdiParent = this;
                frmUretimKodlariListele.Text = "Üretim Kodlarını Listele";
                frmUretimKodlariListele.Show();

            }

        }

    
        private void barBtnUretimKodlariListele_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmUretimKodlariListele == null || frmUretimKodlariListele.IsDisposed)
            {
                frmUretimKodlariListele = new projeUretimKodlariListele();
                frmUretimKodlariListele.MdiParent = this;
                frmUretimKodlariListele.Show();

            }
            else
            {
                xtraTabbedMdiManager1.SelectedPage = xtraTabbedMdiManager1.Pages[frmUretimKodlariListele];
               // MessageBox.Show(xtraTabbedMdiManager1.Pages[frmUretimKodlariListele].Text.ToString());
            }
        }
      
    }
}