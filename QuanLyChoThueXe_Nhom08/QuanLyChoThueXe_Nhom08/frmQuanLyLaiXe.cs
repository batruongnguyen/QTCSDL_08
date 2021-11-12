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
    public partial class frmQuanLyLaiXe : Form
    {
        bool isThoat = true;
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-FBHSS47\SQLEXPRESS;Initial Catalog=VanChuyenKhach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public frmQuanLyLaiXe()
        {
            InitializeComponent();
        }

        private void frmQuanLyLaiXe_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * from LAIXE";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvLX.DataSource = table;
            dgvLX.Columns[0].HeaderText = "Mã lái xe";
            dgvLX.Columns[1].HeaderText = "Tên lái xe";
            dgvLX.Columns[2].HeaderText = "Số điện thoại";
            dgvLX.Columns[3].HeaderText = "Địa chỉ";
            dgvLX.Columns[0].Width = 125;
            dgvLX.Columns[1].Width = 220;
            dgvLX.Columns[2].Width = 152;
            dgvLX.Columns[3].Width = 480;
        }
        private void ResetValue()
        {
            txtMaLX.ReadOnly = false;
            txtMaLX.Text = "";
            txtTenLX.Text = "";
            txtSDT_LX.Text = "";
            txtDiaChiLX.Text = "";
        }

        private void dgvLX_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        private void frmQuanLyLaiXe_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }
    }
}
