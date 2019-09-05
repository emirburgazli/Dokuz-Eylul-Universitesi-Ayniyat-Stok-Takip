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

namespace StokTakipMain.tip
{
    public partial class t_guncelle : Form
    {
        public t_guncelle()
        {
            InitializeComponent();
        }
        //StokTakipEntities7 db = new StokTakipEntities7();
        İmyoStokTakipEntities db = new İmyoStokTakipEntities();
        private void btn_kabul_Click(object sender, EventArgs e)
        {

        }

        private void t_guncelle_Load(object sender, EventArgs e)
        {

            var liste = db.Tip.ToList();
            datagrid_tip.DataSource = liste;
            datagrid_tip.Columns[0].Visible = false;
            datagrid_tip.Columns[2].Visible = false;
            datagrid_tip.Columns[1].Width = 196;
        }
        string id;
        private void btn_sil_Click(object sender, EventArgs e)
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
                    datagrid_tip.DataSource = liste;
                    txt_ad.Text = "";
                    MessageBox.Show("Silme İşleminiz Tamamlandı..");
                }
                catch (Exception)
                {

                    MessageBox.Show("Bu Veriyi Silemezsiniz..");
                }
            }
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var guncelle = db.Tip.Find(Convert.ToInt32(id));
                guncelle.Ad = txt_ad.Text;
                db.SaveChanges();
                var liste = db.Tip.ToList();
                datagrid_tip.DataSource = liste;
                MessageBox.Show("Düzenleme Kaydedildi..");
            }
            catch (Exception)
            {

                MessageBox.Show("Buradan Ekleme Yapamazsınız..");
            }
        }

        private void datagrid_tip_Click(object sender, EventArgs e)
        {
            txt_ad.Text = datagrid_tip.CurrentRow.Cells["Ad"].Value.ToString();
            id = datagrid_tip.CurrentRow.Cells["Urun_Tipi_ID"].Value.ToString();
        }
    }
}
