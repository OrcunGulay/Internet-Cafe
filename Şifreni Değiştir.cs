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
    public partial class Şifreni_Değiştir : Form
    {
        sqlbaglanti baglan = new sqlbaglanti();
        public Şifreni_Değiştir()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Kullanicilar",baglan.sqlbaglan());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                if (dr["KullaniciAdi"].ToString()==txtKullaniciAdi.Text && dr["Sifre"].ToString()==txtSifre.Text)
                {
                    if (txtYSifre.Text==txtYSifreTekrar.Text)
                    {
                        SqlCommand komut2 = new SqlCommand("update Kullanicilar set Sifre='"+txtYSifre.Text+"' where KullaniciAdi='"+txtKullaniciAdi.Text+"'",baglan.sqlbaglan());
                        komut2.ExecuteNonQuery();
                        MessageBox.Show("Şifre Değiştirme işlemi tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    else MessageBox.Show("Hatalı giriş.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Hatalı giriş.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
