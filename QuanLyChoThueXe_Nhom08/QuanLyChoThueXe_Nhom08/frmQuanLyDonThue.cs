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
    public partial class frmQuanLyDonThue : Form
    {
        bool isThoat = true;
        SqlConnection con = new SqlConnection (@"Data Source=NGBATRUONG;Initial Catalog=VanChuyenKhach;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public frmQuanLyDonThue()
        {
            InitializeComponent();
        }

        //Loaddata Hóa đơn
        public void loaddataHD()
        {
            string query = "select * from DAT";
            dgvDonThue.DataSource = GetRecords(query);
        }

        public void loaddataHDCT()
        {
            string HDCT = "select * from DAT_CHITIET";
            dgvHDCT.DataSource = GetRecords(HDCT);

        }
        public void ExcuteDB(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối dữ liệu!", "Thông báo");
            }
            con.Close();
        }
        public DataTable GetRecords(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        //Chức năng thoát
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

         void loadCbbMaKH()
         {   
            SqlDataAdapter da = new SqlDataAdapter("select * from KHACHHANG", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbKH.DisplayMember = "MaKH";
            cbbKH.DataSource = dt;
         }

        void loadCbbMaNV()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from NHANVIEN", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbNV.DisplayMember = "MaNV";
            cbbNV.DataSource = dt;
        }


        void loadCbbBSX()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from XE", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbBienSoXe.DisplayMember = "BienSoXe";
            cbbBienSoXe.DataSource = dt;
        }

        void loadcbbDV()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from DichVu", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbbMaDV.DisplayMember = "MaDichVu";
            cbbMaDV.DataSource = dt;
        }

        private void frmQuanLyDonThue_Load(object sender, EventArgs e)
        {
            loadCbbMaKH();
            loadCbbMaNV();
            loadCbbBSX();
            loadcbbDV();
            loaddataHD();
            loaddataHDCT();
            btnThanhToan.Enabled = false;
            txtTenDV.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbKH.SelectedItem == null || cbbNV.SelectedItem == null || txtMaHD.Text == "" || cbbBienSoXe.SelectedItem == null || txtKyHieuHD.Text == "" || txtMauSoHD.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ!", "Thông báo");
            }
            else
            {
                string MaHD = Convert.ToString(txtMaHD);
                string MaKH = cbbKH.SelectedItem.ToString();
                string MaNV = cbbNV.SelectedItem.ToString();
                string BSX = cbbBienSoXe.SelectedItem.ToString();
                string KyHieuHD = Convert.ToString(txtKyHieuHD);
                string MauSoHD = Convert.ToString(txtMauSoHD);
                DateTime NgayDat = Convert.ToDateTime(dtNgayDat.Value);
                DateTime NgayTra = Convert.ToDateTime(dtNgayTra.Value);
                string query = "Insert into DAT values ('";
                query = MaHD + "' , '" + MaKH + "' , N'" + MaNV
                    + "' , '" + KyHieuHD + "' , '" + MauSoHD + "' ,' " + NgayDat.ToString("yyyy-MM-dd") + "' , '" + NgayTra.ToString("yyyy-MM-dd")
                    + "', NULL, NULL, NULL)";
                ExcuteDB(query);
                loaddataHD();
                MessageBox.Show("Đã thêm thành công!", "Thông báo");
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            cbbBienSoXe.Text = "";
            cbbKH.Text = "";
            cbbNV.Text = "";
            txtKyHieuHD.Text = "";
            txtMauSoHD.Text = "";
            dtNgayDat.Text = "";
            dtNgayTra.Text = "";
            txtDonGia.Text = "";
            txtTongTien.Text = "";
            txtVAT.Text = "";
            cbbMaHD.Text = "";
        }
        private void cbbMaDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load tên dịch vụ vao textbox
            con.Open();
            string TenDV = "select TenDichVu from DICHVU where MaDichVu = '" + cbbMaDV.Text + "'";
            SqlCommand cmd = new SqlCommand(TenDV, con);
            var tmp = cmd.ExecuteScalar();
            txtTenDV.Text = tmp.ToString();
            cmd.Dispose();
            con.Close();
        }
       
        private void btnResetCT_Click(object sender, EventArgs e)
        {
            txtMaHDCT.Text = "";
            cbbMaDV.Text = "";
            txtTenDV.Text = "";
            txtDonVi.Text = "";
            txtThanhTien.Text = "";
            txtSoLuong.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (flag == true)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo", MessageBoxButtons.OKCancel);
                if (confirmResult == DialogResult.OK)
                {
                    try
                    {
                        if (dgvDonThue.CurrentCell != null)
                        {
                            int MaHD = Convert.ToInt32(dgvDonThue.CurrentRow.Cells[0].Value);
                            string query = "delete from DAT where MaHD = " + MaHD;
                            ExcuteDB(query);
                            loaddataHD();
                        }
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xảy ra lỗi trong quá trình xóa!", "Thông báo");
                    }
                    loaddataHD();
                }
            }
        }

        private void frmQuanLyDonThue_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }

        private void dgvDonThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtTongTien.Text == "")
            {
                btnThanhToan.Enabled = false;
            }
            else
            {
                btnThanhToan.Enabled = true;
            }

            int i;
            i = dgvDonThue.CurrentRow.Index;
            txtMaHD.Text = dgvDonThue.Rows[i].Cells[0].Value.ToString();
            cbbKH.Text = dgvDonThue.Rows[i].Cells[1].Value.ToString();
            cbbNV.Text = dgvDonThue.Rows[i].Cells[2].Value.ToString();
            cbbBienSoXe.Text = dgvDonThue.Rows[i].Cells[3].Value.ToString();
            txtKyHieuHD.Text = dgvDonThue.Rows[i].Cells[4].Value.ToString();
            txtMauSoHD.Text = dgvDonThue.Rows[i].Cells[5].Value.ToString();
            dtNgayDat.Text = dgvDonThue.Rows[i].Cells[6].Value.ToString();
            dtNgayTra.Text = dgvDonThue.Rows[i].Cells[7].Value.ToString();

            //int MaHD = Convert.ToInt32(dgvDonThue.CurrentRow.Cells[0].Value);
            //string query = "select * from DAT where MaHD = ' " + MaHD + "'";
            //foreach (DataRow i in GetRecords(query).Rows)
            //{
            //    txtMaHD.Text = i["MaHD"].ToString();
            //    cbbKH.Text = i["MaKH"].ToString();
            //    cbbNV.Text = i["MaNV"].ToString();
            //    cbbBienSoXe.Text = i["BienSoXe"].ToString();
            //    txtKyHieuHD.Text = i["KyHieuHD"].ToString();
            //    txtMauSoHD.Text = i["MauSoHD"].ToString();
            //    dtNgayDat.Value = Convert.ToDateTime(i["NgayDat"].ToString());
            //    dtNgayTra.Value = Convert.ToDateTime(i["NgayTra"].ToString());
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "insert into DAT_CHITIET values ('" + txtMaHDCT.Text + "', '" + cbbMaDV.Text + "', '" + txtDonVi.Text + "', '" + txtSoLuong.Text + "', '" + txtThanhTien.Text + "')";

            if (txtMaHDCT.Text == "" || cbbMaDV.Text == "" || txtDonVi.Text == "" || txtSoLuong.Text == "" || txtThanhTien.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ!", "Thông báo");
            }
            else
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công!", "Thống báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xảy ra lỗi trong quá trình thêm!", "Thông báo");
                }
                loaddataHDCT();
            }
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "Update DAT_CHITIET set MaHD = '" + txtMaHDCT.Text + "', MaDichVu = '" + cbbMaDV.Text + "', DonVi='" + txtDonVi.Text + "', SoLuong='" + txtSoLuong.Text + "', ThanhTien='" + txtThanhTien.Text + "'";

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật!", "Thông báo");
            }
            loaddataHDCT();
            
        }
    }
}
