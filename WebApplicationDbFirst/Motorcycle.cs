//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationDbFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Motorcycle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Motorcycle()
        {
            this.Dealers = new HashSet<Dealer>();
        }
        //[Required]
        public int MotorcycleId { get; set; }

        //[Required]
        //[StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        //[DisplayName("Insert Model")]
        public string Model { get; set; }

        //[Range(1, 30000)]
        //[DisplayName("Insert Price")]
        public double Price { get; set; }

        public Nullable<int> BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dealer> Dealers { get; set; }
    }
}
