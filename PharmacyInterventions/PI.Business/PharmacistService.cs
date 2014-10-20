using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Data;
using PI.Models;

namespace PI.Business
{
    public class PharmacistService
    {
        private PharmacistRepository _pharmacistRepository;

        public PharmacistService()
        {
            _pharmacistRepository = new PharmacistRepository();
        }

        public IEnumerable<Pharmacist> GetAllPharmacists(bool includeDeleted = false)
        {
            return _pharmacistRepository.GetAllPharmacists(includeDeleted);
        }

        public void CreatePharmacist(Pharmacist pharmacist)
        {
            if (pharmacist.DisplayOrder == 0)
            {
                int highestDisplayOrder = GetAllPharmacists(true).Max(w => w.DisplayOrder);
                pharmacist.DisplayOrder = highestDisplayOrder + 1;
            }
            _pharmacistRepository.CreatePharmacist(pharmacist);
        }

        public void UpdatePharmacist(int pharmacistId, string pharmacistName, bool isActive)
        {
            var pharmacist = _pharmacistRepository.GetPharmacistById(pharmacistId);

            if(pharmacist==null)
                throw new Exception("Attempting to update pharmacist, but no pharmacist found with id of "+ pharmacistId);

            pharmacist.Name = pharmacistName;
            pharmacist.IsActive = isActive;

            _pharmacistRepository.Save();
        }

        public void ReorderPharmacist(int pharmacistId, int newIndex)
        {
            var pharmacists = _pharmacistRepository.GetAllPharmacists(true).ToList();

            if (pharmacists.All(w => w.Id != pharmacistId))
                throw new Exception("Attempting to reorder pharmacist, but no pharmacist found with id of " + pharmacistId);

            var updatedPharmacist = pharmacists.First(w => w.Id == pharmacistId);

            // man, I dunno
            // pull our guy out
            // order the list based on the index in the list
            // update our guy

            pharmacists = pharmacists.Where(w => w.Id != pharmacistId).ToList();

            pharmacists.ForEach(w => w.DisplayOrder = pharmacists.IndexOf(w) >= newIndex ? pharmacists.IndexOf(w) + 1 : pharmacists.IndexOf(w));

            updatedPharmacist.DisplayOrder = newIndex;

            _pharmacistRepository.Save();
        }
    }
}
