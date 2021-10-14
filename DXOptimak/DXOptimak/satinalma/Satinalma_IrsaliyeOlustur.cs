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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;

using DevExpress.XtraBars;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using TCMBCurrencies;

namespace DXOptimak.satinalma
{
    public partial class Satinalma_IrsaliyeOlustur : DevExpress.XtraEditors.XtraForm
    {
        DataTable gelenTablo;
        string referans_irsaliye_id;
        public Satinalma_IrsaliyeOlustur()
        {
            InitializeComponent();

        }
        public Satinalma_IrsaliyeOlustur(string _referans_irsaliye_id)
        {
            InitializeComponent();
            referans_irsaliye_id = _referans_irsaliye_id;
        }

        public Satinalma_IrsaliyeOlustur(DataTable IrsaliyeDetayTablosu)
        {
            InitializeComponent();
            gelenTablo = new DataTable();
            gelenTablo = IrsaliyeDetayTablosu;
        }

        public Satinalma_IrsaliyeOlustur(DataTable IrsaliyeDetayTablosu, bool _DepoAktarim)
        {
            InitializeComponent();
            gelenTablo = new DataTable();
            gelenTablo = IrsaliyeDetayTablosu;
            DepoAktarim = _DepoAktarim;
        }

        DataTable dtKurlar;
        private void KurCekimi(DateTime tarih)
        {
            DateTime date = tarih;
            try
            {
                dtKurlar = CurrenciesExchange.GetDataTableAllCurrenciesHistoricalExchangeRates(date);
            }
            catch (Exception e)
            {
                if (e.Message == "The date specified may be a weekend or a public holiday!")
                {
                    //  MessageBox.Show(date.ToLongDateString() + " tarihinde kur bilgisi bulunamadı. Önceki güne bakılıyor.");
                    KurCekimi(tarih.AddDays(-1));

                }

            }


        }


        bool DepoAktarim;
        DataTable dtDepolar;
        SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);
        DataTable dtStokKartlari;

