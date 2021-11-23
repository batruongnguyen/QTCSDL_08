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
        string str = @"Data Source=localhost;Initial Catalog=VanChuyenKhach;Integrated Security=True";
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
            dgvNV.Columns[0].Width = 180;
            dgvNV.Columns[1].Width = 235;
            dgvNV.Columns[2].Width = 170;
            dgvNV.Columns[3].Width = 420;

            this.dgvNV.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvNV.AlternatingRowsDefaultCellStyle.BackColor =
                Color.GhostWhite;
        }
     
        private void ResetValue()
        {
            txtMaNV.ReadOnly = false;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtSDT_NV.Text = "";
            txtDiaChiNV.Text = "";
        }
        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
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
            command = connection.CreateCommand();
            command.CommandText = "insert into NHANVIEN values ('" + txtMaNV.Text + "', N'" + txtTenNV.Text + "', '" + txtSDT_NV.Text + "',N'" + txtDiaChiNV.Text + "')";

            if (txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }
            if (txtSDT_NV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            if (txtDiaChiNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChiNV.Focus();
                return;
            }
            else
            {
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loaddata();
            }

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
            bool flag = true;
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "Delete from NHANVIEN where MaNV = '" + txtMaNV.Text + "'";
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Không thể xóa nhân viên này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flag = false;
            }
            finally
            {
                if (flag == true)
                {
                    var confirmResult = MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Xảy ra lỗi trong quá trình xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        loaddata();
                        ResetValue();
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlConnection TKNV = new SqlConnection(str);
            try
            {
                TKNV.Open();
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
            string sQuery = "Select MaNV,TenNV, SDT_NV, DiaChiNV from NHANVIEN where MaNV like N'%" + txtTimKiem.Text + "%' or TenNV like N'%" + txtTimKiem.Text + "%'or SDT_NV like '%" + txtTimKiem.Text + "%'or DiaChiNV like N'%" + txtTimKiem.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, TKNV);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "NHANVIEN");
            dgvNV.DataSource = ds.Tables["NHANVIEN"];
            TKNV.Close();
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
