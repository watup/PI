using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI.Data;
using PI.Models;

namespace PI.Business
{
    public class KpiService
    {
        private readonly KpiRepository _kpiRepository;

        public KpiService()
        {
            _kpiRepository = new KpiRepository();
        }

        public IEnumerable<Kpi> GetAllKpis()
        {
            var kpis = _kpiRepository.GetAllKpis();

            return kpis;
        }

        public Kpi GetKpiById(int id)
        {
            var kpi = _kpiRepository.GetKpiById(id);

            return kpi;
        }


        public void SaveKpi(Kpi updatedKpi)
        {
            if (updatedKpi.Id != 0)
            {
                _kpiRepository.Save();
            }
            else
            {
                _kpiRepository.AddKpi(updatedKpi);
            }
        }

    }
}
