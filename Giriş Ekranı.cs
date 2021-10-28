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
    public partial class Giriş_Ekranı : Form
    {
        sqlbaglanti baglan = new sqlbaglanti();
       
        public Giriş_Ekranı()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            txtSifre.Properties.UseSystemPasswordChar = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtSifre.Properties.UseSystemPasswordChar == false) txtSifre.Properties.UseSystemPasswordChar = true;
            else txtSifre.Properties.UseSystemPasswordChar = false;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select *from Kullanicilar where KullaniciAdi=@p1 AND Sifre=@p2", baglan.sqlbaglan());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre uyuşmuyor!\nLütfen kontrol ediniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
            }
            baglan.sqlbaglan().Close();
        
    }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            if (txtSifre.Properties.UseSystemPasswordChar == false) txtSifre.Properties.UseSystemPasswordChar = true;
            else txtSifre.Properties.UseSystemPasswordChar = false;
        }

        private void SifremiUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Şifre_Güncelle frm = new Şifre_Güncelle();
            frm.Show();
            this.Hide();
        }

        private void Giriş_Ekranı_Load(object sender, EventArgs e)
        {

        }
    }
}
