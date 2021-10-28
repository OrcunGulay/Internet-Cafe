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
    public partial class Kullanıcılar : Form
    {
        sqlbaglanti baglan = new sqlbaglanti();
        public Kullanıcılar()
        {
            InitializeComponent();
        }

        private void Kullanıcılar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from Kullanicilar", baglan.sqlbaglan());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtKullaniciAdi.Text = dr["KullaniciAdi"].ToString();
                txtSifre.Text = dr["Sifre"].ToString();
                txtSifreTekrar.Text = dr["Sifre"].ToString();
                txtTC.Text = dr["TC"].ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Kullanicilar where ID='" + txtID.Text + "'", baglan.sqlbaglan());
            komut.ExecuteNonQuery();
            baglan.sqlbaglan().Close();
            MessageBox.Show("Silme işlemi başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }
        void temizle()
        {
            txtID.Text = "";
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
            txtSifreTekrar.Text = "";
            txtTC.Text = "";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSifre.Text==txtSifreTekrar.Text)
                {
                    SqlCommand komut = new SqlCommand("Insert into Kullanicilar (KullaniciAdi,Sifre,TC) values (@p1,@p2,@p3)", baglan.sqlbaglan());
                    komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                    komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                    komut.Parameters.AddWithValue("@p3", txtTC.Text);
                    komut.ExecuteNonQuery();
                    baglan.sqlbaglan().Close();
                    MessageBox.Show("Kaydetme işlemi başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    temizle();
                }
             
            }
            catch
            {
                MessageBox.Show("Hatalı Seçim.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
