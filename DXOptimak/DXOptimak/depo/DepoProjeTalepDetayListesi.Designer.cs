namespace DXOptimak.depo
{
    partial class DepoProjeTalepDetayListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepoProjeTalepDetayListesi));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navbarGrupFormIslemleri = new DevExpress.XtraNavBar.NavBarGroup();
            this.navbarSatinalma = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarUretimIsEmri = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarSatinAlmaIsEmri = new DevExpress.XtraNavBar.NavBarItem();
            this.navbarTasarimIsEmri = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
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
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gridControl1.Size = new System.Drawing.Size(915, 654);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.BeepOnError = true;
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repositoryItemTextEdit1_EditValueChanging);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1115, 654);
            this.splitContainerControl1.SplitterPosition = 190;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navbarGrupFormIslemleri;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navbarGrupFormIslemleri});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navbarSatinalma,
            this.navbarUretimIsEmri,
            this.navbarSatinAlmaIsEmri,
            this.navbarTasarimIsEmri});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 190;
            this.navBarControl1.Size = new System.Drawing.Size(190, 654);
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
            new DevExpress.XtraNavBar.NavBarItemLink(this.navbarSatinalma)});
            this.navbarGrupFormIslemleri.Name = "navbarGrupFormIslemleri";
            // 
            // navbarSatinalma
            // 
            this.navbarSatinalma.Caption = "Çıkış İrsaliyesi Oluştur";
            this.navbarSatinalma.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navbarSatinalma.ImageOptions.LargeImage")));
            this.navbarSatinalma.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navbarSatinalma.ImageOptions.SmallImage")));
            this.navbarSatinalma.Name = "navbarSatinalma";
            this.navbarSatinalma.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navbarSatinalma_LinkClicked);
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
            // DepoProjeTalepDetayListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 654);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "DepoProjeTalepDetayListesi";
            this.Text = "DepoProjeTalepDetayListesi";
            this.Load += new System.EventHandler(this.DepoProjeTalepDetayListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
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
        private DevExpress.XtraNavBar.NavBarItem navbarSatinalma;
        private DevExpress.XtraNavBar.NavBarItem navbarUretimIsEmri;
        private DevExpress.XtraNavBar.NavBarItem navbarSatinAlmaIsEmri;
        private DevExpress.XtraNavBar.NavBarItem navbarTasarimIsEmri;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}