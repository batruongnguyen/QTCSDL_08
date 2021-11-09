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
        SqlConnection cmn = new SqlConnection(@"Data Source=NGBATRUONG;Initial Catalog=VanChuyenKhach;Integrated Security=True");

        public frmQuanLyDonThue()
        {
            InitializeComponent();
        }

        //Chức năng thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        public DataTable GetRecords(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, cmn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmn.Open();
            da.Fill(dt);
            cmn.Close();
            return dt;
        }

        public void ExcuteDB(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cmn);
            try
            {
                cmn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối dữ liệu!", "Thông báo");
            }
            cmn.Close();
        }



    }
}
