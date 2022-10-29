using AppQuanLyDanhBa.Model;
using AppQuanLyDanhBa.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyDanhBa.Services
{
    public class NhomServices
    {
        public static List<NhomViewModel> GetList()
        {

            var db = new Model1();
            var rs = db.Nhoms.Select(e => new NhomViewModel
            {

                ID = (int)e.ID,
                TenNhom = e.TenNhom ,
                

            }).ToList();
            return rs;
        }
        public static KetQua AdNhom(Nhom n)
        {
            var db = new Model1();
            int count = db.Nhoms.Where(e => e.TenNhom == n.TenNhom).Count();
            if (count > 0)
            {
                return KetQua.Loi;
            }

            else
            {
                db.Nhoms.Add(n);
                db.SaveChanges();
                return KetQua.ThanhCong;
            }
        }
        public static KetQua RemoveNhom(NhomViewModel n)
        {
            var db = new Model1();
            var nhom = db.Nhoms.Where(e => e.ID == n.ID).FirstOrDefault();
            List<Nguoi> nguoiCuaNhom = db.Nguois.Where(e => e.IDNhom == n.ID).ToList();
            foreach (Nguoi ng in nguoiCuaNhom)
            {
                db.Nguois.Remove(ng);
            }
            db.Nhoms.Remove(nhom);
            db.SaveChanges();
            return KetQua.ThanhCong;
        }

    }
}
