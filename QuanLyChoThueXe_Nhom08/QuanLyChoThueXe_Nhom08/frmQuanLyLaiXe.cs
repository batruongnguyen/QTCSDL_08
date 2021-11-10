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
            dgvLX.Columns[0].Width = 75;
            dgvLX.Columns[1].Width = 150;
            dgvLX.Columns[2].Width = 100;
            dgvLX.Columns[3].Width = 370;
        }

        private void dgvLX_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLX.ReadOnly = true;
            int i;
            i = dgvLX.CurrentRow.Index;
            txtMaLX.Text = dgvLX.Rows[i].Cells[0].Value.ToString();
            txtTenLX.Text = dgvLX.Rows[i].Cells[1].Value.ToString();
            txtSDT_LX.Text = dgvLX.Rows[i].Cells[2].Value.ToString();
            txtDiaChiLX.Text = dgvLX.Rows[i].Cells[3].Value.ToString();
        }
        private void ResetValue()
        {
            txtMaLX.ReadOnly = false;
            txtMaLX.Text = "";
            txtTenLX.Text = "";
            txtSDT_LX.Text = "";
            txtDiaChiLX.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into LAIXE values ('" + txtMaLX.Text + "', N'" + txtTenLX.Text + "', '" + txtSDT_LX.Text + "',N'" + txtDiaChiLX.Text + "')";

            if (txtMaLX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã lái xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLX.Focus();
                return;
            }
            if (txtTenLX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên lái xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLX.Focus();
                return;
            }
            if (txtSDT_LX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLX.Focus();
                return;
            }
            if (txtDiaChiLX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChiLX.Focus();
                return;
            }
            else
            {
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm lái xe thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mã lái xe này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loaddata();
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

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

        private void frmQuanLyLaiXe_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn rời khỏi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.No)
                e.Cancel = true;
        }
    }
}
