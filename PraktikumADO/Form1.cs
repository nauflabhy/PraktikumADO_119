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
                Koneksi();
                conn.Open();

                MessageBox.Show("Koneksi ke database berhasil");

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHitungMhs_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "SELECT COUNT(*) FROM Mahasiswa";

                cmd = new SqlCommand(query, conn);

                int jumlah = (int)cmd.ExecuteScalar();

                txtHasil.Text = jumlah.ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Renamed to match the Designer registration: btnHitungMk_Click (lowercase k)
        private void btnHitungMk_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "SELECT COUNT(*) FROM MataKuliah";

                cmd = new SqlCommand(query, conn);

                int jumlah = (int)cmd.ExecuteScalar();

                txtHasil.Text = jumlah.ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "UPDATE Mahasiswa SET Alamat='Yogyakarta' WHERE NIM='23110100001'";

                cmd = new SqlCommand(query, conn);

                int hasil = cmd.ExecuteNonQuery();

                MessageBox.Show("Jumlah baris terpengaruh : " + hasil);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHitungDosen_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "SELECT COUNT(*) FROM Dosen";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int jumlah = Convert.ToInt32(cmd.ExecuteScalar());
                    txtHasil.Text = jumlah.ToString();

                    MessageBox.Show($"Jumlah dosen saat ini: {jumlah} orang",
                                    "Hasil Hitung",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung jumlah dosen:\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnUpdateSKS_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = @"UPDATE MataKuliah 
                         SET SKS = 4 
                         WHERE KodeMK = 'IF210101'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Update berhasil!\n{rowsAffected} mata kuliah telah diubah SKS menjadi 4.",
                                        "Sukses Update",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Tidak ada mata kuliah dengan KodeMK 'IF210101' yang ditemukan.",
                                        "Informasi",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal melakukan update SKS:\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnInsertProdi_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi();
                conn.Open();

                string query = "INSERT INTO ProgramStudi (KodeProdi, NamaProdi) VALUES ('MI01', 'Manajemen Informatika')";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Insert berhasil!\n{rowsAffected} program studi baru telah ditambahkan.",
                                        "Sukses Insert",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Insert gagal (mungkin duplikat primary key atau error lain).",
                                        "Peringatan",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menambahkan program studi:\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
