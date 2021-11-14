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
    public partial class frmQuanLyTaiKhoan : Form
    {
        bool isThoat = true;
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=HOANGGIAPC\SQLEXPRESS;Initial Catalog=VanChuyenKhach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }
        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }
        private void loaddata()

        {
            command = connection.CreateCommand();
            command.CommandText = "Select * from TAIKHOAN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dtgvUser.DataSource = table;
            dtgvUser.Columns[0].HeaderText = "Tên Tài Khoản";
            dtgvUser.Columns[1].HeaderText = "Mật Khẩu";
            dtgvUser.Columns[2].HeaderText = "Loại Tài Khoản";
            dtgvUser.Columns[0].Width = 135;
            dtgvUser.Columns[1].Width = 230;
            dtgvUser.Columns[2].Width = 152;


            this.dtgvUser.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dtgvUser.AlternatingRowsDefaultCellStyle.BackColor =
                Color.GhostWhite;
        }
        private void ResetValue()
        {
            txtTenTaiKhoan.ReadOnly = false;
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            cbLoaiTaiKhoan.Text = "";

        }

        private void dtgvUser_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtTenTaiKhoan.ReadOnly = true;
            int i;
            i = dtgvUser.CurrentRow.Index;
            txtTenTaiKhoan.Text = dtgvUser.Rows[i].Cells[0].Value.ToString();
            txtMatKhau.Text = dtgvUser.Rows[i].Cells[1].Value.ToString();
            cbLoaiTaiKhoan.Text = dtgvUser.Rows[i].Cells[2].Value.ToString();
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

        private void frmQuanLyTaiKhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Insert into TINHTRANG values('" + txtTenTaiKhoan.Text + "','" + txtMatKhau.Text + "',N'" + cbLoaiTaiKhoan.Text + "',N'" + "')";
            if (txtTenTaiKhoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTaiKhoan.Focus();
                return;
            }
            if (txtMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            else
            {
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tài khoản hàng này đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loaddata();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool flag = true;
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from TAIKHOAN where Username='" + txtTenTaiKhoan.Text + "'";
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Bị lỗi ràng buộc! Không thể xóa thông tin này!", "Thông báo");
                flag = false;
            }
            finally
            {
                if (flag == true)
                {
                    var confirmResult = MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo", MessageBoxButtons.OKCancel);
                    if (confirmResult == DialogResult.OK)
                    {
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Xóa thành công!", "Thông báo");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Xảy ra lỗi trong quá trình xóa!", "Thông báo");
                        }
                        loaddata();
                        txtTenTaiKhoan.Text = "";
                        txtMatKhau.Text = "";
                        cbLoaiTaiKhoan.Text = "";


                        txtTenTaiKhoan.Enabled = true;
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update TAIKHOAN set Username=N'" + txtTenTaiKhoan.Text + "',Password=N'" + txtMatKhau.Text + "',TypeAcc=N'" + cbLoaiTaiKhoan.Text + "'";
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật!", "Thông báo");
            }
            loaddata();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            ResetValue();
        }
    }
}
    
    

