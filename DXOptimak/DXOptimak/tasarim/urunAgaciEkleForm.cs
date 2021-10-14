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
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.XtraTreeList;

namespace DXOptimak.tasarim
{
    public partial class urunAgaciEkleForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public urunAgaciEkleForm()
        {
            InitializeComponent();

        }

        private void spreadsheetControl1_Click(object sender, EventArgs e)
        {

        }

        DataTable urunagaci;

        private void barButtonItemRangeToDataTable_ItemClick(object sender, ItemClickEventArgs e)
        {

            Worksheet worksheet = spreadsheetControl1.Document.Worksheets.ActiveWorksheet;
            CellRange range = worksheet.GetUsedRange();

            for (int col = 0; col < range.ColumnCount; col++)
            {
                if (range[0, col].Value.ToString().IndexOf('\n').ToString() != "-1")
                {
                    range[0, col].SetValueFromText(range[0, col].Value.ToString().Replace("\n", ""));
                }
            }

            DataTable dataTable = worksheet.CreateDataTable(range, true);


            for (int col = 0; col < range.ColumnCount; col++)
            {
                CellValueType cellType = range[0, col].Value.Type;
                for (int r = 1; r < range.RowCount; r++)
                {
                    if (cellType != range[r, col].Value.Type)
                    {
                        dataTable.Columns[col].DataType = typeof(string);
                        break;
                    }
                }
            }
            DataTableExporter exporter = worksheet.CreateDataTableExporter(range, dataTable, true);
            exporter.CellValueConversionError += exporter_CellValueConversionError;
            exporter.Export();


            DataTable gelenDT = new DataTable();

            gelenDT = Tabloyap(dataTable);

            urunAgaciGosterForm urunagacigosterform = new urunAgaciGosterForm(dataTable);
            urunagaci = gelenDT;
            urunagacigosterform.ShowDialog();

             //       ShowResult(dataTable);
            //    ShowTreeList(dataTable);

            barButtonItem2.Enabled = true;
            
        }

        Boolean RotaAra(Array rota_arr, string arananmetin)
        {

            if (Array.IndexOf(rota_arr, arananmetin) > 0)
                return true;
            else
                return false;
        }


