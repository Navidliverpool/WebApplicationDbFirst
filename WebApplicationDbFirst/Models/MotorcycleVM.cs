using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationDbFirst.Models
{
    public class MotorcycleVM
    {
        public Motorcycle Motorcycle { get; set; }
        public ICollection<Dealer> Dealers { get; set; }
        public IEnumerable<Dealer> AllDealers { get; set; }
        public Dealer Dealer { get; set; }
    }
}
