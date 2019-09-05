using StokTakipMain.sifreleme;
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
using Microsoft.Reporting;
using StokTakipMain.Sifre_degiştir;
using Microsoft.VisualBasic;
using StokTakipMain.Hakkımızda;

namespace StokTakipMain
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        İmyoStokTakipEntities3 db = new İmyoStokTakipEntities3();
        //StokTakipEntities db = new StokTakipEntities();
        Urun_Hareket uh = new Urun_Hareket();
        Urunler u = new Urunler();
        Kategori kat = new Kategori();
        Unvanlar unvn = new Unvanlar();
        Bolum bolum = new Bolum();
        string id = "0";
        int secili_bolum, secili_ketegori, secili_unvan, secili_tip;
        DataTable dt = new DataTable();
        DataTable dt_rapor = new DataTable();
        string veri;
        int sayac = 0;
        int katsayac = 0;
        List<string> barkodlar = new List<string>();
        List<string> sira_no = new List<string>();
        List<string> barkod = new List<string>();
        List<string> ad = new List<string>();
        List<string> olcu_birimi = new List<string>();
        List<int> istenilen_miktar = new List<int>();
        string istekyapan;
        string[] parclar;
        private void main_Load(object sender, EventArgs e)
        {
            var besurun = db.Urunler.OrderBy(p => p.Adet).Take(5).ToList();
            for (int i = 0; i < besurun.Count; i++)
            {
                lbsonbesurun.Items.Add(besurun[i].Ad + " Ürününden " + besurun[i].Adet + " Kalmıştır.");
                lbsonbesurun.Items.Add(" ");
            }

            var besolay = db.tb_Urun_Cıkıs.OrderByDescending(p => p.Cıkıs_Tarihi).Take(5).ToList();
            for (int j = 0; j < besolay.Count; j++)
            {
                lbsonbesolay.Items.Add(besolay[j].Ad + " " + besolay[j].Soyad + " " + besolay[j].Barkod + "'lu " + besolay[j].Urun_adi + " Üründen " + besolay[j].Adet + " tane Aldı.");
                lbsonbesolay.Items.Add(" ");
            }
        }

        private void sil()
        {
            txt_ad_personel.Text = "";
            txt_soyad_personel.Text = "";
            txt_sicil_no_personel.Text = "";
            txt_personel_ekle_gorev.Text = "";
            combo_unvan.SelectedIndex = -1;
            cb_bolum_personel.SelectedIndex = -1;
        }
        private void btn_sil_Click(object sender, EventArgs e)
        {
            try
            {
                var silinecek = db.Personel.Find(Convert.ToInt32(id));
                if (silinecek == null)
                {
                    MessageBox.Show("Lütfen Silinecek Kişinin Üzerine Tıklayınız.");
                }
                else
                {
                    try
                    {
                        db.Personel.Remove(silinecek);
                        db.SaveChanges();
                        var liste = db.Personel.ToList();
                        dtg_personel.DataSource = liste;
                        sil();
                        MessageBox.Show("Silme İşlemi Tamamlandı..");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bu Kişiyi Silemezsiniz..");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bu Satırı Silemezsiniz.");
            }
        }

        private void btn_kabul_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_ad_kategori.Text == "")
                {
                    MessageBox.Show("Lütfen Boş Bırakmayınız..");
                }
                else
                {
                    kat.Ad = txt_ad_kategori.Text;
                    db.Kategori.Add(kat);
                    db.SaveChanges();
                    txt_ad_kategori.Text = "";
                    var kategori = db.Kategori.ToList();
                    datagrid_kategori.DataSource = kategori;
                    MessageBox.Show("Kayıt Başarıyla Eklendi");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Veri Eklemede Hata Oluştu. Lütfen Bizimle İletişime Geçiniz.");
            }

        }
        private void datagrid_kategori_Click(object sender, EventArgs e)
        {
            try
            {
                txt_ad_kategori_guncelle.Text = datagrid_kategori.CurrentRow.Cells["Ad"].Value.ToString();
                id = datagrid_kategori.CurrentRow.Cells["Kategori_ID"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Veri Kaydı Yoktur..");
            }
        }

        string guncellenecek_urun;
        private void data_Urunler_Click(object sender, EventArgs e)
        {
            try
            {
                guncellenecek_urun = data_Urunler.CurrentRow.Cells["Barkod"].Value.ToString();
                secili_tip = Convert.ToInt32(data_Urunler.CurrentRow.Cells[4].Value);
                secili_ketegori = Convert.ToInt32(data_Urunler.CurrentRow.Cells[5].Value); //OKULDA 5 OLACAK evde 4
                cb_kategori_guncelle_urun.Items.Clear();
                cb_tip_guncelle_urun.Items.Clear();
                cb_kategori_guncelle_urun.Text = "";
                cb_tip_guncelle_urun.Text = "";

                var tip = db.Tip.ToList();
                var kategori = db.Kategori.ToList();
                int tipsayi = tip.Count();
                int kategorisayi = kategori.Count();

                for (int k = 0; k < tipsayi; k++)
                {
                    cb_tip_guncelle_urun.Items.Add(tip[k].Ad);
                }

                for (int j = 0; j < kategorisayi; j++)
                {
                    cb_kategori_guncelle_urun.Items.Add(kategori[j].Ad);
                }

                id = data_Urunler.CurrentRow.Cells["UrunID"].Value.ToString();
                txt_barkod_guncelle_urun.Text = data_Urunler.CurrentRow.Cells["Barkod"].Value.ToString();
                txt_ad_guncelle_urun.Text = data_Urunler.CurrentRow.Cells["Ad"].Value.ToString();
                txt_adet_guncelle_urun.Text = data_Urunler.CurrentRow.Cells["Adet"].Value.ToString();
                int kategori_index_deger = Convert.ToInt32(data_Urunler.CurrentRow.Cells[5].Value); // OKULDA 5 OLACAK evde 4
                var gelen_kat = db.Kategori.Where(p => p.Kategori_ID == kategori_index_deger).ToList();
                cb_kategori_guncelle_urun.Text = gelen_kat[0].Ad;
                int deger = Convert.ToInt32(data_Urunler.CurrentRow.Cells[4].Value);
                var gelendeger = db.Tip.Where(b => b.Urun_Tipi_ID == deger).ToList();
                cb_tip_guncelle_urun.Text = gelendeger[0].Ad;
            }
            catch (Exception)
            {

                MessageBox.Show("HATA: 10");
            }

        }
        private void btn_kaydet_urun_Click(object sender, EventArgs e)
        {
            try
            {
                Urunler u = new Urunler();
                if (txt_barkod_urun.Text == "" || txt_barkod_urun.Text == "" || txt_ad_urun.Text == "" || txt_adet_urun.Text == "" || cb_tip_urun.SelectedIndex == -1 || cb_kategori_urun.SelectedIndex == -1)
                {
                    MessageBox.Show("Boş alan Bırakmayınız.");
                }
                else
                {
                    var deger = db.Urunler.Where(p => p.Barkod == txt_barkod_urun.Text).ToList();
                    if (deger.Count == 1)
                    {
                        MessageBox.Show("Barkod Veritabanında Kayıtlı.");
                    }
                    else
                    {
                        u.Barkod = txt_barkod_urun.Text;
                        u.Ad = txt_ad_urun.Text;
                        u.Adet = Convert.ToInt16(txt_adet_urun.Text);

                        var katdeger = db.Kategori.Where(p => p.Ad == cb_kategori_urun.Text).ToList();
                        u.Kategori_ID = katdeger[0].Kategori_ID;
                        var tipdeger = db.Tip.Where(p => p.Ad == cb_tip_urun.Text).ToList();
                        u.Tipi_ID = tipdeger[0].Urun_Tipi_ID;
                        u.Giris_Tarihi = DateTime.Now;
                        db.Urunler.Add(u);
                        db.SaveChanges();
                        txt_barkod_urun.Text = "";
                        txt_ad_urun.Text = "";
                        txt_adet_urun.Text = "";
                        cb_kategori_urun.SelectedIndex = -1;
                        cb_tip_urun.SelectedIndex = -1;
                        var liste = db.Urunler.ToList();
                        data_Urunler.DataSource = liste;
                        MessageBox.Show("Başarıyla Eklendi");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Veri Eklemede Hata Oluştu. Lütfen Bizimle İletişime Geçiniz.");
            }
        }
        private void btn_sil_urun_Click(object sender, EventArgs e)
        {
            try
            {
                var silinecek = db.Urunler.Find(Convert.ToInt32(id));
                if (silinecek == null)
                {
                    MessageBox.Show("Silinecek Verinin Üzerine Tıklayınız");
                }
                else
                {
                    db.Urunler.Remove(silinecek);
                    db.SaveChanges();
                    var urunler = db.Urunler.ToList();
                    data_Urunler.DataSource = urunler;
                    temizle();
                    MessageBox.Show("Silme İşlemi Tamamlandı..");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bu Satırı Silemezsiniz.");
            }

        }
        private void temizle()
        {
            txt_adet_guncelle_urun.Text = "";
            txt_barkod_guncelle_urun.Text = "";
            txt_ad_guncelle_urun.Text = "";
            cb_tip_guncelle_urun.SelectedText = "";
            cb_kategori_guncelle_urun.SelectedText = "";
        }
        private void btn_sil_kategori_Click(object sender, EventArgs e)
        {
            try
            {
                var silinecek = db.Kategori.Find(Convert.ToInt32(id));
                if (silinecek == null)
                {
                    MessageBox.Show("Silinecek Verinin Üzerine Tıklanıyınız");
                }
                else
                {
                    db.Kategori.Remove(silinecek);
                    db.SaveChanges();
                    var kategori = db.Kategori.ToList();
                    datagrid_kategori.DataSource = kategori;
                    sil();
                    MessageBox.Show("Silme İşlemi Tamamladı..");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bu Satırı Silemezsiniz.");
            }

        }
        private void btn_guncelle_kategori_Click(object sender, EventArgs e)
        {
            try
            {
                var guncelle = db.Kategori.Find(Convert.ToInt32(id));
                guncelle.Ad = txt_ad_kategori_guncelle.Text;
                db.SaveChanges();
                var liste = db.Kategori.ToList();
                datagrid_kategori.DataSource = liste;
                MessageBox.Show("Düzenleme Kaydedildi.");
            }
            catch (Exception)
            {
                MessageBox.Show("Burdan Veri Girişi Yapamazsınız..");
            }
        }
        private void btn_birim_ekle_olcu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_ad_olcu.Text == "")
                {
                    MessageBox.Show("Lütfen Boş Bırakmayınız..");
                }
                else
                {
                    Tip t = new Tip();
                    t.Ad = txt_ad_olcu.Text;
                    db.Tip.Add(t);
                    db.SaveChanges();
                    var liste = db.Tip.ToList();
                    data_olcu_birim.DataSource = liste;
                    MessageBox.Show("Başarıyla Eklendi..");
                    txt_ad_olcu.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("HATA: 10");
            }
        }
        private void btn_birim_guncelle_olcu_Click(object sender, EventArgs e)
        {
            try
            {
                var guncelle = db.Tip.Find(Convert.ToInt32(id));
                guncelle.Ad = txt_ad_guncelle_olcu.Text;
                db.SaveChanges();
                var liste = db.Tip.ToList();
                data_olcu_birim.DataSource = liste;
                MessageBox.Show("Düzenleme Kaydedildi..");
            }
            catch (Exception)
            {
                MessageBox.Show("Buradan Ekleme Yapamazsınız..");
            }
        }
        private void btn_birim_sil_olcu_Click(object sender, EventArgs e)
        {

            var silinecek = db.Tip.Find(Convert.ToInt32(id));
            if (silinecek == null)
            {
                MessageBox.Show("Lütfen Silmek İstediginiz değere Tıklayınız.");
            }
            else
            {
                try
                {
                    db.Tip.Remove(silinecek);
                    db.SaveChanges();
                    var liste = db.Tip.ToList();
                    data_olcu_birim.DataSource = liste;
                    txt_ad_guncelle_olcu.Text = "";
                    MessageBox.Show("Silme İşleminiz Tamamlandı..");
                }
                catch (Exception)
                {

                    MessageBox.Show("Bu Veriyi Silemezsiniz..");
                }
            }
        }
        private void data_olcu_birim_Click(object sender, EventArgs e)
        {
            try
            {
                txt_ad_guncelle_olcu.Text = data_olcu_birim.CurrentRow.Cells["Ad"].Value.ToString();
                id = data_olcu_birim.CurrentRow.Cells["Urun_Tipi_ID"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Veri Kaydı Yoktur..");
            }

        }
        //List<string> urunler;
        private void btn_kaydet_guncelle_urun_Click(object sender, EventArgs e)
        {
            try
            {
                var guncelle = db.Urunler.Find(Convert.ToInt32(id));
                guncelle.Barkod = txt_barkod_guncelle_urun.Text;
                guncelle.Ad = txt_ad_guncelle_urun.Text;
                guncelle.Adet = Convert.ToInt16(txt_adet_guncelle_urun.Text);
                if (cb_kategori_guncelle_urun.SelectedIndex == -1)
                {
                    guncelle.Kategori_ID = secili_ketegori;
                }
                else
                {
                    var katdeger = db.Kategori.Where(p => p.Ad == cb_kategori_guncelle_urun.Text).ToList();
                    guncelle.Kategori_ID = katdeger[0].Kategori_ID;
                }

                if (cb_tip_guncelle_urun.SelectedIndex == -1)
                {
                    guncelle.Tipi_ID = secili_tip;
                }
                else
                {
                    var tipdeger = db.Tip.Where(p => p.Ad == cb_tip_guncelle_urun.Text).ToList();
                    guncelle.Tipi_ID = tipdeger[0].Urun_Tipi_ID;
                }
                db.SaveChanges();
                MessageBox.Show("Düzenleme Kaydedildi..");
                var liste = db.Urunler.ToList();
                data_Urunler.DataSource = liste;
            }
            catch (Exception)
            {
                MessageBox.Show("Burada Ekleme İşlemi Yapamazsınız..");
            }
        }
        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tabYetkiliMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secilen = tabYetkiliMenu.SelectedIndex;
            switch (secilen)
            {
                case 0:
                    var bolumlistesi = db.Bolum.ToList();
                    cb_bolum_personel.DataSource = bolumlistesi;
                    var unvanlistesi = db.Unvanlar.ToList();
                    combo_unvan.DataSource = unvanlistesi;
                    var personelliste = db.Personel.ToList();
                    cb_personel_ekle_kategori.DataSource = db.Bolum.ToList();
                    dtg_personel.DataSource = personelliste;
                    dtg_personel.Columns[0].Visible = false;
                    dtg_personel.Columns[1].Visible = false;
                    dtg_personel.Columns[4].Visible = false;
                    dtg_personel.Columns[9].Visible = false;
                    dtg_personel.Columns[2].Width = 130; // AD GENİŞLİK
                    dtg_personel.Columns[3].Width = 120; // SOYAD GENİŞLİK
                    dtg_personel.Columns[5].Width = 90; // SİCİL NO GENİŞLİK
                    dtg_personel.Columns[6].Width = 120; // GOREV NO GENİŞİLİK
                    dtg_personel.Columns[7].Width = 150; // UNVAN GENİŞLİK
                    dtg_personel.Columns[8].Width = 150; // BOLUM GENİŞLİK
                    cb_bolum_personel.SelectedIndex = -1;
                    combo_unvan.SelectedIndex = -1;
                    cb_personel_ekle_kategori.SelectedIndex = -1;
                    break;
                case 1:
                    var kategori = db.Kategori.ToList();
                    datagrid_kategori.DataSource = kategori;
                    datagrid_kategori.Columns[0].Visible = false;
                    datagrid_kategori.Columns[2].Visible = false;
                    datagrid_kategori.Columns[1].Width = 730;
                    break;
                case 2:
                    var tip_liste = db.Tip.ToList();
                    data_olcu_birim.DataSource = tip_liste;
                    data_olcu_birim.Columns[0].Visible = false;
                    data_olcu_birim.Columns[2].Visible = false;
                    data_olcu_birim.Columns[1].Width = 730;
                    break;
                case 3:
                    var urunler = db.Urunler.ToList();
                    var tipliste = db.Tip.ToList();
                    var kategorilistesi = db.Kategori.ToList();
                    cb_urun_ekle_kategori.DataSource = db.Kategori.ToList();
                    cb_tip_urun.DataSource = tipliste;
                    cb_kategori_urun.DataSource = kategorilistesi;
                    data_Urunler.DataSource = urunler;
                    data_Urunler.Columns[0].Visible = false;
                    data_Urunler.Columns[5].Visible = false;
                    data_Urunler.Columns[6].Visible = false;
                    data_Urunler.Columns[4].Visible = false;
                    data_Urunler.Columns[9].Visible = false;
                    data_Urunler.Columns[1].Width = 150;
                    data_Urunler.Columns[2].Width = 240;
                    data_Urunler.Columns[3].Width = 70;
                    data_Urunler.Columns[7].Width = 165;
                    data_Urunler.Columns[8].Width = 127;
                    cb_tip_urun.SelectedIndex = -1;
                    cb_kategori_urun.SelectedIndex = -1;
                    cb_urun_ekle_kategori.SelectedIndex = -1;
                    break;
                case 4:
                    var unvanlar = db.Unvanlar.ToList();
                    dtgunvan.DataSource = unvanlar;
                    dtgunvan.Columns[0].Visible = false;
                    dtgunvan.Columns[2].Visible = false;
                    dtgunvan.Columns[1].Width = 761;
                    break;
                case 5:
                    var bolumler = db.Bolum.ToList();
                    dtg_bolum.DataSource = bolumler;
                    dtg_bolum.Columns[0].Visible = false;
                    dtg_bolum.Columns[2].Visible = false;
                    dtg_bolum.Columns[1].Width = 765;
                    break;
            }
        }
        private void tabAnaMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secilen = tabAnaMenu.SelectedIndex;
            switch (secilen)
            {
                case 0:
                    lbsonbesolay.Items.Clear();
                    lbsonbesurun.Items.Clear();
                    var besurun = db.Urunler.OrderBy(p => p.Adet).Take(5).ToList();
                    for (int i = 0; i < besurun.Count; i++)
                    {
                        lbsonbesurun.Items.Add(besurun[i].Ad + " Ürününden " + besurun[i].Adet + " Kalmıştır.");
                        lbsonbesurun.Items.Add(" ");
                    }

                    var besolay = db.tb_Urun_Cıkıs.OrderByDescending(p => p.Cıkıs_Tarihi).Take(5).ToList();
                    for (int j = 0; j < besolay.Count; j++)
                    {
                        lbsonbesolay.Items.Add(besolay[j].Ad + " " + besolay[j].Soyad + " " + besolay[j].Barkod + "'lu " + besolay[j].Urun_adi + " Üründen " + besolay[j].Adet + " tane Aldı.");
                        lbsonbesolay.Items.Add(" ");
                    }
                    var urunlertum = db.Urunler.ToList();
                    List<int> adet = new List<int>();
                    for (int i = 0; i < urunlertum.Count; i++)
                    {
                        int sayi = Convert.ToInt32(urunlertum[i].Adet.ToString());
                        adet.Add(Convert.ToInt32(sayi.ToString()));
                    }
                    break;
                case 1:
                    dt.Clear();
                    cb_urun_cıkıs_istekyapan.Items.Clear();
                    lbl_kisi.Text = "";
                    clb_urun_cıkıs_urunler.Items.Clear();
                    var urunler = db.Urunler.ToList();
                    foreach (var item in urunler)
                    {
                        string gelenurun = item.Ad;
                        clb_urun_cıkıs_urunler.Items.Add(gelenurun);
                    }
                    var personel_liste = db.Personel.ToList();
                    foreach (var item in personel_liste)
                    {
                        string adsoyad = item.Ad + " " + item.Soyad;
                        cb_urun_cıkıs_istekyapan.Items.Add(adsoyad);
                    }
                    cb_urun_cıkıs_istekyapan.SelectedIndex = -1;
                    dt.Columns.Clear();
                    dt.Columns.Add("SIRA NO", typeof(int));
                    dt.Columns.Add("BARKOD", typeof(String));
                    dt.Columns.Add("AD", typeof(String));
                    dt.Columns.Add("ÖLÇÜ BİRİMİ", typeof(String));
                    dt.Columns.Add("İSTENİLEN MİKTAR", typeof(int));
                    dt.Columns.Add("KARŞILANAN MİKTAR", typeof(string));
                    break;
                case 2:

                    var raporliste = db.tb_Urun_Cıkıs.ToList();
                    dtrapor.DataSource = raporliste;

                    dtrapor.Columns[8].Visible = false;
                    dtrapor.Columns[0].Width = 100; // AD GENİŞLİK
                    dtrapor.Columns[1].Width = 110; // SOYAD GENİŞLİK
                    dtrapor.Columns[2].Width = 110; // SİCİL NO GENİŞLİK
                    dtrapor.Columns[3].Width = 140; // BOLUM NO GENİŞİLİK
                    dtrapor.Columns[4].Width = 125; // UNVAN GENİŞLİK
                    dtrapor.Columns[5].Width = 50; // SİCİL NO GENİŞLİK
                    dtrapor.Columns[6].Width = 75; // BOLUM NO GENİŞİLİK
                    dtrapor.Columns[7].Width = 110; // UNVAN GENİŞLİK
                    dtrapor.Columns[8].Visible = false;
                    dt_rapor.Columns.Clear();
                    dt_rapor.Columns.Add("SİCİL NO", typeof(string));
                    dt_rapor.Columns.Add("AD", typeof(string));
                    dt_rapor.Columns.Add("SOYAD", typeof(string));
                    dt_rapor.Columns.Add("BARKOD", typeof(string));
                    dt_rapor.Columns.Add("URUN ADI", typeof(string));
                    dt_rapor.Columns.Add("ADET", typeof(string));
                    dt_rapor.Columns.Add("BİRİM", typeof(string));
                    dt_rapor.Columns.Add("K.MİKTAR", typeof(string));
                    cb_raporlar_listele_ad.DataSource = db.Personel.ToList();

                    break;
                case 3:
                    var bolumlistesi = db.Bolum.ToList();
                    cb_bolum_personel.DataSource = bolumlistesi;
                    var unvanlistesi = db.Unvanlar.ToList();
                    combo_unvan.DataSource = unvanlistesi;
                    var personelliste = db.Personel.ToList();
                    dtg_personel.DataSource = personelliste;
                    cb_personel_ekle_kategori.DataSource = db.Bolum.ToList();
                    dtg_personel.Columns[0].Visible = false;
                    dtg_personel.Columns[1].Visible = false;
                    dtg_personel.Columns[4].Visible = false;
                    dtg_personel.Columns[9].Visible = false;
                    dtg_personel.Columns[2].Width = 130; // AD GENİŞLİK
                    dtg_personel.Columns[3].Width = 120; // SOYAD GENİŞLİK
                    dtg_personel.Columns[5].Width = 90; // SİCİL NO GENİŞLİK
                    dtg_personel.Columns[6].Width = 120; // GOREV NO GENİŞİLİK
                    dtg_personel.Columns[7].Width = 150; // UNVAN GENİŞLİK
                    dtg_personel.Columns[8].Width = 150; // BOLUM GENİŞLİK
                    cb_bolum_personel.SelectedIndex = -1;
                    combo_unvan.SelectedIndex = -1;
                    cb_personel_ekle_kategori.SelectedIndex = -1;
                    break;
            }
        }
        int kisi;
        private void btn_urun_cıkıs_barkod_yazdır_Click(object sender, EventArgs e)
        {
            try
            {
                int sayi = datagrid_urun_cıkıs_sepet.RowCount;
                string barkod = txt_urun_cıkıs_barkod.Text;
                string adet = txt_urun_cıkıs_adet.Text;
                kisi = cb_urun_cıkıs_istekyapan.SelectedIndex;
                var urunler = db.Urunler.ToList();
                var gelen_urun = urunler.Where(p => p.Barkod == barkod).ToList();

                for (int l = sayac; l < dt.Rows.Count; l++)
                {
                    barkodlar.Add(datagrid_urun_cıkıs_sepet.Rows[l].Cells[1].Value.ToString());
                    sayac = sayac + 1;
                }

                if (barkodlar.Contains(barkod) == false)
                {
                    if (gelen_urun.Count == 0)
                    {
                        MessageBox.Show("Barkod Doğru Değil");
                    }
                    else
                    {
                        dt.Rows.Add((sayi + 1), barkod, (gelen_urun[0].Ad).ToString(), "ADET", adet, " ");
                        datagrid_urun_cıkıs_sepet.DataSource = dt;
                        veri = datagrid_urun_cıkıs_sepet.Rows[0].Cells[1].Value.ToString();
                        txt_urun_cıkıs_adet.Text = "";
                        cb_urun_cıkıs_istekyapan.Text = "";
                        txt_urun_cıkıs_adet.Enabled = false;
                        cb_urun_cıkıs_istekyapan.Enabled = false;
                        btn_urun_cıkıs_barkod_yazdır.Enabled = false;
                    }
                }
                else
                {
                    int sayilar = barkodlar.BinarySearch(barkod);
                    string urunadet = datagrid_urun_cıkıs_sepet.Rows[sayilar].Cells[4].Value.ToString();
                    datagrid_urun_cıkıs_sepet.Rows[sayilar].Cells[4].Value = Convert.ToInt32(urunadet) + Convert.ToInt32(txt_urun_cıkıs_adet.Text);
                    MessageBox.Show("Barkod Numarası Aynı Olan Değer Girdiniz. Adet Güncellendi.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ÇIKTI HATASI BİZE ULAŞIN: emirhanburgazli@gmail.com");
            }
        }

        private void cb_urun_cıkıs_istekyapan_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_urun_cıkıs_istekyapan.SelectedItem == null)
            {
                lbl_kisi.Text = "";
                MessageBox.Show("Lütfen Bir Personel Seçiniz");
            }
            else
            {
                cb_urun_cıkıs_istekyapan.Enabled = false;
                string ad = cb_urun_cıkıs_istekyapan.SelectedItem.ToString();
                parclar = ad.Split(' ');
                var gelenkisi = db.Personel.SqlQuery("Select * from Personel where Ad = @ad", new SqlParameter("@ad", parclar[0])).ToList().FirstOrDefault();

                lbl_kisi.Text = gelenkisi.Ad + " " + gelenkisi.Soyad;

                istekyapan = gelenkisi.Ad + " " + gelenkisi.Soyad;
            }
        }
        private void hazırlayanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hakkimizda h = new Hakkimizda();
            h.Show();
        }
        private void txt_urun_cıkıs_barkod_TextChanged(object sender, EventArgs e)
        {
            txt_urun_cıkıs_barkod.Text = txt_urun_cıkıs_barkod.Text.ToUpper();
            string deger = txt_urun_cıkıs_barkod.Text;
            if (deger.Count() != 0)
            {
                gb_manuel_urun_cıkıs.Enabled = false;
                var urunler = db.Urunler.ToList();

                var urunadigetir = urunler.Where(p => p.Barkod == deger).ToList();
                if (urunadigetir.Count != 0)
                {
                    txt_urun_cıkıs_adet.Enabled = true;
                    cb_urun_cıkıs_istekyapan.Enabled = true;
                    btn_urun_cıkıs_barkod_yazdır.Enabled = true;
                    lbl_urun_cıkıs_urun_adi.Text = urunadigetir[0].Ad.ToString();
                }
                else
                {
                    lbl_urun_cıkıs_urun_adi.Text = "ÜRÜN YOK";
                }
            }
            else
            {
                gb_manuel_urun_cıkıs.Enabled = true;
            }
        }
        private void txt_ad_personel_TextChanged(object sender, EventArgs e)
        {
            txt_ad_personel.CharacterCasing = CharacterCasing.Upper;
        }
        private void txt_soyad_personel_TextChanged(object sender, EventArgs e)
        {
            txt_soyad_personel.CharacterCasing = CharacterCasing.Upper;
        }
        private void txt_ad_g_TextChanged(object sender, EventArgs e)
        {
            txt_ad_g.CharacterCasing = CharacterCasing.Upper;
        }
        private void txt_soyad_g_TextChanged(object sender, EventArgs e)
        {
            txt_soyad_g.CharacterCasing = CharacterCasing.Upper;
        }
        private void txt_ad_kategori_TextChanged(object sender, EventArgs e)
        {
            txt_ad_kategori.CharacterCasing = CharacterCasing.Upper;
        }
        private void txt_ad_kategori_guncelle_TextChanged(object sender, EventArgs e)
        {
            txt_ad_kategori_guncelle.CharacterCasing = CharacterCasing.Upper;
        }
        private void txt_ad_olcu_TextChanged(object sender, EventArgs e)
        {
            txt_ad_olcu.CharacterCasing = CharacterCasing.Upper;
        }
        private void txt_ad_guncelle_olcu_TextChanged(object sender, EventArgs e)
        {
            txt_ad_guncelle_olcu.CharacterCasing = CharacterCasing.Upper;
        }
        private void txt_barkod_urun_TextChanged(object sender, EventArgs e)
        {
            txt_barkod_urun.CharacterCasing = CharacterCasing.Upper;
            ///////ÜRÜN VAR MI KONTROL ET
            //var deger = db.Urunler.Where(p => p.Barkod == txt_barkod_urun.Text).FirstOrDefault().ToString();

        }
        private void txt_ad_urun_TextChanged(object sender, EventArgs e)
        {
            txt_ad_urun.CharacterCasing = CharacterCasing.Upper;
        }
        private void txt_adet_urun_TextChanged(object sender, EventArgs e)
        {
            txt_adet_urun.CharacterCasing = CharacterCasing.Upper;
        }
        private void txt_barkod_guncelle_urun_TextChanged(object sender, EventArgs e)
        {
            txt_barkod_guncelle_urun.CharacterCasing = CharacterCasing.Upper;
        }
        private void txt_ad_guncelle_urun_TextChanged(object sender, EventArgs e)
        {
            txt_ad_guncelle_urun.CharacterCasing = CharacterCasing.Upper;
        }
        private void txt_adet_guncelle_urun_TextChanged(object sender, EventArgs e)
        {
            txt_adet_guncelle_urun.CharacterCasing = CharacterCasing.Upper;
        }

        private void btn_ekle_personel_Click(object sender, EventArgs e)
        {
            try
            {
                Personel pe = new Personel();
                if (txt_ad_personel.Text == "" || txt_soyad_personel.Text == "" || txt_personel_ekle_gorev.Text == "" || combo_unvan.SelectedIndex == -1 || txt_sicil_no_personel.Text == "" || cb_bolum_personel.SelectedIndex == -1)
                {
                    MessageBox.Show("Boş alan Bırakmayınız.");
                }
                else
                {
                    var perliste = db.Personel.Where(a => a.Sicil_No == txt_sicil_no_personel.Text).ToList();
                    if (perliste.Count == 1)
                    {
                        MessageBox.Show("Bu Sicil Numarada Birisi Kayıtlı");
                    }
                    else
                    {
                        pe.Sicil_No = txt_sicil_no_personel.Text;
                        var unvanlar = db.Unvanlar.Where(p => p.Ad == combo_unvan.Text).ToList();
                        pe.Unvan_ID = unvanlar[0].Unvan_ID;
                        pe.Soyad = txt_soyad_personel.Text;
                        pe.Ad = txt_ad_personel.Text;
                        pe.Gorev = txt_personel_ekle_gorev.Text;
                        var bolumler = db.Bolum.Where(b => b.Bolum_Adi == cb_bolum_personel.Text).ToList();
                        pe.Bolum_ID = bolumler[0].Bolum_ID;
                        db.Personel.Add(pe);
                        db.SaveChanges();
                        var liste = db.Personel.ToList();
                        dtg_personel.DataSource = liste;
                        MessageBox.Show("Başarıyla Eklendi");
                        sil();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Veri Eklemede Hata Oluştu. Lütfen Bizimle İletişime Geçiniz.");
            }
        }

        private void btn_kaydet_personel_Click(object sender, EventArgs e)
        {
            try
            {
                var guncelle = db.Personel.Find(Convert.ToInt32(id));
                guncelle.Ad = txt_ad_g.Text;
                guncelle.Soyad = txt_soyad_g.Text;
                guncelle.Sicil_No = txt_sicil_no_g.Text;
                guncelle.Gorev = txt_personel_ekle_gorev_guncelle.Text;
                if (combo_guncelle_unvan.SelectedIndex == -1)
                {
                    guncelle.Unvan_ID = secili_unvan;
                }
                else
                {
                    var unvanid = db.Unvanlar.Where(p => p.Ad == combo_guncelle_unvan.Text).ToList();
                    guncelle.Unvan_ID = unvanid[0].Unvan_ID;
                }
                if (cb_bolum_g.SelectedIndex == -1)
                {
                    guncelle.Bolum_ID = secili_bolum;
                }
                else
                {
                    var bolumid = db.Bolum.Where(p => p.Bolum_Adi == cb_bolum_g.Text).ToList();
                    guncelle.Bolum_ID = bolumid[0].Bolum_ID;
                }
                db.SaveChanges();
                txt_ad_g.Text = "";
                txt_soyad_g.Text = "";
                combo_guncelle_unvan.SelectedIndex = -1;
                cb_bolum_g.SelectedIndex = -1;
                txt_sicil_no_g.Text = "";

                var liste = db.Personel.ToList();
                dtg_personel.DataSource = liste;
                MessageBox.Show("Düzenleme Kaydedildi..");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR:10 Burada Ekleme İşlemi Yapamazsınız..");
            }
        }
        private void btn_raporla_goster_Click(object sender, EventArgs e)
        {
            //dt_rapor.Clear();
            var selectedRows = dtrapor.SelectedRows.OfType<DataGridViewRow>().Where(row => !row.IsNewRow).ToArray(); // seçili olan satırları yakalar.
            dt_rapor.Clear();
            foreach (var item in selectedRows)
            {
                var deger = dtrapor.Rows[item.Index].Cells[0].Value;
                var deger1 = dtrapor.Rows[item.Index].Cells[1].Value;
                var deger2 = dtrapor.Rows[item.Index].Cells[2].Value;
                var deger3 = dtrapor.Rows[item.Index].Cells[3].Value;
                var deger4 = dtrapor.Rows[item.Index].Cells[4].Value;
                var deger5 = dtrapor.Rows[item.Index].Cells[5].Value;
                var deger6 = dtrapor.Rows[item.Index].Cells[6].Value;
                var deger7 = dtrapor.Rows[item.Index].Cells[7].Value;
                dt_rapor.Rows.Add(deger.ToString(), deger1.ToString(), deger2.ToString(), deger3.ToString(), deger4.ToString(), deger5.ToString(), deger6.ToString(), deger7.ToString());
            }
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        int i;
        List<string> rapor_barkodlar = new List<string>();
        List<string> rapor_ad = new List<string>();
        List<string> rapor_adet = new List<string>();
        List<string> rapor_tip = new List<string>();
        List<string> rapor_kategori = new List<string>();
        List<string> rapor_tarih = new List<string>();
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string tarih = DateTime.Now.ToString();
            int boyut = tarih.ToString().Length;
            string kısatarih = tarih.Substring(0, boyut - 9);
            e.Graphics.DrawString("İZMİR MESLEK YÜKSEK OKULU TAŞINIR İSTEK BELGESİ", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(70, 30));
            e.Graphics.DrawString("İSTEK YAPAN KİŞİ: " + istekyapan, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 80));
            e.Graphics.DrawString("TARİH: " + kısatarih, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 80));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 90));
            e.Graphics.DrawString("SIRA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(20, 120));
            e.Graphics.DrawString("SİCİL NO", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(80, 120));
            e.Graphics.DrawString("ADI", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(200, 120));
            e.Graphics.DrawString("SOYAD", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(290, 120));
            e.Graphics.DrawString("URUN ADI", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(410, 120));
            e.Graphics.DrawString("ADET", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(530, 120));
            e.Graphics.DrawString("BİRİM", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(610, 120));
            e.Graphics.DrawString("MİKTAR", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(700, 120));
            for (i = 0; i < dt_rapor.Rows.Count; i++)
            {
                e.Graphics.DrawString((i + 1).ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(25, 150 + i * 35));
                e.Graphics.DrawString(dt_rapor.Rows[i][0].ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 150 + i * 35));
                e.Graphics.DrawString(dt_rapor.Rows[i][1].ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(200, 150 + i * 35));
                e.Graphics.DrawString(dt_rapor.Rows[i][2].ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(290, 150 + i * 35));
                e.Graphics.DrawString(dt_rapor.Rows[i][4].ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(410, 150 + i * 35));
                e.Graphics.DrawString(dt_rapor.Rows[i][5].ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(545, 150 + i * 35));
                e.Graphics.DrawString(dt_rapor.Rows[i][6].ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(610, 150 + i * 35));
                e.Graphics.DrawString(dt_rapor.Rows[i][5].ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(715, 150 + i * 35));
            }
            e.Graphics.DrawString("TAŞINIR İŞLEM YETKİLİSİ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(100, 170 + i * 35));
            e.Graphics.DrawString("AHMET AÇIL", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(145, 190 + i * 35));
            e.Graphics.DrawString("TESLİM ALAN", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(550, 170 + i * 35));
            e.Graphics.DrawString(istekyapan, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 190 + i * 35));
        }

        private void btn_raporlar_isim_Click(object sender, EventArgs e)
        {
            if (cb_raporlar_listele_ad.Text != "HEPSİ")
            {
                dtrapor.DataSource = db.tb_Urun_Cıkıs.SqlQuery("select * from tb_Urun_Cıkıs where Ad = @ad and Cıkıs_Tarihi = @tarih", new SqlParameter("@ad", cb_raporlar_listele_ad.SelectedItem.ToString()), new SqlParameter("@tarih", dtp_raporlar_listele_tarih.Text)).ToList();
            }
            else
            {
                dtrapor.DataSource = db.tb_Urun_Cıkıs.ToList();
            }

        }
        private void btn_unvan_ekle_guncele_Click(object sender, EventArgs e)
        {
            try
            {
                var guncelle = db.Unvanlar.Find(Convert.ToInt32(id));
                guncelle.Ad = txt_unvan_ekle_ad_guncelle.Text;
                db.SaveChanges();
                var liste = db.Unvanlar.ToList();
                dtgunvan.DataSource = liste;
                MessageBox.Show("Düzenleme Kaydedildi.");
            }
            catch (Exception)
            {
                MessageBox.Show("Burdan Veri Girişi Yapamazsınız..");
            }
        }

        private void btn_unvan_ekle_sil_Click(object sender, EventArgs e)
        {
            var silinecek = db.Unvanlar.Find(Convert.ToInt32(id));
            if (silinecek == null)
            {
                MessageBox.Show("Silinecek Verinin Üzerine Tıklanıyınız");
            }
            else
            {
                db.Unvanlar.Remove(silinecek);
                db.SaveChanges();
                var unvanlar = db.Unvanlar.ToList();
                dtgunvan.DataSource = unvanlar;
                txt_unvan_ekle_ad_guncelle.Text = "";
                MessageBox.Show("Silme İşlemi Tamamladı..");
            }
        }

        private void btn_unvan_ekle_onayla_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_unvan_ekle_ad.Text == "")
                {
                    MessageBox.Show("Lütfen Boş Bırakmayınız..");
                }
                else
                {
                    unvn.Ad = txt_unvan_ekle_ad.Text;
                    db.Unvanlar.Add(unvn);
                    db.SaveChanges();
                    txt_unvan_ekle_ad.Text = "";
                    var unvanlar = db.Unvanlar.ToList();
                    dtgunvan.DataSource = unvanlar;
                    MessageBox.Show("Kayıt Başarıyla Eklendi");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Veri Eklemede Hata Oluştu. Lütfen Bizimle İletişime Geçiniz.");
            }
        }

        private void dtgunvan_Click(object sender, EventArgs e)
        {
            try
            {
                txt_unvan_ekle_ad_guncelle.Text = dtgunvan.CurrentRow.Cells["Ad"].Value.ToString();
                id = dtgunvan.CurrentRow.Cells["Unvan_ID"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Veri Kaydı Yoktur..");
            }

        }

        private void btn_bolum_ekle_onayla_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_bolum_ekle_ad.Text == "")
                {
                    MessageBox.Show("Lütfen Boş Bırakmayınız..");
                }
                else
                {
                    bolum.Bolum_Adi = txt_bolum_ekle_ad.Text;
                    db.Bolum.Add(bolum);
                    db.SaveChanges();
                    txt_bolum_ekle_ad.Text = "";
                    var bolumler = db.Bolum.ToList();
                    dtg_bolum.DataSource = bolumler;
                    MessageBox.Show("Kayıt Başarıyla Eklendi");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Veri Eklemede Hata Oluştu. Lütfen Bizimle İletişime Geçiniz.");
            }

        }

        private void btn_bolum_ekle_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var guncelle = db.Bolum.Find(Convert.ToInt32(id));
                guncelle.Bolum_Adi = txt_bolum_ekle_guncelle_ad.Text;
                db.SaveChanges();
                var liste = db.Bolum.ToList();
                dtg_bolum.DataSource = liste;
                MessageBox.Show("Düzenleme Kaydedildi.");
            }
            catch (Exception)
            {
                MessageBox.Show("Burdan Veri Girişi Yapamazsınız..");
            }
        }

        private void btn_bolum_ekle_sil_Click(object sender, EventArgs e)
        {
            try
            {
                var silinecek = db.Bolum.Find(Convert.ToInt32(id));
                if (silinecek == null)
                {
                    MessageBox.Show("Silinecek Verinin Üzerine Tıklanıyınız");
                }
                else
                {
                    db.Bolum.Remove(silinecek);
                    db.SaveChanges();
                    var bolumler = db.Bolum.ToList();
                    dtg_bolum.DataSource = bolumler;
                    sil();
                    MessageBox.Show("Silme İşlemi Tamamladı..");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bu Satırı Silemezsiniz.");
            }

        }

        private void dtg_bolum_Click(object sender, EventArgs e)
        {
            try
            {
                txt_bolum_ekle_guncelle_ad.Text = dtg_bolum.CurrentRow.Cells["Bolum_Adi"].Value.ToString();
                id = dtg_bolum.CurrentRow.Cells["Bolum_ID"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Veri Kaydı Yoktur..");
            }

        }

        private void txt_unvan_ekle_ad_TextChanged(object sender, EventArgs e)
        {
            txt_unvan_ekle_ad.CharacterCasing = CharacterCasing.Upper;
        }

        private void txt_unvan_ekle_ad_guncelle_TextChanged(object sender, EventArgs e)
        {
            txt_unvan_ekle_ad_guncelle.CharacterCasing = CharacterCasing.Upper;
        }

        private void txt_bolum_ekle_ad_TextChanged(object sender, EventArgs e)
        {
            txt_bolum_ekle_ad.CharacterCasing = CharacterCasing.Upper;
        }

        private void txt_bolum_ekle_guncelle_ad_TextChanged(object sender, EventArgs e)
        {
            txt_bolum_ekle_guncelle_ad.CharacterCasing = CharacterCasing.Upper;
        }

        private void btn_urun_cıkıs_raporla_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Raporlamak İçin Veri Bulunamadı..");
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cb_urun_cıkıs_istekyapan.Enabled = true;
                    sira_no.Add(datagrid_urun_cıkıs_sepet.Rows[i].Cells[0].Value.ToString());
                    barkod.Add(datagrid_urun_cıkıs_sepet.Rows[i].Cells[1].Value.ToString());
                    ad.Add(datagrid_urun_cıkıs_sepet.Rows[i].Cells[2].Value.ToString());
                    olcu_birimi.Add(datagrid_urun_cıkıs_sepet.Rows[i].Cells[3].Value.ToString());
                    istenilen_miktar.Add(Convert.ToInt32(datagrid_urun_cıkıs_sepet.Rows[i].Cells[4].Value));

                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var urunid = db.Urunler.SqlQuery("Select * from Urunler where Barkod = @id", new SqlParameter("@id", barkod[i])).FirstOrDefault();
                    var personelid = db.Personel.SqlQuery("Select * from Personel where Ad = @id", new SqlParameter("@id", parclar[0])).FirstOrDefault();
                    uh.Urun_ID = urunid.UrunID;
                    uh.Personel_ID = personelid.Personel_ID;
                    uh.Adet = Convert.ToInt32(istenilen_miktar[i]);
                    Urunler processUrunler = db.Urunler.Where(p => p.UrunID == urunid.UrunID).Single();
                    if (processUrunler.Adet < istenilen_miktar[i])
                    {
                        MessageBox.Show("Ürün Stok Miktarını Kontrol Ediniz.");
                        dt.Clear();
                    }
                    else
                    {
                        processUrunler.Adet = Convert.ToInt16(processUrunler.Adet - uh.Adet);
                        uh.Cıkıs_Tarihi = DateTime.Now;
                        db.Urun_Hareket.Add(uh);
                        db.SaveChanges();
                        MessageBox.Show("Kayıt Gerçekleştirildi. Raporlar Sayfasına Gidiniz..");
                        dt.Clear();
                    }
                }
            }
        }

        private void cb_urun_ekle_kategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (katsayac > 1)
                {
                    string kat_ad = cb_urun_ekle_kategori.Text;
                    if (kat_ad == "HEPSİ")
                    {
                        var urunler = db.Urunler.ToList();
                        data_Urunler.DataSource = urunler;
                    }
                    else
                    {
                        var katid = db.Kategori.SqlQuery("Select * from kategori where ad = @id", new SqlParameter("@id", kat_ad)).FirstOrDefault();
                        data_Urunler.DataSource = katid.Urunler.ToList();
                    }

                }
                else
                {
                    katsayac++;
                }
            }
            catch (Exception)
            {


            }
        }

        private void cb_personel_ekle_kategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (katsayac > 1)
                {
                    string bol_ad = cb_personel_ekle_kategori.Text;
                    if (bol_ad == "HEPSİ")
                    {
                        var bolumler = db.Bolum.ToList();
                        dtg_personel.DataSource = bolumler;
                    }
                    else
                    {
                        var bolid = db.Bolum.SqlQuery("Select * from bolum where Bolum_Adi = @id", new SqlParameter("@id", bol_ad)).FirstOrDefault();
                        dtg_personel.DataSource = bolid.Personel.ToList();
                    }
                }
                else
                {
                    katsayac++;
                }
            }
            catch (Exception)
            {

            }
        }

        private void dtg_personel_Click_1(object sender, EventArgs e)
        {
            try
            {
                secili_bolum = Convert.ToInt32((dtg_personel.CurrentRow.Cells["Bolum_ID"].Value.ToString()));
                secili_unvan = Convert.ToInt32((dtg_personel.CurrentRow.Cells["Unvan_ID"].Value.ToString()));
                id = dtg_personel.CurrentRow.Cells["Personel_ID"].Value.ToString();
                if (txt_ad_g.Text == "")
                {
                    cb_bolum_g.Items.Clear();
                    combo_guncelle_unvan.Items.Clear();
                    var bolumlistesi = db.Bolum.ToList();
                    int sayi = bolumlistesi.Count();
                    for (int i = 0; i < sayi; i++)
                    {
                        cb_bolum_g.Items.Add(bolumlistesi[i].Bolum_Adi);
                    }
                    var unvanlistesi = db.Unvanlar.ToList();
                    for (int i = 0; i < unvanlistesi.Count; i++)
                    {
                        combo_guncelle_unvan.Items.Add(unvanlistesi[i].Ad);
                    }
                }
                txt_ad_g.Text = dtg_personel.CurrentRow.Cells["Ad"].Value.ToString();
                txt_soyad_g.Text = dtg_personel.CurrentRow.Cells["Soyad"].Value.ToString();
                if (dtg_personel.CurrentRow.Cells[6].Value == null)
                {
                    txt_personel_ekle_gorev_guncelle.Text = "";
                }
                else
                {
                    txt_personel_ekle_gorev_guncelle.Text = dtg_personel.CurrentRow.Cells[6].Value.ToString();
                }
                var bolum_adi = db.Bolum.Where(p => p.Bolum_ID == secili_bolum).ToList();
                cb_bolum_g.Text = bolum_adi[0].Bolum_Adi;
                txt_sicil_no_g.Text = dtg_personel.CurrentRow.Cells["Sicil_No"].Value.ToString();

                if (cb_bolum_g.SelectedIndex == -1)
                {
                    cb_bolum_g.SelectedIndex = -1;
                }
                else
                {
                    cb_bolum_g.SelectedItem = dtg_personel.CurrentRow.Cells["Bolum"].Value.ToString();
                }
                var unvanlar = db.Unvanlar.Where(p => p.Unvan_ID == secili_unvan).ToList();
                combo_guncelle_unvan.Text = unvanlar[0].Ad;

                if (combo_guncelle_unvan.SelectedIndex == -1)
                {
                    combo_guncelle_unvan.SelectedIndex = -1;
                }
                else
                {
                    combo_guncelle_unvan.SelectedItem = dtg_personel.CurrentRow.Cells["Unvanlar"].Value.ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btn_urun_ekle_raporla_Click(object sender, EventArgs e)
        {
            rapor_barkodlar.Clear();
            rapor_ad.Clear();
            rapor_adet.Clear();
            rapor_tip.Clear();
            rapor_kategori.Clear();
            MessageBox.Show("Raporlamak Sunucu Hızınıza Göre Değişiklik Gösterebilir.. Lütfen Bekleyin..");
            if (cb_urun_ekle_kategori.Text != "")
            {
                foreach (var item in data_Urunler.Rows)
                {
                    for (int i = 0; i < data_Urunler.Rows.Count; i++)
                    {
                        var barkod = data_Urunler.Rows[i].Cells[1].Value;
                        var ad = data_Urunler.Rows[i].Cells[2].Value;
                        var adet = data_Urunler.Rows[i].Cells[3].Value;
                        var tip = db.Tip.SqlQuery("Select * from Tip where Urun_Tipi_ID = @id", new SqlParameter("@id", data_Urunler.Rows[i].Cells[4].Value)).FirstOrDefault();
                        var kategori = db.Kategori.SqlQuery("Select * from kategori where Kategori_ID = @id", new SqlParameter("@id", data_Urunler.Rows[i].Cells[5].Value)).FirstOrDefault();
                        var giris_tarihi = data_Urunler.Rows[i].Cells[6].Value;
                        rapor_barkodlar.Add(barkod.ToString());
                        rapor_ad.Add(ad.ToString());
                        rapor_adet.Add(adet.ToString());
                        rapor_tip.Add(tip.ToString());
                        rapor_kategori.Add(kategori.ToString());
                    }
                }
                printPreviewDialog2.Document = printDocument2;
                printPreviewDialog2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Test");
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string tarih = DateTime.Now.ToString();
            int boyut = tarih.ToString().Length;
            string kısatarih = tarih.Substring(0, boyut - 9);
            e.Graphics.DrawString("İZMİR MESLEK YÜKSEK OKULU RAPOR BELGESİ", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(90, 30));
            e.Graphics.DrawString("TARİH: " + kısatarih, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 80));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 90));
            e.Graphics.DrawString("SIRA", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(20, 120));
            e.Graphics.DrawString("BARKOD", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(80, 120));
            e.Graphics.DrawString("ADI", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(200, 120));
            e.Graphics.DrawString("ADET", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(465, 120));
            e.Graphics.DrawString("TİPİ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(535, 120));
            e.Graphics.DrawString("KATEGORİ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(615, 120));
            for (i = 0; i < data_Urunler.Rows.Count; i++)
            {
                e.Graphics.DrawString((i + 1).ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(25, 150 + i * 35));
                e.Graphics.DrawString(rapor_barkodlar[i], new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 150 + i * 35));
                e.Graphics.DrawString(rapor_ad[i], new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(200, 150 + i * 35));
                e.Graphics.DrawString(rapor_adet[i], new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(470, 150 + i * 35));
                e.Graphics.DrawString(rapor_tip[i], new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(535, 150 + i * 35));
                e.Graphics.DrawString(rapor_kategori[i], new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(615, 150 + i * 35));
            }
        }

        private void kullanıcıBilgileriGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifre_Degistirme sifre_degistir = new Sifre_Degistirme();
            this.Hide();
            sifre_degistir.Show();
        }
        int numara;
        private void dtrapor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//farenin sağ tuşuna basılmışsa
            {
                int satir = dtrapor.HitTest(e.X, e.Y).RowIndex;
                if (satir > -1) //www.yazilimkodlama.com
                {
                    dtrapor.Rows[satir].Selected = true;//bu tıkladığımız alanı seçtiriyoruz
                    numara = Convert.ToInt32(dtrapor.Rows[satir].Cells[8].Value);
                }
            }
        }

        private void txt_urun_cıkıs_ara_TextChanged(object sender, EventArgs e)
        {
            var gelenkisi = db.Urunler.SqlQuery("Select * from Urunler where Ad like '%'+@ad+'%'", new SqlParameter("@ad", txt_urun_cıkıs_ara.Text)).ToList();
            clb_urun_cıkıs_urunler.Items.Clear();
            foreach (var item in gelenkisi)
            {
                clb_urun_cıkıs_urunler.Items.Add(item);
            }
        }

        private void clb_urun_cıkıs_urunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in clb_urun_cıkıs_urunler.CheckedItems)
            {
                var secilenUrun = db.Urunler.SqlQuery("select * from Urunler where Ad=@ad", new SqlParameter("@ad", item.ToString())).ToList().FirstOrDefault();
                //var secilenbarkod = db.Urunler.SqlQuery("select * from Urunler where Barkod=@barkod", new SqlParameter("@barkod", item.ToString())).ToList().FirstOrDefault();
                string adet = Interaction.InputBox("Adet Giriniz?");
                dt.Rows.Add(1, secilenUrun.Barkod, secilenUrun.Ad, "ADET", adet, " ");
                datagrid_urun_cıkıs_sepet.DataSource = dt;
            }

        }



        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sil(numara);
        }

        private void sil(int numara)
        {

            string inSifre = Interaction.InputBox("Şifrenizi Giriniz ", "Güvenlik İçin");
            var deger = db.Kullanici.SqlQuery("Select * from Kullanici where Kullanici_Adi=@ad and Sifre=@sifre", new SqlParameter("@ad", "ahmet"), new SqlParameter("@sifre", inSifre)).ToList();
            if (deger.Count != 1)
            {
                MessageBox.Show("Silme İşlemi İçin Yetkiniz Olması Gerekmektedir.");
            }
            else
            {
                var silinecek = db.Urun_Hareket.Find(Convert.ToInt32(numara));
                db.Urun_Hareket.Remove(silinecek);
                db.SaveChanges();
                var uharaket = db.tb_Urun_Cıkıs.ToList();
                dtrapor.DataSource = uharaket;
                dtrapor.DataSource = db.tb_Urun_Cıkıs.ToList();
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

