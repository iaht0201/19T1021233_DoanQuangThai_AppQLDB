using AppQuanLyDanhBa.Model;
using AppQuanLyDanhBa.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBa.Services
{
    public class NguoiService
    {
        //Lay toan bo lop hoc

        public static List<NguoiViewModel> Getlist()
        {
            var db = new Model1();
            var rs = db.Nguois.Select(e => new NguoiViewModel
            {
                ID = e.ID,
                TenGoi = e.TenGoi,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                IDNhom = (int)e.IDNhom,
                DiaChi = e.DiaChi,

            }).ToList();

            return rs;

        }

        public static List<NguoiViewModel> Getlist(int idNhom)
        {
            var db = new Model1();
            var rs = db.Nguois.Where(e => e.IDNhom == idNhom).Select(e => new NguoiViewModel
            {
                ID = e.ID,
                TenGoi = e.TenGoi,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                IDNhom = (int)e.IDNhom,
                DiaChi = e.DiaChi,
            }).ToList();
            return rs;
        }


        public static KetQua AddLienLac(Nguoi n)
        {
            var db = new Model1();
            var countNumberPhone = db.Nguois.Where(e => e.PhoneNumber == n.PhoneNumber || e.TenGoi == n.TenGoi).Count();
            if (countNumberPhone == 0)
            {
                db.Nguois.Add(n);
                db.SaveChanges();
                return KetQua.ThanhCong;
            }
            else
            {
                return KetQua.Loi;
            }


        }
        public static KetQua RemoveLienLac(NguoiViewModel n)
        {
            var db = new Model1();
            var nguoi = db.Nguois.Where(e => e.ID == n.ID).FirstOrDefault();
            db.Nguois.Remove(nguoi);
            db.SaveChanges();
            return KetQua.ThanhCong;
        }
        public static List<NguoiViewModel> TimKiemLienLac(int idNhom, string key)
        {
            var rs = NguoiService.Getlist(idNhom).Where(e => e.TenGoi.ToLower().Contains(key.ToLower()) || e.PhoneNumber.Contains(key) ).ToList();
            return rs;
        }
        public static KetQua RemoveTatCa(NguoiViewModel n)
        {
            var db = new Model1();
           
            List<Nguoi> nguoiCuaNhom = db.Nguois.Where(e => e.IDNhom == n.ID).ToList();
            foreach (Nguoi ng in nguoiCuaNhom)
            {
                db.Nguois.Remove(ng);
            }
            db.SaveChanges();
            return KetQua.ThanhCong;
       
        }
    }
}
