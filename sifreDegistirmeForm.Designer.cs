namespace AracKiralamaUygulaması
{
    partial class sifreDegistirmeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sifreDegistirmeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMevcutSifre = new System.Windows.Forms.TextBox();
            this.txtYeniSifre = new System.Windows.Forms.TextBox();
            this.txtYeniSifreTekrar = new System.Windows.Forms.TextBox();
            this.btnSifreDegistir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mevcut Şifre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Yeni Şifre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 175);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Yeni Şifre Tekrar:";
            // 
            // txtMevcutSifre
            // 
            this.txtMevcutSifre.Location = new System.Drawing.Point(135, 76);
            this.txtMevcutSifre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMevcutSifre.Name = "txtMevcutSifre";
            this.txtMevcutSifre.Size = new System.Drawing.Size(132, 22);
            this.txtMevcutSifre.TabIndex = 3;
            this.txtMevcutSifre.UseSystemPasswordChar = true;
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Location = new System.Drawing.Point(135, 127);
            this.txtYeniSifre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Size = new System.Drawing.Size(132, 22);
            this.txtYeniSifre.TabIndex = 4;
            this.txtYeniSifre.UseSystemPasswordChar = true;
            // 
            // txtYeniSifreTekrar
            // 
            this.txtYeniSifreTekrar.Location = new System.Drawing.Point(135, 171);
            this.txtYeniSifreTekrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtYeniSifreTekrar.Name = "txtYeniSifreTekrar";
            this.txtYeniSifreTekrar.Size = new System.Drawing.Size(132, 22);
            this.txtYeniSifreTekrar.TabIndex = 5;
            this.txtYeniSifreTekrar.UseSystemPasswordChar = true;
            // 
            // btnSifreDegistir
            // 
            this.btnSifreDegistir.Location = new System.Drawing.Point(60, 219);
            this.btnSifreDegistir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSifreDegistir.Name = "btnSifreDegistir";
            this.btnSifreDegistir.Size = new System.Drawing.Size(208, 47);
            this.btnSifreDegistir.TabIndex = 6;
            this.btnSifreDegistir.Text = "Şifre Değiştir";
            this.btnSifreDegistir.UseVisualStyleBackColor = true;
            this.btnSifreDegistir.Click += new System.EventHandler(this.btnSifreDegistir_Click);
            // 
            // sifreDegistirmeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 320);
            this.Controls.Add(this.btnSifreDegistir);
            this.Controls.Add(this.txtYeniSifreTekrar);
            this.Controls.Add(this.txtYeniSifre);
            this.Controls.Add(this.txtMevcutSifre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "sifreDegistirmeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifre Değiştir";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMevcutSifre;
        private System.Windows.Forms.TextBox txtYeniSifre;
        private System.Windows.Forms.TextBox txtYeniSifreTekrar;
        private System.Windows.Forms.Button btnSifreDegistir;
    }
}