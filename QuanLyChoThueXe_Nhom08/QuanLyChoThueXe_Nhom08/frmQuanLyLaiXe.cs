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
            txtMaLX.ReadOnly = true;
            int i;
            i = dgvLX.CurrentRow.Index;
            txtMaLX.Text = dgvLX.Rows[i].Cells[0].Value.ToString();
            txtTenLX.Text = dgvLX.Rows[i].Cells[1].Value.ToString();
            txtSDT_LX.Text = dgvLX.Rows[i].Cells[2].Value.ToString();
            txtDiaChiLX.Text = dgvLX.Rows[i].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into LAIXE values ('" + txtMaLX.Text + "', N'" + txtTenLX.Text + "', '" + txtSDT_LX.Text + "',N'" + txtMaLX.Text + "')";

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
            bool flag = true;
            command = connection.CreateCommand();
            command.CommandText = "Update LAIXE set TenLaiXe=N'" + txtTenLX.Text + "', SDT_LX='" + txtSDT_LX.Text + "', DiaChi_LX=N'" + txtDiaChiLX.Text + "' where MaLaiXe = '" + txtMaLX.Text + "'";
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
            SqlConnection TK = new SqlConnection(str);
            try
            {
                TK.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối");
            }
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sQuery = "Select MaLaiXe,TenLaiXe, SDT_LX, DiaChi_LX from LAIXE where MaLaiXe like N'%" + txtTimKiem.Text + "%' or TenLaiXe like '%" + txtTimKiem.Text + "%'or SDT_LX like '%" + txtTimKiem.Text + "'or DiaChi_LX like N'%" + txtTimKiem.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, TK);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "LAIXE");
            dgvLX.DataSource = ds.Tables["LAIXE"];
            TK.Close();

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
        private void frmQuanLyLaiXe_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }
    }
}
