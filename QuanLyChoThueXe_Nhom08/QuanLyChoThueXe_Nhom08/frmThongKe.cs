using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChoThueXe_Nhom08
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            try { 
            using (VanChuyenKhachEntities db = new VanChuyenKhachEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                cbbBienSoXe.DataSource = db.XEs.ToList();
                cbbBienSoXe.ValueMember = "BienSoXe";
                cbbBienSoXe.DisplayMember = "BienSoXe";
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void cbbBienSoXe_SelectionChangeCommitted(object sender, EventArgs e)
        {
            XE obj = cbbBienSoXe.SelectedItem as XE;
            if (obj != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    using (VanChuyenKhachEntities db = new VanChuyenKhachEntities())
                    {
                        db.Configuration.ProxyCreationEnabled = false;
                        var query = from o in db.TINHTRANGs
                                    where o.BienSoXe == obj.BienSoXe
                                    select o;
                        dgvThongKe.DataSource = query.ToList();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