        DataTable Tabloyap(DataTable dt)
        {
           
            dt.Columns.Add("ID"); // ÖĞE NO.
            dt.Columns.Add("ParentID"); // ÖĞE NO'SUNUN SON NOKTASINDAN ÖNCEKİLERİ 
            dt.Columns.Add("ID1"); // FOR DÖNGÜMDEKİ İ.
            dt.Columns.Add("ParentID1"); // FOR DÖNGÜSÜNDE, ÜZERİNDE BAĞLI OLDUĞU İD1.
            dt.Columns.Add("GerekenMik", typeof(Double)); // MİKTAR * ÜST GEREKEN MİKTAR.
            dt.Columns.Add("Tip"); // MAMÜL - YARIMAMÜL - HAMMADDE
            dt.Columns.Add("carpim"); // ÇARPIM? --> ÇARPILACAK VEYA ÇARPILMAYACAK.
            dt.Columns.Add("Kategori"); // LAZER / KAYNAK / VS. SATIN ALMACILARIN GÖREBİLECEĞİ, FİLTRELİ ALAN. 
                                        // Tip: Mamul, Yarı Mamül, Hammadde

          
            // ID ve hesaplama.
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string strparcaAdi = dt.Rows[i]["Parça Adı"].ToString();

                if (String.IsNullOrWhiteSpace(strparcaAdi))
                {
                    MessageBox.Show("Parça Adı Boş Olamaz!" + "\nSatır: " + (i + 1).ToString());

                }


                string grubuadi = dt.Rows[i]["Grubu Adı"].ToString(); 
                string prosesgrubu = dt.Rows[i]["Proses Grubu"].ToString();
                string altgrubuadi = dt.Rows[i]["Alt Grubu Adı"].ToString();
                string tip = dt.Rows[i]["Tip"].ToString();
                string rota = dt.Rows[i]["Rota"].ToString();
                string id = dt.Rows[i][0].ToString(); // ÖĞE NO
                dt.Rows[i]["ID1"] = i; // ID1 : İ ATANIYOR.
                dt.Rows[i]["ID"] = id; // dt.Rows[i][0].ToString(); öğe no

                string[] rota_arr = rota.Split('-'); // rotayı bölüyorum. 


               

                string parentid;
                if (id.LastIndexOf('.') > 0) // id değişkeninde nokta varsa, en son noktanın kaçıncı sırada olduğunu alıyorum. (0'dan başlıyoruz saymaya)
                    parentid = id.Remove(id.LastIndexOf('.'), ((id.Length) - id.LastIndexOf('.'))); // parentid değişkenime, id remove(başlangıç değeri, uzunluk) ( başlangıç değeri : .'mın olduğu sıra) (uzunluk: id'min karakter sayısını alıyorum, en son noktaya .'ya kadar siliyorum. bu da bana PARENT ID'yi vermiş oluyor.) 
                else
                {
                    dt.Rows[i]["GerekenMik"] = dt.Rows[i][11];
                    parentid = "0";
                }

         

                dt.Rows[i]["ParentID"] = parentid;
                DataRow[] filtrelisatir = dt.Select("ID = '" + parentid + "'");
                dt.Rows[i]["ParentID1"] = filtrelisatir[0]["ID1"];


                if (dt.Rows[i]["carpim"].ToString() != "Hayır")
                {
                    if (dt.Rows[i]["ParentID1"].ToString() != dt.Rows[i]["ID1"].ToString())
                    {
                       
                        
                        dt.Rows[i]["GerekenMik"] = Convert.ToDouble(filtrelisatir[0][17].ToString()) * Convert.ToDouble(dt.Rows[i][11].ToString());
                    }
                }

                if (grubuadi != "Alt Montaj" && grubuadi != "Kaynak" && altgrubuadi != "Civata Montaj" && prosesgrubu == "İMALAT" && grubuadi != "MONTAJ" && tip != "Hammadde")
                {
                    //      MessageBox.Show("row ekliyo." + dt.Rows[i][0].ToString() + ".1");
                    DataRow row = dt.NewRow();
                    row["ÖĞE NO."] = dt.Rows[i][0].ToString() + ".1";
                    row["Parça Adı"] = dt.Rows[i]["Parça Stok Adı"].ToString();
                    row["Proses Grubu"] = prosesgrubu;
                    row["Grubu Adı"] = grubuadi;
                    row["Alt Grubu Adı"] = altgrubuadi;
                    row["Parça Stok Adı"] = dt.Rows[i]["Parça Stok Adı"].ToString();
                    row["Malzeme Cinsi"] = dt.Rows[i]["Malzeme Cinsi"].ToString();
                    row["Uzunluk"] = dt.Rows[i]["Uzunluk"].ToString();
                    row["Ağırlık"] = dt.Rows[i]["Ağırlık"].ToString();
                    // row["Rota"] = dt.Rows[i]["Rota"].ToString();
                    row["Rota"] = String.Empty;
                    row["MİKT."] = dt.Rows[i]["MİKT."].ToString();
                    row["SeriNumarasi"] = String.Empty;
                    row["Tip"] = "Hammadde";
                    row["GerekenMik"] = dt.Rows[i]["GerekenMik"].ToString();
                    row["carpim"] = "Hayır";
                    dt.Rows.InsertAt(row, i + 1);
                    dt.Rows[i]["Tip"] = "Yarı Mamül";

                    //MessageBox.Show("Grubu adı: " + grubuadi + "\nParça Adı: " + dt.Rows[i]["Parça Adı"].ToString() + "\nParça Stok Adı: " + dt.Rows[i]["Parça Stok Adı"].ToString());

                }
                else if (prosesgrubu == "OEM" && rota == "1-16")
                {
                    dt.Rows[i]["Tip"] = "Hammadde";
                }
                else if (prosesgrubu == "OEM" && rota != "1-16" && tip != "Hammadde")
                {
                    DataRow row = dt.NewRow();
                    row["ÖĞE NO."] = dt.Rows[i][0].ToString() + ".1";
                    row["Parça Adı"] = dt.Rows[i]["Parça Stok Adı"].ToString();
                    row["Proses Grubu"] = prosesgrubu;
                    row["Grubu Adı"] = grubuadi;
                    row["Alt Grubu Adı"] = altgrubuadi;
                    row["Parça Stok Adı"] = dt.Rows[i]["Parça Stok Adı"].ToString();
                    row["Malzeme Cinsi"] = dt.Rows[i]["Malzeme Cinsi"].ToString();
                    row["Uzunluk"] = dt.Rows[i]["Uzunluk"].ToString();
                    row["Ağırlık"] = dt.Rows[i]["Ağırlık"].ToString();
                    // row["Rota"] = dt.Rows[i]["Rota"].ToString();
                    row["Rota"] = String.Empty;
                    row["MİKT."] = dt.Rows[i]["MİKT."].ToString();
                    row["SeriNumarasi"] = String.Empty;
                    row["Tip"] = "Hammadde";
                    row["carpim"] = "Hayır";
                    dt.Rows[i]["Tip"] = "Yarı Mamül";
                    dt.Rows.InsertAt(row, i + 1);



                }
                else if (id == parentid)
                {
                    dt.Rows[i]["Tip"] = "Mamül";
                }


                // Tip yukarıda bir işlem daha görüyor.
                tip = dt.Rows[i]["Tip"].ToString();
                // Kategori Tanımları

                if (RotaAra(rota_arr, "2"))
                {
                    dt.Rows[i]["Kategori"] = "LAZER";
                }

                if ((RotaAra(rota_arr, "4") || RotaAra(rota_arr, "7") || RotaAra(rota_arr, "8") || RotaAra(rota_arr, "18")) && RotaAra(rota_arr, "9"))
                {
                    dt.Rows[i]["Kategori"] = "T-K-MEKANİK";
                }
                else if (RotaAra(rota_arr, "4") || RotaAra(rota_arr, "7") || RotaAra(rota_arr, "8") || RotaAra(rota_arr, "18") && (RotaAra(rota_arr, "9") == false))
                {
                    dt.Rows[i]["Kategori"] = "T-MEKANİK";
                }

                if (grubuadi == "Kaynak")
                {
                    dt.Rows[i]["Kategori"] = "KAYNAK";
                }

                if (grubuadi == "Pnömatik")
                {
                    dt.Rows[i]["Kategori"] = "PNÖMATİK";
                }

                if (grubuadi == "Redüktör/Motor")
                {
                    dt.Rows[i]["Kategori"] = "MOTOR";
                }


                if (grubuadi == "Hırdavat")
                {
                    dt.Rows[i]["Kategori"] = "HIRDAVAT";
                }

                if (grubuadi == "Alt Montaj")
                {
                    dt.Rows[i]["Kategori"] = "ALT MONTAJ";
                }


                if (altgrubuadi == "Rulman")
                {
                    dt.Rows[i]["Kategori"] = "RULMAN";
                }

                if (altgrubuadi == "Klavuz")
                {
                    dt.Rows[i]["Kategori"] = "MEKANİK";
                }

                if(grubuadi == "Taşıma - Bant")
                {
                    dt.Rows[i]["Kategori"] = "MEKANİK";
                }

      
                if (prosesgrubu == "OEM" && tip == "Hammadde" && String.IsNullOrEmpty(dt.Rows[i]["Kategori"].ToString()))
                {
                    dt.Rows[i]["Kategori"] = "MEKANİK";
                }




            }


            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (dt.Rows[j]["ID1"].ToString() == dt.Rows[j]["ParentID1"].ToString())
                {
                    dt.Rows[j]["Tip"] = "Mamül";
                    dt.Rows[j]["Kategori"] = "Montaj";

                }
                else if (dt.Select("ParentID1= '" + dt.Rows[j]["ID1"].ToString() + "'").Length > 0)
                {
                    dt.Rows[j]["Tip"] = "Yarı Mamül";
                }

            }

            dt.Columns.Remove("ID");
         //   dt.Columns.Remove("ParentID");
          

            return dt;

        }



    
        
     

        #region #ShowResultForm
        Form ShowResult(DataTable dt)
        {
            Form newForm = new Form();
            newForm.Width = 600;
            newForm.Height = 300;

            //     dt = Tabloyap(dt);


    

            DevExpress.XtraGrid.GridControl grid = new DevExpress.XtraGrid.GridControl();
            grid.Dock = DockStyle.Fill;
            grid.DataSource = dt;

            newForm.Controls.Add(grid);
            grid.ForceInitialize();
            ((DevExpress.XtraGrid.Views.Grid.GridView)grid.FocusedView).OptionsView.ShowGroupPanel = false;

            

            newForm.ShowDialog(this);
            return newForm;
        }
        #endregion #ShowResultForm

        #region #CellValueConversionErrorHandler
        void exporter_CellValueConversionError(object sender, CellValueConversionErrorEventArgs e)
        {
            MessageBox.Show("Error in cell " + e.Cell.GetReferenceA1());
            e.DataTableValue = null;
            e.Action = DataTableExporterAction.Continue;
        }
        #endregion #CellValueConversionErrorHandler

        private async void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            progressPanel1.Location = new Point((this.Width/2)-(progressPanel1.Width/2), (this.Height / 2) - (progressPanel1.Height / 2));
            progressPanel1.Visible = true;
        bool gelen= await ClassUrunAgaci.urunAgaciYukle(urunagaci);
   
            if(gelen)
            {
                MessageBox.Show("Ürün ağacı başarıyla eklendi.","Eklendi", MessageBoxButtons.OK,MessageBoxIcon.Information);

            

                // Klasör ve Dosya oluştur. 



            }
            else
            {
                MessageBox.Show("Ürün ağacı eklenemedi", "Eklenemedi", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            progressPanel1.Visible = false;
        }

        private void urunAgaciEkleForm_Load(object sender, EventArgs e)
        {
       
           // barButtonItem2.Enabled = false;

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}