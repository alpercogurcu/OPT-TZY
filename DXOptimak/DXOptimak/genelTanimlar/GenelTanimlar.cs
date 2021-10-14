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

namespace DXOptimak.genelTanimlar
{
    public partial class GenelTanimlar : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public GenelTanimlar()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navigationFrame1.SelectedPage = pageKullaniciEkle;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            navigationFrame1.SelectedPage = pageKullaniciListesi;


        }


        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        /*  void navBarControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
{
navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
}
void barButtonNavigation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
{
int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
navBarControl.ActiveGroup = navBarControl.Groups[barItemIndex];
}*/
    }
}