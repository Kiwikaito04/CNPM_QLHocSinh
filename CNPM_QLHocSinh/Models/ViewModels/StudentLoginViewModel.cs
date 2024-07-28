using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CNPM_QLHocSinh.Models.ViewModels
{
    public class StudentLoginViewModel
    {
        [Required]
        [Display(Name = "Mã Học Sinh")]
        public string MaHS { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}