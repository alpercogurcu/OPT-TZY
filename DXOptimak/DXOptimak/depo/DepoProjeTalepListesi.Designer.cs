namespace DXOptimak.depo
{
    partial class DepoProjeTalepListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepoProjeTalepListesi));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navbarGrupFormIslemleri = new DevExpress.XtraNavBar.NavBarGroup();
            this.navbarDepoIslemBitir = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarUrunAgaciGoster = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarMalzemeListesi = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarUretimIsEmri = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarSatinAlmaIsEmri = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarTasarimIsEmri = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(750, 681);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(925, 681);
            this.splitContainerControl1.SplitterPosition = 165;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navbarGrupFormIslemleri;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navbarGrupFormIslemleri});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navbarDepoIslemBitir,
            this.navbarUrunAgaciGoster,
            this.navbarMalzemeListesi,
            this.navbarUretimIsEmri,
            this.navbarSatinAlmaIsEmri,
            this.navbarTasarimIsEmri});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 165;
            this.navBarControl1.Size = new System.Drawing.Size(165, 681);
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navbarGrupFormIslemleri
            // 
            this.navbarGrupFormIslemleri.Caption = "Form İşlemleri";
            this.navbarGrupFormIslemleri.Expanded = true;
            this.navbarGrupFormIslemleri.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navbarGrupFormIslemleri.ImageOptions.LargeImage")));
            this.navbarGrupFormIslemleri.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navbarGrupFormIslemleri.ImageOptions.SmallImage")));
            this.navbarGrupFormIslemleri.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarDepoIslemBitir),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarUrunAgaciGoster),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarMalzemeListesi)});
            this.navbarGrupFormIslemleri.Name = "navbarGrupFormIslemleri";
            // 
            // navbarDepoIslemBitir
            // 
            this.navbarDepoIslemBitir.Caption = "İşlem Bitir";
            this.navbarDepoIslemBitir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navbarDepoTransfer.ImageOptions.LargeImage")));
            this.navbarDepoIslemBitir.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navbarDepoTransfer.ImageOptions.SmallImage")));
            this.navbarDepoIslemBitir.Name = "navbarDepoIslemBitir";
            this.navbarDepoIslemBitir.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navbarDepoIslemBitir_LinkClicked);
            // 
            // navbarUrunAgaciGoster
            // 
            this.navbarUrunAgaciGoster.Caption = "Ürün Ağacını Göster";
            this.navbarUrunAgaciGoster.Enabled = false;
            this.navbarUrunAgaciGoster.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navbarUrunAgaciGoster.ImageOptions.LargeImage")));
            this.navbarUrunAgaciGoster.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navbarUrunAgaciGoster.ImageOptions.SmallImage")));
            this.navbarUrunAgaciGoster.Name = "navbarUrunAgaciGoster";
            // 
            // navbarMalzemeListesi
            // 
            this.navbarMalzemeListesi.Caption = "Malzeme Listesini Göster";
            this.navbarMalzemeListesi.Enabled = false;
            this.navbarMalzemeListesi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navbarMalzemeListesi.ImageOptions.LargeImage")));
            this.navbarMalzemeListesi.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navbarMalzemeListesi.ImageOptions.SmallImage")));
            this.navbarMalzemeListesi.Name = "navbarMalzemeListesi";
            // 
            // navbarUretimIsEmri
            // 
            this.navbarUretimIsEmri.Caption = "Üretim İş Emri";
            this.navbarUretimIsEmri.Name = "navbarUretimIsEmri";
            this.navbarUretimIsEmri.Visible = false;
            // 
            // navbarSatinAlmaIsEmri
            // 
            this.navbarSatinAlmaIsEmri.Caption = "Satınalma İş Emri";
            this.navbarSatinAlmaIsEmri.Name = "navbarSatinAlmaIsEmri";
            // 
            // navbarTasarimIsEmri
            // 
            this.navbarTasarimIsEmri.Caption = "Tasarım İş Emri ";
            this.navbarTasarimIsEmri.Name = "navbarTasarimIsEmri";
            // 
            // DepoProjeTalepListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 681);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "DepoProjeTalepListesi";
            this.Text = "DepoProjeTalepListesi";
            this.Load += new System.EventHandler(this.DepoProjeTalepListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navbarGrupFormIslemleri;
        private DevExpress.XtraNavBar.NavBarItem navbarDepoIslemBitir;
        private DevExpress.XtraNavBar.NavBarItem navbarUrunAgaciGoster;
        private DevExpress.XtraNavBar.NavBarItem navbarMalzemeListesi;
        private DevExpress.XtraNavBar.NavBarItem navbarUretimIsEmri;
        private DevExpress.XtraNavBar.NavBarItem navbarSatinAlmaIsEmri;
        private DevExpress.XtraNavBar.NavBarItem navbarTasarimIsEmri;
    }
}