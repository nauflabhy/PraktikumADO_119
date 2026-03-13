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

        private void btnHitungMhs_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();           // panggil method koneksi yang sudah dibuat sebelumnya
                conn.Open();

                string query = "SELECT COUNT(*) FROM Mahasiswa";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int jumlah = (int)cmd.ExecuteScalar();
                    txtHasil.Text = jumlah.ToString();
                }

                conn.Close();

                // Optional: beri feedback ke user
                MessageBox.Show($"Jumlah mahasiswa: {txtHasil.Text} orang",
                                "Informasi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan:\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnHitungMK_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();           // panggil method koneksi yang sudah ada
                conn.Open();

                string query = "SELECT COUNT(*) FROM MataKuliah";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int jumlah = Convert.ToInt32(cmd.ExecuteScalar());
                    txtHasil.Text = jumlah.ToString();
                }

                conn.Close();

                // Optional: tampilkan pesan sukses (bisa dihapus jika tidak perlu)
                MessageBox.Show($"Jumlah mata kuliah: {txtHasil.Text} mata kuliah",
                                "Informasi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan:\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
