using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CNPM_QLHocSinh.Models.ViewModels
{
    public class KLView
    {
        [Required(ErrorMessage = "Vui lòng chọn số.")]
        [Range(1, 9, ErrorMessage = "Vui lòng chọn số khả dụng.")]
        public int? SelectedNumber { get; set; }
    }
}