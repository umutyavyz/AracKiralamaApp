using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;


namespace AracKiralamaUygulaması
{
    public partial class AnaForm : Form
    {
        
        ComboBox markaCombo, vitesCombo, benzinCombo;
        Panel scrollPanel;

        kullaniciProfil kullaniciProfil = new kullaniciProfil();

        public void AraclariYenile()
        {
            this.Controls.Clear();
            AnaForm_Load(null, null);
        }

        public AnaForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private string GetUserNameFromDatabase(int userId)
        {
            string username = string.Empty;
            using (SqlConnection baglanti = ConnectionManager.GetConnection())
            {
                try
                {
                    baglanti.Open();
                    string query = "SELECT KullaniciAdi FROM Kullanicilar WHERE KullaniciID = @UserID";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.Parameters.AddWithValue("@UserID", userId);
                    username = komut.ExecuteScalar()?.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
            return username;
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            // Header Panel
            Panel headerPanel = new Panel();
            headerPanel.Size = new Size(this.ClientSize.Width, 50);
            headerPanel.BackColor = Color.SteelBlue;
            this.Controls.Add(headerPanel);

            string username = CurrentUser.UserName;
            CurrentUser.UserName = username;

            Label welcomeLabel = new Label();
            welcomeLabel.Text = "Merhaba, " + username;
            welcomeLabel.ForeColor = Color.White;
            welcomeLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            welcomeLabel.Location = new Point(10, 15);
            welcomeLabel.Size = new Size(500, 30);
            headerPanel.Controls.Add(welcomeLabel);

            Button profilButon = new Button();
            profilButon.Text = "Profil";
            profilButon.Size = new Size(100, 30);
            profilButon.Location = new Point(headerPanel.Width - 230, 10);
            profilButon.BackColor = Color.LightSeaGreen;
            profilButon.ForeColor = Color.White;
            profilButon.FlatStyle = FlatStyle.Flat;
            profilButon.Click += (s, args) => {
                kullaniciProfil.ShowDialog();
                AraclariYenile();
            };
            headerPanel.Controls.Add(profilButon);

            Button cikisButon = new Button();
            cikisButon.Text = "Çıkış Yap";
            cikisButon.Size = new Size(100, 30);
            cikisButon.Location = new Point(headerPanel.Width - 110, 10);
            cikisButon.BackColor = Color.IndianRed;
            cikisButon.ForeColor = Color.White;
            cikisButon.FlatStyle = FlatStyle.Flat;
            cikisButon.Click += (s, args) =>
            {
                if (MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                    loginForm loginForm = new loginForm();
                    loginForm.Show();
                }
            };
            headerPanel.Controls.Add(cikisButon);

            // Filtre Paneli
            Panel filtrePanel = new Panel();
            filtrePanel.Size = new Size(this.ClientSize.Width, 60);
            filtrePanel.Location = new Point(0, 50);
            filtrePanel.BackColor = Color.WhiteSmoke;
            this.Controls.Add(filtrePanel);

            Label markaLabel = new Label()
            {
                Text = "Marka",
                Location = new Point(20, 0),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            Label vitesLabel = new Label()
            {
                Text = "Vites Tipi",
                Location = new Point(190, 0),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            Label benzinLabel = new Label()
            {
                Text = "Yakıt Tipi",
                Location = new Point(360, 0),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            filtrePanel.Controls.AddRange(new Control[] {
                markaLabel, vitesLabel, benzinLabel
            });

            markaCombo = new ComboBox() { Location = new Point(20, 20), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            vitesCombo = new ComboBox() { Location = new Point(190, 20), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            benzinCombo = new ComboBox() { Location = new Point(360, 20), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };

            markaCombo.Items.Add("Tümü"); vitesCombo.Items.Add("Tümü"); benzinCombo.Items.Add("Tümü");


            using (SqlConnection baglanti = ConnectionManager.GetConnection())
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Marka FROM Araclar", baglanti);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) markaCombo.Items.Add(reader.GetString(0));
                }

                cmd = new SqlCommand("SELECT DISTINCT VitesTipi FROM Araclar", baglanti);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) vitesCombo.Items.Add(reader.GetString(0));
                }

                cmd = new SqlCommand("SELECT DISTINCT YakitTipi FROM Araclar", baglanti);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) benzinCombo.Items.Add(reader.GetString(0));
                }
            }

            markaCombo.SelectedIndex = 0;
            vitesCombo.SelectedIndex = 0;
            benzinCombo.SelectedIndex = 0;

            markaCombo.SelectedIndexChanged += (s, eventargs) => FiltreleVeListele();
            vitesCombo.SelectedIndexChanged += (s, eventargs) => FiltreleVeListele();
            benzinCombo.SelectedIndexChanged += (s, eventargs) => FiltreleVeListele();

            filtrePanel.Controls.AddRange(new Control[] { markaCombo, vitesCombo, benzinCombo });

            // Scroll Panel
            int spacing = 10;
            filtrePanel.Location = new Point(0, headerPanel.Bottom + spacing);

            scrollPanel = new Panel();
            scrollPanel.Location = new Point(0, filtrePanel.Bottom + spacing);
            scrollPanel.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - scrollPanel.Location.Y);
            scrollPanel.AutoScroll = true;
            scrollPanel.BackColor = Color.LightGray;
            this.Controls.Add(scrollPanel);

            FiltreleVeListele(); // İlk yükleme
        }

