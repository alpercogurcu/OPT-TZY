namespace DXOptimak.tasarim
{
    partial class urunAgaciGosterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(urunAgaciGosterForm));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.list = new DevExpress.XtraTreeList.TreeList();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGrupTasarimYonetim = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBtnPDFGoster = new DevExpress.XtraNavBar.NavBarItem();
            this.navBtnDXFGoster = new DevExpress.XtraNavBar.NavBarItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnRenkDegistir = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.splitContainerControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 43);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(941, 473);
            this.panelControl2.TabIndex = 2;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.list);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(937, 469);
            this.splitContainerControl1.SplitterPosition = 140;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // list
            // 
            this.list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list.Location = new System.Drawing.Point(0, 0);
            this.list.Name = "list";
            this.list.OptionsBehavior.Editable = false;
            this.list.OptionsNavigation.MoveOnEdit = false;
            this.list.Size = new System.Drawing.Size(787, 469);
            this.list.TabIndex = 1;
            this.list.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.list_FocusedNodeChanged);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGrupTasarimYonetim;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGrupTasarimYonetim});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBtnPDFGoster,
            this.navBtnDXFGoster});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControl1.Size = new System.Drawing.Size(140, 469);
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGrupTasarimYonetim
            // 
            this.navBarGrupTasarimYonetim.Caption = "Ürün Ağacı";
            this.navBarGrupTasarimYonetim.Expanded = true;
            this.navBarGrupTasarimYonetim.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGrupTasarimYonetim.ImageOptions.LargeImage")));
            this.navBarGrupTasarimYonetim.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGrupTasarimYonetim.ImageOptions.SmallImage")));
            this.navBarGrupTasarimYonetim.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBtnPDFGoster),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBtnDXFGoster)});
            this.navBarGrupTasarimYonetim.Name = "navBarGrupTasarimYonetim";
            // 
            // navBtnPDFGoster
            // 
            this.navBtnPDFGoster.Caption = "PDF Göster";
            this.navBtnPDFGoster.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBtnPDFGoster.ImageOptions.LargeImage")));
            this.navBtnPDFGoster.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBtnPDFGoster.ImageOptions.SmallImage")));
            this.navBtnPDFGoster.Name = "navBtnPDFGoster";
            this.navBtnPDFGoster.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBtnPDFGoster_LinkClicked);
            // 
            // navBtnDXFGoster
            // 
            this.navBtnDXFGoster.Caption = "DXF Göster";
            this.navBtnDXFGoster.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBtnDXFGoster.ImageOptions.LargeImage")));
            this.navBtnDXFGoster.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBtnDXFGoster.ImageOptions.SmallImage")));
            this.navBtnDXFGoster.Name = "navBtnDXFGoster";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnRenkDegistir);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(941, 43);
            this.panelControl1.TabIndex = 1;
            // 
            // btnRenkDegistir
            // 
            this.btnRenkDegistir.Location = new System.Drawing.Point(12, 9);
            this.btnRenkDegistir.Name = "btnRenkDegistir";
            this.btnRenkDegistir.Size = new System.Drawing.Size(88, 29);
            this.btnRenkDegistir.TabIndex = 0;
            this.btnRenkDegistir.Text = "Renk Değiştir";
            this.btnRenkDegistir.UseVisualStyleBackColor = true;
            this.btnRenkDegistir.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // urunAgaciGosterForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 516);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("urunAgaciGosterForm.IconOptions.LargeImage")));
            this.Name = "urunAgaciGosterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Ağacı Göster / Kaydet";
            this.Load += new System.EventHandler(this.urunAgaciGosterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraTreeList.TreeList list;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnRenkDegistir;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGrupTasarimYonetim;
        private DevExpress.XtraNavBar.NavBarItem navBtnPDFGoster;
        private DevExpress.XtraNavBar.NavBarItem navBtnDXFGoster;
    }
}