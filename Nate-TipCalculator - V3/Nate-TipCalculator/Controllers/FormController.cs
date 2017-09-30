using Nate_TipCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nate_TipCalculator.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult CalculateTip()
        {
            Tip tipToAdd = new Tip();
            return View(tipToAdd);

        }

        [HttpPost]
        public ActionResult CalculateTip(Tip fromWeb)
        {
            if (ModelState.IsValid)
            {
                TipRepo.SetTip(fromWeb);
                fromWeb.TipTotalForMeal = fromWeb.MealCost * (fromWeb.TipPercentage / 100);
                string tipTotal = $"{fromWeb.TipTotalForMeal:c}";

                return View("../Form/GetTipCalculation", fromWeb);

            }
            else return View("CalculateTip", fromWeb);
        }

        [HttpGet]
        public ActionResult GetTipCalculation()
        {
            Tip tip = TipRepo.GetTip();
            return View(tip);
        }
    }
}