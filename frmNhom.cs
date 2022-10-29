using AppQuanLyDanhBa.Model;
using AppQuanLyDanhBa.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppQuanLyDanhBa
{
    public partial class frmNhom : Form
    {
        public frmNhom()
        {
            InitializeComponent();
        }

        private void tbNhom_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbNhom.Text))
            {
                MessageBox.Show("Tên lớp không được để trống", "Thong bao");
                tbNhom.Focus();


            }
            else
            {
                var n = new Nhom
                {
                    TenNhom = tbNhom.Text,
                };
                if (NhomServices.AdNhom(n) == ViewModel.KetQua.ThanhCong)
                {

                    MessageBox.Show("Đã thêm nhóm thành công", "Thông báo");
                    DialogResult = DialogResult.OK;
                    

                }

                else
                {
                    MessageBox.Show($" {tbNhom} đã tồn tại !", "Thông báo");
                    DialogResult = DialogResult.No;
                    tbNhom.Focus();
                }

            }
            /*else
            {
                var n = new Nhom
                {
                    TenNhom = tbNhom.Text,
                };
                if (NhomServices.AdNhom(n) == ViewModel.KetQua.ThanhCong)
                {
                    NapDanh();
                    MessageBox.Show("Đã theem lớp", "Thong bao");



                }

                else
                {
                    MessageBox.Show("Ten lop trung", "Thong bao");
                    txtTenLopHoc.Focus();
                }
                
               *//* var lh = new Nhom
                {
                    TenNhom = tbNhom.Text,

                };
                if (LopHocService.AddLopHocs(lh) == KetQua.ThanhCong)
                {
                    NapDanhSachLopHoc();
                    MessageBox.Show("Đã theem lớp", "Thong bao");



                }

                else
                {
                    MessageBox.Show("Ten lop trung", "Thong bao");
                    txtTenLopHoc.Focus();
                }*//*


            }*/
        }

        private void frmNhom_Load(object sender, EventArgs e)
        {

        }
    }
}
