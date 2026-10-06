using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5._1_06102026
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Dat ngay sinh mac dinh la nguoi du 18 tuoi
            dtpNgaySinh.Value = DateTime.Today.AddYears(-18);

            // An mat khau
            txtMatKhau.UseSystemPasswordChar = true;
            txtXacNhanMatKhau.UseSystemPasswordChar = true;
        }

        // =========================
        // NUT DANG KY
        // =========================
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Xoa tat ca loi cu
            epCheck.Clear();

            bool hopLe = true;

            // 1. Kiem tra ten dang nhap
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                epCheck.SetError(
                    txtTenDangNhap,
                    "Ten dang nhap khong duoc de trong!"
                );

                hopLe = false;
            }

            // 2. Kiem tra mat khau
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                epCheck.SetError(
                    txtMatKhau,
                    "Mat khau khong duoc de trong!"
                );

                hopLe = false;
            }

            // 3. Kiem tra xac nhan mat khau
            if (string.IsNullOrWhiteSpace(txtXacNhanMatKhau.Text))
            {
                epCheck.SetError(
                    txtXacNhanMatKhau,
                    "Vui long nhap lai mat khau!"
                );

                hopLe = false;
            }
            else if (txtMatKhau.Text != txtXacNhanMatKhau.Text)
            {
                epCheck.SetError(
                    txtXacNhanMatKhau,
                    "Mat khau xac nhan khong khop!"
                );

                hopLe = false;
            }

            // 4. Tinh tuoi
            int tuoi = TinhTuoi(dtpNgaySinh.Value);

            if (tuoi < 18)
            {
                epCheck.SetError(
                    dtpNgaySinh,
                    "Nguoi dang ky phai tu 18 tuoi tro len!"
                );

                hopLe = false;
            }

            // 5. Kiem tra dieu khoan
            if (!chkDieuKhoan.Checked)
            {
                epCheck.SetError(
                    chkDieuKhoan,
                    "Ban phai dong y voi dieu khoan dich vu!"
                );

                hopLe = false;
            }

            // 6. Neu tat ca hop le
            if (hopLe)
            {
                MessageBox.Show(
                    "Dang ky tai khoan thanh cong!",
                    "Thong bao",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        // =========================
        // HAM TINH TUOI
        // =========================
        private int TinhTuoi(DateTime ngaySinh)
        {
            int tuoi = DateTime.Today.Year - ngaySinh.Year;

            if (ngaySinh.Date > DateTime.Today.AddYears(-tuoi))
            {
                tuoi--;
            }

            return tuoi;
        }

        // =========================
        // NUT LAM MOI
        // =========================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Xoa ten dang nhap
            txtTenDangNhap.Clear();

            // Xoa mat khau
            txtMatKhau.Clear();

            // Xoa xac nhan mat khau
            txtXacNhanMatKhau.Clear();

            // Dat lai ngay sinh
            dtpNgaySinh.Value = DateTime.Today.AddYears(-18);

            // Bo chon gioi tinh
            rdoNam.Checked = false;
            rdoNu.Checked = false;

            // Bo tich dieu khoan
            chkDieuKhoan.Checked = false;

            // Xoa thong bao loi
            epCheck.Clear();

            // Dua con tro ve o ten dang nhap
            txtTenDangNhap.Focus();
        }
    }
}
