using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Models;

namespace PI.Data
{
    public class BaseRepository
    {
        protected readonly PharmacyInterventionsEntities Entities;

        public BaseRepository()
        {
            Entities = new PharmacyInterventionsEntities();
            
        }

        public void Save()
        {
            Entities.SaveChanges();
        }
    }
}
