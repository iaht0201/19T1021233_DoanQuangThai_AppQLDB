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
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
            NapDsNhom();
            NapDsNguoiTheoNhom();
            NapThongTin();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public NhomViewModel selectedNhom
        {
            get
            {
                return bdsNhom.Current as NhomViewModel;
            }
        }
        public NguoiViewModel selectedNguoi
        {
            get {
                return bdsNguoi.Current as NguoiViewModel;
            }
        }

        void NapDsNhom()
        {
          
            var ls = NhomServices.GetList(); 
            bdsNhom.DataSource = ls;

            gridNhom.DataSource = bdsNhom;
           


        }
        void NapDsNguoiTheoNhom()
        {
            if (selectedNhom != null)
            {
                var ls = NguoiService.Getlist(selectedNhom.ID);
                bdsNguoi.DataSource = ls;
                gridNguoi.DataSource = bdsNguoi;
            }
              
            

        }
        void NapDsNguoiTheoTimKiem()
        {
            if (selectedNhom != null)
            {
                var ls = NguoiService.TimKiemLienLac(selectedNhom.ID, txtTimKiem.Text);
                bdsNguoi.DataSource = ls;
                gridNguoi.DataSource = bdsNguoi;
            }
        }
        void NapThongTin()
        {
            if (selectedNguoi != null)
            {
                txtEmail.Show();
                txtSoDienThoai.Show();
                txtDiaChi.Show();
                lblEmail.Show();
                lblDiaChi.Show();
                lblSDT.Show();

                txtTenGoi.Text = selectedNguoi.TenGoi;
                txtEmail.Text = selectedNguoi.Email;
                txtSoDienThoai.Text = selectedNguoi.PhoneNumber;
                txtDiaChi.Text = selectedNguoi.DiaChi;

            }
            else
            {
                txtTenGoi.Text = $"{selectedNhom.TenNhom.ToUpper()} HIỆN CHƯA CÓ LIÊN LẠC !";
                txtEmail.Hide();
                txtSoDienThoai.Hide() ;
                txtDiaChi.Hide() ;
                lblEmail.Hide();
                lblDiaChi.Hide();
                lblSDT.Hide(); 
                
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(selectedNhom != null)
            {
                NapDsNguoiTheoNhom();
                NapThongTin();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapThongTin();
        }

        private void txtDiaChi_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var f = new frmNhom();
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                NapDsNhom();
               
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (selectedNhom != null)
            {
                if (selectedNguoi != null)
                {
                    var rs = MessageBox.Show($"{selectedNhom.TenNhom.ToUpper()} đang có người liên lạc. Bạn có chắc là muốn xóa {selectedNhom.TenNhom.ToUpper()}?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (rs == DialogResult.OK)
                    {
                        NhomServices.RemoveNhom(selectedNhom);
                        NapDsNhom();
                        NapDsNguoiTheoNhom();
                    }
                }
                else
                {
                    var rs = MessageBox.Show("Bạn có chắc là muốn xóa Nhóm?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (rs == DialogResult.OK)
                    {
                        NhomServices.RemoveNhom(selectedNhom);
                        NapDsNhom();
                        NapDsNguoiTheoNhom();
                    }
                }


            }
           


            }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var f = new frmNguoi(selectedNhom);
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                NapDsNguoiTheoNhom();
                NapThongTin();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (selectedNguoi != null)
            {
                var rs = MessageBox.Show($"Bạn có muốn xóa {selectedNguoi.TenGoi} ?", "Chú ý", MessageBoxButtons.OKCancel);
                if (rs == DialogResult.OK)
                {             

                    NguoiService.RemoveLienLac(selectedNguoi);
                    NapDsNguoiTheoNhom();
                    /*NapThongTin();*/

                }
            }


        }



     
        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NapDsNguoiTheoTimKiem();
                NapThongTin();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (selectedNguoi != null)
            {
                var rs = MessageBox.Show($"Bạn có muốn xóa?", "Chú ý", MessageBoxButtons.OKCancel);
                if (rs == DialogResult.OK)
                {

                    NguoiService.RemoveTatCa(selectedNguoi);
                    NapDsNguoiTheoNhom();

                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
