using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Data;

namespace DXOptimak.tasarim
{
    class ClassDosyaIslemleri
    {






        public static class NetworkShare
        {
            /// <summary>
            /// Connects to the remote share
            /// </summary>
            /// <returns>Null if successful, otherwise error message.</returns>
            public static string ConnectToShare(string uri, string username, string password)
            {
                //Create netresource and point it at the share
                NETRESOURCE nr = new NETRESOURCE();
                nr.dwType = RESOURCETYPE_DISK;
                nr.lpRemoteName = uri;

                //Create the share
                int ret = WNetUseConnection(IntPtr.Zero, nr, password, username, 0, null, null, null);

                //Check for errors
                if (ret == NO_ERROR)
                    return null;
                else
                    return GetError(ret);
            }

            /// <summary>
            /// Remove the share from cache.
            /// </summary>
            /// <returns>Null if successful, otherwise error message.</returns>
            public static string DisconnectFromShare(string uri, bool force)
            {
                //remove the share
                int ret = WNetCancelConnection(uri, force);

                //Check for errors
                if (ret == NO_ERROR)
                    return null;
                else
                    return GetError(ret);
            }

            #region P/Invoke Stuff
            [DllImport("Mpr.dll")]
            private static extern int WNetUseConnection(
                IntPtr hwndOwner,
                NETRESOURCE lpNetResource,
                string lpPassword,
                string lpUserID,
                int dwFlags,
                string lpAccessName,
                string lpBufferSize,
                string lpResult
                );

            [DllImport("Mpr.dll")]
            private static extern int WNetCancelConnection(
                string lpName,
                bool fForce
                );

            [StructLayout(LayoutKind.Sequential)]
            private class NETRESOURCE
            {
                public int dwScope = 0;
                public int dwType = 0;
                public int dwDisplayType = 0;
                public int dwUsage = 0;
                public string lpLocalName = "";
                public string lpRemoteName = "";
                public string lpComment = "";
                public string lpProvider = "";
            }

            #region Consts
            const int RESOURCETYPE_DISK = 0x00000001;
            const int CONNECT_UPDATE_PROFILE = 0x00000001;
            #endregion

            #region Errors
            const int NO_ERROR = 0;

            const int ERROR_ACCESS_DENIED = 5;
            const int ERROR_ALREADY_ASSIGNED = 85;
            const int ERROR_BAD_DEVICE = 1200;
            const int ERROR_BAD_NET_NAME = 67;
            const int ERROR_BAD_PROVIDER = 1204;
            const int ERROR_CANCELLED = 1223;
            const int ERROR_EXTENDED_ERROR = 1208;
            const int ERROR_INVALID_ADDRESS = 487;
            const int ERROR_INVALID_PARAMETER = 87;
            const int ERROR_INVALID_PASSWORD = 1216;
            const int ERROR_MORE_DATA = 234;
            const int ERROR_NO_MORE_ITEMS = 259;
            const int ERROR_NO_NET_OR_BAD_PATH = 1203;
            const int ERROR_NO_NETWORK = 1222;
            const int ERROR_SESSION_CREDENTIAL_CONFLICT = 1219;

            const int ERROR_BAD_PROFILE = 1206;
            const int ERROR_CANNOT_OPEN_PROFILE = 1205;
            const int ERROR_DEVICE_IN_USE = 2404;
            const int ERROR_NOT_CONNECTED = 2250;
            const int ERROR_OPEN_FILES = 2401;

            private struct ErrorClass
            {
                public int num;
                public string message;
                public ErrorClass(int num, string message)
                {
                    this.num = num;
                    this.message = message;
                }
            }

