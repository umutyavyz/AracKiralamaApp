using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace AracKiralamaUygulaması
{
    public partial class kullaniciProfil : Form
    {
        public kullaniciProfil()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private Panel headerPanel;
        private Panel scrollPanel;
        private Label lblKullaniciAdi;

        private void kullaniciProfil_Load(object sender, EventArgs e)
        {
            HeaderPanelOlustur();
            KiralananAraclariGoster();
        }

        private void HeaderPanelOlustur()
        {
            if (headerPanel != null && this.Controls.Contains(headerPanel))
                return; // Zaten oluşturulmuş, tekrar oluşturma

            headerPanel = new Panel();
            headerPanel.Size = new Size(this.ClientSize.Width, 80);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.BackColor = Color.SteelBlue;
            this.Controls.Add(headerPanel);

            lblKullaniciAdi = new Label();
            lblKullaniciAdi.Text = $"Hoş geldin, {CurrentUser.UserName}";
            lblKullaniciAdi.Font = new Font("Arial", 14, FontStyle.Bold);
            lblKullaniciAdi.ForeColor = Color.White;
            lblKullaniciAdi.Location = new Point(20, 25);
            lblKullaniciAdi.AutoSize = true;
            headerPanel.Controls.Add(lblKullaniciAdi);

            Button btnSifreDegistir = new Button();
            btnSifreDegistir.Text = "Şifre Değiştir";
            btnSifreDegistir.Size = new Size(120, 35);
            btnSifreDegistir.Location = new Point(headerPanel.Width - 140, 22);
            btnSifreDegistir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSifreDegistir.BackColor = Color.White;
            btnSifreDegistir.ForeColor = Color.SteelBlue;
            btnSifreDegistir.FlatStyle = FlatStyle.Flat;
            btnSifreDegistir.Click += BtnSifreDegistir_Click;
            headerPanel.Controls.Add(btnSifreDegistir);
        }

        private void BtnSifreDegistir_Click(object sender, EventArgs e)
        {
            sifreDegistirmeForm sifreDegistirmeForm = new sifreDegistirmeForm();
            sifreDegistirmeForm.ShowDialog();
        }

        private void KiralananAraclariGoster()
        {
            scrollPanel = new Panel();
            scrollPanel.Dock = DockStyle.Fill;
            scrollPanel.AutoScroll = true;
            scrollPanel.BackColor = Color.WhiteSmoke;
            scrollPanel.Padding = new Padding(0, 10, 0, 0); // Header panelden sonra 10px boşluk

            this.Controls.Add(scrollPanel);
            this.Controls.SetChildIndex(scrollPanel, 1); // HeaderPanel'in altına gelsin

            using (SqlConnection baglanti = ConnectionManager.GetConnection())
            {
                baglanti.Open();

                string query = @"
SELECT k.KiralamaID, k.AracID, k.AlisTarihi, k.IadeTarihi, k.Ucret,
       a.Marka, a.Model, a.Image, a.VitesTipi, a.YakitTipi
FROM Kiralama k
INNER JOIN Araclar a ON k.AracID = a.AracID
WHERE k.KullaniciID = @kullaniciId";

                SqlCommand cmd = new SqlCommand(query, baglanti);
                cmd.Parameters.AddWithValue("@kullaniciId", CurrentUser.UserId);

                SqlDataReader reader = cmd.ExecuteReader();

                int x = 20;
                int y = headerPanel.Bottom + 20;

                while (reader.Read())
                {
                    Panel kiralamaPanel = new Panel();
                    kiralamaPanel.Size = new Size(600, 180);
                    kiralamaPanel.Location = new Point(x, y);
                    kiralamaPanel.BackColor = Color.FromArgb(230, 230, 230);

                    PictureBox pic = new PictureBox();
                    pic.Size = new Size(150, 120);
                    pic.Location = new Point(10, 30);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    string imgUrl = reader["Image"].ToString();
                    if (!string.IsNullOrEmpty(imgUrl))
                        pic.Load(imgUrl);
                    kiralamaPanel.Controls.Add(pic);

                    Label detay = new Label();
                    detay.Location = new Point(180, 20);
                    detay.Size = new Size(350, 100);
                    detay.Font = new Font("Arial", 10, FontStyle.Regular);
                    detay.Text = $"Araç: {reader["Marka"]} {reader["Model"]}\n" +
                                 $"Alış Tarihi: {Convert.ToDateTime(reader["AlisTarihi"]).ToShortDateString()}\n" +
                                 $"İade Tarihi: {Convert.ToDateTime(reader["IadeTarihi"]).ToShortDateString()}\n" +
                                 $"Toplam Ücret: {reader["Ucret"]} TL";
                    kiralamaPanel.Controls.Add(detay);

                    Button iptalBtn = new Button();
                    iptalBtn.Text = "Kiralamayı İptal Et";
                    iptalBtn.Size = new Size(150, 40);
                    iptalBtn.Location = new Point(420, 120);
                    iptalBtn.BackColor = Color.IndianRed;
                    iptalBtn.ForeColor = Color.White;
                    iptalBtn.FlatStyle = FlatStyle.Flat;

                    int kiralamaId = Convert.ToInt32(reader["KiralamaID"]);
                    int aracId = Convert.ToInt32(reader["AracID"]);

                    iptalBtn.Click += (s, args) =>
                    {
                        IptalEtVeYenile(kiralamaId, aracId);
                    };

                    kiralamaPanel.Controls.Add(iptalBtn);
                    scrollPanel.Controls.Add(kiralamaPanel);

                    y += 200;
                }

                reader.Close();
            }
        }

        private void IptalEtVeYenile(int kiralamaId, int aracId)
        {
            using (SqlConnection baglanti = ConnectionManager.GetConnection())
            {
                try
                {
                    baglanti.Open();

                    string deleteQuery = "DELETE FROM Kiralama WHERE KiralamaID = @kid";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, baglanti);
                    deleteCmd.Parameters.AddWithValue("@kid", kiralamaId);
                    deleteCmd.ExecuteNonQuery();

                    string updateQuery = "UPDATE Araclar SET Durum = 'Müsait' WHERE AracID = @aid";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, baglanti);
                    updateCmd.Parameters.AddWithValue("@aid", aracId);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Kiralama başarıyla iptal edildi.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    scrollPanel.Controls.Clear();
                    KiralananAraclariGoster();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
