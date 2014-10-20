using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PI.Models;

namespace PI.Web.Models
{
    public class PharmacistIndexViewModel
    {
        public PharmacistIndexViewModel()
        {
            IsValid = true;
        }

        public bool IsValid { get; set; }
        public Pharmacist NewPharmacist { get; set; }
        public IEnumerable<Pharmacist> Pharmacists { get; set; } 
    }
}