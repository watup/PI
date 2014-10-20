using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Models;

namespace PI.Data
{
    public class LookupRepository : BaseRepository
    {

        public IEnumerable<Pharmacist> GetAllPharmacists()
        {
            return Entities.Pharmacists.Where(p => p.IsActive).OrderBy(p => p.DisplayOrder);
        }

        public IEnumerable<Medication> GetAllMedications()
        {
            return Entities.Medications.Where(m => m.IsActive);
        }

        public IEnumerable<Outcome> GetAllOutcomes()
        {
            return Entities.Outcomes;
        }

        public IEnumerable<Stage> GetAllStages()
        {
            return Entities.Stages;
        }

        public IEnumerable<StaffType> GetAllStaffTypes()
        {
            return Entities.StaffTypes;
        }

        public IEnumerable<TimeFrame> GetAllTimeFrames()
        {
            return Entities.TimeFrames;
        }
    }
}
