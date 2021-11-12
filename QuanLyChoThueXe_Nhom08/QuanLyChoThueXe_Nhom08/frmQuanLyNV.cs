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
    public partial class frmQuanLyNV : Form
    {
        bool isThoat = true;
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=NGBATRUONG;Initial Catalog=VanChuyenKhach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public frmQuanLyNV()
        {
            InitializeComponent();
        }

        private void frmQuanLyNV_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "Select * from NHANVIEN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvNV.DataSource = table;
            dgvNV.Columns[0].HeaderText = "Mã nhân viên";
            dgvNV.Columns[1].HeaderText = "Tên nhân viên";
            dgvNV.Columns[2].HeaderText = "Số điện thoại";
            dgvNV.Columns[3].HeaderText = "Địa chỉ";
            dgvNV.Columns[0].Width = 153;
            dgvNV.Columns[1].Width = 235;
            dgvNV.Columns[2].Width = 155;
            dgvNV.Columns[3].Width = 451;
        }
     
        private void ResetValue()
        {
            txtMaNV.ReadOnly = false;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtSDT_NV.Text = "";
            txtDiaChiNV.Text = "";
        }

        private void dgvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.ReadOnly = true;
            int i;
            i = dgvNV.CurrentRow.Index;
            txtMaNV.Text = dgvNV.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNV.Rows[i].Cells[1].Value.ToString();
            txtSDT_NV.Text = dgvNV.Rows[i].Cells[2].Value.ToString();
            txtDiaChiNV.Text = dgvNV.Rows[i].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool flag = true;
            command = connection.CreateCommand();
            command.CommandText = "Update NHANVIEN set TenNV=N'" + txtTenNV.Text + "', SDT_NV='" + txtSDT_NV.Text + "', DiaChiNV=N'" + txtDiaChiNV.Text + "' where MaNV = '" + txtMaNV.Text + "'";
            command.ExecuteNonQuery();
            if (flag == true)
            {
                var confirmResult = MessageBox.Show("Bạn muốn sửa thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thông tin đã được sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        DialogResult dialogResult = MessageBox.Show("Có lỗi đã xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    loaddata();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            loaddata();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            isThoat = false;
            DialogResult dlr = MessageBox.Show("Bạn muốn rời khỏi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
                frmGiaoDien f = new frmGiaoDien();
                f.Show();
            }
        }

        private void frmQuanLyNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }
    }
}
