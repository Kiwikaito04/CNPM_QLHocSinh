using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPM_QLHocSinh.Models.ViewModels
{
    public class GVView
    {
        public GiaoVien GiaoVien { get; set; }
        public IEnumerable<ChucVu> ChucVuList { get; set; }
    }
}