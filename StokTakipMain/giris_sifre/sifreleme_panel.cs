using StokTakipMain.Veritabani;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipMain.sifreleme
{
    public partial class sifreleme_panel : Form
    {
        public sifreleme_panel()
        {
            InitializeComponent();
        }
        İmyoStokTakipEntities3 db = new İmyoStokTakipEntities3();
        //StokTakipEntities db = new StokTakipEntities();
        Random rastgele = new Random();
        StringBuilder sb = new StringBuilder();
        Kullanici k = new Kullanici();
        public string BURGAZLIAD, BURGAZLISOYAD;
        private void btn_giris_Click_1(object sender, EventArgs e)
        {
            if (btn_giris.Text == "Şifremi Yenile")
            {
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;
                sc.Credentials = new NetworkCredential("emirhanburgazli@gmail.com", "05457849611918490..");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("emirhanburgazli@gmail.com", "DEU ŞİFRE YENİLEME");
                mail.To.Add(txt_kullanici.Text);
                mail.CC.Add(txt_kullanici.Text);
                mail.Subject = "E-Posta Konusu";
                mail.IsBodyHtml = true;
                sifregonder();
                mail.Body = sb.ToString();
                sc.Send(mail);
                var guncelle = db.Kullanici.Where(p => p.Mail == txt_kullanici.Text).FirstOrDefault();
                guncelle.Sifre = sb.ToString();
                db.SaveChanges();
                MessageBox.Show("Mail Adresinizi Kontrol Ediniz..");
                panel4.Visible = true;
                txt_sifre.Visible = true;
                btn_sifremi_unutum.Visible = true;
                label1.Visible = false;
                btn_giris.Text = "GİRİŞ YAP";

            }
            else
            {
                var deger = db.Kullanici.SqlQuery("select * from Kullanici where Kullanici_Adi = @ad and Sifre = @sifre", new SqlParameter("@ad", txt_kullanici.Text.ToString()), new SqlParameter("@Sifre", txt_sifre.Text.ToString())).ToList();
                if (deger.Count != 0)
                {
                    if (deger[0].Kullanici_Adi == txt_kullanici.Text && deger[0].Sifre == txt_sifre.Text)
                    {
                        main m = new main();
                        m.Show();
                        this.Hide();
                    }
                    else
                    {
                      
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış");
                }
              
            }

        }

        private void sifregonder()
        {
            for (int i = 0; i < 8; i++)
            {
                int ascii = rastgele.Next(32, 127);
                char karakter = Convert.ToChar(ascii);
                sb.Append(karakter);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_sifremi_unutum_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            txt_sifre.Visible = false;
            label1.Visible = true;
            btn_sifremi_unutum.Visible = false;
            btn_giris.Text = "Şifremi Yenile";

        }

        private void sifreleme_panel_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
        }
    }
}
