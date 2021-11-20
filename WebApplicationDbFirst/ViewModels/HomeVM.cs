using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationDbFirst.Entities;

namespace WebApplicationDbFirst.ViewModels
{
    public class HomeVM
    {
        public Motorcycle MotorcyclesHomeVM { get; set; }
        public Brand BrandsHomeVM { get; set; }
    }
}