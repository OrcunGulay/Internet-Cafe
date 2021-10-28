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

    public partial class gelir_gider : Form
    {
        sqlbaglanti baglan = new sqlbaglanti();
        public gelir_gider()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into Giderler (GiderTuru,Tutar,Tarih) values (@p1,@p2,@p3)", baglan.sqlbaglan());
            komut.Parameters.AddWithValue("@p1", txtGiderTuru.Text);
            komut.Parameters.AddWithValue("@p2", txtGiderTutari.Text);
            komut.Parameters.AddWithValue("@p3", DateTime.Now.ToString());
            komut.ExecuteNonQuery();
            baglan.sqlbaglan().Close();
            MessageBox.Show("Kaydetme işlemi başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
            toplamGider();
        }
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from Giderler", baglan.sqlbaglan());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void toplamGider()
        {
            SqlCommand komut = new SqlCommand("Select sum(Tutar) as toplamGider from Giderler", baglan.sqlbaglan());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtToplamGider.Text = dr["toplamGider"].ToString()+" TL";
            }
            baglan.sqlbaglan().Close();
        }
        void temizle()
        {
            txtGiderTuru.Text = "";
            txtGiderTutari.Text = "";
            txtID.Text = "";
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtGiderTuru.Text = dr["GiderTuru"].ToString();
                txtGiderTutari.Text = dr["Tutar"].ToString();
                txtTarih.Text = dr["Tarih"].ToString();
            }
        }

        private void gelir_gider_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            toplamGider();
            listele();
            temizle();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Giderler where ID='" + txtID.Text + "'", baglan.sqlbaglan());
            komut.ExecuteNonQuery();
            baglan.sqlbaglan().Close();
            MessageBox.Show("Silme işlemi başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
            toplamGider();
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Giderler where ID='" + txtID.Text + "'", baglan.sqlbaglan());
            komut.ExecuteNonQuery();
            baglan.sqlbaglan().Close();
            MessageBox.Show("Silme işlemi başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
            toplamGider();
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            try
            {

            SqlCommand komut = new SqlCommand("Insert into Giderler (GiderTuru,Tutar,Tarih) values (@p1,@p2,@p3)", baglan.sqlbaglan());
            komut.Parameters.AddWithValue("@p1", txtGiderTuru.Text);
            komut.Parameters.AddWithValue("@p2", txtGiderTutari.Text);
            komut.Parameters.AddWithValue("@p3", DateTime.Now.ToString());
            komut.ExecuteNonQuery();
            baglan.sqlbaglan().Close();
            MessageBox.Show("Kaydetme işlemi başarıyla tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
            toplamGider();
            }
            catch 
                {
                MessageBox.Show("Hatalı Seçim.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
