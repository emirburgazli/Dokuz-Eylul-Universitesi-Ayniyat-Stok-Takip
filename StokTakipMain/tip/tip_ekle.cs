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
    public partial class tip_ekle : Form
    {
        public tip_ekle()
        {
            InitializeComponent();
        }
        //StokTakipEntities7 db = new StokTakipEntities7();
        İmyoStokTakipEntities db = new İmyoStokTakipEntities();
        private void tip_ekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            main main = new main();
            main.Show();
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            main main = new main();
            main.Show();
        }

        private void btn_kabul_Click(object sender, EventArgs e)
        {
            if (txt_ad.Text == "")
            {
                MessageBox.Show("Lütfen Boş Bırakmayınız..");
            }
            else
            {
                Tip t = new Tip();
                t.Ad = txt_ad.Text;
                db.Tip.Add(t);
                db.SaveChanges();
                MessageBox.Show("Başarıyla Eklendi..");
                txt_ad.Text = "";

            }
        }

        private void güncelleSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t_guncelle tg = new t_guncelle();
            tg.Show();

        }


    }
}
