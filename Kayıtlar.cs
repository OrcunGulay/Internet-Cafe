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
    public partial class Kayıtlar : Form
    {
        sqlbaglanti baglan = new sqlbaglanti();
        public Kayıtlar()
        {
            InitializeComponent();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {

        }

        private void Kayıtlar_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *from Kayitlar", baglan.sqlbaglan());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            SqlCommand komut = new SqlCommand("Select * from Kayitlar", baglan.sqlbaglan());
            SqlDataReader dr = komut.ExecuteReader();
            double top = 0;
            while (dr.Read())
            {
                if (dr["Ucret"].ToString()!="")
                {
                    top = top + Convert.ToDouble(dr["Ucret"].ToString());
                }
            }
            txtToplamGelir.Text = top.ToString()+" TL";
            baglan.sqlbaglan().Close();
        }
    }
}
