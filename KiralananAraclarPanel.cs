using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AracKiralamaUygulaması
{
    public partial class KiralananAraclarPanel : Form
    {
        public KiralananAraclarPanel()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private Panel filtrePanel;
        private ComboBox cbMarka, cbVites, cbBenzin;
        private string secilenMarka = "Tümü";
        private string secilenVites = "Tümü";
        private string secilenBenzin = "Tümü";

        private void KiralananAraclarPanel_Load(object sender, EventArgs e)
        {
            FiltrePaneliOlustur();
            KiralananAraclariGoster();
        }

        private void FiltrePaneliOlustur()
        {
            filtrePanel = new Panel();
            filtrePanel.Size = new Size(this.Width, 60);
            filtrePanel.Location = new Point(0, 0);
            filtrePanel.BackColor = Color.FromArgb(245, 245, 245);
            filtrePanel.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(filtrePanel);

            Label lbl1 = new Label() { Text = "Marka:", Location = new Point(10, 20) };
            lbl1.Size = new Size(50, 15);
            cbMarka = new ComboBox() { Location = new Point(60, 15), Width = 120 };
            cbMarka.DropDownStyle = ComboBoxStyle.DropDownList;

            Label lbl2 = new Label() { Text = "Vites Tipi:", Location = new Point(200, 20) };
            lbl2.Size = new Size(58, 15);
            cbVites = new ComboBox() { Location = new Point(260, 15), Width = 120 };
            cbVites.DropDownStyle = ComboBoxStyle.DropDownList;

            Label lbl3 = new Label() { Text = "Benzin Tipi:", Location = new Point(410, 20) };
            lbl3.Size = new Size(80, 15);
            cbBenzin = new ComboBox() { Location = new Point(490, 15), Width = 120 };
            cbBenzin.DropDownStyle = ComboBoxStyle.DropDownList;

            Button filtreleBtn = new Button()
            {
                Text = "Filtrele",
                Location = new Point(640, 12),
                Size = new Size(100, 30),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            filtreleBtn.Click += (s, e) =>
            {
                secilenMarka = cbMarka.SelectedItem?.ToString() ?? "Tümü";
                secilenVites = cbVites.SelectedItem?.ToString() ?? "Tümü";
                secilenBenzin = cbBenzin.SelectedItem?.ToString() ?? "Tümü" ;
                KiralananAraclariGoster();
            };

            filtrePanel.Controls.AddRange(new Control[] { lbl1, cbMarka, lbl2, cbVites, lbl3, cbBenzin, filtreleBtn });
            MarkaVitesBenzinDoldur();
        }

        private void MarkaVitesBenzinDoldur()
        {
            using (SqlConnection baglanti = ConnectionManager.GetConnection())
            {
                baglanti.Open();

                void Doldur(string sorgu, ComboBox cb)
                {
                    SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    cb.Items.Clear();
                    cb.Items.Add("Tümü"); // boş seçenek
                    while (rdr.Read()) cb.Items.Add(rdr[0].ToString());
                    rdr.Close();
                }

                Doldur("SELECT DISTINCT Marka FROM Araclar", cbMarka);
                Doldur("SELECT DISTINCT VitesTipi FROM Araclar", cbVites);
                Doldur("SELECT DISTINCT YakitTipi FROM Araclar", cbBenzin);
            }
        }

        private void KiralananAraclariGoster()
        {
             Panel panel = this.Controls.OfType<Panel>().FirstOrDefault(p => p.Dock == DockStyle.Fill);
    if (panel == null)
    {
        panel = new Panel();
        panel.Dock = DockStyle.Fill;
        panel.AutoScroll = true;
        this.Controls.Add(panel);
    }
    else
    {
        panel.Controls.Clear();
    }

            using (SqlConnection baglanti = ConnectionManager.GetConnection())
            {
        baglanti.Open();

        string query = @"
SELECT k.KiralamaID, k.AracID, k.AlisTarihi, k.IadeTarihi, k.Ucret,
       a.Marka, a.Model, a.Image, a.VitesTipi, a.YakitTipi,
       ku.KullaniciID, ku.KullaniciAdi
FROM Kiralama k
INNER JOIN Araclar a ON k.AracID = a.AracID
INNER JOIN Kullanicilar ku ON k.KullaniciID = ku.KullaniciID
WHERE 1 = 1";

        if (secilenMarka != "Tümü")
            query += " AND a.Marka = @marka";
        if (secilenVites != "Tümü")
            query += " AND a.VitesTipi = @vites";
        if (secilenBenzin != "Tümü")
            query += " AND a.YakitTipi = @benzin";

        SqlCommand cmd = new SqlCommand(query, baglanti);

        if (secilenMarka != "Tümü")
            cmd.Parameters.AddWithValue("@marka", secilenMarka);
        if (secilenVites != "Tümü")
            cmd.Parameters.AddWithValue("@vites", secilenVites);
        if (secilenBenzin != "Tümü")
            cmd.Parameters.AddWithValue("@benzin", secilenBenzin);

        SqlDataReader reader = cmd.ExecuteReader();

        int x = 20;
        int y = filtrePanel.Bottom+20;
        int count = 0;

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
                         $"Toplam Ücret: {reader["Ucret"]} TL\n" +
                         $"Kiracı: {reader["KullaniciAdi"]} (ID: {reader["KullaniciID"]})";
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
            panel.Controls.Add(kiralamaPanel);

            count++;

            if (count % 2 == 0)
            {
                x = 20;
                y += 200;
            }
            else
            {
                x = 650;
            }
        }

        reader.Close();
    }

    // Filtre panelini en üste getir
    if (filtrePanel != null)
        this.Controls.SetChildIndex(filtrePanel, 0);
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

                    this.Controls.Clear();
                    KiralananAraclarPanel_Load(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
