using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Models;

namespace PI.Data
{
    public class PharmacistRepository : BaseRepository
    {
        public IEnumerable<Pharmacist> GetAllPharmacists(bool includeDeleted = false)
        {
            return Entities.Pharmacists.Where(p => includeDeleted || p.IsActive).OrderBy(p => p.DisplayOrder);
        }

        public Pharmacist GetPharmacistById(int id)
        {
            return Entities.Pharmacists.FirstOrDefault(p => p.Id == id);
        }

        public void CreatePharmacist(Pharmacist pharmacist)
        {
            Entities.Pharmacists.Add(pharmacist);
            Save();
        }
    }
}
