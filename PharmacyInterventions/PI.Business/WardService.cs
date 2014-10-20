using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Data;
using PI.Models;

namespace PI.Business
{
    public class WardService
    {
        private WardRepository _wardRepository;

        public WardService()
        {
            _wardRepository = new WardRepository();
        }

        public IEnumerable<Ward> GetAllWards(bool includeDeleted = false)
        {
            return _wardRepository.GetAllWards(includeDeleted);
        }

        public void CreateWard(Ward ward)
        {
            if (ward.DisplayOrder == 0)
            {
                int highestDisplayOrder = GetAllWards(true).Max(w => w.DisplayOrder);
                ward.DisplayOrder = highestDisplayOrder + 1;
            }
            _wardRepository.CreateWard(ward);
        }

        public void UpdateWard(int wardId, string wardName, bool isActive)
        {
            var ward = _wardRepository.GetWardById(wardId);

            if(ward==null)
                throw new Exception("Attempting to update ward, but no ward found with id of "+ wardId);

            ward.Name = wardName;
            ward.IsActive = isActive;

            _wardRepository.Save();
        }

        public void ReorderWard(int wardId, int newIndex)
        {
            var wards = _wardRepository.GetAllWards(true).ToList();

            if (wards.All(w => w.Id != wardId))
                throw new Exception("Attempting to reorder ward, but no ward found with id of " + wardId);

            var updatedWard = wards.First(w => w.Id == wardId);

            // man, I dunno
            // pull our guy out
            // order the list based on the index in the list
            // update our guy

            wards = wards.Where(w => w.Id != wardId).ToList();

            wards.ForEach(w => w.DisplayOrder = wards.IndexOf(w) >= newIndex ? wards.IndexOf(w) + 1 : wards.IndexOf(w));

            updatedWard.DisplayOrder = newIndex;

            _wardRepository.Save();
        }
    }
}
