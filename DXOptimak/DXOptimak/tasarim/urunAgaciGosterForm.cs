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
using DevExpress.XtraTreeList.Nodes;
namespace DXOptimak.tasarim
{
    public partial class urunAgaciGosterForm : DevExpress.XtraEditors.XtraForm
    {
        DataTable _dt;
        public urunAgaciGosterForm(DataTable dt)
        {
            InitializeComponent();
            _dt = dt;

            list.NodeCellStyle += list_NodeCellStyle;
        }


        public urunAgaciGosterForm(string id, bool durum)
        {
            InitializeComponent();
            

            list.NodeCellStyle += list_NodeCellStyle;
        }

        void list_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            e.Appearance.BackColor = renkAc(Color.Orange, e.Node.Level);
            e.Appearance.ForeColor = Color.Black;
        }



        Color renkAc(Color renk, int level)
        {
            for (int i = 0; i < level; i++)
            {
                renk = ControlPaint.Light(renk);
            }

            return renk;
        }


        SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);
        private void urunAgaciGosterForm_Load(object sender, EventArgs e)
        {
            
            try
            {




                if (baglanti.State != ConnectionState.Open)
                  //  baglanti.Open();

                list.KeyFieldName = "ID1";
                list.ParentFieldName = "ParentID1";
                list.OptionsBehavior.ReadOnly = true;
                list.DataSource = _dt;
                //   list.Columns["ID"].Visible = false;


                list.Columns["ParentID"].Visible = false;
                list.Columns["carpim"].Visible = false;

                if (_dt.Columns.Contains("id") || _dt.Columns.Contains("mamul_id"))
                {
                    list.Columns["id"].Visible = false;
                    list.Columns["mamul_id"].Visible = false;
                    list.Columns["kullaniciadi"].Visible = false;
                }

                if (_dt.Columns.Contains("stok_id"))
                {
                    list.Columns["stok_id"].Visible = false;
                }

                helper.ayar.SutunAdiMethodUrunAgaci(_dt, ref list, this);
              
                /*
                for (int i = 0; i < _dt.Columns.Count; i++)
                {
  
                    DataRow[] dr = helper.ayar.dtSutunAdlari.Select("sutunAdi = '" + _dt.Columns[i].ColumnName + "'");


                    if (dr.Length > 0)
                    {

                        if (!dr[0].IsNull("caption"))
                            list.Columns[_dt.Columns[i].ColumnName].Caption = dr[0]["caption"].ToString();
                    }

                    
                 
                } */

              





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Color baslangicrenk = colorDialog1.Color;

            colorDialog1.ShowDialog();
            Color bitisrenk = colorDialog1.Color;



        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color secilenrenk = colorDialog1.Color;
                list.BackColor = secilenrenk; 
               // Seçilen Renk kullanıcı adı ile veritabanına kaydedilecek.  
            }
          


            /*
            if (String.IsNullOrWhiteSpace(list.ActiveFilterString))
                return;

            MessageBox.Show(list.ActiveFilterString);

    */
        }

        private void list_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

       //    string parcaAdi = list.GetRowCellValue(list.FocusedNode, list.Columns["parcaAdi"]).ToString();
           
        }

        private void navBtnPDFGoster_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                ClassDosyaIslemleri.parcaAdiPdfAc(this.Tag.ToString(), list.GetRowCellValue(list.FocusedNode, list.Columns["parcaAdi"]).ToString() + ".pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +  "\n" + ex.StackTrace);
            }
        }

    }
}