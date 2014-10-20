using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Models.Validation;

namespace PI.Models
{
    [MetadataType(typeof(InterventionMetadata))]
    public partial class Intervention
    {
        
    }
    public class InterventionMetadata
    {
        public int Id { get; set; }
        [Required]
        [StringLength(7)]
        [DisplayName("NHI Number")]
        public string Nhi { get; set; }
        [DisplayName("Ward")]
        public int WardId { get; set; }
        [DisplayName("Pharmacist")]
        public int PharmacistId { get; set; }
        public System.DateTime Date { get; set; }
        [StringLength(2000)]
        public string Details { get; set; }
        [IntegerRangeValidation(1,5,  ErrorMessage = "Grade is not valid")]
        [DisplayName("Grade")]
        public int InterventionGradeValue { get; set; }
        [DisplayName("Dose Received")]
        public bool DoseReceived { get; set; }
        [DisplayName("Medication 1")]
        public int MedicationId1 { get; set; }
        [DisplayName("Intervention Type")]
        public int InterventionTypeId { get; set; }
        [DisplayName("Medication 2")]
        public Nullable<int> MedicationId2 { get; set; }
        [DisplayName("Risk Monitor Pro")]
        public bool RiskMonitorPro { get; set; }
        [DisplayName("Staff Involved")]
        public int StaffInvolvedId { get; set; }
        [DisplayName("Time Taken")]
        public int TimeFrameId { get; set; }
        [DisplayName("Outcome")]
        public int OutcomeId { get; set; }
        [DisplayName("Stage")]
        public int StageId { get; set; }

    }
}
