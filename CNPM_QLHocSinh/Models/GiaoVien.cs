//------------------------------------------------------------------------------
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
    
    public partial class GiaoVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiaoVien()
        {
            this.LichGiangDay = new HashSet<LichGiangDay>();
        }
    
        public string MaGV { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string MaCV { get; set; }
        public string Pass { get; set; }
    
        public virtual ChucVu ChucVu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichGiangDay> LichGiangDay { get; set; }
    }
}
