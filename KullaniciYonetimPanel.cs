using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;



namespace AracKiralamaUygulaması
{

    public partial class KullaniciYonetimPanel : Form
    {

        private int secilenSatirIndex = -1;

        public KullaniciYonetimPanel()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void VerileriTemizle()
        {
            txtID.Clear();
            txtKullaniciAdi.Clear();
            txtSifre.Clear();
            txtEposta.Clear();
            txtTelefon.Clear();
            cmbRol.SelectedIndex = -1;
        }

        private void KullaniciVerileriniYukle()
        {
            
            using (SqlConnection baglanti = ConnectionManager.GetConnection())
            {
                string query = "SELECT * FROM Kullanicilar";
                SqlDataAdapter da = new SqlDataAdapter(query, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void KullaniciYonetimPanel_Load(object sender, EventArgs e)
        {
            cmbRol.Items.Add("Admin");
            cmbRol.Items.Add("Müşteri");
            cmbRol.SelectedIndex = -1;

            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            try
            {
                AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath);

                using (SqlConnection baglanti = ConnectionManager.GetConnection())
                {
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("SELECT * FROM Kullanicilar", baglanti);
                        SqlDataAdapter da = new SqlDataAdapter(komut);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnPanelCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                secilenSatirIndex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtID.Text = row.Cells["KullaniciID"].Value.ToString();
                txtKullaniciAdi.Text = row.Cells["KullaniciAdi"].Value.ToString();
                txtSifre.Text = row.Cells["Sifre"].Value.ToString();
                txtEposta.Text = row.Cells["Eposta"].Value.ToString();
                txtTelefon.Text = row.Cells["Telefon"].Value.ToString();
                cmbRol.Text = row.Cells["Rol"].Value.ToString();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text) ||
                string.IsNullOrWhiteSpace(txtEposta.Text) ||
                string.IsNullOrWhiteSpace(txtTelefon.Text) ||
                cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!");
                return;
            }

            
            using (SqlConnection baglanti = ConnectionManager.GetConnection())
            {
                baglanti.Open();

                string kontrolQuery = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi AND KullaniciID <> @KullaniciID";
                SqlCommand kontrolCmd = new SqlCommand(kontrolQuery, baglanti);
                kontrolCmd.Parameters.AddWithValue("@KullaniciAdi", txtKullaniciAdi.Text);
                kontrolCmd.Parameters.AddWithValue("@KullaniciID", txtID.Text);

                int ayniKullaniciSayisi = (int)kontrolCmd.ExecuteScalar();

                if (ayniKullaniciSayisi > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı başka bir kullanıcıya ait!");
                    return;
                }

                string updateQuery = "UPDATE Kullanicilar SET KullaniciAdi = @KullaniciAdi, Sifre = @Sifre, Eposta = @Eposta, Telefon = @Telefon, Rol = @Rol WHERE KullaniciID = @KullaniciID";

                SqlCommand cmd = new SqlCommand(updateQuery, baglanti);
                cmd.Parameters.AddWithValue("@KullaniciAdi", txtKullaniciAdi.Text);
                cmd.Parameters.AddWithValue("@Sifre", txtSifre.Text);
                cmd.Parameters.AddWithValue("@Eposta", txtEposta.Text);
                cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text.Replace(" ", ""));
                cmd.Parameters.AddWithValue("@Rol", cmbRol.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@KullaniciID", txtID.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Kullanıcı başarıyla güncellendi.");
                    dataGridView1.Rows[secilenSatirIndex].Cells["KullaniciAdi"].Value = txtKullaniciAdi.Text;
                    dataGridView1.Rows[secilenSatirIndex].Cells["Sifre"].Value = txtSifre.Text;
                    dataGridView1.Rows[secilenSatirIndex].Cells["Eposta"].Value = txtEposta.Text;
                    dataGridView1.Rows[secilenSatirIndex].Cells["Telefon"].Value = txtTelefon.Text;
                    dataGridView1.Rows[secilenSatirIndex].Cells["Rol"].Value = cmbRol.SelectedItem.ToString();
                }
                else
                {
                    MessageBox.Show("Güncelleme başarısız. Lütfen tekrar deneyin.");
                }

                VerileriTemizle();
            }
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            if (secilenSatirIndex == -1)
            {
                MessageBox.Show("Lütfen silinecek bir kullanıcı seçin.");
                return;
            }

            // Yönetici kontrolü
            string kullaniciTuru = dataGridView1.Rows[secilenSatirIndex].Cells["Rol"].Value?.ToString();
            if (kullaniciTuru == "Admin")
            {
                MessageBox.Show("Yönetici rolündeki kullanıcılar silinemez.", "İşlem Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bu kullanıcıyı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection baglanti = ConnectionManager.GetConnection())
                {
                    string deleteQuery = "DELETE FROM Kullanicilar WHERE KullaniciID = @KullaniciID";
                    SqlCommand cmd = new SqlCommand(deleteQuery, baglanti);
                    cmd.Parameters.AddWithValue("@KullaniciID", txtID.Text);

                    try
                    {
                        baglanti.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Kullanıcı başarıyla silindi.");
                            dataGridView1.Rows.RemoveAt(secilenSatirIndex);
                            secilenSatirIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi başarısız. Lütfen tekrar deneyin.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                    VerileriTemizle();
                }
            }
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MessageBox.Show("Seçili kullanıcıyı değiştirmek yerine yeni kullanıcı eklemek istiyorsanız önce seçimden çıkın ya da kutuları temizleyin.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text) ||
                string.IsNullOrWhiteSpace(txtEposta.Text) ||
                string.IsNullOrWhiteSpace(txtTelefon.Text) ||
                cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!");
                return;
            }

            using (SqlConnection baglanti = ConnectionManager.GetConnection())
            {
                baglanti.Open();

                string checkUsername = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi";
                SqlCommand cmdUsername = new SqlCommand(checkUsername, baglanti);
                cmdUsername.Parameters.AddWithValue("@KullaniciAdi", txtKullaniciAdi.Text);
                if ((int)cmdUsername.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten mevcut!");
                    return;
                }

                string checkEmail = "SELECT COUNT(*) FROM Kullanicilar WHERE Eposta = @Eposta";
                SqlCommand cmdEmail = new SqlCommand(checkEmail, baglanti);
                cmdEmail.Parameters.AddWithValue("@Eposta", txtEposta.Text);
                if ((int)cmdEmail.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Bu e-posta adresi zaten kullanımda!");
                    return;
                }

                string checkPhone = "SELECT COUNT(*) FROM Kullanicilar WHERE Telefon = @Telefon";
                SqlCommand cmdPhone = new SqlCommand(checkPhone, baglanti);
                cmdPhone.Parameters.AddWithValue("@Telefon", txtTelefon.Text.Replace(" ", ""));
                if ((int)cmdPhone.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Bu telefon numarası zaten kullanımda!");
                    return;
                }

                string insertQuery = "INSERT INTO Kullanicilar (KullaniciAdi, Sifre, Eposta, Telefon, Rol) VALUES (@KullaniciAdi, @Sifre, @Eposta, @Telefon, @Rol)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, baglanti);
                insertCmd.Parameters.AddWithValue("@KullaniciAdi", txtKullaniciAdi.Text);
                insertCmd.Parameters.AddWithValue("@Sifre", txtSifre.Text);
                insertCmd.Parameters.AddWithValue("@Eposta", txtEposta.Text);
                insertCmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text.Replace(" ", ""));
                insertCmd.Parameters.AddWithValue("@Rol", cmbRol.SelectedItem.ToString());

                int rowsAffected = insertCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Kullanıcı başarıyla eklendi.");
                    KullaniciVerileriniYukle();
                    VerileriTemizle(); // <<< burada olmalı
                }
                else
                {
                    MessageBox.Show("Kullanıcı eklenirken bir hata oluştu.");
                }
            }
        }

        private void txtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            string telefon = txtTelefon.Text;
            telefon = new string(telefon.Where(char.IsDigit).ToArray());

            if (telefon.Length > 10)
            {
                telefon = telefon.Substring(0, 10);
            }

            if (telefon.Length == 10)
            {
                txtTelefon.Text = telefon.Substring(0, 3) + " " + telefon.Substring(3, 3) + " " + telefon.Substring(6, 4);
            }
            else if (telefon.Length >= 4)
            {
                txtTelefon.Text = telefon.Substring(0, 3) + " " + telefon.Substring(3);
            }
            else
            {
                txtTelefon.Text = telefon;
            }

            txtTelefon.SelectionStart = txtTelefon.Text.Length;
        }
    }
}
