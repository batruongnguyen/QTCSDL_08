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
    public partial class frmQuanLyKH : Form
    {
        bool isThoat = true;
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-FBHSS47\SQLEXPRESS;Initial Catalog=VanChuyenKhach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public frmQuanLyKH()
        {
            InitializeComponent();
        }

        private void frmQuanLyKH_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * from KHACHHANG";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvKH.DataSource = table;
            dgvKH.Columns[0].HeaderText = "Mã khách hàng";
            dgvKH.Columns[1].HeaderText = "Tên khách hàng";
            dgvKH.Columns[2].HeaderText = "Số điện thoại";
            dgvKH.Columns[3].HeaderText = "Địa chỉ";
            dgvKH.Columns[0].Width = 135;
            dgvKH.Columns[1].Width = 230;
            dgvKH.Columns[2].Width = 152;
            dgvKH.Columns[3].Width = 460;
        }
      
        private void ResetValue()
        {
            txtMaKH.ReadOnly = false;
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT_KH.Text = "";
            txtDiaChiKH.Text = "";
        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
        private void frmQuanLyKH_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }
    }
}
