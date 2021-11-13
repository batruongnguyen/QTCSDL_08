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
    public partial class frmQuanLyXe : Form
    {
        bool isThoat = true;
        SqlConnection con = new SqlConnection(@"Data Source=DIEUHOAI\SQLEXPRESS;Initial Catalog=VanChuyenKhach;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public frmQuanLyXe()
        {
            InitializeComponent();
        }
        void loaddataXe()
        {
            string query = "select * from XE";
            dgvXe.DataSource = GetRecords(query);
        }
        void loaddataDV()
        {
            string query = "select * from DICHVU";
            dgvDichVu.DataSource = GetRecords(query);
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

        private void button3_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (flag == true)
            {
                var confirmResult = MessageBox.Show("Bạn muốn thực hiện xóa?", "Thông báo", MessageBoxButtons.OKCancel);
                if (confirmResult == DialogResult.OK)
                {
                    try
                    {
                        if (dgvDichVu.CurrentCell != null)
                        {
                            string BienSoXe = dgvXe.CurrentRow.Cells[0].Value.ToString();
                            string query = "delete from XE where BienSoXe = '" + BienSoXe + "'";
                            ExcuteDB(query);
                        }
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        loaddataXe();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xảy ra lỗi trong quá trình xóa!", "Thông báo");
                    }
                    loaddataXe();
                }
            }
        }

        private void frmQuanLyXe_Load(object sender, EventArgs e)
        {
            loaddataXe();
            loaddataDV();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string querry = "Update XE set SCN ='" + cbbSCN.Text + "'";
                try
                {
                ExcuteDB(querry);
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình cập nhật!\n" + ex.Message, "Thông báo");
            }
            loaddataXe();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBienSoXe.Text = "";
            loaddataXe();
            cbbSCN.Text = "";
            txtTimXe.Text = "";
            txtBienSoXe.Enabled = true;
            btnXoaXe.Enabled = true;
            btnSuaXe.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbSCN.SelectedItem == null || txtBienSoXe.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ!", "Thông báo");
            }
            else
            {
                string BienSoXe = txtBienSoXe.Text;
                string SCN = cbbSCN.Text;

                string query = "insert into XE values ('" + BienSoXe + "', '" + SCN + "')";
                ExcuteDB(query);
                loaddataXe();
                MessageBox.Show("Đã thêm thành công!", "Thông báo");
            }

        }

        private void txtBienSoXe_TextChanged(object sender, EventArgs e)
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

        private void frmQuanLyXe_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }


        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (cbbTenDV.SelectedItem == null || txtMaDV.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin đầy đủ!", "Thông báo");
            }
            else
            {
                string MaDichVu = txtMaDV.Text;
                string TenDichVu = cbbTenDV.Text;

                string query = "insert into DICHVU values ('" + MaDichVu + "', '" + TenDichVu + "')";
                ExcuteDB(query);
                loaddataDV();
                MessageBox.Show("Đã thêm thành công!", "Thông báo");
            }
        }

        private void dgvXe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBienSoXe.Enabled = false;
            int i = dgvXe.CurrentRow.Index;
            txtBienSoXe.Text = dgvXe.Rows[i].Cells[0].Value.ToString();
            cbbSCN.Text = dgvXe.Rows[i].Cells[1].Value.ToString();

        }

        private void dgvDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDV.Enabled = false;
            int i = dgvDichVu.CurrentRow.Index;
            txtMaDV.Text = dgvDichVu.Rows[i].Cells[0].Value.ToString();
            cbbTenDV.Text = dgvDichVu.Rows[i].Cells[1].Value.ToString();
        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (flag == true)
            {
                var confirmResult = MessageBox.Show("Bạn muốn thực hiện xóa?", "Thông báo", MessageBoxButtons.OKCancel);
                if (confirmResult == DialogResult.OK)
                {
                    try
                    {
                        if (dgvDichVu.CurrentCell != null)
                        {
                            string MaDichVu = dgvDichVu.CurrentRow.Cells[0].Value.ToString();
                            string query = "delete from DICHVU where MaDichVu = '" + MaDichVu + "'";
                            ExcuteDB(query);
                        }
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        loaddataDV();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xảy ra lỗi trong quá trình xóa!", "Thông báo");
                    }
                    loaddataDV();
                }
            }
        }

        private void btnResetDv_Click(object sender, EventArgs e)
        {
            txtMaDV.Text = "";
            loaddataDV();
            cbbTenDV.Text = "";
            txtTimDV.Text = "";
            txtMaDV.Enabled = true;
            btnXoaDV.Enabled = true;
            btnSuaDV.Enabled = true;
        }

        private void btnTimXe_Click(object sender, EventArgs e)
        {
            if (txtTimXe.Text != "" && txtTimXe.Text.Length <= 10 && txtTimXe.Text.Length > 0)
            {
                string query_XE = "Select * from XE where BienSoXe like '%" + txtTimXe.Text + "%' or SCN like '%" + txtTimXe.Text + "%'";
                dgvXe.DataSource = GetRecords(query_XE);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (txtTimDV.Text != "" && txtTimDV.Text.Length <= 10 && txtTimDV.Text.Length > 0)
            {
                string query_DV = "Select * from DICHVU where MaDichVu like '%" + txtTimDV.Text + "%' or TenDichVu like '%" + txtTimDV.Text + "%'";
                dgvDichVu.DataSource = GetRecords(query_DV);
            }
        }
    }
}
