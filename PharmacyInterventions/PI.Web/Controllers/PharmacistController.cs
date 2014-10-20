using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PI.Business;
using PI.Models;
using PI.Web.Models;

namespace PI.Web.Controllers
{
    public class PharmacistController : Controller
    {
        //
        // GET: /Ward/

        public ActionResult Index()
        {
            var service = new PharmacistService();

            var model = new PharmacistIndexViewModel
                            {
                                Pharmacists = service.GetAllPharmacists(true)
                            };

            return View(model);
        }

        public ActionResult PharmacistList()
        {
            var model = CreatePharmacistIndexViewModel();

            return View("_PharmacistList", model);
        }

        [HttpPost]
        public ActionResult Index(Pharmacist newPharmacist, FormCollection formCollection)
        {
            var service = new PharmacistService();

            if (ModelState.IsValid)
            {
                // create the thing here
                newPharmacist.IsActive = true;
                service.CreatePharmacist(newPharmacist);
            } else
            {
                var model = CreatePharmacistIndexViewModel();
                model.IsValid = false;
                model.NewPharmacist = newPharmacist;
                return View("_PharmacistList", model);
            }


            return RedirectToAction("PharmacistList");
        }

        private PharmacistIndexViewModel CreatePharmacistIndexViewModel()
        {
            var service = new PharmacistService();

            var model = new PharmacistIndexViewModel
            {
                Pharmacists = service.GetAllPharmacists(true)
            };

            return model;
        }

        public JsonResult UpdatePharmacist(int pharmacistId, string pharmacistName, bool isActive, int? newIndex)
        {
            bool success = false;
            string errorMessage = "";

            var service = new PharmacistService();
            service.UpdatePharmacist(pharmacistId, pharmacistName, isActive);

            if(newIndex.HasValue)
                service.ReorderPharmacist(pharmacistId, newIndex.Value);

            success = true;

            return Json(new 
            {
                errorMessage,
                success
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
