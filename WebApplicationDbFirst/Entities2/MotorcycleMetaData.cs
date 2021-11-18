using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApplicationDbFirst.Entities2
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
        [StringLength(50)]
        [Display(Name = "Model Name")]
        public string Model { get; set; }
        [Required]
        [Range(1, 5)]
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


