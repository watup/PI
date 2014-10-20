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
    public class WardController : Controller
    {
        //
        // GET: /Ward/

        public ActionResult Index()
        {
            var service = new WardService();

            var model = new WardIndexViewModel
                            {
                                Wards = service.GetAllWards(true)
                            };

            return View(model);
        }

        public ActionResult WardList()
        {
            var model = CreateWardIndexViewModel();

            return View("_WardList", model);
        }

        [HttpPost]
        public ActionResult Index(Ward newWard, FormCollection formCollection)
        {
            var service = new WardService();

            if (ModelState.IsValid)
            {
                // create the thing here
                newWard.IsActive = true;
                service.CreateWard(newWard);
            } else
            {
                var model = CreateWardIndexViewModel();
                model.IsValid = false;
                model.NewWard = newWard;
                return View("_WardList", model);
            }


            return RedirectToAction("WardList");
        }

        private WardIndexViewModel CreateWardIndexViewModel()
        {
            var service = new WardService();

            var model = new WardIndexViewModel
            {
                Wards = service.GetAllWards(true)
            };

            return model;
        }

        public JsonResult UpdateWard(int wardId, string wardName, bool isActive, int? newIndex)
        {
            bool success = false;
            string errorMessage = "";

            var service = new WardService();
            service.UpdateWard(wardId, wardName, isActive);

            if(newIndex.HasValue)
                service.ReorderWard(wardId, newIndex.Value);

            success = true;

            return Json(new 
            {
                errorMessage,
                success
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
