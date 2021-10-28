using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace İnternet_Cafe_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

            gelir_gider gg;
        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (gg == null || gg.IsDisposed)
            {
                gg = new gelir_gider();
                gg.MdiParent = this;
                gg.Show();
            }
        }
        Masalar ms;
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (ms == null || ms.IsDisposed)
            {
                ms = new Masalar();
                ms.MdiParent = this;
                ms.Show();
            }
        }
        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }
        Kullanıcılar klnc;
        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (klnc==null || klnc.IsDisposed)
            {
                klnc = new Kullanıcılar();
                klnc.MdiParent = this;
                klnc.Show();
            }
        }
        Şifreni_Değiştir sd;
        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            sd = new Şifreni_Değiştir();
            sd.Show();
        }

            Kayıtlar ky;
        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (ky == null || ky.IsDisposed)
            {
                ky = new Kayıtlar();
                ky.MdiParent = this;
                ky.Show();
            }
        }
        Notlar nt;
        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (nt == null || nt.IsDisposed)
            {
                nt = new Notlar();
                nt.MdiParent = this;
                nt.Show();
            }
        }
    }
}
