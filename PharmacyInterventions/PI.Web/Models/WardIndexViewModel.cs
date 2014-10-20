using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PI.Models;

namespace PI.Web.Models
{
    public class WardIndexViewModel
    {
        public WardIndexViewModel ()
        {
            IsValid = true;
        }

        public bool IsValid { get; set; }
        public Ward NewWard { get; set; }
        public IEnumerable<Ward> Wards { get; set; } 
    }
}