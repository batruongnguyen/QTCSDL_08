using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChoThueXe_Nhom08
{
    public partial class frmGiaoDien : Form
    {
        public frmGiaoDien()
        {
            InitializeComponent();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyKH add = new frmQuanLyKH();
            add.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyNV add = new frmQuanLyNV();
            add.ShowDialog();
        }

        private void láiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyLaiXe add = new frmQuanLyLaiXe();
            add.ShowDialog();
        }

        private void xeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyXe add = new frmQuanLyXe();
            add.ShowDialog();
        }

        private void đơnThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyDonThue add = new frmQuanLyDonThue();
            add.ShowDialog();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe add = new frmThongKe();
            add.ShowDialog();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoan add = new frmQuanLyTaiKhoan();
            add.ShowDialog();
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            frmQuanLyKH add = new frmQuanLyKH();
            add.ShowDialog();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            frmQuanLyNV add = new frmQuanLyNV();
            add.ShowDialog();
        }

        private void btnLaiXe_Click(object sender, EventArgs e)
        {
            frmQuanLyLaiXe add = new frmQuanLyLaiXe();
            add.ShowDialog();
        }

        private void btnXe_Click(object sender, EventArgs e)
        {
            frmQuanLyXe add = new frmQuanLyXe();
            add.ShowDialog();
        }

        private void btnDonThue_Click(object sender, EventArgs e)
        {
            frmQuanLyDonThue add = new frmQuanLyDonThue();
            add.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmThongKe add = new frmThongKe();
            add.ShowDialog();
        }


    }
}
