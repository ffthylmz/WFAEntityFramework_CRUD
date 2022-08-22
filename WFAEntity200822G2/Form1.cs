using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAEntity200822G2
{
    public partial class Form1 : Form
    {
        RehberDBEntities db = new RehberDBEntities();

        public void KisileriDoldur(List<Kisi> kisiListesi)
        {
            listView1.Items.Clear();

            foreach (var item in kisiListesi)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = item.ID.ToString(); // Listview ' in constructor metodunda ıd.Text şeklinde geldiği için yazıldı.
                listViewItem.SubItems.Add(item.Ad);
                listViewItem.SubItems.Add(item.Soyad);
                listViewItem.SubItems.Add(item.Telefon);

                listViewItem.Tag = item;
                listView1.Items.Add(listViewItem);
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            if (txtAd.Text.Trim() == "" || txtSoyad.Text.Trim() == "" || txtTelefon.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen her alanı doldurduğunuzdan emin olunuz!");
            }
            else
            {
                Kisi kisi1 = new Kisi();
                kisi1.Ad = txtAd.Text;
                kisi1.Soyad = txtSoyad.Text;

                if (txtTelefon.Text.Length > 10)
                {
                    MessageBox.Show("Lütfen 10 haneli giriş yapınız!");
                }
                else
                {
                    kisi1.Telefon = txtTelefon.Text;
                    db.Kisis.Add(kisi1);
                    MessageBox.Show(kisi1.Ad + " isimli kayıt eklenmiştir.");
                    db.SaveChanges();
                    KisileriDoldur(db.Kisis.ToList());
                }
            }


        }

        private void txtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsSeparator(e.KeyChar);
        }

        private void txtSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsSeparator(e.KeyChar);
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            KisileriDoldur(db.Kisis.ToList());
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            List<Kisi> filtreliKisiListesi = db.Kisis.Where(k => (k.Ad.ToLower() + " " + k.Soyad.ToLower()).Contains(textBox4.Text)).ToList();

            KisileriDoldur(filtreliKisiListesi);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
