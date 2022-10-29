using AppQuanLyDanhBa.Model;
using AppQuanLyDanhBa.Services;
using AppQuanLyDanhBa.ViewModel;
using QuanLyDanhBa.Services;
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
    public partial class frmNguoi : Form
    {
        NhomViewModel nhom; 
        public frmNguoi(NhomViewModel nhom)
        {

            InitializeComponent();
            NapNhomLienLac();
            this.nhom = nhom ;
            if (nhom!= null)
            {
                txtNhom.Text = nhom.TenNhom; 
            }
        }
        void NapNhomLienLac()
        {
            var list = NhomServices.GetList();
         
        }
        private void frmNguoi_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtNhom_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
               
                var nguoi = new Nguoi
                {
  
                    TenGoi = txtTenGoi.Text ,
                    Email = txtEmail.Text,
                    PhoneNumber = txtSDT.Text,
                    IDNhom = nhom.ID,
                    DiaChi = txtDiaChi.Text ,


                };
            if (String.IsNullOrEmpty(txtTenGoi.Text))
            {
                MessageBox.Show("Hãy đặt tên liên lạc !", "Thông báo");
                txtTenGoi.Focus();


            }
            else if (String.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được trống !", "Thông báo");
                txtTenGoi.Focus();
            }
            else
            {
                if (NguoiService.AddLienLac(nguoi) == KetQua.Loi)
                {
                    MessageBox.Show("Số điện thoại hoặc tên liên lạc đã tồn tại !", "Thông báo");
                    txtSDT.Focus();

                }

                else
                {
                    MessageBox.Show("Đã thêm liên lạc mới!", "Thong bao");

                    DialogResult = DialogResult.OK;
                }
            }
         
            
        }

        private void lblDiaChi_Click(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
