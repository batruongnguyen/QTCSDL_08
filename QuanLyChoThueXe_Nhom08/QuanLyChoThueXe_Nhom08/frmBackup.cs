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
using System.Data.Sql;

namespace QuanLyChoThueXe_Nhom08
{

    public partial class frmBackup : Form
    {
        bool isThoat = true;
        public frmBackup()
        {
            InitializeComponent();
        }
        private string func_backup(string filename)
        {
            string servername = txtServername.Text;
            string dbname = txtDatabasename.Text;
            string backup = @"Data Source =" + servername + ";Initial Catalog=" + dbname + ";Integrated Security=True";
            SqlConnection con = new SqlConnection(backup);
            con.Open();
            string str = "USE " + dbname + ";";
            string str1 = "BACKUP DATABASE " + dbname + " TO DISK = '" + filename
                + "' WITH FORMAT,MEDIANAME = 'Z_SQLServerBackups',NAME = 'Full Backup of " + dbname + "';";
            SqlCommand cmd1 = new SqlCommand(str, con);
            SqlCommand cmd2 = new SqlCommand(str1, con);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Dữ liệu đã được sao lưu thành công", "Thông báo");
            con.Close();
            return filename;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            isThoat = false;
            DialogResult dlr = MessageBox.Show("Bạn muốn rời khỏi ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            dlg.Title = "Thu mục";
            dlg.InitialDirectory = @"C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\Backup";
            //dlg.Filter = ".bak";
            dlg.RestoreDirectory = true;

            DateTime d = DateTime.Now;
            string dd = d.Day.ToString() + d.Month.ToString() + (d.Year % 100).ToString();

            dlg.FileName = txtDatabasename.Text + "_" + dd + ".bak";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtThuMuc.Text = func_backup(dlg.FileName);
                //MessageBox.Show("Ch?n thành công","Thông báo");
            }
        }

        private void frmBackup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isThoat)
                Application.Exit();
        }

    }
}
