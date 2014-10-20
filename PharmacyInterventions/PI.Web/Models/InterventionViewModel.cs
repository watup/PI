using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PI.Models;

namespace PI.Web.Models
{
    public class InterventionViewModel
    {
        public InterventionViewModel()
        {
            IsValid = true;
            InterventionTypeCategoryId = 1;
        }

        // any response that goes back to the user around created/updated interventions
        public InterventionResponseViewModel Response { get; set; }

        // the intervention being created/edited
        public Intervention Intervention { get; set; }

        public int InterventionTypeCategoryId { get; set; }

        // for populating the dropdowns
        public SelectList Wards { get; set; }
        public SelectList Pharmacists { get; set; }
        public SelectList Medications { get; set; }
        public SelectList InterventionTypeCategories { get; set; }
        public IEnumerable<InterventionType> InterventionTypes { get; set; }
        public SelectList Outcomes { get; set; }
        public SelectList Stages { get; set; }
        public SelectList StaffTypes { get; set; }
        public SelectList TimeFrames { get; set; }

        // for creating grade selection
        public IEnumerable<InterventionGrade> InterventionGrades { get; set; }

        // we got any errors
        public bool IsValid { get; set; }
    }

    // object to hold details around the intervention just added/updated
    public class InterventionResponseViewModel
    {
        public Intervention UpdatedIntervention { get; set; }

        public bool WasNew { get; set; }

        public bool CreatingAnother { get; set; }
    }


}