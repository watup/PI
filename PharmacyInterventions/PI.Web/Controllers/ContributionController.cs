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
    public class ContributionController : Controller
    {
        private readonly ContributionService _contributionService;
        private readonly WardService _wardService;
        private readonly LookupService _lookupService;

        public ContributionController()
        {
            _contributionService = new ContributionService();
            _wardService = new WardService();
            _lookupService = new LookupService();
        }

        public ActionResult Index()
        {
            var model = new ContributionIndexViewModel
            {
                Contributions = _contributionService.GetAllContributions()
            };
            return View(model);
        }

        public ActionResult ContributionRecords([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var service = new ContributionService();

            var allContributions = service.GetAllContributions();

            // apply filter
            IEnumerable<Contribution> filteredContributions;
            string searchValue = requestModel.Search.Value;
            if (!string.IsNullOrEmpty(searchValue))
            {
                filteredContributions = allContributions
                         .Where(c => c.Nhi.Contains(searchValue, StringComparison.CurrentCultureIgnoreCase) ||
                            c.Ward.Name.Contains(searchValue, StringComparison.CurrentCultureIgnoreCase) ||
                            c.Id.ToString().Contains(searchValue, StringComparison.CurrentCultureIgnoreCase) ||
                            c.Date.ToString("dd/MM/yyyy HH:mm").Contains(searchValue, StringComparison.CurrentCultureIgnoreCase) ||
                            c.Pharmacist.Name.Contains(searchValue, StringComparison.CurrentCultureIgnoreCase));
            }
            else
            {
                filteredContributions = allContributions;
            }

            //// sorting
            var sortedColumns = requestModel.Columns.GetSortedColumns();
            var isSorted = false;
            foreach (var column in sortedColumns)
            {
                Func<Contribution, string> orderingFunction = (c => column.Name == "Id" ? c.Id.ToString() :
                                                                    column.Name == "Nhi" ? c.Nhi :
                                                                    column.Name == "Ward" ? c.Ward.Name :
                                                                    column.Name == "Pharmacist" ? c.Pharmacist.Name :
                                                                    c.Date.ToString("yyyyMMddHHmm")); // fix me yyyyMMdd
                filteredContributions = column.SortDirection == Column.OrderDirection.Ascendant ? filteredContributions.OrderBy(orderingFunction) : filteredContributions.OrderByDescending(orderingFunction);
            }

            // paging
            var displayedContributions = filteredContributions
                                .Skip(requestModel.Start)
                                .Take(requestModel.Length);

            // convert to object datatable can understand
            //var result = from c in displayedContributions
            //             select new[] { Convert.ToString(c.Id), c.Nhi, c.Ward.Name, c.Pharmacist.Name, c.Date.ToString("dd/MM/yyyy HH:mm") };

            var result = from c in displayedContributions
                         select c.MapToJsonModel();

            return Json(new DataTablesResponse(requestModel.Draw, result, filteredContributions.Count(), allContributions.Count()), JsonRequestBehavior.AllowGet);
        }

        public void PopulateAdditionalContributionViewModelFields(ContributionViewModel model)
        {
            model.Pharmacists = new SelectList(_lookupService.GetAllPharmacists(), "Id", "Name");
            model.Wards = new SelectList(_wardService.GetAllWards(), "Id", "Name");
            model.Medications = new SelectList(_lookupService.GetAllMedications(), "Id", "Name");
            model.ContributionTypes = _contributionService.GetAllContributionTypes();
            model.Outcomes = new SelectList(_lookupService.GetAllOutcomes(), "Id", "Value");
            model.Stages = new SelectList(_lookupService.GetAllStages(), "Id", "Value");
            model.StaffTypes = new SelectList(_lookupService.GetAllStaffTypes(), "Id", "Value");
            model.TimeFrames = new SelectList(_lookupService.GetAllTimeFrames(), "Id", "Value");
        }

        [OutputCache(Duration = 0)]
        public ActionResult Edit(int? id, int? updatedContributionId, bool? created, int? createAnotherBasedOnId)
        {
            var service = new ContributionService();


            var model = new ContributionViewModel();
            if (updatedContributionId.HasValue)
            {
                var updatedContribution = service.GetContributionById(updatedContributionId.Value);
                model.Response = new ContributionResponseViewModel
                {
                    UpdatedContribution = updatedContribution,
                    WasNew = created.HasValue && created.Value,
                    CreatingAnother = createAnotherBasedOnId.HasValue
                };
            }

            PopulateAdditionalContributionViewModelFields(model);
            if (createAnotherBasedOnId.HasValue)
            {
                // we're creating a new one based on the past one
                var baseOnContribution = service.GetContributionById(createAnotherBasedOnId.Value);
                ModelState.Clear();
                model.Contribution = new Contribution
                {
                    Nhi = baseOnContribution.Nhi,
                    Date = baseOnContribution.Date,
                    PharmacistId = baseOnContribution.PharmacistId,
                    WardId = baseOnContribution.WardId
                };
            }
            else if (id.HasValue && !created.HasValue)
            {
                // we're editing an existing
                var contribution = service.GetContributionById(id.Value);
                model.Contribution = contribution;
            }
            else
            {
                // we're creating
                ModelState.Clear();
                model.Contribution = new Contribution
                {
                    Date = DateTime.Now
                };
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ContributionViewModel model, FormCollection formCollection)
        {
            var service = new ContributionService();

            if (ModelState.IsValid)
            {
                Contribution updatedContribution;
                bool created = false;
                if (model.Contribution.Id != 0)
                {
                    var currentContribution = service.GetContributionById(model.Contribution.Id);
                    UpdateModel(currentContribution, "Contribution", formCollection);
                    service.SaveContribution(currentContribution);
                    updatedContribution = currentContribution;
                }
                else
                {
                    service.SaveContribution(model.Contribution);
                    updatedContribution = model.Contribution;
                    created = true;
                }
                int? createAnotherBasedOnId = null;
                if (formCollection["SubmissionType"] != null && formCollection["SubmissionType"] == ((int)SubmissionType.SaveAndAnotherForPatient).ToString())
                {
                    createAnotherBasedOnId = updatedContribution.Id;
                }
                return RedirectToAction("Edit", new { updatedContributionId = updatedContribution.Id, created, createAnotherBasedOnId });
            }

            // something wrong
            PopulateAdditionalContributionViewModelFields(model);
            model.IsValid = false;

            return View("Edit", model);
        }
    }
}
