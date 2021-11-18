using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationDbFirst.Entities
{
    public class sysdiagramMetaData
    {
        public string name { get; set; }
        public int principal_id { get; set; }
        public int diagram_id { get; set; }
        public Nullable<int> version { get; set; }
        public byte[] definition { get; set; }
    }

    [MetadataType(typeof(sysdiagramMetaData))]
    public partial class sysdiagram
    {

    }
}