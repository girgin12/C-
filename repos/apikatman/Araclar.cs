//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace apikatman
{
    using System;
    using System.Collections.Generic;
    
    public partial class Araclar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Araclar()
        {
            this.Firmalars = new HashSet<Firmalar>();
            this.Soforlers = new HashSet<Soforler>();
        }
    
        public int AracID { get; set; }
        public string Aracmodel { get; set; }
        public string Aracadi { get; set; }
        public string Aractipi { get; set; }
        public string Aracıkullanan { get; set; }
        public Nullable<int> SoforID { get; set; }
        public string Aracsayisi { get; set; }
    
        public virtual Soforler Soforler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Firmalar> Firmalars { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Soforler> Soforlers { get; set; }
    }
}
