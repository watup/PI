using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI.Web.Models
{
    public class KpiJsonModel
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string WardName { get; set; }
        public string PharmacistName { get; set; }
        public int MedicationChartsReviewed { get; set; }
        public int MedicinesReconciliationsMedical { get; set; }
        public int MedicinesReconciliationsSurgical { get; set; }
        public int MedicinesReconciliationsOther { get; set; }
        public int YellowCardsCompleted { get; set; }
        public int YellowCardsCompletedAndCounselled { get; set; }
        public int WarfarinCounselling { get; set; }
        public int SelfMedication { get; set; }
        public int DischargeOrderReview { get; set; }
        public int CommunityLiaison { get; set; }
        public int MedicineEducationTalks { get; set; }
    }
}