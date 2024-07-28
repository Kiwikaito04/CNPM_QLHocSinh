using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CNPM_QLHocSinh.Models.ViewModels
{
    public class LGDView
    {
        [DisplayName("Lớp")]
        [Required(ErrorMessage = "Vui lòng chọn lớp học")]
        public string MaLop { get; set; }

        [DisplayName("Môn")]
        [Required(ErrorMessage = "Vui lòng chọn môn học")]
        public string MaMH { get; set; }

        [DisplayName("Giáo viên")]
        [Required(ErrorMessage = "Vui lòng chọn giáo viên")]
        public string MaGV { get; set; }

        [DisplayName("Ca")]
        [Required(ErrorMessage = "Vui lòng chọn ca")]
        public string MaCa { get; set; }
    }
}