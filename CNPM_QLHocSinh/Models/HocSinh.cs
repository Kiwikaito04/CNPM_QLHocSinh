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
    
    public partial class HocSinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocSinh()
        {
            this.BangDiems = new HashSet<BangDiem>();
        }
    
        public string MaHS { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string MaTT { get; set; }
        public string MaLop { get; set; }
        public string Pass { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangDiem> BangDiems { get; set; }
        public virtual LopHoc LopHoc { get; set; }
        public virtual TrangThaiH TrangThaiH { get; set; }
    }
}
