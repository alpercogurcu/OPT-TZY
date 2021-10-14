using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DXOptimak.tasarim
{
    public partial class SqlTest : Form
    {
        public SqlTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(textBox2.Text);

                conn.Open();
                MessageBox.Show("Bağlantı oke");

                SqlCommand cmd = new SqlCommand(textBox1.Text, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SqlTest_Load(object sender, EventArgs e)
        {
            textBox2.Text = SQLProcess.connectionstring;
        }

        private void barCodeControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
