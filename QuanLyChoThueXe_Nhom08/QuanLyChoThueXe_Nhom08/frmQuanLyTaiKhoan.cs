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
        int index = -1;
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public static Boolean save;
        public static string TenTaiKhoan;
        public static string LoaiTaiKhoan;
        public static string MatKhau;


        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=HOANGGIAPC\SQLEXPRESS;Initial Catalog=VanChuyenKhach;Integrated Security=True");
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "select * from TAIKHOAN";  // lay het du lieu trong bang tai khoan
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dtgvUser.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        private void dtgvUser_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
                index = e.RowIndex;

                txtTenTaiKhoan.Text = dtgvUser.Rows[index].Cells[0].Value.ToString();
                txtMatKhau.Text = dtgvUser.Rows[index].Cells[1].Value.ToString();
            cbLoaiTaiKhoan.Text = dtgvUser.Rows[index].Cells[2].Value.ToString();
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
            if (cbLoaiTaiKhoan.SelectedItem == null || txtTenTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ!", "Thông báo");
            }
            else
            {
                string Username = txtTenTaiKhoan.Text;
                string Password = txtMatKhau.Text;
                string TypeAcc = cbLoaiTaiKhoan.Text;

                string query = "insert into TAIKHOAN values ('" + Username + "', '" + Password + "', '" + TypeAcc + "')";
                ketnoicsdl();
                MessageBox.Show("Đã thêm thành công!", "Thông báo");
            }

                }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvUser.Rows.Count == 0)
            {
                return;
            }
            if (dtgvUser.Rows[dtgvUser.CurrentCell.RowIndex].Cells[0].Value.ToString() == "0")
            {
                MessageBox.Show("Không được phép xóa tài khoản quản trị viên", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa dòng dữ liệu này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                dtgvUser.Rows[dtgvUser.CurrentCell.RowIndex].Cells[0].Value.ToString();
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ketnoicsdl();
            }
            else
                return;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgvUser.Rows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = this.dtgvUser.Rows[dtgvUser.CurrentCell.RowIndex];
            save = false;
            frmQuanLyTaiKhoan frm = new frmQuanLyTaiKhoan();
            frm.txtTenTaiKhoan.Text = row.Cells[0].Value.ToString();
            TenTaiKhoan = row.Cells[0].Value.ToString();
            if (row.Cells[0].Value.ToString() == "0")
            {
                MessageBox.Show("Không được phép sửa tài khoản quản trị viên", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dt2 =  new DataTable(row.Cells[0].Value.ToString());
            MatKhau = dt2.Rows[0]["MatKhau"].ToString();
            frm.cbLoaiTaiKhoan.Text = row.Cells[1].Value.ToString();
            frm.Text = "Sửa";
            frm.ShowDialog();
            ketnoicsdl();
        }
    }
    }
    
    

