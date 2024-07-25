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

    public partial class HocSinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocSinh()
        {
            this.BangDiem = new HashSet<BangDiem>();
        }

        [DisplayName("Mã số học sinh")]
        [StringLength(10)]
        public string MaHS { get; set; }

        [DisplayName("Tên học sinh")]
        [Required(ErrorMessage = "Họ tên là bắt buộc.")]
        [StringLength(20)]
        public string HoTen { get; set; }

        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
        public bool GioiTinh { get; set; }

        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh là bắt buộc.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
        [StringLength(50)]
        public string DiaChi { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        [StringLength(30)]
        public string Email { get; set; }

        [DisplayName("Số điện thoại")]
        [StringLength(10)]
        public string SDT { get; set; }

        public string MaTT { get; set; }
        public string MaLop { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [StringLength(20)]
        public string Pass { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiem { get; set; }
        public virtual LopHoc LopHoc { get; set; }
        public virtual TrangThaiHS TrangThaiHS { get; set; }
    }
}
