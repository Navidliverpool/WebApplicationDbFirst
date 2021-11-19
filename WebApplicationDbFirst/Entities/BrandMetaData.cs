﻿using System.ComponentModel.DataAnnotations;

namespace WebApplicationDbFirst.Entities
{
    public class BrandMetaData
    {
        public int BrandId { get; set; }
        //[Required]
        //[StringLength(20)]
        public string Name { get; set; }
    }

    [MetadataType(typeof(BrandMetaData))]
    public partial class Brand
    {
    }
}