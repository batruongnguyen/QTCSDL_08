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
        bool isThoat = true;
        public frmGiaoDien()
        {
            InitializeComponent();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyKH add = new frmQuanLyKH();
            add.Show();
            this.Hide();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyNV add = new frmQuanLyNV();
            add.Show();
            this.Hide();
        }

        private void láiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyLaiXe add = new frmQuanLyLaiXe();
            add.Show();
            this.Hide();
        }

        private void xeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyXe add = new frmQuanLyXe();
            add.Show();
            this.Hide();
        }

        private void đơnThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyDonThue add = new frmQuanLyDonThue();
            add.Show();
            this.Hide();
        }


        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoan add = new frmQuanLyTaiKhoan();
            add.Show();
            this.Hide();
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            frmQuanLyKH add = new frmQuanLyKH();
            add.Show();
            this.Hide();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            frmQuanLyNV add = new frmQuanLyNV();
            add.Show();
            this.Hide();
        }

        private void btnLaiXe_Click(object sender, EventArgs e)
        {
            frmQuanLyLaiXe add = new frmQuanLyLaiXe();
            add.Show();
            this.Hide();
        }

        private void btnXe_Click(object sender, EventArgs e)
        {
            frmQuanLyXe add = new frmQuanLyXe();
            add.Show();
            this.Hide();
        }

        private void btnDonThue_Click(object sender, EventArgs e)
        {
            frmQuanLyDonThue add = new frmQuanLyDonThue();
            add.Show();
            this.Hide();
        }



        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isThoat = false;
            this.Close();
            frmDangNhap f = new frmDangNhap();
            f.Show();
        }

        private void frmGiaoDien_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }

        private void btnTinhTrang_Click(object sender, EventArgs e)
        {
            frmTinhTrang add = new frmTinhTrang();
            add.Show();
            this.Hide();
        }

        private void tìnhTrạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTinhTrang add = new frmTinhTrang();
            add.Show();
            this.Hide();
        }

        private void frmGiaoDien_Load(object sender, EventArgs e)
        {

        }
    }
}
