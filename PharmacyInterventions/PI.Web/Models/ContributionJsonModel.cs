using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI.Web.Models
{
    public class ContributionJsonModel
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string Nhi { get; set; }
        public string WardName { get; set; }
        public string PharmacistName { get; set; }
        public string Medication1 { get; set; }
        public string Medication2 { get; set; }
        public string ContributionType { get; set; }
        public string Outcome { get; set; }
        public string Stage { get; set; }
        public string StaffInvolved { get; set; }
        public string TimeTaken { get; set; }
    }
}