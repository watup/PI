using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI.Models
{
    [MetadataType(typeof(KpiMetadata))]
    public partial class Kpi
    {
    }

    public class KpiMetadata
    {
        [DisplayName("Ward")]
        public int WardId { get; set; }
        [DisplayName("Pharmacist")]
        public int PharmacistId { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Number")]
        [DisplayName("Medication Charts Reviewed")]
        public string MedicationChartsReviewed { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Number")]
        [DisplayName("Medicines Reconciliations Medical")]
        public string MedicinesReconciliationsMedical { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Number")]
        [DisplayName("Medicines Reconciliations Surgical")]
        public string MedicinesReconciliationsSurgical { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Number")]
        [DisplayName("Medicines Reconciliations Other")]
        public string MedicinesReconciliationsOther { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Number")]
        [DisplayName("Yellow Cards Completed")]
        public string YellowCardsCompleted { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Number")]
        [DisplayName("Yellow Cards Completed And Counselled")]
        public string YellowCardsCompletedAndCounselled { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Number")]
        [DisplayName("Warfarin Counselling")]
        public string WarfarinCounselling { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Number")]
        [DisplayName("Self Medication")]
        public string SelfMedication { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Number")]
        [DisplayName("Discharge Order Review")]
        public string DischargeOrderReview { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Number")]
        [DisplayName("Community Liaison")]
        public string CommunityLiaison { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Invalid Number")]
        [DisplayName("Medicine Education Talks")]
        public string MedicineEducationTalks { get; set; }
    }
}
