using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Models;


namespace PI.Data
{
    public class InterventionRepository : BaseRepository
    {
        public Intervention GetInterventionById(int id)
        {
            return Entities.Interventions.FirstOrDefault(i => i.Id == id);
        }


        public IEnumerable<InterventionGrade> GetAllInterventionGrades()
        {
            return Entities.InterventionGrades.OrderBy(ig=>ig.Value);
        }

        public void AddIntervention(Intervention newIntervention)
        {
            Entities.Interventions.Add(newIntervention);
            Entities.SaveChanges();
        }



        public IEnumerable<InterventionType> GetAllInterventionTypes()
        {
            return Entities.InterventionTypes.Where(i => i.IsActive).OrderBy(i=>i.DisplayOrder);
        }

        public System.Collections.IEnumerable GetAllInterventionTypeCategories()
        {
            return Entities.InterventionTypeCategories.Where(i => i.IsActive).OrderBy(i => i.DisplayOrder);
        }

        public IEnumerable<Intervention> GetAllInterventions()
        {
            return Entities.Interventions;
        }


    }
}
