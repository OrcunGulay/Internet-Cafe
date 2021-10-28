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
    
    public partial class Masalar : Form
    {
        sqlbaglanti baglan = new sqlbaglanti();
        
        public Masalar()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, EventArgs e)
        {
            temizle();
            groupControl1.Visible = true;
            Button btn = sender as Button;
            lblMasa.Text = btn.Text;
            cboxTalep.Text = lblID.Text;
            if (btn.BackColor == Color.Red)
            {
                btnArıza.Text = "Arıza Bildir";
                btnMasaAc.Enabled = false;
                btnArıza.Enabled = false;
                btnAktar.Enabled = true;
                btnMasaKapat.Enabled = true;
                btnTalep.Enabled = true;
                btnSuresiz.Enabled = true;
                SqlCommand komut = new SqlCommand("select * from Kayitlar where MasaAdi='" + lblMasa.Text + "'", baglan.sqlbaglan());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["CikisTarihi"].ToString() == "")
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = true;
                        txtGirisTarihi.Text = dr["GirisTarihi"].ToString();
                        txtUcret.Text = dr["Ucret"].ToString();
                        lblID.Text = dr["ID"].ToString();
                        cboxSureSec.Text = dr["Sure"].ToString();

                    }
                }
            }
            else if (btn.BackColor == Color.Yellow)
            {
                btnMasaAc.Enabled = false;
                btnAktar.Enabled = false;
                btnMasaKapat.Enabled = false;
                btnTalep.Enabled = false;
                btnSuresiz.Enabled = false;
                btnArıza.Enabled = true;
                btnArıza.Text = "Arıza Giderildi";

            }
            else if (btn.BackColor == Color.Blue)
            {
                btnArıza.Text = "Arıza Bildir";
                btnMasaAc.Enabled = false;
                btnArıza.Enabled = false;
                btnAktar.Enabled = true;
                btnMasaKapat.Enabled = true;
                btnSuresiz.Enabled = false;
                btnTalep.Enabled = true;
                SqlCommand komut = new SqlCommand("select * from Kayitlar where MasaAdi='" + lblMasa.Text + "'", baglan.sqlbaglan());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["CikisTarihi"].ToString() == "")
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        txtGirisTarihi.Text = dr["GirisTarihi"].ToString();
                        lblID.Text = dr["ID"].ToString();
                        txtKalanSüre.Text = dr["Sure"].ToString();

                    }
                }
                DateTime giris = DateTime.Parse(txtGirisTarihi.Text);
                TimeSpan gecen = DateTime.Now - giris;
                double ucret = (Convert.ToDouble(gecen.TotalMinutes))/15+2;
                txtUcret.Text = ucret.ToString("0.00");

            }
            else
            {
                btnArıza.Text = "Arıza Bildir";
                timer1.Enabled = true;
                timer2.Enabled = false;
                btnAktar.Enabled = false;
                btnArıza.Enabled = true;
                btnMasaAc.Enabled = true;
                btnMasaKapat.Enabled = false;
                btnTalep.Enabled = false;
                btnSuresiz.Enabled = true;
            }           
        }

        void MasaDurumu()
        {
            SqlCommand komut = new SqlCommand("select * from MasaDurumu",baglan.sqlbaglan());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                foreach (Control item in Controls)
                {
                    if (item is Button)
                    {
                        if (item.Text == dr[1].ToString() && dr[2].ToString() == "True")
                        {
                            item.BackColor = Color.Red;
                        }
                        if (item.Text == dr[1].ToString() && dr[2].ToString() == "False")
                        {
                            item.BackColor = Color.LimeGreen;
                        }
                        if (item.Text == dr[1].ToString() && dr[2].ToString() == "NULL")
                        {
                            item.BackColor = Color.Yellow;
                            btnArıza.Text = "Arıza Giderildi";
                        }
                        if (item.Text == dr[1].ToString() && dr[2].ToString() == "Sure")
                        {
                            item.BackColor = Color.Blue;
                        }

                    }
                }
            }
            baglan.sqlbaglan().Close();

        }

        private void Masalar_Load(object sender, EventArgs e)
        {
               this.button1.PerformClick();
            
            MasaDurumu();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtGirisTarihi.Text = DateTime.Now.ToString();
            MasaDurumu();
        }

        private void btnMasaAc_Click(object sender, EventArgs e)
        {
            try
            {

                timer1.Enabled = false;
                timer2.Enabled = true;
                SqlCommand komut = new SqlCommand("insert into Kayitlar (MasaAdi,GirisTarihi,Sure,Ucret) values(@p1,@p2,@p3,@p4)", baglan.sqlbaglan());
                komut.Parameters.AddWithValue("@p1", lblMasa.Text);
                komut.Parameters.AddWithValue("@p2", txtGirisTarihi.Text);
                komut.Parameters.AddWithValue("@p3", cboxSureSec.Text);
                double ucret = (Convert.ToDouble(cboxSureSec.Text)) / 15;
                komut.Parameters.AddWithValue("@p4", ucret.ToString());
                komut.ExecuteNonQuery();
                SqlCommand komut2 = new SqlCommand("update MasaDurumu set Durum='True' where MasaAdi='" + lblMasa.Text + "'", baglan.sqlbaglan());
                komut2.ExecuteNonQuery();
                MasaDurumu();
                baglan.sqlbaglan().Close();
            }
            catch
            {
                timer2.Enabled = false;
                MessageBox.Show("Hatalı Seçim.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnMasaKapat_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
            SqlCommand komut = new SqlCommand("update Kayitlar set CikisTarihi='"+DateTime.Now.ToString()+"', Ucret='"+txtUcret.Text+"' where ID='"+lblID.Text+"'",baglan.sqlbaglan());
            komut.ExecuteNonQuery();
            SqlCommand komut2 = new SqlCommand("update MasaDurumu set Durum='False' where MasaAdi='"+lblMasa.Text+"'",baglan.sqlbaglan());
            komut2.ExecuteNonQuery();
            baglan.sqlbaglan().Close();
            MasaDurumu();
            temizle();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime giris, cıkıs;
                giris = DateTime.Parse(txtGirisTarihi.Text);
                string sure = cboxSureSec.Text;
                cıkıs = giris.AddMinutes(Convert.ToDouble(sure));
                TimeSpan kalan;
                kalan = cıkıs - DateTime.Now;
                txtKalanSüre.Text = kalan.TotalMinutes.ToString("0.00");
                SqlCommand komut = new SqlCommand("select * from Kayitlar where MasaAdi='" + lblMasa.Text + "'", baglan.sqlbaglan());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["CikisTarihi"].ToString() == "")
                    {
                        txtUcret.Text = dr["Ucret"].ToString();
                    }
                }
              
            }
            catch
            {
                timer2.Enabled = false;
                MessageBox.Show("Hatalı giriş.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnArıza_Click(object sender, EventArgs e)
        {
            
            if (btnArıza.Text=="Arıza Bildir")
            {
                
                foreach (Control item in Controls)
                {
                    if (item is Button && lblMasa.Text==item.Text)
                    {
                        SqlCommand komut = new SqlCommand("update MasaDurumu set Durum='NULL' where MasaAdi='"+lblMasa.Text+"'",baglan.sqlbaglan());
                        komut.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                
                foreach (Control item in Controls)
                {
                    if (item is Button)
                    {
                        if (item.Text == lblMasa.Text)
                        {
                            item.BackColor = Color.Green;
                            SqlCommand komut = new SqlCommand("update MasaDurumu set Durum='False' where MasaAdi='" + lblMasa.Text + "'", baglan.sqlbaglan());
                            komut.ExecuteNonQuery();
                        }


                    }
                }
                baglan.sqlbaglan().Close();
            }
            temizle();
            MasaDurumu();
        }
        void temizle()
        {
            txtKalanSüre.Text = "";
            txtUcret.Text = "";
            cboxSureSec.Text = "";
        }

        private void btnAktar_Click(object sender, EventArgs e)
        {
            Aktar akt = new Aktar();
            akt.lblMasaAdi.Text = lblMasa.Text;
            akt.Show();
            MasaDurumu();
        }

        private void btnSuresiz_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer1.Enabled = false;
           
            DateTime giris;
            giris = DateTime.Parse(txtGirisTarihi.Text);
            TimeSpan gecen;
            gecen = DateTime.Now - giris;
            foreach (Control item in Controls)
            {
                if (item is Button && item.Text==lblMasa.Text)
                {
                    item.BackColor = Color.Blue;
                }
            }

            timer1.Enabled = false;
            SqlCommand komut = new SqlCommand("insert into Kayitlar (MasaAdi,GirisTarihi,Sure,Ucret) values(@p1,@p2,@p3,@p4)", baglan.sqlbaglan());
            komut.Parameters.AddWithValue("@p1", lblMasa.Text);
            komut.Parameters.AddWithValue("@p2", txtGirisTarihi.Text);
            komut.Parameters.AddWithValue("@p3", "--");
            double ucret = (Convert.ToDouble(gecen.TotalMinutes))/15 + 2;
            komut.Parameters.AddWithValue("@p4", ucret.ToString());
            komut.ExecuteNonQuery();
            SqlCommand komut2 = new SqlCommand("update MasaDurumu set Durum='Sure' where MasaAdi='" + lblMasa.Text + "'", baglan.sqlbaglan());
            komut2.ExecuteNonQuery();
            MasaDurumu();
            temizle();
            baglan.sqlbaglan().Close();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnTalep_Click(object sender, EventArgs e)
        {
            double ucret=Convert.ToDouble(txtUcret.Text);
            if (cboxTalep.Text=="Çay")
            {
                ucret = ucret + 1.50;
            }
            if (cboxTalep.Text == "Tost")
            {
                ucret = ucret + 7.50;
            }
            if (cboxTalep.Text == "Poğaça-Simit")
            {
                ucret = ucret + 2.00;
            }
            if (cboxTalep.Text == "Döner")
            {
                ucret = ucret + 10.00;
            }
            if (cboxTalep.Text == "Meyve Suyu")
            {
                ucret = ucret + 3.00;
            }
            if (cboxTalep.Text == "Kola")
            {
                ucret = ucret + 4.00;
            }
            if (cboxTalep.Text == "Ayran")
            {
                ucret = ucret + 2.00;
            }
            if (cboxTalep.Text == "Su")
            {
                ucret = ucret + 2.00;
            }
            if (cboxTalep.Text == "Kek")
            {
                ucret = ucret + 2.50;
            }
            SqlCommand komut = new SqlCommand("update Kayitlar set Ucret='"+ucret.ToString()+"'",baglan.sqlbaglan());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                if (dr["CikisTarihi"].ToString()=="")
                {
                    txtUcret.Text = dr["Ucret"].ToString();
                }
            }

            

        }

    }
}
