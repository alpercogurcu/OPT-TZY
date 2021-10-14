using DevExpress.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars.ToastNotifications;
using System.Xml;
using System.Runtime.InteropServices;

namespace DXOptimak
{
    public partial class loginForm : DevExpress.XtraEditors.XtraForm
    {
        public loginForm()
        {
            InitializeComponent();
        }

        anaForm anasayfa = new anaForm();
       // kullanici.AnaForm anasayfa = new kullanici.AnaForm();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text.Length > 0 && textEdit2.Text.Length > 0)
            {
                if (kullanicibilgileri.Login(textEdit1.Text, textEdit2.Text, checkBox1.Checked))
                {

                    this.Hide();
                    anasayfa.Show();
                }

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya parola giriniz.");
            }
        }

      




        private void loginForm_Load(object sender, EventArgs e)
        {


            if (!ShellHelper.IsApplicationShortcutExist("Optimak ERP"))
            {
                ShellHelper.TryCreateShortcut(
                    applicationId: toastNotificationsManager1.ApplicationId,
                    name: "Optimak ERP");
                //restart the app
                Application.Restart();
            }
            
            bool durum = helper.ayar.ayar_yukle().Result;
          
        }

        private void loginForm_Shown(object sender, EventArgs e)
        {
            try
            {


                if (kullanicibilgileri.tokenCheck(Properties.Settings.Default["kullaniciadi"].ToString(), Properties.Settings.Default["token"].ToString()))
                {
                
                    timer1.Start();
                    this.Hide();
                    anasayfa.Show();
                }


            }
            catch
            {

            }
        }
  
        private void timer1_Tick(object sender, EventArgs e)
        {
            ToastNotification mng = new ToastNotification();
            mng.Body = "Eee";
            mng.Body2 = "CCC";
            mng.Header = "HHH";
            mng.ID = "aaae";
            mng.BeginUpdate();
         //   toastNotificationsManager1.ShowNotification(mng);
      //   MessageBox.Show(mng.ID.ToString());
           // toastNotificationsManager1.Notifications[0].Body = "Aaa" + aaa.ToString(); ;
         //   toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0].ID);

         
        }

        private void toastNotificationsManager1_Activated(object sender, DevExpress.XtraBars.ToastNotifications.ToastNotificationEventArgs e)
        {
            MessageBox.Show("Tıkladı: "+ e.NotificationID.ToString());

            switch (e.NotificationID.ToString())
            {
                case "57ca1e62-73bf-40a2-a4be-f594c9add1a3":
                    
                    break;
            }
        }

        private void toastNotificationsManager1_UpdateToastContent(object sender, UpdateToastContentEventArgs e)
        {
         
        }
    }
}
