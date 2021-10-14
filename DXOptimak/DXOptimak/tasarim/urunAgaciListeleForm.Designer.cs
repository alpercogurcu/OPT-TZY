namespace DXOptimak.tasarim
{
    partial class urunAgaciListeleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(urunAgaciListeleForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGrupTasarimYonetim = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBtnPDFYukle = new DevExpress.XtraNavBar.NavBarItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.navBtnTasarimdanKopyala = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.navBarControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1172, 745);
            this.splitContainer1.SplitterDistance = 930;
            this.splitContainer1.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(930, 745);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGrupTasarimYonetim;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGrupTasarimYonetim});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBtnPDFYukle,
            this.navBtnTasarimdanKopyala});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 238;
            this.navBarControl1.Size = new System.Drawing.Size(238, 745);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGrupTasarimYonetim
            // 
            this.navBarGrupTasarimYonetim.Caption = "Tasarım Yönetim";
            this.navBarGrupTasarimYonetim.Expanded = true;
            this.navBarGrupTasarimYonetim.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGrupTasarimYonetim.ImageOptions.LargeImage")));
            this.navBarGrupTasarimYonetim.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGrupTasarimYonetim.ImageOptions.SmallImage")));
            this.navBarGrupTasarimYonetim.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBtnPDFYukle),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBtnTasarimdanKopyala)});
            this.navBarGrupTasarimYonetim.Name = "navBarGrupTasarimYonetim";
            // 
            // navBtnPDFYukle
            // 
            this.navBtnPDFYukle.Caption = "PDF Yükle";
            this.navBtnPDFYukle.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBtnPDFYukle.ImageOptions.LargeImage")));
            this.navBtnPDFYukle.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBtnPDFYukle.ImageOptions.SmallImage")));
            this.navBtnPDFYukle.Name = "navBtnPDFYukle";
            this.navBtnPDFYukle.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBtnDosyaYukle_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Dosya Adı";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Dosya Seç";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // navBtnTasarimdanKopyala
            // 
            this.navBtnTasarimdanKopyala.Caption = "Dosyaları Mevcut Tasarımdan Kopyala";
            this.navBtnTasarimdanKopyala.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("tasarimdanKopyala.ImageOptions.LargeImage")));
            this.navBtnTasarimdanKopyala.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("tasarimdanKopyala.ImageOptions.SmallImage")));
            this.navBtnTasarimdanKopyala.Name = "navBtnTasarimdanKopyala";
            this.navBtnTasarimdanKopyala.Visible = false;
            this.navBtnTasarimdanKopyala.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBtnTasarimdanKopyala_LinkClicked);
            // 
            // urunAgaciListeleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 745);
            this.Controls.Add(this.splitContainer1);
            this.Name = "urunAgaciListeleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Ağacı Listele";
            this.Load += new System.EventHandler(this.urunAgaciListeleForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGrupTasarimYonetim;
        private DevExpress.XtraNavBar.NavBarItem navBtnPDFYukle;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraNavBar.NavBarItem navBtnTasarimdanKopyala;
    }
}