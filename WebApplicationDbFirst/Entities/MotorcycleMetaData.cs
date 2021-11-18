using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationDbFirst.Entities
{
    public class MotorcycleMetaData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MotorcycleMetaData()
        {
            this.Dealers = new HashSet<DealerMetaData>();
        }

        public int MotorcycleId { get; set; }
        [Required]
        [StringLength(20)]
        public string Model { get; set; }
        [Required]
        [Range(1,6)]
        public double Price { get; set; }
        public Nullable<int> BrandId { get; set; }
        public byte[] Image { get; set; }

        public virtual BrandMetaData Brand { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealerMetaData> Dealers { get; set; }
    }

    [MetadataType(typeof(MotorcycleMetaData))]
    public partial class Motorcycle
    {
    }
}