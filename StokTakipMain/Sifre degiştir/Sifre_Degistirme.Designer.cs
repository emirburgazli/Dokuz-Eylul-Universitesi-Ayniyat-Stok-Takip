namespace StokTakipMain.Sifre_degiştir
{
    partial class Sifre_Degistirme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sifre_Degistirme));
            this.btn_sifre_degistir_kontrol = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_mail = new System.Windows.Forms.TextBox();
            this.txt_kallanici_adi = new System.Windows.Forms.TextBox();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_sifre_g = new System.Windows.Forms.TextBox();
            this.btn_sifre_degistir_guncelle = new System.Windows.Forms.Button();
            this.txt_kullanici_adi_g = new System.Windows.Forms.TextBox();
            this.txt_mail_g = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_sifre_degistir_kontrol
            // 
            this.btn_sifre_degistir_kontrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_sifre_degistir_kontrol.Location = new System.Drawing.Point(156, 146);
            this.btn_sifre_degistir_kontrol.Name = "btn_sifre_degistir_kontrol";
            this.btn_sifre_degistir_kontrol.Size = new System.Drawing.Size(163, 23);
            this.btn_sifre_degistir_kontrol.TabIndex = 0;
            this.btn_sifre_degistir_kontrol.Text = "Bilgileri Kontrol Et";
            this.btn_sifre_degistir_kontrol.UseVisualStyleBackColor = true;
            this.btn_sifre_degistir_kontrol.Click += new System.EventHandler(this.btn_sifre_degistir_kontrol_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_sifre);
            this.groupBox1.Controls.Add(this.btn_sifre_degistir_kontrol);
            this.groupBox1.Controls.Add(this.txt_kallanici_adi);
            this.groupBox1.Controls.Add(this.txt_mail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 184);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Şifre Değiştirilecek Hesap Bilgileri";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kullanıcı Adı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Şifre";
            // 
            // txt_mail
            // 
            this.txt_mail.Location = new System.Drawing.Point(116, 33);
            this.txt_mail.Name = "txt_mail";
            this.txt_mail.Size = new System.Drawing.Size(188, 22);
            this.txt_mail.TabIndex = 3;
            // 
            // txt_kallanici_adi
            // 
            this.txt_kallanici_adi.Location = new System.Drawing.Point(116, 66);
            this.txt_kallanici_adi.Name = "txt_kallanici_adi";
            this.txt_kallanici_adi.Size = new System.Drawing.Size(188, 22);
            this.txt_kallanici_adi.TabIndex = 4;
            // 
            // txt_sifre
            // 
            this.txt_sifre.Location = new System.Drawing.Point(116, 101);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.Size = new System.Drawing.Size(188, 22);
            this.txt_sifre.TabIndex = 5;
            this.txt_sifre.UseSystemPasswordChar = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_sifre_g);
            this.groupBox2.Controls.Add(this.btn_sifre_degistir_guncelle);
            this.groupBox2.Controls.Add(this.txt_kullanici_adi_g);
            this.groupBox2.Controls.Add(this.txt_mail_g);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(13, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 184);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Şifre Değiştirilecek Hesap Bilgileri";
            // 
            // txt_sifre_g
            // 
            this.txt_sifre_g.Location = new System.Drawing.Point(116, 101);
            this.txt_sifre_g.Name = "txt_sifre_g";
            this.txt_sifre_g.Size = new System.Drawing.Size(188, 22);
            this.txt_sifre_g.TabIndex = 5;
            this.txt_sifre_g.UseSystemPasswordChar = true;
            // 
            // btn_sifre_degistir_guncelle
            // 
            this.btn_sifre_degistir_guncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_sifre_degistir_guncelle.Location = new System.Drawing.Point(156, 146);
            this.btn_sifre_degistir_guncelle.Name = "btn_sifre_degistir_guncelle";
            this.btn_sifre_degistir_guncelle.Size = new System.Drawing.Size(163, 23);
            this.btn_sifre_degistir_guncelle.TabIndex = 0;
            this.btn_sifre_degistir_guncelle.Text = "Bilgileri Kontrol Et";
            this.btn_sifre_degistir_guncelle.UseVisualStyleBackColor = true;
            this.btn_sifre_degistir_guncelle.Click += new System.EventHandler(this.btn_sifre_degistir_guncelle_Click);
            // 
            // txt_kullanici_adi_g
            // 
            this.txt_kullanici_adi_g.Location = new System.Drawing.Point(116, 66);
            this.txt_kullanici_adi_g.Name = "txt_kullanici_adi_g";
            this.txt_kullanici_adi_g.Size = new System.Drawing.Size(188, 22);
            this.txt_kullanici_adi_g.TabIndex = 4;
            // 
            // txt_mail_g
            // 
            this.txt_mail_g.Location = new System.Drawing.Point(116, 33);
            this.txt_mail_g.Name = "txt_mail_g";
            this.txt_mail_g.Size = new System.Drawing.Size(188, 22);
            this.txt_mail_g.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Şifre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Kullanıcı Adı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Email";
            // 
            // Sifre_Degistirme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 401);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sifre_Degistirme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifre Değiştirme Ekranı";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Sifre_Degistirme_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_sifre_degistir_kontrol;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_sifre;
        private System.Windows.Forms.TextBox txt_kallanici_adi;
        private System.Windows.Forms.TextBox txt_mail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_sifre_g;
        private System.Windows.Forms.Button btn_sifre_degistir_guncelle;
        private System.Windows.Forms.TextBox txt_kullanici_adi_g;
        private System.Windows.Forms.TextBox txt_mail_g;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}