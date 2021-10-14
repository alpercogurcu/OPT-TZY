
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

namespace DXOptimak
{

    public partial class anaForm : DevExpress.XtraEditors.XtraForm
    {
        public anaForm()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragDrop += new DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new DragEventHandler(this.Form1_DragEnter);
        }
        private Image picture;
        private Point pictureLocation;
        protected override void OnPaint(PaintEventArgs e)
        {
            // If there is an image and it has a location, 
            // paint it when the Form is repainted.
            base.OnPaint(e);
            if (this.picture != null && this.pictureLocation != Point.Empty)
            {
                e.Graphics.DrawImage(this.picture, this.pictureLocation);
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            AllowDrop = false;
            GC.Collect();
            GC.Collect();
            AllowDrop = true;
            // Handle FileDrop data.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                try
                {
                    // Assign the first image to the picture variable.
                    this.picture = Image.FromFile(files[0]);
                    // Set the picture location equal to the drop point.
                    this.pictureLocation = this.PointToClient(new Point(e.X, e.Y));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            // Handle Bitmap data.
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                try
                {
                    // Create an Image and assign it to the picture variable.
                    this.picture = (Image)e.Data.GetData(DataFormats.Bitmap);
                    // Set the picture location equal to the drop point.
                    this.pictureLocation = this.PointToClient(new Point(e.X, e.Y));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            // Force the form to be redrawn with the image.
            this.Invalidate();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // If the data is a file or a bitmap, display the copy cursor.
            if (e.Data.GetDataPresent(DataFormats.Bitmap) ||
               e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void anaForm_Load(object sender, EventArgs e)
        {
            bool durum = helper.ayar.sutunSiralamalarini_yukle().Result;
        }

        private void tasarimForm_Click(object sender, EventArgs e)
        {
            tasarim.TasarimAnaRbnForm tasarimAnaForm = new tasarim.TasarimAnaRbnForm();
            if (Application.OpenForms["tasarimAnaForm"] == null)
            {
                tasarimAnaForm.Show();
            }
            else
            {
                Application.OpenForms["tasarimAnaForm"].Focus();
            }
        }


        private void anaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Programı kapatmak istediğinize emin misiniz?", "KAPATILIYOR.", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    e.Cancel = true;
                else
                    Environment.Exit(0);
            }
            catch
            {

            }
        }


        private void btnFabrikaTanimlari_Click(object sender, EventArgs e)
        {
            genelTanimlar.GenelTanimlar frmGenelTanimlar = new genelTanimlar.GenelTanimlar();
            frmGenelTanimlar.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            depo.DepoRbnAnaForm depoAnaForm = new depo.DepoRbnAnaForm();
            depoAnaForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            satinalma.SatinalmaRbnAnaForm stnanaform = new satinalma.SatinalmaRbnAnaForm();
            stnanaform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            satinalma.Satinalma_IrsaliyeOlustur irsaliye = new satinalma.Satinalma_IrsaliyeOlustur();
            irsaliye.ShowDialog();
        }

     

        private void schedulerControl1_EditAppointmentFormShowing_1(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {

        }

        private void btnProjeEkibi_Click(object sender, EventArgs e)
        {
            proje.ProjeAnaRbnForm projeanaform = new proje.ProjeAnaRbnForm();
            projeanaform.ShowDialog();
        }
    }
}