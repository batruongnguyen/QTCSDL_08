
namespace QuanLyChoThueXe_Nhom08
{
    partial class frmQuanLyTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyTaiKhoan));
            this.dtgvUser = new System.Windows.Forms.DataGridView();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLoaiTaiKhoan = new System.Windows.Forms.ComboBox();
            this.txtTenTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.QLTK = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvUser)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvUser
            // 
            this.dtgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvUser.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.PassWord,
            this.TypeAcc});
            this.dtgvUser.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvUser.Location = new System.Drawing.Point(21, 31);
            this.dtgvUser.MultiSelect = false;
            this.dtgvUser.Name = "dtgvUser";
            this.dtgvUser.ReadOnly = true;
            this.dtgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgvUser.Size = new System.Drawing.Size(720, 181);
            this.dtgvUser.TabIndex = 0;
            this.dtgvUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvUser_CellClick_1);
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "Tên Tài Khoản";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // PassWord
            // 
            this.PassWord.DataPropertyName = "PassWord";
            this.PassWord.HeaderText = "Mật Khẩu";
            this.PassWord.Name = "PassWord";
            this.PassWord.ReadOnly = true;
            // 
            // TypeAcc
            // 
            this.TypeAcc.DataPropertyName = "TypeAcc";
            this.TypeAcc.HeaderText = "Loại Tài Khoản";
            this.TypeAcc.Name = "TypeAcc";
            this.TypeAcc.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên Tài  Khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật Khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Loại Tài Khoản";
            // 
            // cbLoaiTaiKhoan
            // 
            this.cbLoaiTaiKhoan.FormattingEnabled = true;
            this.cbLoaiTaiKhoan.Items.AddRange(new object[] {
            "Admin",
            "Nhân Viên"});
            this.cbLoaiTaiKhoan.Location = new System.Drawing.Point(283, 129);
            this.cbLoaiTaiKhoan.Name = "cbLoaiTaiKhoan";
            this.cbLoaiTaiKhoan.Size = new System.Drawing.Size(192, 33);
            this.cbLoaiTaiKhoan.TabIndex = 4;
            // 
            // txtTenTaiKhoan
            // 
            this.txtTenTaiKhoan.Location = new System.Drawing.Point(283, 36);
            this.txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            this.txtTenTaiKhoan.Size = new System.Drawing.Size(192, 30);
            this.txtTenTaiKhoan.TabIndex = 5;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(283, 81);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(192, 30);
            this.txtMatKhau.TabIndex = 6;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(133)))));
            this.btnThem.Location = new System.Drawing.Point(663, 64);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(87, 34);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(133)))));
            this.btnSua.Location = new System.Drawing.Point(663, 104);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(87, 34);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(133)))));
            this.btnXoa.Location = new System.Drawing.Point(663, 144);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(87, 34);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(133)))));
            this.btnThoat.Location = new System.Drawing.Point(717, 490);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 35);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // QLTK
            // 
            this.QLTK.AutoSize = true;
            this.QLTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QLTK.Location = new System.Drawing.Point(237, 9);
            this.QLTK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.QLTK.Name = "QLTK";
            this.QLTK.Size = new System.Drawing.Size(324, 33);
            this.QLTK.TabIndex = 11;
            this.QLTK.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(133)))));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbLoaiTaiKhoan);
            this.groupBox1.Controls.Add(this.txtTenTaiKhoan);
            this.groupBox1.Controls.Add(this.txtMatKhau);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(36, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 186);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.groupBox2.Controls.Add(this.dtgvUser);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(133)))));
            this.groupBox2.Location = new System.Drawing.Point(36, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(756, 229);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(108)))), ((int)(((byte)(133)))));
            this.btnReset.Location = new System.Drawing.Point(663, 185);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 38);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Tải lại";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmQuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(842, 539);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.QLTK);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQuanLyTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ TÀI KHOẢN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuanLyTaiKhoan_FormClosed);
            this.Load += new System.EventHandler(this.frmQuanLyTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvUser)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLoaiTaiKhoan;
        private System.Windows.Forms.TextBox txtTenTaiKhoan;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label QLTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeAcc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReset;
    }
}