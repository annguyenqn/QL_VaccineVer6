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
    using QL_VaccineVer6.ViewModel;

    public partial class Vaccine : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vaccine()
        {
            this.BenhNhans = new HashSet<BenhNhan>();
            this.InputIfs = new HashSet<InputIf>();
            this.OutputIfs = new HashSet<OutputIf>();
        }

        private string _IdVac;
        public string IdVac { get => _IdVac; set { _IdVac = value; OnPropertyChanged(); } }
        private string _TenVac;
        public string TenVac { get => _TenVac; set { _TenVac = value; OnPropertyChanged(); } }
        private int _IdNcc;
        public int IdNcc { get => _IdNcc; set { _IdNcc = value; OnPropertyChanged(); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BenhNhan> BenhNhans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InputIf> InputIfs { get; set; }

        private NhacungCap _Ncc;
        public virtual NhacungCap NhacungCap
        {
            get => _Ncc; set { _Ncc = value; OnPropertyChanged(); }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OutputIf> OutputIfs { get; set; }
    }
}
