using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DXOptimak.satinalma
{
    class IrsaliyeClass
    {
        private static SqlConnection baglanti = new SqlConnection(SQLProcess.connectionstring);

        public static DataTable dtIrsaliyeDetayBosTablo()
        {
            if (baglanti.State != ConnectionState.Open)
                baglanti.Open();

         DataTable IrsaliyeDetaybosTablo = new DataTable();

        //      DataTable IrsaliyeDetaybosTablo = new DataTable();
        SqlCommand bosTabloCek = new SqlCommand("select * from irsaliye_IrsaliyeDetay where id = -1",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(bosTabloCek);
            da.Fill(IrsaliyeDetaybosTablo);

            return IrsaliyeDetaybosTablo;
          
        }

    }
}
