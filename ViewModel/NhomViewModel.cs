﻿using AppQuanLyDanhBa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyDanhBa.ViewModel
{
    public enum KetQua
    {
        Loi,
        ThanhCong
    }
   
    public class NhomViewModel
    {

        public int ID { get; set; }
        public string TenNhom { get; set; }

    }
}
