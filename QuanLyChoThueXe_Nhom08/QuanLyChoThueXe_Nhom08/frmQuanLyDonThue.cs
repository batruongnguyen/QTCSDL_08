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

namespace QuanLyChoThueXe_Nhom08
{
    public partial class frmQuanLyDonThue : Form
    {
        SqlConnection con = new SqlConnection (@"Data Source=NGBATRUONG;Initial Catalog=VanChuyenKhach;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public frmQuanLyDonThue()
        {
            InitializeComponent();
        }

        //Chức năng thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        void loadCbbMaKH()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from KHACHHANG", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbKH.DisplayMember = "MaKH";
            cbbKH.DataSource = dt;
        }

        void loadCbbMaNV()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from NHANVIEN", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbNV.DisplayMember = "MaNV";
            cbbNV.DataSource = dt;
        }

        void loadCbbDV()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from DICHVU", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbDV.DisplayMember = "TenDichVu";
            cbbDV.DataSource = dt;
        }

        void loadCbbBSX()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from XE", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbBienSoXe.DisplayMember = "BienSoXe";
            cbbBienSoXe.DataSource = dt;
        }

        private void frmQuanLyDonThue_Load(object sender, EventArgs e)
        {
            loadCbbMaKH();
            loadCbbMaNV();
            loadCbbDV();
            loadCbbBSX();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbKH.SelectedItem == null || cbbNV.SelectedItem == null || cbbDV.SelectedItem == null || cbbBienSoXe.SelectedItem == null || txtKyHieuHD.Text == "" || txtMauSoHD.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ!", "Thông báo");
            }
            else
            {
                string MaKH = cbbKH.SelectedItem.ToString();
                string MaNV = cbbNV.SelectedItem.ToString();
                string TenDV = cbbDV.SelectedItem.ToString();
                string BSX = cbbBienSoXe.SelectedItem.ToString();
                string KyHieuHD = Convert.ToString(txtKyHieuHD);
                string MauSoHD = Convert.ToString(txtMauSoHD);
                string query = "Insert into DAT values ()
                ExcuteDB(query);
                loaddata();
                MessageBox.Show("Đã thêm thành công!", "Thông báo");
            }
        }
    }
}
