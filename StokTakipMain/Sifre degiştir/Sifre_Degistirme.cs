using StokTakipMain.Veritabani;
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

namespace StokTakipMain.Sifre_degiştir
{
    public partial class Sifre_Degistirme : Form
    {
        public Sifre_Degistirme()
        {
            InitializeComponent();
        }
        İmyoStokTakipEntities3 db = new İmyoStokTakipEntities3();
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Sifre_Degistirme_FormClosed(object sender, FormClosedEventArgs e)
        {
            main m = new main();
            this.Hide();
            m.Show();
        }
        int id;
        private void btn_sifre_degistir_kontrol_Click(object sender, EventArgs e)
        {
            var deger = db.Kullanici.SqlQuery("select * from Kullanici where (Kullanici_Adi=@ad and Sifre=@sifre and Mail=@mail)", new SqlParameter("@ad", txt_kallanici_adi.Text), new SqlParameter("@sifre", txt_sifre.Text), new SqlParameter("@mail", txt_mail.Text)).ToList();
            if (deger.Count == 1)
            {
                id = deger[0].ID;
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                MessageBox.Show("Güncellemek istediğiniz bilgileri değiştirip GÜNCELLE butonuna basınız.");
            }
            else
            {
                MessageBox.Show("Girdiğiniz Bilgilerde Kullanıcı Bulunamadı.");
            }
        }

        private void btn_sifre_degistir_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var guncelle = db.Kullanici.Find(Convert.ToInt32(id));
                guncelle.Kullanici_Adi = txt_kullanici_adi_g.Text;
                guncelle.Mail = txt_mail_g.Text;
                guncelle.Sifre = txt_sifre_g.Text;
                db.SaveChanges();
               
                main m = new main();
                this.Hide();
                m.Show();
                MessageBox.Show("Düzenleme Kaydedildi.");

            }
            catch (Exception)
            {
                MessageBox.Show("HATA");
            }

        }
    }
}
