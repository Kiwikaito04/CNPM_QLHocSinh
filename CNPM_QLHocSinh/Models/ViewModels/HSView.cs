using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CNPM_QLHocSinh.Models.ViewModels
{
    public class HSView
    {
        public HocSinh HocSinh { get; set; }
        public IEnumerable<LopHoc> LopHocList { get; set; }
    }

}