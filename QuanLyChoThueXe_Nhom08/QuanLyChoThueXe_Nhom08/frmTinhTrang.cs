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
    public partial class frmTinhTrang : Form
    {
        bool isThoat = true;
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=localhost;Initial Catalog=VanChuyenKhach;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public frmTinhTrang()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from TINHTRANG";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvTinhTrang.DataSource = table;
        }
       

        private void frmTinhTrang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool flag = true;
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from TINHTRANG where MaTinhTrang='" + txtMaTT.Text + "'";
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Bị lỗi ràng buộc! Không thể xóa thông tin này!","Thông báo");
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
                        txtMaTT.Text = "";
                        txtBienSoXe.Text = "";
                        cbbDongCo.Text = "";
                        cbbMayLanh.Text = "";
                        txtNguonDien.Text = "";
                        cbbCuaXe.Text = "";
                        dtThoiGianCN.Text = "";

                        txtMaTT.Enabled = true;
                    }
                }
            }   
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Insert into TINHTRANG values('" + txtMaTT.Text + "','" + txtBienSoXe.Text + "',N'" + cbbDongCo.Text + "',N'" + cbbMayLanh.Text + "','" + txtNguonDien.Text + "',N'" + cbbCuaXe.Text + "','" + dtThoiGianCN.Text + "')";
            if (txtBienSoXe.Text == "" || cbbDongCo.SelectedItem == null || cbbMayLanh.SelectedItem == null || txtNguonDien.Text == "" || cbbCuaXe.SelectedItem == null || dtThoiGianCN.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ!", "Thông báo");
            }
            else
            {
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình thêm!", "Thông báo");
                }
                loaddata();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaTT.Text = "";
            txtBienSoXe.Text = "";
            cbbDongCo.Text = "";
            cbbMayLanh.Text = "";
            txtNguonDien.Text = "";
            cbbCuaXe.Text = "";
            dtThoiGianCN.Text = "";
            txtTimKiem.Text = "";
            txtMaTT.Enabled = true;
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update TINHTRANG set DongCo=N'" + cbbDongCo.Text + "',MayLanh=N'" + cbbMayLanh.Text + "',NguonDien=N'" + txtNguonDien.Text + "',CuaXe=N'" + cbbCuaXe.Text + "',ThoiGianCapNhap='" + dtThoiGianCN.Text + "' where MaTinhTrang='" + txtMaTT.Text + "'";
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlConnection TK = new SqlConnection(str);
            try
            {
                TK.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình kết nối DB");
            }

            string sQuery = "select * from TINHTRANG where MaTinhTrang like N'%" + txtTimKiem.Text + "%'or BienSoXe like '%" + txtTimKiem.Text + "%'or DongCo like N'%" + txtTimKiem.Text + "%' or MayLanh like N'%" + txtTimKiem.Text + "%' or NguonDien like N'%" + txtTimKiem.Text + "%'or CuaXe like N'%" + txtTimKiem.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sQuery, TK);

            DataSet ds = new DataSet();

            adapter.Fill(ds, "KHACHHANG");

            dgvTinhTrang.DataSource = ds.Tables["KHACHHANG"];

            TK.Close();
        }

        private void dgvTinhTrang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTT.Enabled = false;
            int i;
            i = dgvTinhTrang.CurrentRow.Index;
            txtMaTT.Text = dgvTinhTrang.Rows[i].Cells[0].Value.ToString();
            txtBienSoXe.Text = dgvTinhTrang.Rows[i].Cells[1].Value.ToString();
            cbbDongCo.Text = dgvTinhTrang.Rows[i].Cells[2].Value.ToString();
            cbbMayLanh.Text = dgvTinhTrang.Rows[i].Cells[3].Value.ToString();
            txtNguonDien.Text = dgvTinhTrang.Rows[i].Cells[4].Value.ToString();
            cbbCuaXe.Text = dgvTinhTrang.Rows[i].Cells[5].Value.ToString();
            dtThoiGianCN.Text = dgvTinhTrang.Rows[i].Cells[6].Value.ToString();
        }
    }
}
