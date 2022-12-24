//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_VaccineVer6.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vaccine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vaccine()
        {
            this.InputIfs = new HashSet<InputIf>();
            this.OutputIfs = new HashSet<OutputIf>();
        }
    
        public string IdVac { get; set; }
        public string TenVac { get; set; }
        public int IdNcc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InputIf> InputIfs { get; set; }
        public virtual NhacungCap NhacungCap { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OutputIf> OutputIfs { get; set; }
    }
}