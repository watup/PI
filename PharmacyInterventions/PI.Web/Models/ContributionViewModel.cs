using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PI.Models;

namespace PI.Web.Models
{
    public class ContributionViewModel
    {
        public ContributionViewModel()
        {
            IsValid = true;
            ContributionTypeCategoryId = 1;
        }

        // any response that goes back to the user around created/updated contributions
        public ContributionResponseViewModel Response { get; set; }

        // the contribution being created/edited
        public Contribution Contribution { get; set; }

        public int ContributionTypeCategoryId { get; set; }

        // for populating the dropdowns
        public SelectList Wards { get; set; }
        public SelectList Pharmacists { get; set; }
        public SelectList Medications { get; set; }
        public SelectList ContributionTypeCategories { get; set; }
        public IEnumerable<ContributionType> ContributionTypes { get; set; }
        public SelectList Outcomes { get; set; }
        public SelectList Stages { get; set; }
        public SelectList StaffTypes { get; set; }
        public SelectList TimeFrames { get; set; }
        
        // we got any errors
        public bool IsValid { get; set; }
    }

    // object to hold details around the contribution just added/updated
    public class ContributionResponseViewModel
    {
        public Contribution UpdatedContribution { get; set; }

        public bool WasNew { get; set; }

        public bool CreatingAnother { get; set; }
    }
}