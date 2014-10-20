using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Data;
using PI.Models;

namespace PI.Business
{
    public class InterventionService
    {
        private readonly InterventionRepository _interventionRepository;

        public InterventionService()
        {
            _interventionRepository = new InterventionRepository();
        }

        public Intervention GetInterventionById(int id)
        {
            return _interventionRepository.GetInterventionById(id);
        }

        public void SaveIntervention(Intervention updatedIntervention)
        {
            if (updatedIntervention.Id != 0)
            {
                //var intervention = GetInterventionById(updatedIntervention.Id);

                _interventionRepository.Save();   
            }
            else
            {
                _interventionRepository.AddIntervention(updatedIntervention);
            }
        }


        
        public IEnumerable<InterventionType> GetAllInterventionTypes()
        {
            return _interventionRepository.GetAllInterventionTypes();
        }

        public System.Collections.IEnumerable GetAllInterventionTypeCategories()
        {
            return _interventionRepository.GetAllInterventionTypeCategories();
        }

        public IEnumerable<InterventionGrade> GetAllInterventionGrades()
        {
            return _interventionRepository.GetAllInterventionGrades();
        }

        public IEnumerable<Intervention> GetAllInterventions()
        {
            return _interventionRepository.GetAllInterventions();
        }

    }
}