            private static ErrorClass[] ERROR_LIST = new ErrorClass[] {
        new ErrorClass(ERROR_ACCESS_DENIED, "Error: Access Denied"),
        new ErrorClass(ERROR_ALREADY_ASSIGNED, "Error: Already Assigned"),
        new ErrorClass(ERROR_BAD_DEVICE, "Error: Bad Device"),
        new ErrorClass(ERROR_BAD_NET_NAME, "Error: Bad Net Name"),
        new ErrorClass(ERROR_BAD_PROVIDER, "Error: Bad Provider"),
        new ErrorClass(ERROR_CANCELLED, "Error: Cancelled"),
        new ErrorClass(ERROR_EXTENDED_ERROR, "Error: Extended Error"),
        new ErrorClass(ERROR_INVALID_ADDRESS, "Error: Invalid Address"),
        new ErrorClass(ERROR_INVALID_PARAMETER, "Error: Invalid Parameter"),
        new ErrorClass(ERROR_INVALID_PASSWORD, "Error: Invalid Password"),
        new ErrorClass(ERROR_MORE_DATA, "Error: More Data"),
        new ErrorClass(ERROR_NO_MORE_ITEMS, "Error: No More Items"),
        new ErrorClass(ERROR_NO_NET_OR_BAD_PATH, "Error: No Net Or Bad Path"),
        new ErrorClass(ERROR_NO_NETWORK, "Error: No Network"),
        new ErrorClass(ERROR_BAD_PROFILE, "Error: Bad Profile"),
        new ErrorClass(ERROR_CANNOT_OPEN_PROFILE, "Error: Cannot Open Profile"),
        new ErrorClass(ERROR_DEVICE_IN_USE, "Error: Device In Use"),
        new ErrorClass(ERROR_EXTENDED_ERROR, "Error: Extended Error"),
        new ErrorClass(ERROR_NOT_CONNECTED, "Error: Not Connected"),
        new ErrorClass(ERROR_OPEN_FILES, "Error: Open Files"),
        new ErrorClass(ERROR_SESSION_CREDENTIAL_CONFLICT, "Error: Credential Conflict"),
    };

            private static string GetError(int errNum)
            {
                foreach (ErrorClass er in ERROR_LIST)
                {
                    if (er.num == errNum) return er.message;
                }
                return "Error: Unknown, " + errNum;
            }
            #endregion

            #endregion
        }







        public static string dosyaIp = "192.168.1.203";
        public static string dosyaERP = @"\\192.168.1.203\ERP";



        public static string StringReplace(string text)
        {
            text = text.Replace("İ", "I");
            text = text.Replace("ı", "i");
            text = text.Replace("Ğ", "G");
            text = text.Replace("ğ", "g");
            text = text.Replace("Ö", "O");
            text = text.Replace("ö", "o");
            text = text.Replace("Ü", "U");
            text = text.Replace("ü", "u");
            text = text.Replace("Ş", "S");
            text = text.Replace("ş", "s");
            text = text.Replace("Ç", "C");
            text = text.Replace("ç", "c");
            text = text.Replace(" ", "_");
            return text;
        }

        public static bool tasarimPDFYukle(string tasarimadi, string[] kaynakyolu, string[] kaynakAdi)
        {
            bool durum = false;
            try
            {
             
          //      NetworkShare.DisconnectFromShare(dosyaERP, true); //Remove this line
                NetworkShare.ConnectToShare(dosyaERP, "erpp", "Erpuser+-1"); //Connect with the new credentials

                if (!Directory.Exists(dosyaERP + "\\tasarim"))
                {
                    Directory.CreateDirectory(dosyaERP + "\\tasarim");
                }

                if (!Directory.Exists(dosyaERP + "\\tasarim\\" + tasarimadi))
                {
                    Directory.CreateDirectory(dosyaERP + "\\tasarim\\" + tasarimadi);
                }


                for (int i = 0; i < kaynakyolu.Length; i++)
                {
                    File.Copy(kaynakyolu[i], dosyaERP + "\\tasarim\\" + tasarimadi + "\\" + StringReplace(kaynakAdi[i]), true);
                    File.SetAttributes(dosyaERP + "\\tasarim\\" + tasarimadi + "\\" + kaynakAdi[i], FileAttributes.Normal);
                    durum = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "---" + ex.StackTrace);
            }

            return durum;
        }

