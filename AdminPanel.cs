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
using AracKiralamaUygulaması;


namespace AracKiralamaUygulaması
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        private void TextBoxTemizle()
        {
            txtID.Clear();
            txtMarka.Clear();
            txtModel.Clear();
            cmbYil.SelectedIndex = -1; // Yıl combobox'ını temizle
            cmbVites.SelectedIndex = -1;
            cmbYakit.SelectedIndex = -1;
            txtKm.Clear();
            txtRenk.Clear();
            txtPlaka.Clear();
            txtUcret.Clear();
            txtDurum.Clear();
            txtLink.Clear();
            pictureBox1.Image = null; // Resmi temizle
        }
        private bool PlakaZatenVar(string plaka, int? aracID = null)
        {
            using (SqlConnection baglanti = ConnectionManager.GetConnection())
            {
                baglanti.Open();
                string sql = "SELECT COUNT(*) FROM Araclar WHERE Plaka = @Plaka";

                if (aracID.HasValue)
                {
                    // Güncellemede aynı ID'li kaydı hariç tut
                    sql += " AND AracID != @AracID";
                }

                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@Plaka", plaka);

                if (aracID.HasValue)
                {
                    komut.Parameters.AddWithValue("@AracID", aracID.Value);
                }

                int count = (int)komut.ExecuteScalar();
                return count > 0;
            }
        }

        private void btnAracDurum_Click(object sender, EventArgs e)
        {
            try
            {
                // Bağlantıyı aç
                using (SqlConnection baglanti = ConnectionManager.GetConnection())
                {
                    baglanti.Open();

                    // Araclar tablosundaki tüm verileri çekecek sorgu
                    SqlCommand komut = new SqlCommand("SELECT * FROM Araclar", baglanti);

                    // Verileri çekmek için SqlDataAdapter kullanıyoruz
                    SqlDataAdapter da = new SqlDataAdapter(komut);

                    // DataTable oluştur
                    DataTable dt = new DataTable();

                    // Verileri DataTable'a doldur
                    da.Fill(dt);

                    // DataGridView'e veri atama
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            for (int yil = DateTime.Now.Year; yil >= 2010; yil--)
            {
                cmbYil.Items.Add(yil.ToString());
            }

            dataGridView1.ClearSelection(); // Form yüklendiğinde seçimi kaldır
            btnGuncelle.Enabled = false; // İlk başta pasif başlasın


            cmbYakit.Items.Clear(); // Önce varsa eski verileri temizle
            cmbYakit.Items.Add("Benzin");
            cmbYakit.Items.Add("Dizel");
            cmbYakit.Items.Add("Elektrik");


            cmbVites.Items.Clear(); // Önce varsa eski verileri temizle
            cmbVites.Items.Add("Otomatik");
            cmbVites.Items.Add("Manuel");
            

            // İstersen ilk seçili öğeyi de ayarlayabilirsin:
            cmbYakit.SelectedIndex = -1; // Hiçbirini seçme

            try
            {
                // Bağlantıyı aç
                using (SqlConnection baglanti = ConnectionManager.GetConnection())
                {   
                    baglanti.Open();

                    // Araclar tablosundaki tüm verileri çekecek sorgu
                    SqlCommand komut = new SqlCommand("SELECT * FROM Araclar", baglanti);

                    // Verileri çekmek için SqlDataAdapter kullanıyoruz
                    SqlDataAdapter da = new SqlDataAdapter(komut);

                    // DataTable oluştur
                    DataTable dt = new DataTable();

                    // Verileri DataTable'a doldur
                    da.Fill(dt);

                    // DataGridView'e veri atama
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ReadOnly = true;  // Hücreleri sadece okunur yapar
            dataGridView1.AllowUserToAddRows = false;  // Kullanıcıların yeni satır eklemesini engeller
            dataGridView1.AllowUserToDeleteRows = false;  // Kullanıcıların satır silmesini engeller

        }

        private void btnKullaniciPanel_Click(object sender, EventArgs e)
        {
            KullaniciYonetimPanel kullaniciYonetimPanel = new KullaniciYonetimPanel();
            kullaniciYonetimPanel.ShowDialog();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void VeriGetir()
        {
            using (SqlConnection baglanti = ConnectionManager.GetConnection())
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Araclar", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Butonu aktif et
                btnGuncelle.Enabled = true;

                // Verileri aktar
                txtID.Text = row.Cells["AracID"].Value.ToString();
                txtMarka.Text = row.Cells["Marka"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                cmbYil.Text = row.Cells["Yil"].Value.ToString();
                cmbVites.SelectedItem = row.Cells["VitesTipi"].Value.ToString();
                cmbYakit.SelectedItem = row.Cells["YakitTipi"].Value.ToString();
                txtKm.Text = row.Cells["Km"].Value.ToString();
                txtRenk.Text = row.Cells["Renk"].Value.ToString();
                txtPlaka.Text = row.Cells["Plaka"].Value.ToString();
                txtUcret.Text = row.Cells["GunlukUcret"].Value.ToString();
                txtDurum.Text = row.Cells["Durum"].Value.ToString();
                txtLink.Text = row.Cells["Image"].Value.ToString();

                try
                {
                    pictureBox1.Load(row.Cells["Image"].Value.ToString());
                }
                catch
                {
                    pictureBox1.Image = null;
                    MessageBox.Show("Resim yüklenemedi.");
                }
            }


        }
        

        
            private void btnGuncelle_Click(object sender, EventArgs e)
        {
           
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            // txtID boşsa güncelleme işlemi yapılmasın
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Lütfen güncellemek için bir araç seçin.");
                return;
            }
            // TextBox'lardan verileri al
            int aracID = Convert.ToInt32(txtID.Text); // AracID, düzenlenecek aracın ID'sini tutuyor
            string marka = txtMarka.Text;
            string model = txtModel.Text;
            string yil = cmbYil.Text;
            string vites = cmbVites.SelectedItem?.ToString();
            string yakit = cmbYakit.SelectedItem?.ToString();
            string km = txtKm.Text;
            string renk = txtRenk.Text;
            string plaka = txtPlaka.Text;
            decimal ucret = Convert.ToDecimal(txtUcret.Text);
            string durum = txtDurum.Text;
            string link = txtLink.Text;

            try
            {
                using (SqlConnection baglanti = ConnectionManager.GetConnection())
                {           
                    baglanti.Open();

                    // SQL UPDATE komutu
                    string sql = "UPDATE Araclar SET Marka = @Marka, Model = @Model, Yil = @Yil, VitesTipi = @VitesTipi, YakitTipi = @YakitTipi, Km = @Km, Renk = @Renk, Plaka = @Plaka, GunlukUcret = @GunlukUcret, Durum = @Durum, Image = @Image WHERE AracID = @aracID";

                    SqlCommand komut = new SqlCommand(sql, baglanti);

                    // Parametreleri ekleyelim
                    komut.Parameters.AddWithValue("@Marka", marka);
                    komut.Parameters.AddWithValue("@Model", model);
                    komut.Parameters.AddWithValue("@Yil", yil);
                    komut.Parameters.AddWithValue("@VitesTipi", vites);
                    komut.Parameters.AddWithValue("@YakitTipi", yakit);
                    komut.Parameters.AddWithValue("@Km", km);
                    komut.Parameters.AddWithValue("@Renk", renk);
                    komut.Parameters.AddWithValue("@Plaka", plaka);
                    komut.Parameters.AddWithValue("@GunlukUcret", ucret);
                    komut.Parameters.AddWithValue("@Durum", durum);
                    komut.Parameters.AddWithValue("@Image", link);
                    komut.Parameters.AddWithValue("@AracID", aracID); // Hangi aracın güncelleneceğini belirliyoruz

                    if (PlakaZatenVar(txtPlaka.Text))
                    {
                        MessageBox.Show("Bu plaka ile kayıtlı bir araç zaten mevcut.");
                        return;
                    }

                    // Güncellemeyi gerçekleştir
                    int rowsAffected = komut.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Araç başarıyla güncellendi!");

                        // DataGridView'i güncellemek için tekrar veriyi al
                        VeriGetir();
                    }
                    else
                    {
                        MessageBox.Show("Bir hata oluştu, aracın güncellenmesi başarısız!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void btnAracEkle_Click(object sender, EventArgs e)
        { // ErrorProvider'ı temizle
            errorProvider1.Clear();

            bool alanlarDoluMu = true;

            // Eğer DataGridView'de bir hücre seçiliyse, ekleme yapılmasın
            if (dataGridView1.SelectedCells.Count > 0)
            {
                dataGridView1.ClearSelection(); // Seçili hücre/satır varsa temizler
                TextBoxTemizle(); // Seçili hücre varsa, TextBox'ları temizle
                MessageBox.Show("Bir kayıt seçili durumda. Yeni araç eklemek için seçimler kaldırıldı. Şimdi ekleyebilirsiniz.");

                for (int yil = DateTime.Now.Year; yil >= 2010; yil--)
                {
                    cmbYil.Items.Add(yil.ToString());
                }
                return; // Fonksiyondan çık
            }

            // Eğer marka TextBox'ı boşsa
            if (string.IsNullOrWhiteSpace(txtMarka.Text))
            {
                errorProvider1.SetError(txtMarka, "Marka boş bırakılamaz.");
                alanlarDoluMu = false;
            }

            // Eğer model TextBox'ı boşsa
            if (string.IsNullOrWhiteSpace(txtModel.Text))
            {
                errorProvider1.SetError(txtModel, "Model boş bırakılamaz.");
                alanlarDoluMu = false;
            }
            // Yıl kontrolü
            if (string.IsNullOrWhiteSpace(cmbYil.Text))
            {
                errorProvider1.SetError(cmbYil, "Yıl boş bırakılamaz.");
                alanlarDoluMu = false;
            }

            // Vites kontrolü
            if (string.IsNullOrWhiteSpace(cmbVites.Text))
            {
                errorProvider1.SetError(cmbVites, "Vites tipi boş bırakılamaz.");
                alanlarDoluMu = false;
            }

            // Yakit tipi kontrolü
            if (string.IsNullOrWhiteSpace(cmbYakit.Text))
            {
                errorProvider1.SetError(cmbYakit, "Yakıt tipi boş bırakılamaz.");
                alanlarDoluMu = false;
            }

            // Km kontrolü
            if (string.IsNullOrWhiteSpace(txtKm.Text))
            {
                errorProvider1.SetError(txtKm, "Kilometre boş bırakılamaz.");
                alanlarDoluMu = false;
            }

            // Renk kontrolü
            if (string.IsNullOrWhiteSpace(txtRenk.Text))
            {
                errorProvider1.SetError(txtRenk, "Renk boş bırakılamaz.");
                alanlarDoluMu = false;
            }

            // Plaka kontrolü
            if (string.IsNullOrWhiteSpace(txtPlaka.Text))
            {
                errorProvider1.SetError(txtPlaka, "Plaka boş bırakılamaz.");
                alanlarDoluMu = false;
            }

            // Ücret kontrolü
            if (string.IsNullOrWhiteSpace(txtUcret.Text))
            {
                errorProvider1.SetError(txtUcret, "Ücret boş bırakılamaz.");
                alanlarDoluMu = false;
            }

            // Link kontrolü
            if (string.IsNullOrWhiteSpace(txtLink.Text))
            {
                errorProvider1.SetError(txtLink, "Image linki boş bırakılamaz.");
                alanlarDoluMu = false;
            }

            // Eğer alanlar eksikse, işlem yapılmasın
            if (!alanlarDoluMu)
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun.");
                return;
            }

            try
            {
                using (SqlConnection baglanti = ConnectionManager.GetConnection())
                {   
                    baglanti.Open();

                    string sql = @"INSERT INTO Araclar (Marka, Model, Yil, VitesTipi, YakitTipi, Km, Renk, Plaka, GunlukUcret, Durum, Image)
                       VALUES (@Marka, @Model, @Yil, @Vites, @Yakit, @Km, @Renk, @Plaka, @Ucret, @Durum, @Image)";

                    SqlCommand komut = new SqlCommand(sql, baglanti);
                    komut.Parameters.AddWithValue("@Marka", txtMarka.Text);
                    komut.Parameters.AddWithValue("@Model", txtModel.Text);
                    komut.Parameters.AddWithValue("@Yil", cmbYil.Text);
                    komut.Parameters.AddWithValue("@Vites", cmbVites.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@Yakit", cmbYakit.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@Km", txtKm.Text);
                    komut.Parameters.AddWithValue("@Renk", txtRenk.Text);
                    komut.Parameters.AddWithValue("@Plaka", txtPlaka.Text);
                    komut.Parameters.AddWithValue("@Ucret", txtUcret.Text);
                    komut.Parameters.AddWithValue("@Durum", "Müsait");
                    komut.Parameters.AddWithValue("@Image", txtLink.Text);

                    if (PlakaZatenVar(txtPlaka.Text))
                    {
                        MessageBox.Show("Bu plaka ile kayıtlı bir araç zaten mevcut.");
                        return;
                    }

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Araç başarıyla eklendi.");

                    VeriGetir(); // DataGridView’i güncelleyen fonksiyonun adı
                    TextBoxTemizle(); // TextBox'ları temizle (varsa)
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu: Aynı plakadan birden fazla olamaz." );
            }
        }


        private void btnAracSil_Click(object sender, EventArgs e)
        {
            // Önce ID'yi kontrol edelim
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Lütfen silmek için bir araç seçin.");
                return;
            }

            DialogResult sonuc = MessageBox.Show("Seçili aracı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (sonuc == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection baglanti = ConnectionManager.GetConnection())
                    {
                        baglanti.Open();

                        SqlCommand komut = new SqlCommand("DELETE FROM Araclar WHERE AracID = @id", baglanti);
                        komut.Parameters.AddWithValue("@id", Convert.ToInt32(txtID.Text));
                        komut.ExecuteNonQuery();
                    }

                    MessageBox.Show("Araç başarıyla silindi.");
                    VeriGetir();   // datagridview verisini güncelle
                    TextBoxTemizle();   // textboxları ve resmi temizle
                    dataGridView1.ClearSelection(); // seçimi temizle
                }
                catch (Exception )
                {
                    MessageBox.Show("Aynı plakadan birden fazla bulunamaz.");
                }
            }
        }

        private void btnPanelCikis_Click(object sender, EventArgs e)
        {
            this.Close(); // AdminPanel'i kapat
            // LoginForm örneği oluştur
            loginForm loginForm = new loginForm();
            loginForm.Show(); // LoginForm'u göster
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnGuncelle.Enabled = dataGridView1.SelectedCells.Count > 0;
        }

        private void txtYil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUcret_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnKiralanlar_Click(object sender, EventArgs e)
        {
            KiralananAraclarPanel kiralananAraclarPanel = new KiralananAraclarPanel();
            kiralananAraclarPanel.ShowDialog();
        }

        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}


