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
        int index = -1;
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=NGBATRUONG;Initial Catalog=VanChuyenKhach;Integrated Security=True");
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "select * from TAIKHOAN";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dtgvUser.DataSource = dt; //đổ dữ liệu vào datagridview
        }
           private void dtgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;

            txtTenTaiKhoan.Text = dtgvUser.Rows[index].Cells[0].Value.ToString();
            txtMatKhau.Text = dtgvUser.Rows[index].Cells[1].Value.ToString();
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
        }
    }
    }

    
    