        private void FiltreleVeListele()
        {
            scrollPanel.Controls.Clear();

            List<string> kosullar = new List<string> { "Durum != 'Kirada'" };
            List<SqlParameter> parametreler = new List<SqlParameter>();

            if (markaCombo.SelectedIndex > 0)
            {
                kosullar.Add("Marka = @Marka");
                parametreler.Add(new SqlParameter("@Marka", markaCombo.SelectedItem));
            }

            if (vitesCombo.SelectedIndex > 0)
            {
                kosullar.Add("VitesTipi = @Vites");
                parametreler.Add(new SqlParameter("@Vites", vitesCombo.SelectedItem));
            }

            if (benzinCombo.SelectedIndex > 0)
            {
                kosullar.Add("YakitTipi = @Benzin");
                parametreler.Add(new SqlParameter("@Benzin", benzinCombo.SelectedItem));
            }

            string whereClause = string.Join(" AND ", kosullar);
            string query = $"SELECT * FROM Araclar WHERE {whereClause}";

            using (SqlConnection baglanti = ConnectionManager.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, baglanti);
                cmd.Parameters.AddRange(parametreler.ToArray());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                int y = 10, x = 10, sayac = 0;
                foreach (DataRow row in dt.Rows)
                {
                    Panel panel = new Panel() { Size = new Size(550, 180), Location = new Point(x, y), BackColor = Color.White, Padding = new Padding(10) };
                    GraphicsPath path = new GraphicsPath();
                    int r = 20;
                    path.AddArc(0, 0, r, r, 180, 90);
                    path.AddArc(panel.Width - r, 0, r, r, 270, 90);
                    path.AddArc(panel.Width - r, panel.Height - r, r, r, 0, 90);
                    path.AddArc(0, panel.Height - r, r, r, 90, 90);
                    panel.Region = new Region(path);

                    PictureBox pic = new PictureBox() { Size = new Size(180, 140), Location = new Point(10, 20), SizeMode = PictureBoxSizeMode.StretchImage };
                    string img = row["Image"].ToString();
                    try
                    {
                        if (!string.IsNullOrEmpty(img))
                            pic.Load(img);
                        else
                            pic.Image = Properties.Resources.placeholder; // varsayılan resim
                    }
                    catch
                    {
                        pic.Image = Properties.Resources.placeholder; // yüklenemezse varsayılan
                    }
                    panel.Controls.Add(pic);

                    Label lbl = new Label()
                    {
                        Size = new Size(230, 150),
                        Location = new Point(190, 50),
                        Text = $"{row["Marka"]} {row["Model"]}\n{row["Yil"]} - {row["VitesTipi"]}\nGünlük Ücret: {row["GunlukUcret"]} TL",
                        Font = new Font("Arial", 14, FontStyle.Bold),
                        ForeColor = Color.Black
                    };
                    panel.Controls.Add(lbl);

                    Button btn = new Button()
                    {
                        Text = "Kirala",
                        Size = new Size(120, 40),
                        Location = new Point(420, 120),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        BackColor = Color.Green,
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat
                    };

                    int aracId = Convert.ToInt32(row["AracID"]);
                    btn.Click += (s, args) =>
                    {
                        KiralamaForm kiralamaForm = new KiralamaForm(aracId);
                        if (kiralamaForm.ShowDialog() == DialogResult.OK)
                            FiltreleVeListele(); // Yeniden filtrele
                    };
                    panel.Controls.Add(btn);

                    scrollPanel.Controls.Add(panel);
                    sayac++;
                    if (sayac % 2 == 0) { x = 10; y += 200; } else { x += 580; }
                }
            }
        }
    }
}
