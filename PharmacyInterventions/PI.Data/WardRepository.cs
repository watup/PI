using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Models;

namespace PI.Data
{
    public class WardRepository : BaseRepository
    {
        public IEnumerable<Ward> GetAllWards(bool includeDeleted = false)
        {
            return Entities.Wards.Where(w => includeDeleted || w.IsActive).OrderBy(w => w.DisplayOrder);
        }

        public Ward GetWardById(int id)
        {
            return Entities.Wards.FirstOrDefault(w => w.Id == id);
        }

        public void CreateWard(Ward ward)
        {
            Entities.Wards.Add(ward);
            Save();
        }
    }
}
