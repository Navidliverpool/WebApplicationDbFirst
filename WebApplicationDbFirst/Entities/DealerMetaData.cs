using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationDbFirst.Entities
{
    public class DealerMetaData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DealerMetaData()
        {
            this.Brands = new HashSet<BrandMetaData>();
            this.Motorcycles = new HashSet<MotorcycleMetaData>();
        }

        public int DealerId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Address { get; set; }
        [Required]
        [Range(1, 11)]
        public int PhoneNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BrandMetaData> Brands { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MotorcycleMetaData> Motorcycles { get; set; }
    }

    [MetadataType(typeof(DealerMetaData))]
    public partial class Dealer
    {
    }
}