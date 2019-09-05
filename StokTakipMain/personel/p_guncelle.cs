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
    public partial class p_guncelle : Form
    {
        public p_guncelle()
        {
            InitializeComponent();
        }
        //StokTakipEntities7 db = new StokTakipEntities7();
        İmyoStokTakipEntities db = new İmyoStokTakipEntities();
        private void Guncelle_Load(object sender, EventArgs e)
        {

            var liste = db.Personel.ToList();
            dataGridView1.DataSource = liste;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 110;
            dataGridView1.Columns[3].Width = 105;
            dataGridView1.Columns[5].Width = 230;
            cb_bolum.SelectedIndex = -1;
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var guncelle = db.Personel.Find(Convert.ToInt32(id));
                guncelle.Ad = txt_ad.Text;
                guncelle.Soyad = txt_soyad.Text;
                guncelle.Unvan = txt_unvan.Text;
                guncelle.Bolum_ID = cb_bolum.SelectedIndex;
                db.SaveChanges();
                var liste = db.Personel.ToList();
                dataGridView1.DataSource = liste;
                MessageBox.Show("Düzenleme Kaydedildi..");
            }
            catch (Exception)
            {

                MessageBox.Show("Burada Ekleme İşlemi Yapamazsınız..");
            }

        }
        string id;
        private void btn_sil_Click(object sender, EventArgs e)
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
                    dataGridView1.DataSource = liste;
                    sil();
                    MessageBox.Show("Silme İşlemi Tamamlandı..");
                }
                catch (Exception)
                {

                    MessageBox.Show("Bu Kişiyi Silemezsiniz..");
                }

            }
        }
        private void sil()
        {
            txt_ad.Text = "";
            txt_soyad.Text = "";
            txt_unvan.Text = "";
            cb_bolum.SelectedIndex = -1;
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (txt_soyad.Text == "")
            {
                var bolumlistesi = db.Bolum.ToList();
                cb_bolum.Items.Add(bolumlistesi[0].Bolum_Adi);
                cb_bolum.Items.Add(bolumlistesi[1].Bolum_Adi);
                cb_bolum.Items.Add(bolumlistesi[2].Bolum_Adi);
            }
            txt_unvan.Text = dataGridView1.CurrentRow.Cells["Unvan"].Value.ToString();
            txt_ad.Text = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString();
            txt_soyad.Text = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString();
            cb_bolum.SelectedIndex = Convert.ToInt32((dataGridView1.CurrentRow.Cells["Bolum_ID"].Value.ToString()));
            if (cb_bolum.SelectedItem == null)
            {
                cb_bolum.SelectedIndex = -1;
            }
            else
            {
                cb_bolum.SelectedItem = dataGridView1.CurrentRow.Cells["Bolum"].Value.ToString();
            }
            id = dataGridView1.CurrentRow.Cells["Personel_ID"].Value.ToString();
        }

    }
}
