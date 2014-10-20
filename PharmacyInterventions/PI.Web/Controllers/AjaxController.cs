using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PI.Business;

namespace PI.Web.Controllers
{
    public class AjaxController : Controller
    {

        public JsonResult ValidNhi(string nhi)
        {
            bool valid = false;

            var valiationService = new ValidationService();
            valid = valiationService.ValidateNhi(nhi);

            return Json(new
            {
                valid
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
