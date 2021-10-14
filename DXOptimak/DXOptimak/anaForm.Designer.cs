namespace DXOptimak
{
    partial class anaForm
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
            this.tasarimForm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnProjeEkibi = new System.Windows.Forms.Button();
            this.btnFabrikaTanimlari = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tasarimForm
            // 
            this.tasarimForm.Location = new System.Drawing.Point(348, 249);
            this.tasarimForm.Name = "tasarimForm";
            this.tasarimForm.Size = new System.Drawing.Size(185, 60);
            this.tasarimForm.TabIndex = 0;
            this.tasarimForm.Text = "Tasarım";
            this.tasarimForm.UseVisualStyleBackColor = true;
            this.tasarimForm.Click += new System.EventHandler(this.tasarimForm_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 60);
            this.button1.TabIndex = 1;
            this.button1.Text = "Satınalma";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnProjeEkibi
            // 
            this.btnProjeEkibi.Location = new System.Drawing.Point(348, 183);
            this.btnProjeEkibi.Name = "btnProjeEkibi";
            this.btnProjeEkibi.Size = new System.Drawing.Size(185, 60);
            this.btnProjeEkibi.TabIndex = 5;
            this.btnProjeEkibi.Text = "Proje Ekibi";
            this.btnProjeEkibi.UseVisualStyleBackColor = true;
            this.btnProjeEkibi.Click += new System.EventHandler(this.btnProjeEkibi_Click);
            // 
            // btnFabrikaTanimlari
            // 
            this.btnFabrikaTanimlari.Location = new System.Drawing.Point(542, 461);
            this.btnFabrikaTanimlari.Name = "btnFabrikaTanimlari";
            this.btnFabrikaTanimlari.Size = new System.Drawing.Size(185, 60);
            this.btnFabrikaTanimlari.TabIndex = 6;
            this.btnFabrikaTanimlari.Text = "Genel Tanımlar";
            this.btnFabrikaTanimlari.UseVisualStyleBackColor = true;
            this.btnFabrikaTanimlari.Click += new System.EventHandler(this.btnFabrikaTanimlari_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(542, 395);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(185, 60);
            this.button6.TabIndex = 7;
            this.button6.Text = "Depo";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(348, 117);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(185, 60);
            this.button7.TabIndex = 8;
            this.button7.Text = "İrsaliye";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(572, 51);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(175, 60);
            this.button9.TabIndex = 10;
            this.button9.Text = "Stok Hareketleri";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(572, 128);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(175, 65);
            this.button10.TabIndex = 11;
            this.button10.Text = "Stok Kartları";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // anaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 576);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnFabrikaTanimlari);
            this.Controls.Add(this.btnProjeEkibi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tasarimForm);
            this.Name = "anaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anasayfa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.anaForm_FormClosing);
            this.Load += new System.EventHandler(this.anaForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tasarimForm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnProjeEkibi;
        private System.Windows.Forms.Button btnFabrikaTanimlari;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
    }
}