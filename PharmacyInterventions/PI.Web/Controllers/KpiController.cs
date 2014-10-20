using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTables.Mvc;
using PI.Business;
using PI.Models;
using PI.Web.Extensions;
using PI.Web.Lookups;
using PI.Web.Models;

namespace PI.Web.Controllers
{
    public class KpiController : Controller
    {
        private readonly KpiService _kpiService;
        private readonly WardService _wardService;
        private readonly LookupService _lookupService;

        public KpiController()
        {
            _kpiService = new KpiService();
            _wardService = new WardService();
            _lookupService = new LookupService();
        }

        public ActionResult Index()
        {
            var model = new KpiIndexViewModel
            {
                Kpis = _kpiService.GetAllKpis()
            };
            return View(model);
        }

        public ActionResult KpiRecords([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var service = new KpiService();

            var allKpis = service.GetAllKpis();

            // apply filter
            IEnumerable<Kpi> filteredKpis;
            string searchValue = requestModel.Search.Value;
            if (!string.IsNullOrEmpty(searchValue))
            {
                filteredKpis = allKpis
                         .Where(c => c.Ward.Name.Contains(searchValue, StringComparison.CurrentCultureIgnoreCase) ||
                            c.Id.ToString().Contains(searchValue, StringComparison.CurrentCultureIgnoreCase) ||
                            c.Date.ToString("dd/MM/yyyy HH:mm").Contains(searchValue, StringComparison.CurrentCultureIgnoreCase) ||
                            c.Pharmacist.Name.Contains(searchValue, StringComparison.CurrentCultureIgnoreCase));
            }
            else
            {
                filteredKpis = allKpis;
            }

            //// sorting
            var sortedColumns = requestModel.Columns.GetSortedColumns();
            var isSorted = false;
            foreach (var column in sortedColumns)
            {
                Func<Kpi, string> orderingFunction = (c => column.Name == "Id" ? c.Id.ToString() :
                                                                    column.Name == "Ward" ? c.Ward.Name :
                                                                    column.Name == "Pharmacist" ? c.Pharmacist.Name :
                                                                    c.Date.ToString("yyyyMMddHHmm")); // fix me yyyyMMdd
                filteredKpis = column.SortDirection == Column.OrderDirection.Ascendant ? filteredKpis.OrderBy(orderingFunction) : filteredKpis.OrderByDescending(orderingFunction);
            }

            // paging
            var displayedKpis = filteredKpis
                                .Skip(requestModel.Start)
                                .Take(requestModel.Length);

            // convert to object datatable can understand
            //var result = from c in displayedKpis
            //             select new[] { Convert.ToString(c.Id), c.Pharmacist.Name, c.Ward.Name, c.Date.ToString("dd/MM/yyyy HH:mm") };

            var result = from c in displayedKpis
                         select c.MapToJsonModel();

            return Json(new DataTablesResponse(requestModel.Draw, result, filteredKpis.Count(), allKpis.Count()), JsonRequestBehavior.AllowGet);
        }


        public void PopulateAdditionalKpiViewModelFields(KpiViewModel model)
        {
            model.Pharmacists = new SelectList(_lookupService.GetAllPharmacists(), "Id", "Name");
            model.Wards = new SelectList(_wardService.GetAllWards(), "Id", "Name");
        }

        [OutputCache(Duration = 0)]
        public ActionResult Edit(int? id, int? updatedKpiId, bool? created, int? createAnotherBasedOnId)
        {
            var service = new KpiService();


            var model = new KpiViewModel();
            if (updatedKpiId.HasValue)
            {
                var updatedKpi = service.GetKpiById(updatedKpiId.Value);
                model.Response = new KpiResponseViewModel
                {
                    UpdatedKpi = updatedKpi,
                    WasNew = created.HasValue && created.Value,
                    CreatingAnother = createAnotherBasedOnId.HasValue
                };
            }

            PopulateAdditionalKpiViewModelFields(model);
            if (createAnotherBasedOnId.HasValue)
            {
                // we're creating a new one based on the past one
                var baseOnKpi = service.GetKpiById(createAnotherBasedOnId.Value);
                ModelState.Clear();
                model.Kpi = new Kpi
                {
                    Date = baseOnKpi.Date,
                    PharmacistId = baseOnKpi.PharmacistId,
                    WardId = baseOnKpi.WardId
                };
            }
            else if (id.HasValue && !created.HasValue)
            {
                // we're editing an existing
                var kpi = service.GetKpiById(id.Value);
                model.Kpi = kpi;
            }
            else
            {
                // we're creating
                ModelState.Clear();
                model.Kpi = new Kpi
                {
                    Date = DateTime.Now
                };
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(KpiViewModel model, FormCollection formCollection)
        {
            var service = new KpiService();

            if (ModelState.IsValid)
            {
                Kpi updatedKpi;
                bool created = false;
                if (model.Kpi.Id != 0)
                {
                    var currentKpi = service.GetKpiById(model.Kpi.Id);
                    UpdateModel(currentKpi, "Kpi", formCollection);
                    service.SaveKpi(currentKpi);
                    updatedKpi = currentKpi;
                }
                else
                {
                    service.SaveKpi(model.Kpi);
                    updatedKpi = model.Kpi;
                    created = true;
                }
                int? createAnotherBasedOnId = null;
                if (formCollection["SubmissionType"] != null && formCollection["SubmissionType"] == ((int)SubmissionType.SaveAndAnotherForPharmacist).ToString())
                {
                    createAnotherBasedOnId = updatedKpi.Id;
                }
                return RedirectToAction("Edit", new { updatedKpiId = updatedKpi.Id, created, createAnotherBasedOnId });
            }

            // something wrong
            PopulateAdditionalKpiViewModelFields(model);
            model.IsValid = false;

            return View("Edit", model);
        }
    }
}
