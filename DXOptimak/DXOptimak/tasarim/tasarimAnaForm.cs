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

namespace DXOptimak.tasarim
{
    public partial class tasarimAnaForm : DevExpress.XtraEditors.XtraForm
    {
        public tasarimAnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tasarim.urunAgaciEkleForm urunagaciekle = new urunAgaciEkleForm();
            urunagaciekle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tasarim.urunAgaciListeleForm urunagacilistele = new tasarim.urunAgaciListeleForm();
            urunagacilistele.ShowDialog();
        }
    }
}