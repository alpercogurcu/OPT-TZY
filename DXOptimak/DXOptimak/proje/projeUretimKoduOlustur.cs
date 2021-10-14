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
    public partial class projeUretimKoduOlustur : DevExpress.XtraEditors.XtraForm
    {
        string projeID;
        public projeUretimKoduOlustur(string _projeID)
        {
            InitializeComponent();
            projeID = _projeID;
        }


        void projeDetayGetir(string _pdID)
        {
            gridControl1.Visible = true;
            splitContainer1.Visible = true;

            SqlCommand cmd2 = new SqlCommand("GET_projeSiparisDetay", baglanti);
            cmd2.Parameters.AddWithValue("@siparisid", _pdID);
            cmd2.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            da.Fill(dt);

            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["siparis_id"].Visible = false;
            gridView1.Columns["id"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["siparis_id"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["TasarimIsEmriID"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["SatinalmaIsEmriID"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["TasarimIsEmriID"].Visible = false;
            gridView1.Columns["SatinalmaIsEmriID"].Visible = false;
          ///  gridView1.Columns["durumTakipID"].Visible = false;


            gridView1.Columns["TasarimIsEmriID"].Caption = "Tasarım İş Emri";
            gridView1.Columns["SatinalmaIsEmriID"].Caption = "Satınalma İş Emri";



            gridView1.Columns["pyp_adi"].Caption = "PYP Adı";
            gridView1.Columns["miktar"].Caption = "Miktar";
            gridView1.Columns["tasarim_adi"].Caption = "Tasarım Adı";
            gridView1.Columns["uretim_kodu"].Caption = "Üretim Kodu";
            gridView1.Columns["TasarimBool"].Caption = "Tasarım İş Emri";
            gridView1.Columns["SatinalmaBool"].Caption = "Satınalma İş Emri";
            

            gridView1.Columns["tasarim_adi"].ColumnEdit = repositoryItemGridLookUpEdit1;



            gridView1.Columns["TasarimBool"].ColumnEdit = repositoryItemCheckEdit1;
            gridView1.Columns["SatinalmaBool"].ColumnEdit = repositoryItemCheckEdit1;


            gridView1.Columns["TasarimBool"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["SatinalmaBool"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Durum"].OptionsColumn.AllowEdit = false;


            // repositoryItemCheckEdit1



            SqlCommand cmdMamulList = new SqlCommand("select id, parcaAdi from tasarim_urunagaci where tip='mamül'", baglanti);
            DataTable dtMamul = new DataTable();
            SqlDataAdapter daMamul = new SqlDataAdapter(cmdMamulList);
            daMamul.Fill(dtMamul);

            repositoryItemGridLookUpEdit1.DataSource = dtMamul;
            repositoryItemGridLookUpEdit1.ValueMember = "id";
            repositoryItemGridLookUpEdit1.DisplayMember = "parcaAdi";
            repositoryItemGridLookUpEdit1.KeyMember = "parcaAdi";




            gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;

            //gridView1.OptionsBehavior.Editable = false;
            //gridView1.OptionsBehavior.ReadOnly = true;

            repositoryItemButtonEdit1.ButtonClick += RepositoryItemButtonEdit1_ButtonClick;
            /*
                                GridColumn gridColumn = gridView1.Columns.AddVisible("islem", string.Empty);
                                RepositoryItemButtonEdit repositoryItemButtonEdit = new RepositoryItemButtonEdit();
                                repositoryItemButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;                
                                repositoryItemButtonEdit.ButtonClick += RepositoryItemButtonEdit_ButtonClick;
                                gridControl1.RepositoryItems.Add(repositoryItemButtonEdit);
                                gridColumn.ColumnEdit = repositoryItemButtonEdit;
                                gridColumn.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;*/




        }

        void kayitekle()
        {
            SqlCommand cmd = new SqlCommand("Insert INTO proje_siparisBaslik(tarih,musteri_id,hatkodu,olusturan, pypSorumlusu)  output INSERTED.id values (@tarih, @musteri_id, @hatkodu, @olusturan, @pypSorumlusu);", baglanti);
            cmd.Parameters.AddWithValue("@tarih", Convert.ToDateTime(tarih.EditValue.ToString()));
            cmd.Parameters.AddWithValue("@musteri_id", musteri.EditValue.ToString());
            cmd.Parameters.AddWithValue("@hatkodu", projekodu.EditValue.ToString());
            cmd.Parameters.AddWithValue("@olusturan", kullanicibilgileri.kullaniciadi);
            cmd.Parameters.AddWithValue("@pypSorumlusu", pypSorumlusu.EditValue.ToString());

            siparisId = (int)cmd.ExecuteScalar();
        }

        SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);
        bool guncelle;
        DataTable dtProjeBaslik;
        private void projeUretimKoduOlustur_Load(object sender, EventArgs e)
        {
            guncelle = false;
            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                DataTable dt = new DataTable();

                SqlCommand cmdMusteri = new SqlCommand("Select id, hesap_adi from HesapBilgileri", baglanti);
                SqlDataAdapter daMusteri = new SqlDataAdapter(cmdMusteri);
                daMusteri.Fill(dt);



                musteri.Properties.DataSource = dt;
                musteri.Properties.ValueMember = "id";
                musteri.Properties.KeyMember = "Hesap_adi";
                musteri.Properties.DisplayMember = "hesap_adi";
                musteri.Properties.PopulateViewColumns();
                musteriView.Columns["id"].Visible = false;
                musteriView.Columns["hesap_adi"].Caption = "Hesap Adı";


                daMusteri.Dispose();


                if (!String.IsNullOrEmpty(projeID) || !String.IsNullOrWhiteSpace(projeID))
                {

                    guncelle = true;
                    SqlCommand cmdProjeBaslikGetir = new SqlCommand("select * from proje_siparisBaslik where id = @projeID", baglanti);
                    cmdProjeBaslikGetir.Parameters.AddWithValue("@projeID", projeID);
                    SqlDataAdapter daProjeGetir = new SqlDataAdapter(cmdProjeBaslikGetir);
                    dtProjeBaslik = new DataTable();
                    daProjeGetir.Fill(dtProjeBaslik);

                    /* SqlCommand cmdProjeDetayGetir = new SqlCommand("Select * from proje_siparisDetay where siparis_id = @projeID", baglanti);
                     cmdProjeDetayGetir.Parameters.AddWithValue("@projeID", projeID);
                     daProjeGetir = new SqlDataAdapter(cmdProjeDetayGetir);
                     dtProjeDetay = new DataTable();
                     daProjeGetir.Fill(dtProjeDetay);
                     */
                    button1.Text = "Güncelle";


                    tarih.EditValue = dtProjeBaslik.Rows[0]["tarih"].ToString();
                    musteri.EditValue = dtProjeBaslik.Rows[0]["musteri_id"].ToString();
                    projekodu.EditValue = dtProjeBaslik.Rows[0]["hatkodu"].ToString();
                    pypSorumlusu.EditValue = dtProjeBaslik.Rows[0]["pypSorumlusu"].ToString();
                    siparisId = Convert.ToInt32(dtProjeBaslik.Rows[0]["id"].ToString());

                    projeDetayGetir(siparisId.ToString());



                }


                baglanti.Close();




                /*gridLookUpEdit1.Properties.PopupView.Columns["id"].Visible = false;
                gridLookUpEdit1.Properties.PopupView.Columns["hesap_kodu"].Visible = false;
                gridLookUpEdit1.Properties.PopupView.Columns["hesap_tipi"].Visible = false;
                gridLookUpEdit1.Properties.PopupView.Columns["hesap_kategori"].Visible = false;
                gridLookUpEdit1.Properties.PopupView.Columns["hesap_VNo"].Visible = false;
                gridLookUpEdit1.Properties.PopupView.Columns["hesap_VDairesi"].Visible = false;
                gridLookUpEdit1.Properties.PopupView.Columns["hesap_OlusturanId"].Visible = false;
                gridLookUpEdit1.Properties.PopupView.Columns["hesap_TcNo"].Visible = false;
                gridLookUpEdit1.Properties.PopupView.Columns["hesap_telefon"].Visible = false;
                */

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show(ex.StackTrace.ToString());
            }
        }



        int siparisId;
      

        private void button1_Click(object sender, EventArgs e)
        {

            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();


            //Güncellenecek mi kontrolü

            if (guncelle)
            {

                SqlCommand cmdKayitGuncelle = new SqlCommand("UPDATE proje_siparisBaslik SET tarih=@tarih, musteri_id=@musteri_id, hatkodu=@hatkodu, olusturan=@olusturan, pypSorumlusu=@pypSorumlusu where id=@id", baglanti);
                cmdKayitGuncelle.Parameters.AddWithValue("@tarih", Convert.ToDateTime(tarih.EditValue.ToString()));
                cmdKayitGuncelle.Parameters.AddWithValue("@musteri_id", musteri.EditValue.ToString());
                cmdKayitGuncelle.Parameters.AddWithValue("@hatkodu", projekodu.EditValue.ToString());
                cmdKayitGuncelle.Parameters.AddWithValue("@olusturan", kullanicibilgileri.kullaniciadi);
                cmdKayitGuncelle.Parameters.AddWithValue("@pypSorumlusu", pypSorumlusu.EditValue.ToString());
                cmdKayitGuncelle.Parameters.AddWithValue("@id", projeID);



                if (cmdKayitGuncelle.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Güncelleme işlemi başarılı.");
                }


            }
            else
            {



                //Kayıt var mı kontrolü

                SqlCommand cmdKayitKontrol = new SqlCommand("select * from proje_siparisBaslik where musteri_id = @musteri_id", baglanti);
                cmdKayitKontrol.Parameters.AddWithValue("@musteri_id", musteri.EditValue.ToString());
                DataTable DtKayitListesi = new DataTable();
                SqlDataAdapter daKayitKontrol = new SqlDataAdapter(cmdKayitKontrol);
                daKayitKontrol.Fill(DtKayitListesi);

                if (DtKayitListesi.Rows.Count > 0)
                {
                    DialogResult msgDr = MessageBox.Show("Bu müşteriye açmış olduğunuz bir kayıt zaten mevcut.\nGörüntülemek ister misiniz?\n ", "Kayıt Mevcut", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (msgDr == DialogResult.No)
                    {

                        kayitekle();
                    }
                    else if (msgDr == DialogResult.Yes)
                    {
                        tarih.EditValue = DtKayitListesi.Rows[0]["tarih"].ToString();
                        musteri.EditValue = DtKayitListesi.Rows[0]["musteri_id"].ToString();
                        projekodu.EditValue = DtKayitListesi.Rows[0]["hatkodu"].ToString();
                        pypSorumlusu.EditValue = DtKayitListesi.Rows[0]["pypSorumlusu"].ToString();
                        siparisId = Convert.ToInt32(DtKayitListesi.Rows[0]["id"].ToString());
                        guncelle = true;
                    }
                    else if (msgDr == DialogResult.Cancel)
                    {

                    }
                }
                else
                {
                    kayitekle();
                }





                if (siparisId > 0)
                {
                    projeDetayGetir(siparisId.ToString());

                }
            }


        }

        private void RepositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {


        }

        private void Btnedit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string ad = (string)gridView1.GetFocusedRowCellValue("pyp_adi");
            gridView1.SetFocusedRowCellValue("islem", ad);
            // MessageBox.Show((string)gridView1.GetFocusedRowCellValue("pyp_adi"));
        }

        private void RepositoryItemButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }



        private void gridView1_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            try
            {
                if (MessageBox.Show(gridView1.GetFocusedRowCellValue("pyp_adi").ToString() + " silmek istediğinizden emin misiniz?", "SİL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (String.IsNullOrWhiteSpace(gridView1.GetFocusedRowCellValue("id").ToString()))
                    {

                    }
                    else
                    {

                        if (baglanti.State != ConnectionState.Open)
                            baglanti.Open();

                        SqlCommand cmdDelete = new SqlCommand("Delete from proje_siparisDetay where id=@id", baglanti);
                        cmdDelete.Parameters.AddWithValue("@id", gridView1.GetFocusedRowCellValue("id").ToString());
                        if (cmdDelete.ExecuteNonQuery() > 0)
                            MessageBox.Show("Başarıyla silindi.");
                        else
                            MessageBox.Show("Hata");

                        baglanti.Close();
                        // veritabanından sil.
                    }

                }
                else
                {
                    e.Cancel = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void navbarKaydet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {

                    string pypadi = gridView1.GetRowCellValue(i, "pyp_adi").ToString();
                    string tasarimadi = gridView1.GetRowCellValue(i, "tasarim_adi").ToString();
                    int miktar = Convert.ToInt32(gridView1.GetRowCellValue(i, "miktar").ToString());
                    string uretimkodu = gridView1.GetRowCellValue(i, "uretim_kodu").ToString();

                    SqlCommand cmdDetayEkle;

                    if (String.IsNullOrWhiteSpace(gridView1.GetRowCellValue(i, "id").ToString()))
                    {
                        cmdDetayEkle = new SqlCommand("INSERT INTO proje_siparisDetay (siparis_id, pyp_adi, miktar, tasarim_adi, uretim_kodu) OUTPUT INSERTED.id values (@sip, @pypadi, @mikt, @tadi, @uretimkodu);", baglanti);
                        cmdDetayEkle.Parameters.AddWithValue("@sip", siparisId);
                        cmdDetayEkle.Parameters.AddWithValue("@pypadi", pypadi);
                        cmdDetayEkle.Parameters.AddWithValue("@mikt", miktar);
                        cmdDetayEkle.Parameters.AddWithValue("@tadi", tasarimadi);
                        cmdDetayEkle.Parameters.AddWithValue("@uretimkodu", uretimkodu);
                        int detay_id = (int)cmdDetayEkle.ExecuteScalar();
                        gridView1.SetRowCellValue(i, "siparis_id", siparisId);
                        gridView1.SetRowCellValue(i, "id", detay_id);
                       


                    }
                    else
                    {
                        cmdDetayEkle = new SqlCommand("UPDATE proje_siparisDetay SET pyp_adi=@pypadi, miktar=@mikt, tasarim_adi=@tadi, uretim_kodu=@uretimkodu where id=@id", baglanti);
                        cmdDetayEkle.Parameters.AddWithValue("@pypadi", pypadi);
                        cmdDetayEkle.Parameters.AddWithValue("@mikt", miktar);
                        cmdDetayEkle.Parameters.AddWithValue("@tadi", tasarimadi);
                        cmdDetayEkle.Parameters.AddWithValue("@uretimkodu", uretimkodu);
                        cmdDetayEkle.Parameters.AddWithValue("@id", gridView1.GetRowCellValue(i, "id").ToString());
                        cmdDetayEkle.ExecuteNonQuery();

                    }

                 


                }
                MessageBox.Show("Kayıtlar tamamlandı / güncellendi.");
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void navbarSil_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }

      

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!gridView1.IsNewItemRow(e.FocusedRowHandle)) {

                navbarGrupIsEmirleri.Visible = true;
                if (!String.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("TasarimIsEmriID").ToString()))
                {
                    navbarTasarimIsEmri.Enabled = false;
                }
                else
                {
                    navbarTasarimIsEmri.Enabled = true;

                }

                if (!String.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("SatinalmaIsEmriID").ToString()))
                {
                    navbarSatinAlmaIsEmri.Enabled = false;
                    navbarTasarimIsEmri.Enabled = false;
                }
                else
                {
                 
                    navbarSatinAlmaIsEmri.Enabled = true;

                }
            }
            else
            {
                navbarGrupIsEmirleri.Visible = false;
            }
        }


        void isEmriOlustur(string tanim)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(gridView1.GetFocusedRowCellValue("id").ToString()))
                {
                    if (baglanti.State != ConnectionState.Open)
                        baglanti.Open();

          
                    SqlCommand isEmriEkle = new SqlCommand("insert into proje_isEmirleri (baslik, aciklama, acilacak_Form, form_gonderilecekDeger, birim, olusturan_Kullanici, sip_DetayID) values (@baslik, @aciklama, @acilacak_Form, @form_gonderilecekDeger, @birim, @olusturan_Kullanici, @sip_DetayID);", baglanti);
                    isEmriEkle.Parameters.AddWithValue("@baslik", "Tasarım İş Emri");
                    isEmriEkle.Parameters.AddWithValue("@aciklama", "İş Emri Pyp Adı:" + gridView1.GetFocusedRowCellValue("pyp_adi").ToString());
                    isEmriEkle.Parameters.AddWithValue("@acilacak_Form", "projeUretimKoduOlustur");
                    isEmriEkle.Parameters.AddWithValue("@form_gonderilecekDeger", gridView1.GetFocusedRowCellValue("id").ToString());
                    isEmriEkle.Parameters.AddWithValue("@birim", tanim);
                    isEmriEkle.Parameters.AddWithValue("@sip_DetayID", gridView1.GetFocusedRowCellValue("id").ToString());
                    isEmriEkle.Parameters.AddWithValue("@olusturan_Kullanici", kullanicibilgileri.kullaniciadi);

                    if (isEmriEkle.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("İş emri başarıyla oluşturuldu.");
                    }
                    else
                    {
                        MessageBox.Show("iş emri oluşturulamadı.");
                    }

                    baglanti.Close();

                    projeDetayGetir(siparisId.ToString());

                    //isEmriEkle.Parameters.AddWithValue("@olusturan_personel", kullanicibilgileri.kullaniciadi);


                }
                else
                {
                    MessageBox.Show("Tabloyu önce kayıt etmelisiniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void navbarTasarimIsEmri_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            isEmriOlustur("Tasarım");
        }

        private void navbarUretimIsEmri_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) // Visible False
        {
            isEmriOlustur("");

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

        private void navbarSatinAlmaIsEmri_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {

                if (String.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("tasarim_adi").ToString()))
                {
                    if (MessageBox.Show("Ürün Ağacı bulunmadığından dolayı satınalma siparişi fason olarak açılacak.\nDevam etmek istiyor musunuz?", "Fason Satınalma", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        isEmriOlustur("Satınalma");
                    }
                }
                else
                {
                    MessageBox.Show(gridView1.GetFocusedRowCellValue("tasarim_adi").ToString() + " - " + gridView1.GetFocusedRowCellValue("id").ToString());

                   
                    MessageBox.Show(gridView1.GetFocusedRowCellValue("tasarim_adi").ToString() + " - " + gridView1.GetFocusedRowCellValue("id").ToString());

                    SqlCommand INSERT_UretimUrunAgaci = new SqlCommand("INSERT_UretimUrunAgaci", baglanti);
                    INSERT_UretimUrunAgaci.Parameters.AddWithValue("@sip_DetayID", gridView1.GetFocusedRowCellValue("id").ToString());
                    INSERT_UretimUrunAgaci.Parameters.AddWithValue("@Tasarim_ID", gridView1.GetFocusedRowCellValue("tasarim_adi").ToString());
                    INSERT_UretimUrunAgaci.Parameters.AddWithValue("@takimSayisi", gridView1.GetFocusedRowCellValue("miktar").ToString());
                    INSERT_UretimUrunAgaci.Parameters.AddWithValue("@kullaniciAdi", kullanicibilgileri.kullaniciadi);
                    INSERT_UretimUrunAgaci.CommandType = CommandType.StoredProcedure;

                    if (baglanti.State != ConnectionState.Open)
                        baglanti.Open();

                    INSERT_UretimUrunAgaci.ExecuteNonQuery();

                    ProjeUrunAgaci.durumDegistir(4, gridView1.GetFocusedRowCellValue("id").ToString());

                    isEmriOlustur("Satınalma");
                    MessageBox.Show("Ürün ağacı başarıyla atandı.");



                    /*
                    // Üretim ağacına ata. 
                    string mamulid = gridView1.GetFocusedRowCellValue("tasarim_adi").ToString();
                    SqlCommand cmdUrunAgaciGetir = new SqlCommand("select * from tasarim_urunAgaci where mamul_id = @mamul_id or id = @mamul_id order by id asc ", baglanti);
                    cmdUrunAgaciGetir.Parameters.AddWithValue("@mamul_id", mamulid );
                    SqlDataAdapter daUrunAgaci = new SqlDataAdapter(cmdUrunAgaciGetir);

                    DataTable dtUrunAgaci = new DataTable();
                    daUrunAgaci.Fill(dtUrunAgaci);

                    // Mamül'ün id 'sini buluyoruz, miktarı değiştiriyoruz.
                    DataRow filtrelisatir = dtUrunAgaci.Select("id = '" + mamulid + "'").First();
                    dtUrunAgaci.Rows[dtUrunAgaci.Rows.IndexOf(filtrelisatir)]["Miktar"] = gridView1.GetFocusedRowCellValue("miktar").ToString();

                    string parentid;

                    for (int i = 0; i < dtUrunAgaci.Rows.Count; i++)
                    {

                        parentid = dtUrunAgaci.Rows[i]["ParentID1"].ToString();

                        DataRow[] filtrelisatirlar = dtUrunAgaci.Select("ID1 = '" + parentid + "'");

                        if(dtUrunAgaci.Rows[i]["ID1"].ToString() == dtUrunAgaci.Rows[i]["ParentID1"].ToString())
                        {
                            dtUrunAgaci.Rows[i]["gerekenMiktar"] = dtUrunAgaci.Rows[i]["miktar"].ToString();

                        }


                        if (dtUrunAgaci.Rows[i]["carpim"].ToString() != "Hayır")
                        {
                           // MessageBox.Show(filtrelisatirlar[0]["ID1"].ToString() + " ---> " + dtUrunAgaci.Rows[i]["ID1"].ToString());

                            if (dtUrunAgaci.Rows[i]["ParentID1"].ToString() != dtUrunAgaci.Rows[i]["ID1"].ToString())
                            {
                                dtUrunAgaci.Rows[i]["gerekenMiktar"] = Convert.ToDouble(filtrelisatirlar[0]["gerekenMiktar"].ToString()) * Convert.ToDouble(dtUrunAgaci.Rows[i]["miktar"].ToString());
                            }
                        }


                    }



                    progressPanel1.Location = new Point((this.Width / 2) - (progressPanel1.Width / 2), (this.Height / 2) - (progressPanel1.Height / 2));
                    progressPanel1.Visible = true;

                    bool gelen = await ProjeUrunAgaci.urunAgaciAktar(dtUrunAgaci, gridView1.GetFocusedRowCellValue("id").ToString(), musteri.EditValue.ToString());

                    if (gelen)
                    {
                        MessageBox.Show("Ürün ağacı başarıyla eklendi.", "Eklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ürün ağacı eklenemedi", "Eklenemedi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    progressPanel1.Visible = false;

                    projeDetayGetir(siparisId.ToString());
                 //   ShowResult(dtUrunAgaci);
                 */


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n"+ex.StackTrace);
            }



        }
    }
}