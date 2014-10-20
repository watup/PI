using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PI.Models;

namespace PI.Web.Models
{
    public class KpiViewModel
    {
        public KpiViewModel()
        {
            IsValid = true;
        }

        // any response that goes back to the user around created/updated kpi
        public KpiResponseViewModel Response { get; set; }

        // the kpi being created/edited
        public Kpi Kpi { get; set; }
        
        // for populating the dropdowns
        public SelectList Wards { get; set; }
        public SelectList Pharmacists { get; set; }
        
        // we got any errors
        public bool IsValid { get; set; }
    }

    // object to hold details around the kpi just added/updated
    public class KpiResponseViewModel
    {
        public Kpi UpdatedKpi { get; set; }

        public bool WasNew { get; set; }

        public bool CreatingAnother { get; set; }
    }
}