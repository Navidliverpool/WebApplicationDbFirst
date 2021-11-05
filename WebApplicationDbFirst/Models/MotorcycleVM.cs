﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;

namespace WebApplicationDbFirst.Models
{
    public class MotorcycleVM
    {
        public Motorcycle Motorcycle { get; set; }
        public IEnumerable<SelectListItem> AllDealers { get; set; }
        private List<int> _selectedDealers;
        public List<int> SelectedDealers
        {
            get
            {
                if (_selectedDealers == null)
                {
                    _selectedDealers = Motorcycle.Dealers.Select(m => m.DealerId).ToList();
                }
                return _selectedDealers;
            }
            set { _selectedDealers = value; }
        }

    }
}
