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
    public partial class Notlar : Form
    {
        sqlbaglanti baglan = new sqlbaglanti();
        public Notlar()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into Notlar (Baslik,Notlar,Tarih) values (@p1,@p2,@p3)", baglan.sqlbaglan());
            komut.Parameters.AddWithValue("@p1", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p2", rtbNot.Text);
            komut.Parameters.AddWithValue("@p3", DateTime.Now.ToString());
            komut.ExecuteNonQuery();
            baglan.sqlbaglan().Close();
            MessageBox.Show("Kaydetme işlemi başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
          
        }
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from Notlar", baglan.sqlbaglan());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("Delete from Notlar where ID='" + txtID.Text + "'", baglan.sqlbaglan());
            komut.ExecuteNonQuery();
            baglan.sqlbaglan().Close();
            MessageBox.Show("Silme işlemi başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void Notlar_Load(object sender, EventArgs e)
        {
            listele();
            timer1.Enabled=true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToString();
        }
    }
}
