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
    
    public partial class BangDiem
    {
        public string MaLop { get; set; }
        public string MaMH { get; set; }
        public string MaHS { get; set; }
        public Nullable<int> DiemLan1 { get; set; }
        public Nullable<int> DiemLan2 { get; set; }
        public Nullable<int> DiemLan3 { get; set; }
        public Nullable<int> DiemGK { get; set; }
        public Nullable<int> DiemCK { get; set; }
    
        public virtual HocSinh HocSinh { get; set; }
        public virtual LopHoc LopHoc { get; set; }
        public virtual MonHoc MonHoc { get; set; }
    }
}
