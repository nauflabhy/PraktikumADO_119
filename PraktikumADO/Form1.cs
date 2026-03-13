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

namespace PraktikumADO
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        private void Koneksi()
        {
            conn = new SqlConnection(
                "Data Source=NAUFAL\\NZO2;" +
                "Initial Catalog=DBAkademikADO;" +
                "Integrated Security=True"
            );
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();           // panggil method yang membuat objek connection
                conn.Open();

                MessageBox.Show("Koneksi ke database berhasil!", "Informasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                conn.Close();        // baiknya ditutup setelah tes koneksi selesai
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal!\n\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
