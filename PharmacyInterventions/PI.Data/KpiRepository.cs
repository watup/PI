using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Models;

namespace PI.Data
{
    public class KpiRepository : BaseRepository
    {
        public IEnumerable<Kpi> GetAllKpis()
        {
            var kpis = Entities.Kpis;

            return kpis;
        }

        public Kpi GetKpiById(int id)
        {
            var kpi = Entities.Kpis.FirstOrDefault(c => c.Id == id);

            return kpi;
        }

        public void AddKpi(Kpi newKpi)
        {
            Entities.Kpis.Add(newKpi);
            Entities.SaveChanges();
        }
    }
}
