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
using System.IO;

namespace QuanLyChoThueXe_Nhom08
{
    public partial class frmBackup : Form
    {

        bool isThoat = true;
        public frmBackup()
        {
            InitializeComponent();
            
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            string dd = d.Day + "-" + d.Month;
            string servername = txtserver.Text;
            string dbname = txtDatabase.Text;
            string ThuMuc = txtThuMuc.Text;

            string backup = @"Data Source =" + servername + ";Initial Catalog=" + dbname + "; Integrated Security = True";
            SqlConnection con = new SqlConnection(backup);

            con.Open();
            string str = "USE " + dbname + ";";
            string str1 = "BACKUP DATABASE " + dbname + " TO DISK = '" + ThuMuc + "" + dbname + "_" + dd
                + ".BAK' WITH FORMAT,MEDIANAME = 'Z_SQLServerBackups',NAME = 'Full Backup of " + dbname + "';";
            SqlCommand cmd1 = new SqlCommand(str, con);
            SqlCommand cmd2 = new SqlCommand(str1, con);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Dữ liệu đã được sao lưu thành công", "Thông báo");
            con.Close();
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

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Thư mục";
            dlg.InitialDirectory = @"D:";
            dlg.Filter = "All files (*.*)|*.*|All files(*.*) | *.* ";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtThuMuc.Text = dlg.FileName;
                MessageBox.Show("Chọn thành công","Thông báo");
            }    
        }

        private void frmBackup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }
    }
}