        private void Satinalma_IrsaliyeOlustur_Load(object sender, EventArgs e)
        {

            txtTermin.EditValue = DateTime.Now.AddDays(3);
            navBarDetayKaydet.Enabled = false;

            SqlCommand cmdUretimKodu = new SqlCommand("Select sd.id, pyp_adi,uretim_kodu, hesap_adi from proje_siparisDetay sd inner join proje_siparisBaslik sb on sd.siparis_id = sb.id inner join hesapBilgileri hb on sb.musteri_id = hb.id", baglanti);
            DataTable dtUretimKodu = new DataTable();
            SqlDataAdapter daUretimKodu = new SqlDataAdapter(cmdUretimKodu);
            daUretimKodu.Fill(dtUretimKodu);

            grid_Uretim.DataSource = dtUretimKodu;
            grid_Uretim.ValueMember = "id";
            grid_Uretim.DisplayMember = "uretim_kodu";
            grid_Uretim.KeyMember = "uretim_kodu";

            SqlCommand cmdStokKartlari = new SqlCommand("select * from stok_StokKartlari", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(cmdStokKartlari);
            dtStokKartlari = new DataTable();
            da.Fill(dtStokKartlari);

            grid_Stok.DataSource = helper.GenelVeri.StokKartlariListele();
            grid_Stok.ValueMember = "id";
            grid_Stok.DisplayMember = "parcaAdi";
            grid_Stok.KeyMember = "parcaAdi";




            if (gelenTablo == null)
            {

                gelenTablo = IrsaliyeClass.dtIrsaliyeDetayBosTablo();
            }



            if (gelenTablo.Columns["BarkodSayisi"] == null)
                gelenTablo.Columns.Add("BarkodSayisi");



            #region Grid İşlemleri -> Kur ve KDV Hesap Sütunları

            // dtKurlar adında tabloya atıyor.
            DateTime tarih = DateTime.Today;
            KurCekimi(tarih);
       //     helper.ayar.ShowResult(dtKurlar);

            dtKurlar.Columns.Add("id");

            for (int i = 0; i < dtKurlar.Rows.Count; i++)
            {
                dtKurlar.Rows[i]["id"] = i;
            }


            //    gridLookUpEdit.Properties.PopupView.Columns["Name"].Visible = false;


            grid_KurCinsi.DataSource = dtKurlar;

            grid_KurCinsi.View.PopulateColumns(dtKurlar);
            grid_KurCinsi.View.Columns["id"].Visible = false;
            grid_KurCinsi.View.Columns["Name"].Visible = false;
            grid_KurCinsi.View.Columns["CrossRateName"].Visible = false;
            grid_KurCinsi.View.Columns["ForexBuying"].Visible = false;
            grid_KurCinsi.View.Columns["ForexSelling"].Visible = false;
            grid_KurCinsi.View.Columns["BanknoteBuying"].Visible = false;
            grid_KurCinsi.View.Columns["BanknoteSelling"].Visible = false;



            grid_KurCinsi.ValueMember = "id";
            grid_KurCinsi.DisplayMember = "Name";
            grid_KurCinsi.KeyMember = "Name";
            gelenTablo.Columns.Add("KurCinsi", typeof(string));


            #endregion


            #region Grid İşlemleri

            gridControl1.DataSource = gelenTablo;

            gridView1.Columns["BarkodSayisi"].Caption = "Barkod Sayısı";

            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["id"].OptionsColumn.AllowEdit = false;

            gridView1.Columns["irsaliye_id"].Visible = false;
            gridView1.Columns["irsaliye_id"].OptionsColumn.AllowEdit = false;

            gridView1.Columns["stok_id"].Visible = true;
            gridView1.Columns["stok_id"].Caption = "Parça Adı";
            gridView1.Columns["stok_id"].ColumnEdit = grid_Stok;

            gridView1.Columns["miktar"].Caption = "Miktar";
            gridView1.Columns["uzunluk"].Caption = "Uzunluk";

            gridView1.Columns["birim"].Caption = "Birim";
            gridView1.Columns["birim"].OptionsColumn.AllowEdit = true;

            gridView1.Columns["birimFiyat"].Caption = "Birim Fiyat";
            gridView1.Columns["birimFiyat"].OptionsColumn.AllowEdit = true;

            gridView1.Columns["kdv"].Caption = "KDV";
            gridView1.Columns["kdv"].OptionsColumn.AllowEdit = true;

            gridView1.Columns["terminTarihi"].Caption = "Termin Tarihi";
            gridView1.Columns["terminTarihi"].OptionsColumn.AllowEdit = true;

            gridView1.Columns["kullanici"].Visible = false;
            gridView1.Columns["kullanici"].OptionsColumn.AllowEdit = false;

            gridView1.Columns["sip_DetayID"].Visible = true;
            gridView1.Columns["sip_DetayID"].Caption = "Üretim Kodu";
            gridView1.Columns["sip_DetayID"].ColumnEdit = grid_Uretim;
            gridView1.Columns["sip_DetayID"].OptionsColumn.AllowEdit = true;

            gridView1.Columns["HS"].Visible = false;
            gridView1.Columns["HS"].OptionsColumn.AllowEdit = false;

            gridView1.Columns["mamul_id"].Visible = false;
            gridView1.Columns["mamul_id"].OptionsColumn.AllowEdit = false;

            gridView1.Columns["KurCinsi"].Visible = true;
            gridView1.Columns["KurCinsi"].Caption = "Kur Cinsi";
            gridView1.Columns["KurCinsi"].ColumnEdit = grid_KurCinsi;



            #endregion

            #region İrsaliye Başlık

            if (String.IsNullOrWhiteSpace(referans_irsaliye_id))
                referans_irsaliye_id = null;



            dtDepolar = helper.GenelVeri.DepoListele();

            TxtTedarik.Properties.DataSource = helper.GenelVeri.TedarikciListele();
            TxtTedarik.Properties.ValueMember = "id";
            TxtTedarik.Properties.KeyMember = "Hesap_adi";
            TxtTedarik.Properties.DisplayMember = "hesap_adi";
            TxtTedarik.Properties.PopulateViewColumns();
            txtTedarikView.Columns["id"].Visible = false;
            txtTedarikView.Columns["hesap_adi"].Caption = "Hesap Adı";

            txtHedefDepo.Properties.DataSource = dtDepolar;
            txtHedefDepo.Properties.ValueMember = "id";
            txtHedefDepo.Properties.KeyMember = "depo_adi";
            txtHedefDepo.Properties.DisplayMember = "depo_adi";
            txtHedefDepo.Properties.PopulateViewColumns();
            txtHedefDepoView.Columns["id"].Visible = false;
            txtHedefDepoView.Columns["depo_birim"].Visible = false;
            txtHedefDepoView.Columns["depo_sorumlu"].Visible = false;



            txtCikisDepo.Properties.DataSource = dtDepolar;
            txtCikisDepo.Properties.ValueMember = "id";
            txtCikisDepo.Properties.KeyMember = "depo_adi";
            txtCikisDepo.Properties.DisplayMember = "depo_adi";
            txtCikisDepo.Properties.PopulateViewColumns();
            txtCikisDepoView.Columns["id"].Visible = false;
            txtCikisDepoView.Columns["depo_birim"].Visible = false;
            txtCikisDepoView.Columns["depo_sorumlu"].Visible = false;

            txtHedefTedarikci.Properties.DataSource = helper.GenelVeri.TedarikciListele();
            txtHedefTedarikci.Properties.ValueMember = "id";
            txtHedefTedarikci.Properties.KeyMember = "Hesap_adi";
            txtHedefTedarikci.Properties.DisplayMember = "hesap_adi";
            txtHedefTedarikci.Properties.PopulateViewColumns();
            txtHedefTedarikciView.Columns["id"].Visible = false;
            txtHedefTedarikciView.Columns["hesap_adi"].Caption = "Hesap Adı";



            txtIrsaliyeKodu.Properties.DataSource = helper.GenelVeri.IrsaiyeKodlariListele();
            txtIrsaliyeKodu.Properties.ValueMember = "id";
            txtIrsaliyeKodu.Properties.KeyMember = "irsaliye_kodu";
            txtIrsaliyeKodu.Properties.DisplayMember = "irsaliye_kodu";
            txtIrsaliyeKodu.Properties.PopulateViewColumns();
            txtIrsaliyeKoduView.Columns["id"].Visible = false;
            txtIrsaliyeKoduView.Columns["irsaliye_tipi"].Visible = false;
            txtIrsaliyeKoduView.Columns["seq"].Visible = false;

            #endregion














        }

        private void txtDepolarArasi_Toggled(object sender, EventArgs e)
        {
            if (txtCikisBirimDepo.IsOn)
            {
                lblTedarik.Text = "Çıkış Depo";
                txtCikisDepo.Visible = true;
                TxtTedarik.Visible = false;
            }
            else
            {
                lblTedarik.Text = "Tedarikçi";
                txtCikisDepo.Visible = false;
                TxtTedarik.Visible = true;
            }
        }
        DataTable dtIrsaliye;
        private void btnHeaderKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                SqlCommand INSERT_IrsaliyeBaslik = new SqlCommand("INSERT_IrsaliyeBaslik", baglanti);
                INSERT_IrsaliyeBaslik.CommandType = CommandType.StoredProcedure;
                INSERT_IrsaliyeBaslik.Parameters.AddWithValue("@termintarihi", Convert.ToDateTime(txtTermin.EditValue.ToString()));
                if (txtCikisBirimDepo.IsOn)
                    INSERT_IrsaliyeBaslik.Parameters.AddWithValue("@tedarikci", txtCikisDepo.EditValue.ToString());
                else
                    INSERT_IrsaliyeBaslik.Parameters.AddWithValue("@tedarikci", TxtTedarik.EditValue.ToString());

                if (txtHedefBirimDepo.IsOn)
                    INSERT_IrsaliyeBaslik.Parameters.AddWithValue("@hedefDepo", txtHedefDepo.EditValue.ToString());
                else
                    INSERT_IrsaliyeBaslik.Parameters.AddWithValue("@hedefDepo", txtHedefTedarikci.EditValue.ToString());


                INSERT_IrsaliyeBaslik.Parameters.AddWithValue("@toplamFiyat", txtToplamFiyat.Text.ToString());
                INSERT_IrsaliyeBaslik.Parameters.AddWithValue("@aciklama", txtAciklama.Text.ToString());
                // INSERT_IrsaliyeBaslik.Parameters.AddWithValue("@ustkirim", txtUstKirim.IsOn.ToString());
                INSERT_IrsaliyeBaslik.Parameters.AddWithValue("@cikisBirimDepo", txtCikisBirimDepo.IsOn.ToString());
                INSERT_IrsaliyeBaslik.Parameters.AddWithValue("@hedefBirimDepo", txtHedefBirimDepo.IsOn.ToString());
                INSERT_IrsaliyeBaslik.Parameters.AddWithValue("@kullaniciadi", kullanicibilgileri.kullaniciadi);
                INSERT_IrsaliyeBaslik.Parameters.AddWithValue("@irsaliye_kod_id", txtIrsaliyeKodu.EditValue.ToString());
                INSERT_IrsaliyeBaslik.Parameters.AddWithValue("@referansIrsaliyeID", referans_irsaliye_id);


                SqlDataAdapter da = new SqlDataAdapter(INSERT_IrsaliyeBaslik);
                dtIrsaliye = new DataTable();
                da.Fill(dtIrsaliye);
                txtIrsaliye.EditValue = dtIrsaliye.Rows[0]["irsaliye_no"].ToString();
                this.Text = dtIrsaliye.Rows[0]["irsaliye_no"].ToString() + " Numaralı İrsaliye";
                baglanti.Close();
                navBarDetayKaydet.Enabled = true;
                btnHeaderKaydet.Enabled = false;

                if (MessageBox.Show("İrsaliye içeriği kaydedilsin mi?", "İrsaliye Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    DetayKayit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }

        }

        private void txtASFT_Toggled(object sender, EventArgs e)
        {

        } //boş

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                (gridControl1.FocusedView as ColumnView).FocusedRowHandle++;
                e.Handled = true;
            }
        }

