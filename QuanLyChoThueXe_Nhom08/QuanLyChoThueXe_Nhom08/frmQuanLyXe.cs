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
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=NGBATRUONG;Initial Catalog=ChoThueXe;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public frmQuanLyXe()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from XE";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvQLXe.DataSource = table;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLyXe_Load(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Insert into XE values('" + txtBienSoXe.Text + "',N'" + cbbSCN.Text + "',N'" + txtMaDichVu.Text + "',N'" + cbbTenDichVu.Text +"')";
            if (txtBienSoXe.Text == "" || cbbSCN.Text == "" || txtMaDichVu.Text == "" || cbbTenDichVu.Text == "")
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
       

        

        private void txtBienSoXe_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
