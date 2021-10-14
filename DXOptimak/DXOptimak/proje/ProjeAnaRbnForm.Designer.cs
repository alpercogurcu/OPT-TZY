namespace DXOptimak.proje
{
    partial class ProjeAnaRbnForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjeAnaRbnForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnUretimKoduOlustur = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnUretimKodlariListele = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.navbarGrupFormIslemleri = new DevExpress.XtraNavBar.NavBarGroup();
            this.navbarUretimKoduOlusturKaydet = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarUretimKoduOlusturSil = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarUretimKoduOlusturUrunAgaciGoster = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarUretimKoduOlusturMalzemeListesi = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarGrupIsEmirleri = new DevExpress.XtraNavBar.NavBarGroup();
            this.navbarUretimKoduOlusturUretimIsEmri = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarUretimKoduOlusturSatinAlmaIsEmri = new DevExpress.XtraNavBar.NavBarItem();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.toolbarFormManager1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barBtnUretimKoduOlustur,
            this.barBtnUretimKodlariListele});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1267, 158);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // barBtnUretimKoduOlustur
            // 
            this.barBtnUretimKoduOlustur.Caption = "Üretim Kodu Oluştur";
            this.barBtnUretimKoduOlustur.Id = 1;
            this.barBtnUretimKoduOlustur.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnUretimKoduOlustur.ImageOptions.SvgImage")));
            this.barBtnUretimKoduOlustur.Name = "barBtnUretimKoduOlustur";
            this.barBtnUretimKoduOlustur.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnUretimKoduOlustur_ItemClick);
            // 
            // barBtnUretimKodlariListele
            // 
            this.barBtnUretimKodlariListele.Caption = "Üretim Kodları Listele";
            this.barBtnUretimKodlariListele.Id = 2;
            this.barBtnUretimKodlariListele.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnUretimKodlariListele.ImageOptions.SvgImage")));
            this.barBtnUretimKodlariListele.Name = "barBtnUretimKodlariListele";
            this.barBtnUretimKodlariListele.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnUretimKodlariListele_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Satış Siparişleri";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnUretimKoduOlustur);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnUretimKodlariListele);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Satış Bilgileri";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Proje Durumu";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 909);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1267, 24);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // navbarGrupFormIslemleri
            // 
            this.navbarGrupFormIslemleri.Caption = "Form İşlemleri";
            this.navbarGrupFormIslemleri.Expanded = true;
            this.navbarGrupFormIslemleri.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navbarGrupFormIslemleri.ImageOptions.LargeImage")));
            this.navbarGrupFormIslemleri.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navbarGrupFormIslemleri.ImageOptions.SmallImage")));
            this.navbarGrupFormIslemleri.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarUretimKoduOlusturKaydet),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarUretimKoduOlusturSil),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarUretimKoduOlusturUrunAgaciGoster),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarUretimKoduOlusturMalzemeListesi)});
            this.navbarGrupFormIslemleri.Name = "navbarGrupFormIslemleri";
            // 
            // navbarUretimKoduOlusturKaydet
            // 
            this.navbarUretimKoduOlusturKaydet.Caption = "Kaydet";
            this.navbarUretimKoduOlusturKaydet.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navbarUretimKoduOlusturKaydet.ImageOptions.LargeImage")));
            this.navbarUretimKoduOlusturKaydet.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navbarUretimKoduOlusturKaydet.ImageOptions.SmallImage")));
            this.navbarUretimKoduOlusturKaydet.Name = "navbarUretimKoduOlusturKaydet";
            // 
            // navbarUretimKoduOlusturSil
            // 
            this.navbarUretimKoduOlusturSil.Caption = "Satır Sil";
            this.navbarUretimKoduOlusturSil.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navbarUretimKoduOlusturSil.ImageOptions.LargeImage")));
            this.navbarUretimKoduOlusturSil.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navbarUretimKoduOlusturSil.ImageOptions.SmallImage")));
            this.navbarUretimKoduOlusturSil.Name = "navbarUretimKoduOlusturSil";
            // 
            // navbarUretimKoduOlusturUrunAgaciGoster
            // 
            this.navbarUretimKoduOlusturUrunAgaciGoster.Caption = "Ürün Ağacını Göster";
            this.navbarUretimKoduOlusturUrunAgaciGoster.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navbarUretimKoduOlusturUrunAgaciGoster.ImageOptions.LargeImage")));
            this.navbarUretimKoduOlusturUrunAgaciGoster.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navbarUretimKoduOlusturUrunAgaciGoster.ImageOptions.SmallImage")));
            this.navbarUretimKoduOlusturUrunAgaciGoster.Name = "navbarUretimKoduOlusturUrunAgaciGoster";
            // 
            // navbarUretimKoduOlusturMalzemeListesi
            // 
            this.navbarUretimKoduOlusturMalzemeListesi.Caption = "Malzeme Listesini Göster";
            this.navbarUretimKoduOlusturMalzemeListesi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navbarUretimKoduOlusturMalzemeListesi.ImageOptions.LargeImage")));
            this.navbarUretimKoduOlusturMalzemeListesi.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navbarUretimKoduOlusturMalzemeListesi.ImageOptions.SmallImage")));
            this.navbarUretimKoduOlusturMalzemeListesi.Name = "navbarUretimKoduOlusturMalzemeListesi";
            // 
            // navbarGrupIsEmirleri
            // 
            this.navbarGrupIsEmirleri.Caption = "İş Emirleri";
            this.navbarGrupIsEmirleri.Expanded = true;
            this.navbarGrupIsEmirleri.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navbarGrupIsEmirleri.ImageOptions.LargeImage")));
            this.navbarGrupIsEmirleri.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navbarGrupIsEmirleri.ImageOptions.SmallImage")));
            this.navbarGrupIsEmirleri.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarUretimKoduOlusturUretimIsEmri),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarUretimKoduOlusturSatinAlmaIsEmri)});
            this.navbarGrupIsEmirleri.Name = "navbarGrupIsEmirleri";
            // 
            // navbarUretimKoduOlusturUretimIsEmri
            // 
            this.navbarUretimKoduOlusturUretimIsEmri.Caption = "Tasarım İş Emri";
            this.navbarUretimKoduOlusturUretimIsEmri.Name = "navbarUretimKoduOlusturUretimIsEmri";
            // 
            // navbarUretimKoduOlusturSatinAlmaIsEmri
            // 
            this.navbarUretimKoduOlusturSatinAlmaIsEmri.Caption = "Satınalma İş Emri";
            this.navbarUretimKoduOlusturSatinAlmaIsEmri.Name = "navbarUretimKoduOlusturSatinAlmaIsEmri";
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.toolbarFormManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 933);
            // 
            // toolbarFormManager1
            // 
            this.toolbarFormManager1.DockControls.Add(this.barDockControlTop);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlBottom);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlLeft);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlRight);
            this.toolbarFormManager1.Form = this;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.toolbarFormManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1267, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 933);
            this.barDockControlBottom.Manager = this.toolbarFormManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1267, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1267, 0);
            this.barDockControlRight.Manager = this.toolbarFormManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 933);
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "ribbonPage2";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // ProjeAnaRbnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 933);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Name = "ProjeAnaRbnForm";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Proje Yönetim Paneli";
            this.Load += new System.EventHandler(this.ProjeAnaRbnForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem barBtnUretimKoduOlustur;
        private DevExpress.XtraBars.BarButtonItem barBtnUretimKodlariListele;
        private DevExpress.XtraNavBar.NavBarGroup navbarGrupFormIslemleri;
        private DevExpress.XtraNavBar.NavBarItem navbarUretimKoduOlusturKaydet;
        private DevExpress.XtraNavBar.NavBarItem navbarUretimKoduOlusturSil;
        private DevExpress.XtraNavBar.NavBarItem navbarUretimKoduOlusturUrunAgaciGoster;
        private DevExpress.XtraNavBar.NavBarItem navbarUretimKoduOlusturMalzemeListesi;
        private DevExpress.XtraNavBar.NavBarGroup navbarGrupIsEmirleri;
        private DevExpress.XtraNavBar.NavBarItem navbarUretimKoduOlusturUretimIsEmri;
        private DevExpress.XtraNavBar.NavBarItem navbarUretimKoduOlusturSatinAlmaIsEmri;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.ToolbarForm.ToolbarFormManager toolbarFormManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
    }
}