using StokTakipMain.Veritabani;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipMain
{
    public partial class Personel_ekle : Form
    {
        public Personel_ekle()
        {
            InitializeComponent();
        }
        İmyoStokTakipEntities db = new İmyoStokTakipEntities();
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Personel Ekle Tablosunda Personelin Adı,Soyadı,Ünvan ve bölümü Seçilip Veritabanına Kaydediliyor.
            //StokTakipEntities7 db = new StokTakipEntities7();

            Personel p = new Personel();
            if (txt_ad.Text == "" || txt_soyad.Text == "" || txt_unvan.Text == "" || cb_bolum.SelectedIndex == null)
            {
                MessageBox.Show("Boş alan Bırakmayınız.");
            }
            else
            {
                p.Unvan = txt_unvan.Text;
                p.Soyad = txt_soyad.Text;
                p.Ad = txt_ad.Text;
                p.Bolum_ID = cb_bolum.SelectedIndex;
                db.Personel.Add(p);
                db.SaveChanges();
                MessageBox.Show("Başarıyla Eklendi");
                sil();
            }
        }

        private void sil()
        {
            txt_ad.Text = "";
            txt_soyad.Text = "";
            txt_unvan.Text = "";
            cb_bolum.SelectedIndex = -1;
        }

        private void gÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p_guncelle g = new p_guncelle();
            g.Show();
        }

        private void Personel_ekle_Load(object sender, EventArgs e)
        {

            var bolumlistesi = db.Bolum.ToList();
            cb_bolum.Items.Add(bolumlistesi[0].Bolum_Adi);
            cb_bolum.Items.Add(bolumlistesi[1].Bolum_Adi);
            cb_bolum.Items.Add(bolumlistesi[2].Bolum_Adi);
        }

        private void Personel_ekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            main main = new main();
            main.Show();
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
