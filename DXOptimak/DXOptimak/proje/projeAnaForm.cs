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

namespace DXOptimak.proje
{
    public partial class projeAnaForm : DevExpress.XtraEditors.XtraForm
    {
        public projeAnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Üretim kodu oluştur
            projeUretimKoduOlustur ukOlustur = new projeUretimKoduOlustur("");
            ukOlustur.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Üretim kodu listele
            proje.projeUretimKodlariListele FRMuretimKodlari = new projeUretimKodlariListele();
            FRMuretimKodlari.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RibbonForm1 frm =  new RibbonForm1();
            frm.ShowDialog();
            //Elektrik Planı Oluştur    

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}