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

    public partial class TrangThaiHS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrangThaiHS()
        {
            this.HocSinh = new HashSet<HocSinh>();
        }

        [DisplayName("Mã trạng thái")]
        public string MaTT { get; set; }

        [DisplayName("Tên trạng thái")]
        public string TenTT { get; set; }

        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocSinh> HocSinh { get; set; }
    }
}
