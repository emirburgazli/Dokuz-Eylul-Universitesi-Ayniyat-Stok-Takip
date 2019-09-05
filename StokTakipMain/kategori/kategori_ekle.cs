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

namespace StokTakipMain.kategori
{
    public partial class kategori_ekle : Form
    {
        public kategori_ekle()
        {
            InitializeComponent();
        }
        İmyoStokTakipEntities db = new İmyoStokTakipEntities();
        //StokTakipEntities7 db = new StokTakipEntities7();
        private void btn_kabul_Click(object sender, EventArgs e)
        {
           
            Kategori kat = new Kategori();
            if (txt_ad.Text=="")
            {
                MessageBox.Show("Lütfen Boş Bırakmayınız..");
            }
            else
            {
                kat.Ad = txt_ad.Text;
                db.Kategori.Add(kat);
                db.SaveChanges();
                MessageBox.Show("Kayıt Başarıyla Eklendi");
                txt_ad.Text = "";
            }
           
        }

        private void kategori_ekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            main main = new main();
            main.Show();
        }

        private void dÜZENLESİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k_guncelle k = new k_guncelle();
            k.Show();
       
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            this.Hide();
            main m = new main();
            m.Show();
        }
    }
}
