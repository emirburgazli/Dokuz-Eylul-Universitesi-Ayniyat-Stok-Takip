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

namespace StokTakipMain.Urun_ekle
{
    public partial class Urun_Ekle : Form
    {
        public Urun_Ekle()
        {
            InitializeComponent();
        }
        //StokTakipEntities7 db = new StokTakipEntities7();
        İmyoStokTakipEntities db = new İmyoStokTakipEntities();
        Kategori kat = new Kategori();
        Urunler urun = new Urunler();
        main m = new main();
        Tip t = new Tip();
        int kid, tid;
        string katisim, tipisim;
        private void button2_Click(object sender, EventArgs e)
        {

            //urun.UrunID = int.Parse(txt_urun_barkod.Text);
            //foreach (var urunid in db.Urunler)
            //{
            //  //veritabanındaki tüm barkodlar kontrol edilecek aynısı yoksa eklenecek..
            //}
            //float deger = Convert.q txt_urun_barkod.Text;
            //urun.UrunID = Convert.
            urun.Ad = txt_ad.Text;
            urun.Adet = Convert.ToInt16(txt_adet.Text);
            tipisim = cb_tip.SelectedValue.ToString();
            foreach (var tip in db.Tip)
            {
                if (tipisim == tip.Ad)
                {
                    tid = tip.Urun_Tipi_ID;
                }
            }
            urun.Tipi_ID = tid;
            katisim = cb_kategori.SelectedValue.ToString();
            foreach (var kategori in db.Kategori)
            {
                if (katisim == kategori.Ad)
                {
                    kid = kategori.Kategori_ID;
                }
            }
            urun.Kategori_ID = kid;
            db.Urunler.Add(urun);
            db.SaveChanges();
            MessageBox.Show("başarıyla eklendi..");



        }
        private void Urun_Ekle_Load(object sender, EventArgs e)
        {
            var kategoriListesi = db.Kategori.ToList();
            var TipListesi = db.Tip.ToList();
            cb_kategori.DataSource = kategoriListesi;
            cb_tip.DataSource = TipListesi;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            m.Show();
        }

        private void Urun_Ekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            m.Show();
        }

        private void düzenleSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            u_guncelle ug = new u_guncelle();
            ug.Show();
        }
    }
}