        private void DetayKayit()
        {

            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                if (String.IsNullOrWhiteSpace(gridView1.GetRowCellValue(i, "id").ToString()))
                {
                    //   MessageBox.Show(gridView1.GetRowCellValue(i, "miktar").ToString());
                    //   MessageBox.Show("girdi - kayit");
                    SqlCommand INSERT_IrsaliyeDetay = new SqlCommand("INSERT_IrsaliyeDetay", baglanti);
                    INSERT_IrsaliyeDetay.CommandType = CommandType.StoredProcedure;
                    INSERT_IrsaliyeDetay.Parameters.AddWithValue("@irsaliye_id", dtIrsaliye.Rows[0]["id"].ToString());
                    INSERT_IrsaliyeDetay.Parameters.AddWithValue("@stok_id", gridView1.GetRowCellValue(i, "stok_id").ToString());
                    //INSERT_IrsaliyeDetay.Parameters.AddWithValue("@kategori", gridView1.GetRowCellValue(i, "kategori").ToString());
                    //INSERT_IrsaliyeDetay.Parameters.AddWithValue("@parcaAdi", gridView1.GetRowCellValue(i, "parcaAdi").ToString());
                    //INSERT_IrsaliyeDetay.Parameters.AddWithValue("@parcaStokAdi", gridView1.GetRowCellValue(i, "parcaStokAdi").ToString());
                    //INSERT_IrsaliyeDetay.Parameters.AddWithValue("@malzeme", gridView1.GetRowCellValue(i, "malzeme").ToString());
                    //INSERT_IrsaliyeDetay.Parameters.AddWithValue("@uzunluk", gridView1.GetRowCellValue(i, "uzunluk").ToString());
                    //INSERT_IrsaliyeDetay.Parameters.AddWithValue("@prosesGrubu", gridView1.GetRowCellValue(i, "prosesGrubu").ToString());
                    //INSERT_IrsaliyeDetay.Parameters.AddWithValue("@grubuAdi", gridView1.GetRowCellValue(i, "grubuAdi").ToString());
                    //INSERT_IrsaliyeDetay.Parameters.AddWithValue("@altGrubuAdi", gridView1.GetRowCellValue(i, "altGrubuAdi").ToString());
                    //INSERT_IrsaliyeDetay.Parameters.AddWithValue("@seriNumarasi", gridView1.GetRowCellValue(i, "seriNumarasi").ToString());
                    //INSERT_IrsaliyeDetay.Parameters.AddWithValue("@tip", gridView1.GetRowCellValue(i, "tip").ToString());
                    INSERT_IrsaliyeDetay.Parameters.AddWithValue("@miktar", gridView1.GetRowCellValue(i, "miktar").ToString());
                    INSERT_IrsaliyeDetay.Parameters.AddWithValue("@uzunluk", gridView1.GetRowCellValue(i, "uzunluk").ToString());
                    INSERT_IrsaliyeDetay.Parameters.AddWithValue("@birim", gridView1.GetRowCellValue(i, "birim").ToString());
                    INSERT_IrsaliyeDetay.Parameters.AddWithValue("@birimFiyat", gridView1.GetRowCellValue(i, "birimFiyat").ToString());
                    INSERT_IrsaliyeDetay.Parameters.AddWithValue("@kdv", gridView1.GetRowCellValue(i, "kdv").ToString());
                    INSERT_IrsaliyeDetay.Parameters.AddWithValue("@terminTarihi", Convert.ToDateTime(gridView1.GetRowCellValue(i, "terminTarihi").ToString()));
                    INSERT_IrsaliyeDetay.Parameters.AddWithValue("@kullanici", kullanicibilgileri.kullaniciadi);
                    INSERT_IrsaliyeDetay.Parameters.AddWithValue("@sip_DetayID", gridView1.GetRowCellValue(i, "sip_DetayID").ToString());
                    INSERT_IrsaliyeDetay.Parameters.AddWithValue("@HS", txtHS.IsOn.ToString());

                    if (DepoAktarim || txtHS.IsOn)
                        INSERT_IrsaliyeDetay.Parameters.AddWithValue("@DepoAktarim", 1); // Alt Kırılımları Satınalma Malzeme Listesinden düşer.




                    //        INSERT_IrsaliyeDetay.Parameters.AddWithValue("@mamul_id", gridView1.GetRowCellValue(i, "mamul_id").ToString());
                    int detay_id = (int)INSERT_IrsaliyeDetay.ExecuteScalar();
                    gridView1.SetRowCellValue(i, "irsaliye_id", dtIrsaliye.Rows[0]["id"].ToString());
                    gridView1.SetRowCellValue(i, "id", detay_id);



                }
                else
                {
                    MessageBox.Show(gridView1.GetRowCellValue(i, "sip_DetayID").ToString());
                    SqlCommand UPDATE_IrsaliyeDetay = new SqlCommand("UPDATE_IrsaliyeDetay", baglanti);
                    UPDATE_IrsaliyeDetay.CommandType = CommandType.StoredProcedure;
                    UPDATE_IrsaliyeDetay.Parameters.AddWithValue("@id", gridView1.GetRowCellValue(i, "id").ToString());
                    UPDATE_IrsaliyeDetay.Parameters.AddWithValue("@stok_id", gridView1.GetRowCellValue(i, "stok_id").ToString());
                    //   UPDATE_IrsaliyeDetay.Parameters.AddWithValue("@miktar", gridView1.GetRowCellValue(i, "miktar").ToString());
                    UPDATE_IrsaliyeDetay.Parameters.AddWithValue("@birim", gridView1.GetRowCellValue(i, "birim").ToString());
                    UPDATE_IrsaliyeDetay.Parameters.AddWithValue("@birimFiyat", gridView1.GetRowCellValue(i, "birimFiyat").ToString());
                    UPDATE_IrsaliyeDetay.Parameters.AddWithValue("@kdv", gridView1.GetRowCellValue(i, "kdv").ToString());
                    UPDATE_IrsaliyeDetay.Parameters.AddWithValue("@terminTarihi", Convert.ToDateTime(gridView1.GetRowCellValue(i, "terminTarihi").ToString()));
                    UPDATE_IrsaliyeDetay.Parameters.AddWithValue("@kullanici", gridView1.GetRowCellValue(i, "kullanici").ToString());
                    UPDATE_IrsaliyeDetay.Parameters.AddWithValue("@sip_DetayID", gridView1.GetRowCellValue(i, "sip_DetayID").ToString());
                    UPDATE_IrsaliyeDetay.ExecuteNonQuery();







                }

            }
            MessageBox.Show("Kayıtlar eklendi / güncellendi. ");

