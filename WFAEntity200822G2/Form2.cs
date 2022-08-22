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
    public partial class Form2 : Form
    {
        RehberDBEntities rb = new RehberDBEntities();

        public Form2()
        {
            InitializeComponent();
            dataGridView1.DataSource = rb.Kisis.ToList();
        }
     

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            Kisi k1 = rb.Kisis.Find(Convert.ToInt32(txtID.Text));
           // Kisi k1 = rb.Kisis.Where(s => s.ID == txtID.Text).ToList();

            if (k1 != null)
            {
                k1.Ad = txtAd.Text;
                k1.Soyad = txtSoyad.Text;
                k1.Telefon = txtTelefon.Text;
                MessageBox.Show(k1.ID + " ID'li Kayıt Güncellenmiştir.");
                rb.SaveChanges();
                dataGridView1.DataSource = rb.Kisis.ToList();
                txtID.Text = "";
                txtAd.Text = "";
                txtSoyad.Text = "";
                txtTelefon.Text = "";
            }
            else
                MessageBox.Show("Girmiş Olduğunuz ID'ye ait Kayıt Bulunamamıştır.");
        }
    }
}
