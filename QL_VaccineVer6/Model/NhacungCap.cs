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


    public partial class NhacungCap : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhacungCap()
        {
            this.Vaccines = new HashSet<Vaccine>();
        }
        private String _TenNcc;
        public int IdNcc { get; set; }
        public string TenNcc { get => _TenNcc; set { _TenNcc = value; OnPropertyChanged(); } }
        public string _Adress;
        public string Adress { get => _Adress; set { _Adress = value; OnPropertyChanged(); } }
        public string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vaccine> Vaccines { get; set; }
    }
}
