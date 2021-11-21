using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationDbFirst.Models
{
    public class HomeVM
    {
        public IEnumerable<Motorcycle> Motorcycles { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}