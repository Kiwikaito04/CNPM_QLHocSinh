using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CNPM_QLHocSinh.Models.ViewModels
{
    public class MHView
    {
        [DisplayName("Tên môn học")]
        [Required(ErrorMessage = "Tên môn học là bắt buộc")]
        [StringLength(20, ErrorMessage = "Tên môn học không thể dài quá 20 ký tự.")]
        public string TenMH { get; set; }

        [DisplayName("Mô tả")]
        [StringLength(100, ErrorMessage = "Mô tả không thể dài quá 100 ký tự.")]
        public string MoTa { get; set; } = string.Empty;
    }
}