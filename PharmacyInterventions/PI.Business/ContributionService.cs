using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Data;
using PI.Models;

namespace PI.Business
{
    public class ContributionService
    {
        private readonly ContributionRepository _contributionRepository;

        public ContributionService()
        {
            _contributionRepository = new ContributionRepository();
        }

        public IEnumerable<Contribution> GetAllContributions()
        {
            var contributions = _contributionRepository.GetAllContributions();

            return contributions;
        }

        public Contribution GetContributionById(int id)
        {
            var contribution = _contributionRepository.GetContributionById(id);

            return contribution;
        }

        public IEnumerable<ContributionType> GetAllContributionTypes()
        {
            var contributionTypes = _contributionRepository.GetAllContributionTypes();

            return contributionTypes;
        }

        public void SaveContribution(Contribution updatedContribution)
        {
            if (updatedContribution.Id != 0)
            {
                _contributionRepository.Save();
            }
            else
            {
                _contributionRepository.AddContribution(updatedContribution);
            }
        }

    }
}
