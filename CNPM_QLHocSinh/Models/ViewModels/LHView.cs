using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CNPM_QLHocSinh.Models.ViewModels
{
    public class LHView
    {
        [Required(ErrorMessage = "Vui lòng chọn số.")]
        public int SelectedNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn khối lớp.")]
        public string SelectedMaKL { get; set; }

        public IEnumerable<int> AvailableNumbers { get; set; }
        public IEnumerable<KhoiLop> DSKhoiLop { get; set; }
    }
}