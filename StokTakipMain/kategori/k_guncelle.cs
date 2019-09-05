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
    public partial class k_guncelle : Form
    {
        public k_guncelle()
        {
            InitializeComponent();
        }
        //StokTakipEntities7 db = new StokTakipEntities7();
        İmyoStokTakipEntities db = new İmyoStokTakipEntities();
        private void k_guncelle_Load(object sender, EventArgs e)
        {

            var kategori = db.Kategori.ToList();
            datagrid_kategori.DataSource = kategori;
            datagrid_kategori.Columns[0].Visible = false;
            datagrid_kategori.Columns[2].Visible = false;
            datagrid_kategori.Columns[1].Width = 197;
        }
        string id;
        private void datagrid_kategori_Click(object sender, EventArgs e)
        {
            txt_ad.Text = datagrid_kategori.CurrentRow.Cells["Ad"].Value.ToString();
            id = datagrid_kategori.CurrentRow.Cells["Kategori_ID"].Value.ToString();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {

            var silinecek = db.Kategori.Find(Convert.ToInt32(id));
            if (txt_ad.Text == "")
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

        private void sil()
        {
            txt_ad.Text = "";
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var guncelle = db.Kategori.Find(Convert.ToInt32(id));
                guncelle.Ad = txt_ad.Text;
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
    }
}
