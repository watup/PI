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
    public class InterventionController : Controller
    {
        //
        // GET: /Intervention/

        public ActionResult Index()
        {
            var service = new InterventionService();

            var model = new InterventionIndexViewModel
                            {
                                Interventions = service.GetAllInterventions()
                            };
            return View(model);
        }

        public ActionResult InterventionRecords([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var service = new InterventionService();

            var allInterventions = service.GetAllInterventions();

            // apply filter
            IEnumerable<Intervention> filteredInterventions;
            string searchValue = requestModel.Search.Value;
            if (!string.IsNullOrEmpty(searchValue))
            {
                filteredInterventions = allInterventions
                         .Where(i => i.Nhi.Contains(searchValue, StringComparison.CurrentCultureIgnoreCase) ||
                            i.Ward.Name.Contains(searchValue, StringComparison.CurrentCultureIgnoreCase) ||
                            i.Id.ToString().Contains(searchValue, StringComparison.CurrentCultureIgnoreCase) ||
                            i.Date.ToString("dd/MM/yyyy HH:mm").Contains(searchValue, StringComparison.CurrentCultureIgnoreCase) ||
                            i.Pharmacist.Name.Contains(searchValue, StringComparison.CurrentCultureIgnoreCase));
            }
            else
            {
                filteredInterventions = allInterventions;
            }

            var sortedColumns = requestModel.Columns.GetSortedColumns();
            foreach (var column in sortedColumns)
            {
                Func<Intervention, string> orderingFunction = (c => column.Name == "Id" ? c.Id.ToString() :
                                                                    column.Name == "Nhi" ? c.Nhi :
                                                                    column.Name == "Ward" ? c.Ward.Name :
                                                                    column.Name == "Pharmacist" ? c.Pharmacist.Name :
                                                                    column.Name == "Grade" ? c.InterventionGradeValue.ToString() :
                                                                    c.Date.ToString("yyyyMMddHHmm")); // fix me yyyyMMdd

                filteredInterventions = column.SortDirection == Column.OrderDirection.Ascendant ? filteredInterventions.OrderBy(orderingFunction) : filteredInterventions.OrderByDescending(orderingFunction);

            }

            var displayedInterventions = filteredInterventions
                                    .Skip(requestModel.Start)
                                    .Take(requestModel.Length);

            //var result = from c in displayedInterventions
            //             select new[] { Convert.ToString(c.Id), c.Date.ToString("dd/MM/yyyy HH:mm"), c.Nhi, c.Ward.Name, c.Pharmacist.Name, c.InterventionGradeValue.ToString(), c.Medication1.Name, c.Medication2 == null ? null : c.Medication2.Name, c.InterventionType.InterventionTypeCategory.Name, c.InterventionType.Name };

            var result = from c in displayedInterventions
                         select c.MapToJsonModel();


            return Json(new DataTablesResponse(requestModel.Draw, result, filteredInterventions.Count(), allInterventions.Count()), JsonRequestBehavior.AllowGet);
        }
        
        
        public ActionResult Create()
        {

            var model = new InterventionViewModel();
            PopulateAdditionalInterventionViewModelFields(model);

            model.Intervention = new Intervention
                                     {
                                         Date = DateTime.Now
                                     };
            return View("Edit", model);
        }

        public void PopulateAdditionalInterventionViewModelFields(InterventionViewModel model)
        {
            var service = new InterventionService();
            var lookupService = new LookupService();
            var wardService = new WardService();

            model.Pharmacists = new SelectList(lookupService.GetAllPharmacists(), "Id", "Name");
            model.Wards = new SelectList(wardService.GetAllWards(), "Id", "Name");
            model.Medications = new SelectList(lookupService.GetAllMedications(), "Id", "Name");
            model.InterventionTypes = service.GetAllInterventionTypes();
            model.InterventionTypeCategories = new SelectList(service.GetAllInterventionTypeCategories(), "Id", "Name");
            model.InterventionGrades = service.GetAllInterventionGrades();
            model.Outcomes = new SelectList(lookupService.GetAllOutcomes(), "Id", "Value");
            model.Stages = new SelectList(lookupService.GetAllStages(), "Id", "Value");
            model.StaffTypes = new SelectList(lookupService.GetAllStaffTypes(), "Id", "Value");
            model.TimeFrames = new SelectList(lookupService.GetAllTimeFrames(), "Id", "Value");
        }

        [OutputCache(Duration = 0)]
        public ActionResult Edit(int? id, int? updatedInterventionId, bool? created, int? createAnotherBasedOnId)
        {
            var service = new InterventionService();


            var model = new InterventionViewModel();
            if (updatedInterventionId.HasValue)
            {
                var updatedIntervention = service.GetInterventionById(updatedInterventionId.Value);
                model.Response = new InterventionResponseViewModel
                                     {
                                         UpdatedIntervention = updatedIntervention,
                                         WasNew = created.HasValue && created.Value,
                                         CreatingAnother = createAnotherBasedOnId.HasValue
                                     };
            }

            PopulateAdditionalInterventionViewModelFields(model);
            if (createAnotherBasedOnId.HasValue)
            {
                // we're creating a new one based on the past one
                var baseOnIntervention = service.GetInterventionById(createAnotherBasedOnId.Value);
                ModelState.Clear();
                model.Intervention = new Intervention
                {
                    Nhi = baseOnIntervention.Nhi,
                    Date = baseOnIntervention.Date,
                    PharmacistId = baseOnIntervention.PharmacistId,
                    WardId = baseOnIntervention.WardId
                };
            } 
            else if (id.HasValue && !created.HasValue)
            {
                // we're editing an existing
                var intervention = service.GetInterventionById(id.Value);
                model.Intervention = intervention;
                model.InterventionTypeCategoryId = intervention.InterventionType.InterventionTypeCategoryId;
            }
            else
            {
                // we're creating
                ModelState.Clear();
                model.Intervention = new Intervention
                {
                    Date = DateTime.Now
                };
            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(InterventionViewModel model, FormCollection formCollection)
        {
            var service = new InterventionService();

            if (ModelState.IsValid)
            {
                Intervention updatedIntervention;
                bool created = false;
                if (model.Intervention.Id != 0)
                {
                    var currentIntervention = service.GetInterventionById(model.Intervention.Id);
                    UpdateModel(currentIntervention, "Intervention", formCollection);
                    service.SaveIntervention(currentIntervention);
                    updatedIntervention = currentIntervention;
                }
                else
                {
                    model.Intervention.InterventionGradeValue = int.Parse(formCollection["Intervention.InterventionGradeValue"]);
                    service.SaveIntervention(model.Intervention);
                    updatedIntervention = model.Intervention;
                    created = true;
                }
                int? createAnotherBasedOnId = null;
                if (formCollection["SubmissionType"] != null && formCollection["SubmissionType"] == ((int)SubmissionType.SaveAndAnotherForPatient).ToString() )
                {
                    createAnotherBasedOnId = updatedIntervention.Id;
                }
                return RedirectToAction("Edit", new { updatedInterventionId = updatedIntervention.Id, created, createAnotherBasedOnId });
            }

            // something wrong
            PopulateAdditionalInterventionViewModelFields(model);
            model.IsValid = false;

            return View("Edit", model);
        }

        


    }


}
