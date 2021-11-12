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
        string str = @"Data Source=NGBATRUONG;Initial Catalog=VanChuyenKhach;Integrated Security=True";
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
            txtMaKH.ReadOnly = true;
            int i;
            i = dgvKH.CurrentRow.Index;
            txtMaKH.Text = dgvKH.Rows[i].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKH.Rows[i].Cells[1].Value.ToString();
            txtSDT_KH.Text = dgvKH.Rows[i].Cells[2].Value.ToString();
            txtDiaChiKH.Text = dgvKH.Rows[i].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into KHACHHANG values ('" + txtMaKH.Text + "', N'" + txtTenKH.Text + "', '" + txtSDT_KH.Text + "',N'" + txtDiaChiKH.Text + "')";

            if (txtMaKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
                return;
            }
            if (txtSDT_KH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            if (txtDiaChiKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChiKH.Focus();
                return;
            }
            else
            {
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mã khách hàng này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loaddata();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bool flag = true;
            command = connection.CreateCommand();
            command.CommandText = "Update KHACHHANG set TenKH=N'" + txtSDT_KH.Text + "', SDT_KH='" + txtSDT_KH.Text + "', DiaChiKH=N'" + txtDiaChiKH.Text + "' where MaKH = '" + txtMaKH.Text + "'";
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
                command.CommandText = "Delete from KHACHHANG where MaKH = '" + txtMaKH.Text + "'";
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Không thể xóa khách hàng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            SqlConnection TKKH = new SqlConnection(str);
            try
            {
                TKKH.Open();
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
            string sQuery = "Select MaKH,TenKH, SDT_KH, DiaChiKH from KHACHHANG where MaKH like N'%" + txtTimKiem.Text + "%' or TenKH like '%" + txtTimKiem.Text + "%'or SDT_KH like '%" + txtTimKiem.Text + "%'or DiaChiKH like '%" + txtTimKiem.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, TKKH);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "KHACHHANG");
            dgvKH.DataSource = ds.Tables["KHACHHANG"];
            TKKH.Close();
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
        private void frmQuanLyKH_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }
    }
}
