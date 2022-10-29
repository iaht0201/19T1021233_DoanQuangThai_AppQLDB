using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyDanhBa.ViewModel
{
    public class NguoiViewModel
    {
        public int ID { get; set; }

        public string TenGoi { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int? IDNhom { get; set; }
        public string DiaChi { get; set; }

    }
}
