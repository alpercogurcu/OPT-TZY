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

namespace DXOptimak.tasarim
{
    public partial class TasarimAnaRbnForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public TasarimAnaRbnForm()
        {
            InitializeComponent();
        }
        urunAgaciEkleForm frmUrunAgaciEkle;
        urunAgaciListeleForm frmUrunAgaciListele;
        urunAgaciListeleForm frmUretimUrunAgaciListele;
        private void barBtnUrunAgaciYukle_ItemClick(object sender, ItemClickEventArgs e)
        {
         
                frmUrunAgaciEkle = new urunAgaciEkleForm();
                //  frmUrunAgaciEkle.MdiParent = this;
                //frmUrunAgaciEkle.Text = "Ürün Ağacı Yükle";
                frmUrunAgaciEkle.ShowDialog();
            
        }

        private void barBtnUrunAgaciListele_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmUrunAgaciListele == null || frmUrunAgaciListele.IsDisposed)
            {
                frmUrunAgaciListele = new urunAgaciListeleForm();
                frmUrunAgaciListele.MdiParent = this;
                frmUrunAgaciListele.Text = "Ürün Ağaçlarını Listele";
                frmUrunAgaciListele.Show();

            }

        }

        private void TasarimAnaRbnForm_Load(object sender, EventArgs e)
        {
            if (frmUrunAgaciListele == null || frmUrunAgaciListele.IsDisposed)
            {
                frmUrunAgaciListele = new urunAgaciListeleForm();
                frmUrunAgaciListele.MdiParent = this;
                frmUrunAgaciListele.Text = "Ürün Ağaçlarını Listele";
                frmUrunAgaciListele.Show();

            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (frmUretimUrunAgaciListele == null || frmUretimUrunAgaciListele.IsDisposed)
            {
                frmUretimUrunAgaciListele = new urunAgaciListeleForm(true);
                frmUretimUrunAgaciListele.MdiParent = this;
                frmUretimUrunAgaciListele.Text = "Ürün Ağaçlarını Listele";
                frmUretimUrunAgaciListele.Show();

            }
        }
    }
}