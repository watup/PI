using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PI.Models;

namespace PI.Web.Models
{
    public class KpiIndexViewModel
    {
        public IEnumerable<Kpi> Kpis { get; set; }
    }
}