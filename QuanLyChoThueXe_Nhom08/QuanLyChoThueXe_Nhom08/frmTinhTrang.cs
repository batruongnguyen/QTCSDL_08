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
        SqlConnection con = new SqlConnection(@"Data Source=DIEUHOAI\SQLEXPRESS;Initial Catalog=VanChuyenKhach;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public frmTinhTrang()
        {
            InitializeComponent();
        }
        void loaddataTT()
        {
            string query = "select * from TINHTRANG";
            dgvTinhTrang.DataSource = GetRecords(query);
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

        private void btnThemXe_Click(object sender, EventArgs e)
        {

        }

        private void frmTinhTrang_Load(object sender, EventArgs e)
        {
            loaddataTT();
        }

        private void dtNgayDat_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void dgvTinhTrang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTT.Enabled = false;
            int i = dgvTinhTrang.CurrentRow.Index;
            txtMaTT.Text = dgvTinhTrang.Rows[i].Cells[0].Value.ToString();
            txtBienSoXe.Text = dgvTinhTrang.Rows[i].Cells[1].Value.ToString();
            cbbDongCo.Text = dgvTinhTrang.Rows[i].Cells[2].Value.ToString();
            cbbMayLanh.Text = dgvTinhTrang.Rows[i].Cells[3].Value.ToString();
            txtNguonDien.Text = dgvTinhTrang.Rows[i].Cells[4].Value.ToString();
            cbbCuaXe.Text = dgvTinhTrang.Rows[i].Cells[5].Value.ToString();
            dtThoiGianCN.Text = dgvTinhTrang.Rows[i].Cells[6].Value.ToString();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbDongCo.SelectedItem == null ||  txtNguonDien.Text == "" || cbbMayLanh.SelectedItem == null || cbbCuaXe.SelectedItem == null || dtThoiGianCN.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ!", "Thông báo");
            }
            else
            {
                string MaTinhTrang = txtMaTT.Text;
                string BienSoXe = txtBienSoXe.Text;
                string DongCo = cbbDongCo.Text;
                string MayLanh = cbbMayLanh.Text;
                string NguonDien = txtNguonDien.Text;
                string CuaXe = cbbCuaXe.Text;
                string ThoiGianCapNhat = dtThoiGianCN.Text;
                string query = "insert into TINHTRANG values ('" + MaTinhTrang + "', '" + BienSoXe + "', '" + DongCo + "', '" + MayLanh + "', '" + NguonDien + "', '" + CuaXe + "', '" + ThoiGianCapNhat + "')";
                ExcuteDB(query);
                loaddataTT();
                MessageBox.Show("Đã thêm thành công!", "Thông báo");
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
            loaddataTT();
            txtTimKiem.Text = "";
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }
    }
}
