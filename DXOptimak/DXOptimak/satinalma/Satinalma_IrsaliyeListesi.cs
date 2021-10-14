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

namespace DXOptimak.satinalma
{
    public partial class Satinalma_IrsaliyeListesi : DevExpress.XtraEditors.XtraForm
    {
        public Satinalma_IrsaliyeListesi()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);
        private void Satinalma_IrsaliyeListesi_Load(object sender, EventArgs e)
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

            SqlCommand cmdIrsaliyeListesi = new SqlCommand("Select * from irsaliye_IrsaliyeBaslik", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(cmdIrsaliyeListesi);

            DataTable dt = new DataTable();
            da.Fill(dt);

            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;

            
        }
    }
}