            baglanti.Close();



            /*
             
    @irsaliye_id,
@stok_id,
@kategori,
@parcaAdi,
@parcaStokAdi,
@malzeme,
@uzunluk,
@prosesGrubu,
@grubuAdi,
@altGrubuAdi,
@seriNumarasi,
@tip,
@miktar,
@birim,
@birimFiyat,
@kdv,
@terminTarihi,
@kullanici,
@sip_DetayID,
@mamul_id
*/


        }

        private void navBarDetayKaydet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DetayKayit();


        }

        private void navBarUstKirimOlustur_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        } //boş

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        } //boş

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (textBox1.Text == "-")
                    {
                        MessageBox.Show("Seri no veya Parça Adı yok.");
                        textBox1.Text = "";
                        return;
                    }

                    if (baglanti.State != ConnectionState.Open)
                        baglanti.Open();

                    SqlCommand cmdStokBul = new SqlCommand("FIND_StokKarti", baglanti);
                    cmdStokBul.CommandType = CommandType.StoredProcedure;
                    cmdStokBul.Parameters.AddWithValue("@barcode", textBox1.Text);

                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmdStokBul);
                    da.Fill(dt);


                    bool ekledi = false;

                    if (dt.Rows.Count < 1)
                    {
                        MessageBox.Show("SERİ NO VEYA PARÇA ADI BULUNAMADI");
                        return;
                    }


                    for (int i = 0; i < gridView1.DataRowCount; i++)

                    {

                        try
                        {
                            if (!String.IsNullOrWhiteSpace(gridView1.GetRowCellValue(i, "stok_id").ToString()))
                            {

                                if (gridView1.GetRowCellValue(i, "stok_id").ToString() == dt.Rows[0]["id"].ToString())
                                {

                                    gridView1.SetRowCellValue(i, "miktar", ((Convert.ToDouble(gridView1.GetRowCellValue(i, "miktar").ToString())) + 1));

                                    ekledi = true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    if (ekledi)
                    {
                        textBox1.Text = "";
                        return;
                    }
                    else
                    {
                        gridView1.AddNewRow();

                        gridView1.SetFocusedRowCellValue("stok_id", dt.Rows[0]["id"].ToString());
                        gridView1.SetFocusedRowCellValue("miktar", 1);
                        gridView1.SetFocusedRowCellValue("birim", "ADET");
                        gridView1.SetFocusedRowCellValue("terminTarihi", txtTermin.EditValue);
                        gridView1.UpdateCurrentRow();
                        textBox1.Text = "";
                    }
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message + " - " + ex2.StackTrace);
                }


            }
        } //Barkod Kontrol - > Enter

        private void navBarSatirSil_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView1.DeleteSelectedRows();


        }

        private void gridView1_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            if (MessageBox.Show(gridView1.GetFocusedRowCellDisplayText("stok_id").ToString() + " silmek istediğinizden emin misiniz?", "SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (String.IsNullOrWhiteSpace(gridView1.GetFocusedRowCellValue("id").ToString()))
                {

                }
                else
                {
                    try
                    {
                        if (baglanti.State != ConnectionState.Open)
                            baglanti.Open();

                        SqlCommand DELETE_IrsaliyeDetay = new SqlCommand("DELETE_IrsaliyeDetay", baglanti);
                        DELETE_IrsaliyeDetay.CommandType = CommandType.StoredProcedure;
                        DELETE_IrsaliyeDetay.Parameters.AddWithValue("@id", gridView1.GetFocusedRowCellValue("id").ToString());
                        DELETE_IrsaliyeDetay.ExecuteNonQuery();
                        MessageBox.Show("Satır başarıyla silindi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void barkodBastir(string _stokid, string _stokadi, string _irsaliyeno, string _serino)
        {
            helper.XtraReport1 report = new helper.XtraReport1();
            report.Parameters[0].Value = _stokid;
            report.Parameters[1].Value = _stokadi;
            report.Parameters[2].Value = _irsaliyeno;
            report.Parameters[3].Value = _serino;
            ReportPrintTool pt = new ReportPrintTool(report);
            report.RequestParameters = false;
            pt.AutoShowParametersPanel = false;
            //   pt.ShowPreviewDialog();
            pt.Print();
            pt.Dispose();
            report.Dispose();
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {


            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                string stokid = gridView1.GetRowCellValue(i, "stok_id").ToString();
                string stokadi = gridView1.GetRowCellDisplayText(i, "stok_id").ToString();
                //     string irsaliyeno = dtIrsaliye.Rows[0]["irsaliye_no"].ToString();
                string irsaliyeno = "-1";
                DataRow drSeriNo;
                drSeriNo = dtStokKartlari.Select("id = " + stokid).First();
                string seriNo = drSeriNo["seriNumarasi"].ToString();
                int BarkodSayisi;


                if (String.IsNullOrWhiteSpace(gridView1.GetRowCellValue(i, "BarkodSayisi").ToString()))
                {
                    BarkodSayisi = 1;
                    gridView1.SetRowCellValue(i, "BarkodSayisi", 1);
                }


                try
                {
                    BarkodSayisi = Convert.ToInt32(gridView1.GetRowCellValue(i, "BarkodSayisi").ToString());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Barkod Sayısı: " + ex.Message);
                    BarkodSayisi = 1;
                    gridView1.SetRowCellValue(i, "BarkodSayisi", 1);
                }


                if (BarkodSayisi > 1)
                {
                    for (int j = 0; j < Convert.ToInt32(gridView1.GetRowCellValue(i, "BarkodSayisi").ToString()); j++)
                    {
                        barkodBastir(stokid, stokadi, irsaliyeno, seriNo);
                    }
                }
                else if (BarkodSayisi == 1)
                {
                    barkodBastir(stokid, stokadi, irsaliyeno, seriNo);
                }
            }
        }

        private void Satinalma_IrsaliyeOlustur_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("İrsaliye ekranını kapatmak istediğinize emin misiniz?", "KAPATILIYOR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void txtHedefDepoTedarikci_Toggled(object sender, EventArgs e)
        {
            if (txtHedefBirimDepo.IsOn)
            {
                lblHedefDepo.Text = "Hedef Depo";

                txtHedefDepo.Visible = true;
                txtHedefTedarikci.Visible = false;



                //          txtIrsaliyeKodu.EditValue = 2;

            }
            else
            {
                lblHedefDepo.Text = "Hdf. Tedarikçi";

                txtHedefDepo.Visible = false;
                txtHedefTedarikci.Visible = true;


                //         txtIrsaliyeKodu.EditValue = ;


            }

        }

        private void txtIrsaliyeKodu_EditValueChanged(object sender, EventArgs e)
        {



        }

        private void txtTermin_EditValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                gridView1.SetRowCellValue(i, "terminTarihi", txtTermin.EditValue);
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(gridView1.GetFocusedRowCellValue("terminTarihi").ToString()))
                gridView1.SetFocusedRowCellValue("terminTarihi", txtTermin.EditValue);

        }




    }
}