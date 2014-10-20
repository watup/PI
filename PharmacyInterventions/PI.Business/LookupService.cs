using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Data;
using PI.Models;

namespace PI.Business
{
    public class LookupService
    {
        private readonly LookupRepository _lookupRepository;

        public LookupService()
        {
            _lookupRepository = new LookupRepository();
        }

        public IEnumerable<Pharmacist> GetAllPharmacists()
        {
            return _lookupRepository.GetAllPharmacists();
        }
        public IEnumerable<Medication> GetAllMedications()
        {
            return _lookupRepository.GetAllMedications();
        }

        public IEnumerable<Outcome> GetAllOutcomes()
        {
            return _lookupRepository.GetAllOutcomes();
        }

        public IEnumerable<Stage> GetAllStages()
        {
            return _lookupRepository.GetAllStages();
        }

        public IEnumerable<StaffType> GetAllStaffTypes()
        {
            return _lookupRepository.GetAllStaffTypes();
        }

        public IEnumerable<TimeFrame> GetAllTimeFrames()
        {
            return _lookupRepository.GetAllTimeFrames();
        }
    }
}
