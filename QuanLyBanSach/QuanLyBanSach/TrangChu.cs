using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class TrangChu : Form
    {
        bool sidebarexpand=false;
        Form1 KH;
        CBQL cbql;
        HoaDon hoadon;
        Sach sach;
        TheKH thekh;
        ChiTietHoaDon cthd;
        KhoSach khosach;
        TrangChu tc;
        
        public TrangChu()
        {
            InitializeComponent();
            GioiThieu gt = new GioiThieu();
            gt.MdiParent = this;
            gt.FormBorderStyle = FormBorderStyle.None;
            gt.Dock = DockStyle.Fill;
            panel9.Controls.Add(gt);
            gt.Show();

        }
        private void Sidebartick(object sender, EventArgs e)
        {
            if(sidebarexpand)
            {
                Sidebar.Width -= 5;
                if(Sidebar.Width == Sidebar.MinimumSize.Width)
                {
                    sidebarexpand = false;
                    timer1.Stop();
                }
            }
            else
            {
                    Sidebar.Width += 5;
                    if(Sidebar.Width==Sidebar.MaximumSize.Width)
                    {
                        sidebarexpand = true;
                        timer1.Stop();
                    }
             }
            
        }

        private void MenuButt_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void KHform_Click(object sender, EventArgs e)
        {
            if(KH == null)
            {
                KH = new Form1();
                KH.FormClosed += KH_FormClosed;
                KH.MdiParent = this;
                KH.TopLevel = false;
                KH.FormBorderStyle = FormBorderStyle.None;
                KH.Dock = DockStyle.Fill;
                panel9.Controls.Add(KH);
                KH.BringToFront();
                KH.Show();
                
            }
            else
            {
                KH.BringToFront();
            }

        }

        private void KH_FormClosed(object sender, FormClosedEventArgs e)
        {
            KH=null;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (hoadon == null)
            {
                
                hoadon = new HoaDon();
                hoadon.FormClosed += Hoadon_FormClosed;
                hoadon.MdiParent = this;
                hoadon.TopLevel = false;
                hoadon.FormBorderStyle = FormBorderStyle.None;
                hoadon.Dock = DockStyle.Fill;
                panel9.Controls.Add(hoadon);
                hoadon.BringToFront();
                hoadon.Show();
               
            }
            else
            {
                hoadon.BringToFront();
            }
        }

        private void Hoadon_FormClosed(object sender, FormClosedEventArgs e)
        {
            hoadon=null;
        }

        private void Cbql_FormClosed(object sender, FormClosedEventArgs e)
        {
            cbql=null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cbql == null)
            {
                cbql = new CBQL();
                cbql.FormClosed += Cbql_FormClosed;
                cbql.MdiParent = this;
                cbql.TopLevel = false;
                cbql.FormBorderStyle = FormBorderStyle.None;
                cbql.Dock = DockStyle.Fill;
                panel9.Controls.Add(cbql);
                cbql.BringToFront();
                cbql.Show();
            }
            else
            {
                cbql.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (thekh == null)
            {
                thekh = new TheKH();
                thekh.FormClosed += Thekh_FormClosed;
                thekh.MdiParent = this;
                thekh.TopLevel = false;
                thekh.FormBorderStyle = FormBorderStyle.None;
                thekh.Dock = DockStyle.Fill;
                panel9.Controls.Add(thekh);
                thekh.BringToFront();
                thekh.Show();
            }
            else
            {
                thekh.BringToFront();
            }
        }

        private void Thekh_FormClosed(object sender, FormClosedEventArgs e)
        {
            thekh=null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cthd == null)
            {
                cthd = new ChiTietHoaDon();
                cthd.FormClosed += Cthd_FormClosed;
                cthd.MdiParent = this;
                cthd.TopLevel = false;
                cthd.FormBorderStyle = FormBorderStyle.None;
                cthd.Dock = DockStyle.Fill;
                panel9.Controls.Add(cthd);
                cthd.BringToFront();
                cthd.Show();
            }
            else
            {
                cthd.BringToFront();
            }
        }

        private void Cthd_FormClosed(object sender, FormClosedEventArgs e)
        {
            cthd=null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (sach == null)
            {
                sach = new Sach();
                sach.FormClosed += Sach_FormClosed;
                sach.MdiParent = this;
                sach.TopLevel = false;
                sach.FormBorderStyle = FormBorderStyle.None;
                sach.Dock = DockStyle.Fill;
                panel9.Controls.Add(sach);
                sach.BringToFront();
                sach.Show();
            }
            else
            {
                sach.BringToFront();
            }
        }

        private void Sach_FormClosed(object sender, FormClosedEventArgs e)
        {
            sach=null;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (khosach == null)
            {
                khosach = new KhoSach();
                khosach.FormClosed += Khosach_FormClosed; ;
                khosach.MdiParent = this;
                khosach.TopLevel = false;
                khosach.FormBorderStyle = FormBorderStyle.None;
                khosach.Dock = DockStyle.Fill;
                panel9.Controls.Add(khosach);
                khosach.BringToFront();
                khosach.Show();
            }
            else
            {
                khosach.BringToFront();
            }
        }

        private void Khosach_FormClosed(object sender, FormClosedEventArgs e)
        {
           khosach=null;
        }

       
    }
}
