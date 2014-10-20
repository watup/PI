using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Models;

namespace PI.Data
{
    public class ContributionRepository : BaseRepository
    {
        public IEnumerable<Contribution> GetAllContributions()
        {
            var contributions = Entities.Contributions;

            return contributions;
        }

        public Contribution GetContributionById(int id)
        {
            var contribution = Entities.Contributions.FirstOrDefault(c => c.Id == id);

            return contribution;
        }

        public IEnumerable<ContributionType> GetAllContributionTypes()
        {
            var contributionTypes = Entities.ContributionTypes;

            return contributionTypes;
        }

        public void AddContribution(Contribution newContribution)
        {
            Entities.Contributions.Add(newContribution);
            Entities.SaveChanges();
        }
    }
}
