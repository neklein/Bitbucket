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
            TipRepo.SetTip(fromWeb);

            return RedirectToAction("GetTipCalculation", "Form");
        }

        [HttpGet]
        public ActionResult GetTipCalculation()
        {
            Tip tip = TipRepo.GetTip();
            tip.TipTotalForMeal = tip.MealCost * (tip.TipPercentage / 100);
            string tipTotal = $"{tip.TipTotalForMeal:c}";
            return View(tip);
        }
    }
}