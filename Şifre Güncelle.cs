using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace İnternet_Cafe_Otomasyonu
{
    public partial class Şifre_Güncelle : Form
    {
        sqlbaglanti baglan = new sqlbaglanti();
        public Şifre_Güncelle()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtYeniSifre.Text != txtYsTekrar.Text) MessageBox.Show("Şifreler uyuşmuyor.", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else guncelle();
           
        }
        void guncelle()
        {
            SqlCommand komut = new SqlCommand("Select *from Kullanicilar where KullaniciAdi=@p1 AND TC=@p2", baglan.sqlbaglan());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                SqlCommand komut2 = new SqlCommand("Update Kullanicilar set Sifre='" + txtYeniSifre.Text +
                    "'where KullaniciAdi='" + txtKullaniciAdi.Text + "'", baglan.sqlbaglan());
                komut2.ExecuteNonQuery();
                MessageBox.Show("Şifreniz başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Giriş_Ekranı ge = new Giriş_Ekranı();
                ge.Show();
                this.Hide();
            }
            baglan.sqlbaglan().Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
