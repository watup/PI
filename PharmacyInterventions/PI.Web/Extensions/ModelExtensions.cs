using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PI.Models;
using PI.Web.Models;

namespace PI.Web.Extensions
{
    public static class ModelExtensions
    {
        public static InterventionJsonModel MapToJsonModel(this Intervention intervention)
        {
            var model = new InterventionJsonModel
            {
                Id = intervention.Id.ToString(),
                Date = intervention.Date.ToString("dd/MM/yyyy HH:mm"),
                Nhi = intervention.Nhi,
                Grade = intervention.InterventionGradeValue.ToString(),
                PharmacistName = intervention.Pharmacist.Name,
                WardName = intervention.Ward.Name,
                CategoryName = intervention.InterventionType.InterventionTypeCategory.Name,
                InterventionType = intervention.InterventionType.Name,
                Medication1 = intervention.Medication1.Name,
                Medication2 = intervention.Medication2 == null ? null : intervention.Medication2.Name,
                Outcome = intervention.Outcome.Value,
                Stage = intervention.Stage.Value,
                StaffInvolved = intervention.StaffType.Value,
                TimeTaken = intervention.TimeFrame.Value,
                DoseRecieved = intervention.DoseReceived
            };
            return model;
        }

        public static ContributionJsonModel MapToJsonModel(this Contribution contribution)
        {
            var model = new ContributionJsonModel
            {
                Id = contribution.Id.ToString(),
                Date = contribution.Date.ToString("dd/MM/yyyy HH:mm"),
                Nhi = contribution.Nhi,
                PharmacistName = contribution.Pharmacist.Name,
                WardName = contribution.Ward.Name,
                ContributionType = contribution.ContributionType.Name,
                Medication1 = contribution.Medication1.Name,
                Medication2 = contribution.Medication2 == null ? null : contribution.Medication2.Name,
                Outcome = contribution.Outcome.Value,
                Stage = contribution.Stage.Value,
                StaffInvolved = contribution.StaffType.Value,
                TimeTaken = contribution.TimeFrame.Value
            };
            return model;
        }
        
        public static KpiJsonModel MapToJsonModel(this Kpi kpi)
        {
            var model = new KpiJsonModel
            {
                Id = kpi.Id.ToString(),
                Date = kpi.Date.ToString("dd/MM/yyyy HH:mm"),
                PharmacistName = kpi.Pharmacist.Name,
                WardName = kpi.Ward.Name,
                MedicationChartsReviewed = kpi.MedicationChartsReviewed,
                MedicinesReconciliationsMedical = kpi.MedicinesReconciliationsMedical,
                MedicinesReconciliationsSurgical = kpi.MedicinesReconciliationsSurgical,
                MedicinesReconciliationsOther = kpi.MedicinesReconciliationsOther,
                YellowCardsCompleted = kpi.YellowCardsCompleted,
                YellowCardsCompletedAndCounselled = kpi.YellowCardsCompletedAndCounselled,
                WarfarinCounselling = kpi.WarfarinCounselling,
                SelfMedication = kpi.SelfMedication,
                DischargeOrderReview = kpi.DischargeOrderReview,
                CommunityLiaison = kpi.CommunityLiaison,
                MedicineEducationTalks = kpi.MedicineEducationTalks
            };
            return model;
        }
    }
}