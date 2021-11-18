using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationDbFirst.Entities
{
    public class BrandMetaData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BrandMetaData()
        {
            this.Motorcycles = new HashSet<MotorcycleMetaData>();
            this.Dealers = new HashSet<DealerMetaData>();
        }

        public int BrandId { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MotorcycleMetaData> Motorcycles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DealerMetaData> Dealers { get; set; }
    }

    [MetadataType(typeof(BrandMetaData))]
    public partial class Brand
    {
      
    }
}