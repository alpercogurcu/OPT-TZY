
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DXOptimak
{
    class SQLProcedures
    {
        public static string connectionstring = SQLProcess.connectionstring;


        private static  SqlConnection Bağlan()
        {
            SqlConnection baglanti = new SqlConnection(connectionstring);

            if (baglanti.State != ConnectionState.Open)
            {
                try
                {
                    baglanti.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            
            return baglanti;
        }


     
    }
}
