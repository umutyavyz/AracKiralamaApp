namespace AracKiralamaUygulaması
{
    partial class AdminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.btnAracDurum = new System.Windows.Forms.Button();
            this.btnKullaniciPanel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtMarka = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtKm = new System.Windows.Forms.TextBox();
            this.txtRenk = new System.Windows.Forms.TextBox();
            this.txtPlaka = new System.Windows.Forms.TextBox();
            this.txtUcret = new System.Windows.Forms.TextBox();
            this.txtDurum = new System.Windows.Forms.TextBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.btnAracSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnAracEkle = new System.Windows.Forms.Button();
            this.btnPanelCikis = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbVites = new System.Windows.Forms.ComboBox();
            this.cmbYakit = new System.Windows.Forms.ComboBox();
            this.cmbYil = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnKiralanlar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAracDurum
            // 
            this.btnAracDurum.ForeColor = System.Drawing.Color.Black;
            this.btnAracDurum.Location = new System.Drawing.Point(12, 12);
            this.btnAracDurum.Name = "btnAracDurum";
            this.btnAracDurum.Size = new System.Drawing.Size(210, 52);
            this.btnAracDurum.TabIndex = 0;
            this.btnAracDurum.Text = "Araç Durumu";
            this.btnAracDurum.UseVisualStyleBackColor = true;
            this.btnAracDurum.Click += new System.EventHandler(this.btnAracDurum_Click);
            // 
            // btnKullaniciPanel
            // 
            this.btnKullaniciPanel.ForeColor = System.Drawing.Color.Black;
            this.btnKullaniciPanel.Location = new System.Drawing.Point(228, 12);
            this.btnKullaniciPanel.Name = "btnKullaniciPanel";
            this.btnKullaniciPanel.Size = new System.Drawing.Size(210, 52);
            this.btnKullaniciPanel.TabIndex = 1;
            this.btnKullaniciPanel.Text = "Kullanıcı Paneli";
            this.btnKullaniciPanel.UseVisualStyleBackColor = true;
            this.btnKullaniciPanel.Click += new System.EventHandler(this.btnKullaniciPanel_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 70);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(668, 479);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(732, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Araç ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(738, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Marka :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(738, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Model :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(764, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Yıl :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(721, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Vites Tipi :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(720, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Yakıt Tipi :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(756, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Km :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(744, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 18);
            this.label8.TabIndex = 10;
            this.label8.Text = "Renk :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(742, 363);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 18);
            this.label9.TabIndex = 11;
            this.label9.Text = "Plaka :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(693, 396);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 18);
            this.label10.TabIndex = 12;
            this.label10.Text = "Günlük Ücret :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(734, 430);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 18);
            this.label11.TabIndex = 13;
            this.label11.Text = "Durum :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(702, 466);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 18);
            this.label12.TabIndex = 14;
            this.label12.Text = "Resim Linki :";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(805, 89);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(146, 20);
            this.txtID.TabIndex = 15;
            // 
            // txtMarka
            // 
            this.txtMarka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMarka.Location = new System.Drawing.Point(805, 124);
            this.txtMarka.Name = "txtMarka";
            this.txtMarka.Size = new System.Drawing.Size(146, 20);
            this.txtMarka.TabIndex = 16;
            // 
            // txtModel
            // 
            this.txtModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModel.Location = new System.Drawing.Point(805, 153);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(146, 20);
            this.txtModel.TabIndex = 17;
            // 
            // txtKm
            // 
            this.txtKm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKm.Location = new System.Drawing.Point(805, 292);
            this.txtKm.Name = "txtKm";
            this.txtKm.Size = new System.Drawing.Size(146, 20);
            this.txtKm.TabIndex = 21;
            this.txtKm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKm_KeyPress);
            // 
            // txtRenk
            // 
            this.txtRenk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRenk.Location = new System.Drawing.Point(805, 326);
            this.txtRenk.Name = "txtRenk";
            this.txtRenk.Size = new System.Drawing.Size(146, 20);
            this.txtRenk.TabIndex = 22;
            // 
            // txtPlaka
            // 
            this.txtPlaka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaka.Location = new System.Drawing.Point(805, 363);
            this.txtPlaka.Name = "txtPlaka";
            this.txtPlaka.Size = new System.Drawing.Size(146, 20);
            this.txtPlaka.TabIndex = 23;
            // 
            // txtUcret
            // 
            this.txtUcret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUcret.Location = new System.Drawing.Point(805, 394);
            this.txtUcret.Name = "txtUcret";
            this.txtUcret.Size = new System.Drawing.Size(146, 20);
            this.txtUcret.TabIndex = 24;
            this.txtUcret.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUcret_KeyPress);
            // 
            // txtDurum
            // 
            this.txtDurum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDurum.Enabled = false;
            this.txtDurum.Location = new System.Drawing.Point(805, 430);
            this.txtDurum.Name = "txtDurum";
            this.txtDurum.Size = new System.Drawing.Size(146, 20);
            this.txtDurum.TabIndex = 25;
            // 
            // txtLink
            // 
            this.txtLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLink.Location = new System.Drawing.Point(805, 464);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(146, 20);
            this.txtLink.TabIndex = 26;
            // 
            // btnAracSil
            // 
            this.btnAracSil.ForeColor = System.Drawing.Color.Black;
            this.btnAracSil.Location = new System.Drawing.Point(995, 497);
            this.btnAracSil.Name = "btnAracSil";
            this.btnAracSil.Size = new System.Drawing.Size(210, 52);
            this.btnAracSil.TabIndex = 28;
            this.btnAracSil.Text = "Aracı Sil";
            this.btnAracSil.UseVisualStyleBackColor = true;
            this.btnAracSil.Click += new System.EventHandler(this.btnAracSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Enabled = false;
            this.btnGuncelle.ForeColor = System.Drawing.Color.Black;
            this.btnGuncelle.Location = new System.Drawing.Point(755, 497);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(210, 52);
            this.btnGuncelle.TabIndex = 29;
            this.btnGuncelle.Text = "Aracı Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click_1);
            // 
            // btnAracEkle
            // 
            this.btnAracEkle.ForeColor = System.Drawing.Color.Black;
            this.btnAracEkle.Location = new System.Drawing.Point(741, 12);
            this.btnAracEkle.Name = "btnAracEkle";
            this.btnAracEkle.Size = new System.Drawing.Size(210, 52);
            this.btnAracEkle.TabIndex = 31;
            this.btnAracEkle.Text = "Araç Ekle";
            this.btnAracEkle.UseVisualStyleBackColor = true;
            this.btnAracEkle.Click += new System.EventHandler(this.btnAracEkle_Click);
            // 
            // btnPanelCikis
            // 
            this.btnPanelCikis.ForeColor = System.Drawing.Color.Black;
            this.btnPanelCikis.Location = new System.Drawing.Point(1062, 12);
            this.btnPanelCikis.Name = "btnPanelCikis";
            this.btnPanelCikis.Size = new System.Drawing.Size(210, 52);
            this.btnPanelCikis.TabIndex = 32;
            this.btnPanelCikis.Text = "Panelden Çıkış Yap";
            this.btnPanelCikis.UseVisualStyleBackColor = true;
            this.btnPanelCikis.Click += new System.EventHandler(this.btnPanelCikis_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cmbVites
            // 
            this.cmbVites.FormattingEnabled = true;
            this.cmbVites.Location = new System.Drawing.Point(805, 214);
            this.cmbVites.Name = "cmbVites";
            this.cmbVites.Size = new System.Drawing.Size(146, 21);
            this.cmbVites.TabIndex = 33;
            // 
            // cmbYakit
            // 
            this.cmbYakit.FormattingEnabled = true;
            this.cmbYakit.Location = new System.Drawing.Point(805, 253);
            this.cmbYakit.Name = "cmbYakit";
            this.cmbYakit.Size = new System.Drawing.Size(146, 21);
            this.cmbYakit.TabIndex = 34;
            // 
            // cmbYil
            // 
            this.cmbYil.FormattingEnabled = true;
            this.cmbYil.Location = new System.Drawing.Point(805, 187);
            this.cmbYil.Name = "cmbYil";
            this.cmbYil.Size = new System.Drawing.Size(76, 21);
            this.cmbYil.TabIndex = 36;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(970, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 184);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // btnKiralanlar
            // 
            this.btnKiralanlar.ForeColor = System.Drawing.Color.Black;
            this.btnKiralanlar.Location = new System.Drawing.Point(444, 12);
            this.btnKiralanlar.Name = "btnKiralanlar";
            this.btnKiralanlar.Size = new System.Drawing.Size(210, 52);
            this.btnKiralanlar.TabIndex = 37;
            this.btnKiralanlar.Text = "Kiralama Paneli";
            this.btnKiralanlar.UseVisualStyleBackColor = true;
            this.btnKiralanlar.Click += new System.EventHandler(this.btnKiralanlar_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1274, 568);
            this.Controls.Add(this.btnKiralanlar);
            this.Controls.Add(this.cmbYil);
            this.Controls.Add(this.cmbYakit);
            this.Controls.Add(this.cmbVites);
            this.Controls.Add(this.btnPanelCikis);
            this.Controls.Add(this.btnAracEkle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnAracSil);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.txtDurum);
            this.Controls.Add(this.txtUcret);
            this.Controls.Add(this.txtPlaka);
            this.Controls.Add(this.txtRenk);
            this.Controls.Add(this.txtKm);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtMarka);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnKullaniciPanel);
            this.Controls.Add(this.btnAracDurum);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPanel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminPanel_FormClosing);
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAracDurum;
        private System.Windows.Forms.Button btnKullaniciPanel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtMarka;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtKm;
        private System.Windows.Forms.TextBox txtRenk;
        private System.Windows.Forms.TextBox txtPlaka;
        private System.Windows.Forms.TextBox txtUcret;
        private System.Windows.Forms.TextBox txtDurum;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Button btnAracSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAracEkle;
        private System.Windows.Forms.Button btnPanelCikis;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cmbYakit;
        private System.Windows.Forms.ComboBox cmbVites;
        private System.Windows.Forms.ComboBox cmbYil;
        private System.Windows.Forms.Button btnKiralanlar;
    }
}