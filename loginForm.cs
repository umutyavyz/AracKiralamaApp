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
using AracKiralamaUygulaması;


namespace AracKiralamaUygulaması
{
    public partial class loginForm : Form
    {
        // Buraya veritabanı dosyanın tam yolunu yaz

        SqlConnection baglanti = ConnectionManager.GetConnection();


        public loginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void txtKullanici_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullanici.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            try
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("SELECT * FROM Kullanicilar WHERE KullaniciAdi = @adi AND Sifre = @sifre", baglanti);
                komut.Parameters.AddWithValue("@adi", kullaniciAdi);
                komut.Parameters.AddWithValue("@sifre", sifre);

                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    CurrentUser.UserId = (int)dr["KullaniciID"];
                    CurrentUser.UserName = dr["KullaniciAdi"].ToString();
                    string rol = dr["Rol"].ToString();

                    if (rol == "Admin")
                    {
                        AdminPanel adminPanel = new AdminPanel();
                        adminPanel.Show();
                        this.Hide();
                    }
                    else
                    {
                        AnaForm ana = new AnaForm();
                        ana.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnHesapOlustur_Click(object sender, EventArgs e)
        {
            registerForm kayitFormu = new registerForm();
            kayitFormu.StartPosition = FormStartPosition.CenterParent;
            kayitFormu.ShowDialog(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void loginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
