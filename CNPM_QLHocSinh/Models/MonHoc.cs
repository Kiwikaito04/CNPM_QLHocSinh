﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNPM_QLHocSinh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class MonHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonHoc()
        {
            this.LichGiangDay = new HashSet<LichGiangDay>();
            this.BangDiem = new HashSet<BangDiem>();
        }

        [DisplayName("Mã môn học")]
        [StringLength(2, ErrorMessage = "Mã môn học chỉ có thể chứa 2 ký tự.")]
        [Required(ErrorMessage = "Mã môn học là bắt buộc")]
        public string MaMH { get; set; }

        [DisplayName("Tên môn học")]
        [Required(ErrorMessage = "Tên môn học là bắt buộc")]
        [StringLength(20, ErrorMessage = "Tên môn học không thể dài quá 20 ký tự.")]
        public string TenMH { get; set; }

        [DisplayName("Mô tả")]
        [StringLength(100, ErrorMessage = "Mô tả không thể dài quá 100 ký tự.")]
        public string MoTa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichGiangDay> LichGiangDay { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiem { get; set; }
    }
}
