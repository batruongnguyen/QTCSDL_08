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
        SqlConnection con = new SqlConnection (@"Data Source=localhost;Initial Catalog=VanChuyenKhach;Integrated Security=True");
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

            this.dgvDonThue.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvDonThue.AlternatingRowsDefaultCellStyle.BackColor =
                Color.GhostWhite;
        }

        public void loaddataHDCT()
        {
            string HDCT = "select * from DAT_CHITIET";
            dgvHDCT.DataSource = GetRecords(HDCT);

            this.dgvHDCT.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            this.dgvHDCT.AlternatingRowsDefaultCellStyle.BackColor =
                Color.GhostWhite;             
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
                MessageBox.Show(ex.Message, "Thông báo");
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
            loadcbbDV();
            loaddataHD();
            loaddataHDCT();        
            txtTenDV.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbKH.SelectedItem == null || cbbNV.SelectedItem == null || txtMaHD.Text == ""  || txtKyHieuHD.Text == "" || txtMauSoHD.Text == "" || txtVAT.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ!", "Thông báo");
            }
            else
            {
                string MaHD = txtMaHD.Text;
                string MaKH = cbbKH.Text;
                string MaNV = cbbNV.Text;
                string KyHieuHD = txtKyHieuHD.Text;
                string MauSoHD = txtMauSoHD.Text;
                string DonGia = txtDonGia.Text;
                string NgayDat = dtNgayDat.Text;
                string NgayTra = dtNgayTra.Text;
                string VAT = txtVAT.Text;

                string query = "insert into DAT values ('"+ MaHD+"', '"+MaKH+"', '"+MaNV+"', '"+KyHieuHD+"', '"+MauSoHD+"', '"+NgayDat+"', '"+ NgayTra + "', '"+DonGia+ "', NULL,'" + VAT + "')";
                ExcuteDB(query);
                loaddataHD();
                MessageBox.Show("Đã thêm thành công!", "Thông báo");
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            loadCbbMaKH();
            loadCbbMaNV();
            loaddataHD();
            txtKyHieuHD.Text = "";
            txtMauSoHD.Text = "";
            dtNgayDat.Text = "";
            dtNgayTra.Text = "";
            txtDonGia.Text = "";
            txtTongTien.Text = "";
            txtVAT.Text = "";
            txtTimKiem.Text = "";
            txtMaHD.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
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
            txtMaHDCT.Enabled = true;
            loaddataHDCT();
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
                            string MaHD = dgvDonThue.CurrentRow.Cells[0].Value.ToString();
                            string query = "delete from DAT where MaHD = '" + MaHD+"'";
                            ExcuteDB(query);  
                        }
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        loaddataHD();
                        loaddataHDCT();
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
            txtMaHD.Enabled = false;
            int i = dgvDonThue.CurrentRow.Index;
            txtMaHD.Text = dgvDonThue.Rows[i].Cells[0].Value.ToString();
            cbbKH.Text = dgvDonThue.Rows[i].Cells[1].Value.ToString();
            cbbNV.Text = dgvDonThue.Rows[i].Cells[2].Value.ToString();
            txtKyHieuHD.Text = dgvDonThue.Rows[i].Cells[3].Value.ToString();
            txtMauSoHD.Text = dgvDonThue.Rows[i].Cells[4].Value.ToString();
            dtNgayDat.Text = dgvDonThue.Rows[i].Cells[5].Value.ToString();
            dtNgayTra.Text = dgvDonThue.Rows[i].Cells[6].Value.ToString();
            txtDonGia.Text = dgvDonThue.Rows[i].Cells[7].Value.ToString(); 
            txtTongTien.Text = dgvDonThue.Rows[i].Cells[8].Value.ToString();
            txtVAT.Text = dgvDonThue.Rows[i].Cells[9].Value.ToString();
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            if (txtMaHDCT.Text == "" || cbbMaDV.SelectedItem == null || txtDonVi.Text == "" || txtSoLuong.Text == "" || txtThanhTien.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ!", "Thông báo");
            }
            else
            {
                string MaHD = txtMaHDCT.Text;
                string MaDV = cbbMaDV.Text;
                string DonVi = txtDonVi.Text;
                string SoLuong = txtSoLuong.Text;
                string ThanhTien = txtThanhTien.Text;

                string query = "insert into DAT_CHITIET values ('" + MaHD + "', '" + MaDV + "', '" + DonVi + "', '" + SoLuong + "', '" + ThanhTien + "')";
                ExcuteDB(query);
                loaddataHDCT();
            }
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            string querry = "Update DAT_CHITIET set MaDichVu = '" + cbbMaDV.Text + "', DonVi='" + txtDonVi.Text +
                            "', SoLuong='" + txtSoLuong.Text + "', ThanhTien='" + txtThanhTien.Text + "' where MaHD = '" + txtMaHDCT.Text + "'";
            try
            {
                ExcuteDB(querry);
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật!\n" + ex.Message, "Thông báo");
            }
            loaddataHDCT();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string querry = "Update DAT set MaKH = '" + cbbKH.Text + "', maNV='" + cbbNV.Text +
                "', kyHieuHD='" + txtKyHieuHD.Text + "', MauSoHD='" + txtMauSoHD.Text + "', NgayDat = '" 
                + dtNgayDat.Text + "', NgayTra = '" + dtNgayTra.Text + "', VAT = '" + txtVAT.Text + "' where MaHD = '"+txtMaHD.Text+"'";
            try
            {
                ExcuteDB(querry);
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật!\n"+ex.Message, "Thông báo");
            }
            loaddataHD();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "" && txtTimKiem.Text.Length <= 10 && txtTimKiem.Text.Length > 0)
            {
                string query_DAT = "Select * from DAT where MaHD like '%" + txtTimKiem.Text + "%'";
                string query_CT_DAT = "Select * from DAT_CHITIET where MaHD like '%" + txtTimKiem.Text + "%'";
                dgvDonThue.DataSource = GetRecords(query_DAT);
                dgvHDCT.DataSource = GetRecords(query_CT_DAT);
            }
        }



        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (flag == true)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo", MessageBoxButtons.OKCancel);
                if (confirmResult == DialogResult.OK)
                {
                    try
                    {
                        if (dgvHDCT.CurrentCell != null)
                        {
                            string MaHD = dgvHDCT.CurrentRow.Cells[0].Value.ToString();
                            string query = "delete from DAT_CHITIET where MaHD = '" + MaHD + "'";
                            ExcuteDB(query);
                        }
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        loaddataHD();
                        loaddataHDCT();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xảy ra lỗi trong quá trình xóa!", "Thông báo");
                    }
                    loaddataHDCT();
                }
            }
        }

        private void dgvHDCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHDCT.Enabled = false;
            int i = dgvHDCT.CurrentRow.Index;
            txtMaHDCT.Text = dgvHDCT.Rows[i].Cells[0].Value.ToString();
            cbbMaDV.Text = dgvHDCT.Rows[i].Cells[1].Value.ToString();
            txtDonVi.Text = dgvHDCT.Rows[i].Cells[2].Value.ToString();
            txtSoLuong.Text = dgvHDCT.Rows[i].Cells[3].Value.ToString();
            txtThanhTien.Text = dgvHDCT.Rows[i].Cells[4].Value.ToString();
        }


    }
}
