namespace DXOptimak.depo
{
    partial class DepoRbnAnaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepoRbnAnaForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnProjeTalepListesiGoster = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnYeniTalepOlustur = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnIrsaliyeOlustur = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnIrsaliyeListesi = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.barBtnProjeTalepListesiGoster,
            this.barBtnYeniTalepOlustur,
            this.barBtnIrsaliyeOlustur,
            this.barBtnIrsaliyeListesi});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1066, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barBtnProjeTalepListesiGoster
            // 
            this.barBtnProjeTalepListesiGoster.Caption = "Proje Talep Listesini Göster";
            this.barBtnProjeTalepListesiGoster.Id = 1;
            this.barBtnProjeTalepListesiGoster.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnProjeTalepListesiGoster.ImageOptions.SvgImage")));
            this.barBtnProjeTalepListesiGoster.Name = "barBtnProjeTalepListesiGoster";
            this.barBtnProjeTalepListesiGoster.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnProjeTalepListesiGoster_ItemClick);
            // 
            // barBtnYeniTalepOlustur
            // 
            this.barBtnYeniTalepOlustur.Caption = "Yeni Talep Oluştur";
            this.barBtnYeniTalepOlustur.Enabled = false;
            this.barBtnYeniTalepOlustur.Id = 2;
            this.barBtnYeniTalepOlustur.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnYeniTalepOlustur.ImageOptions.SvgImage")));
            this.barBtnYeniTalepOlustur.Name = "barBtnYeniTalepOlustur";
            // 
            // barBtnIrsaliyeOlustur
            // 
            this.barBtnIrsaliyeOlustur.Caption = "İrsaliye Oluştur";
            this.barBtnIrsaliyeOlustur.Id = 3;
            this.barBtnIrsaliyeOlustur.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnIrsaliyeOlustur.ImageOptions.SvgImage")));
            this.barBtnIrsaliyeOlustur.Name = "barBtnIrsaliyeOlustur";
            this.barBtnIrsaliyeOlustur.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnIrsaliyeOlustur_ItemClick);
            // 
            // barBtnIrsaliyeListesi
            // 
            this.barBtnIrsaliyeListesi.Caption = "İrsaliye Listesi";
            this.barBtnIrsaliyeListesi.Id = 4;
            this.barBtnIrsaliyeListesi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnIrsaliyeListesi.ImageOptions.SvgImage")));
            this.barBtnIrsaliyeListesi.Name = "barBtnIrsaliyeListesi";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Depo Yönetimi";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnYeniTalepOlustur);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnProjeTalepListesiGoster);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Proje Talepleri";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barBtnIrsaliyeOlustur);
            this.ribbonPageGroup2.ItemLinks.Add(this.barBtnIrsaliyeListesi);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Sevk İşlemleri";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 594);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1066, 24);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // DepoRbnAnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 618);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "DepoRbnAnaForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Depo Yönetim Paneli ";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barBtnProjeTalepListesiGoster;
        private DevExpress.XtraBars.BarButtonItem barBtnYeniTalepOlustur;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem barBtnIrsaliyeOlustur;
        private DevExpress.XtraBars.BarButtonItem barBtnIrsaliyeListesi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}