        public static bool uretimPDFYukle(string tasarimadi, string[] kaynakyolu, string[] kaynakAdi)
        {
            bool durum = false;
            try
            {

                //      NetworkShare.DisconnectFromShare(dosyaERP, true); //Remove this line
                NetworkShare.ConnectToShare(dosyaERP, "erpp", "Erpuser+-1"); //Connect with the new credentials

                if (!Directory.Exists(dosyaERP + "\\uretim"))
                {
                    Directory.CreateDirectory(dosyaERP + "\\uretim");
                }

                if (!Directory.Exists(dosyaERP + "\\uretim\\" + tasarimadi))
                {
                    Directory.CreateDirectory(dosyaERP + "\\uretim\\" + tasarimadi);
                }


                for (int i = 0; i < kaynakyolu.Length; i++)
                {

                    File.Copy(kaynakyolu[i], dosyaERP + "\\uretim\\" + tasarimadi + "\\" + kaynakAdi[i], true);
                    File.SetAttributes(dosyaERP + "\\uretim\\" + tasarimadi + "\\" + kaynakAdi[i], FileAttributes.Normal);
                    durum = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "---" + ex.StackTrace);
            }

            return durum;
        }


        public static bool uretimDosyaKopyala(string tasarimadi, string musteri, string uretimkodu, string hatkodu, string siparis_id)
        {
            bool durum = false;
            try
            {

                //      NetworkShare.DisconnectFromShare(dosyaERP, true); //Remove this line
                NetworkShare.ConnectToShare(dosyaERP, "erpp", "Erpuser+-1"); //Connect with the new credentials


                if (!Directory.Exists(dosyaERP + "\\tasarim\\" + tasarimadi))
                {
                    MessageBox.Show("Bu ürün ağacının tasarım dosyasına herhangi bir içerik yüklenmemiş. Klasör Bulunamadı.");

                    return false;

                }

             


                if (!Directory.Exists(dosyaERP + "\\uretim"))
                {
                    Directory.CreateDirectory(dosyaERP + "\\uretim");
                }

                if (!Directory.Exists(dosyaERP + "\\uretim\\" + musteri))
                {
                    Directory.CreateDirectory(dosyaERP + "\\uretim\\" + musteri);
                }

                if (!Directory.Exists(dosyaERP + "\\uretim\\" + musteri + "\\" + hatkodu))
                {
                    Directory.CreateDirectory(dosyaERP + "\\uretim\\" + musteri + "\\" + hatkodu);
                }

                if (!Directory.Exists(dosyaERP + "\\uretim\\" + musteri + "\\" + hatkodu + "\\"+ uretimkodu +"-" + siparis_id ))
                {
                    Directory.CreateDirectory(dosyaERP + "\\uretim\\" + musteri + "\\" + hatkodu + "\\" + uretimkodu + "-" + siparis_id);
                }

                var diKaynak = new DirectoryInfo(dosyaERP + "\\tasarim\\" + tasarimadi);

                foreach (FileInfo dosya in diKaynak.GetFiles())
                {                 
                    dosya.CopyTo(dosyaERP + "\\uretim\\" + musteri + "\\" + hatkodu + "\\" + uretimkodu + "-" + siparis_id + "\\"+ dosya.Name, true);
                    
                }

                return true;





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "---" + ex.StackTrace);
            }

            return durum;
        }

        /*
        public static DataTable tasarimAdiPdfGetir(string tasarimadi)
        {
            NetworkShare.ConnectToShare(dosyaERP, "erpp", "Erpuser+-1"); //Connect with the new credentials

             DataTable dt = new DataTable();

            if (Directory.Exists(dosyaERP + "\\tasarim\\" + tasarimadi))
            {
                string[] dosyalar = Directory.GetFiles(dosyaERP + "\\tasarim\\" + tasarimadi);


                foreach (string dosya in dosyalar)
                {
                    MessageBox.Show(dosya);
                }
            }

            return dt;

        }*/

        public static void parcaAdiPdfAc(string tasarimadi, string parcaAdi)
        {
            NetworkShare.ConnectToShare(dosyaERP, "erpp", "Erpuser+-1"); //Connect with the new credentials

            if (Directory.Exists(dosyaERP + "\\tasarim\\" + tasarimadi))
            {
                if (File.Exists(dosyaERP + "\\tasarim\\" + tasarimadi + "\\" + parcaAdi))
                {
                    System.Diagnostics.Process.Start(dosyaERP + "\\tasarim\\" + tasarimadi + "\\" + parcaAdi);

                }
                else
                {
                    MessageBox.Show("PDF bulunamadı.");
                }

            }

        }
    }
}
