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
            if (string.IsNullOrWhiteSpace(fromWeb.MealType))
            {
                ModelState.AddModelError("MealType", "Please enter the meal type");
            }
            if(fromWeb.MealCost == null || fromWeb.MealCost <= 0)
            {
                ModelState.AddModelError("MealCost", "Please enter a valid meal cost");
            }
            if (fromWeb.TipPercentage == null || fromWeb.TipPercentage <= 0)
            {
                ModelState.AddModelError("TipPercentage", "Please enter a valid tip amount");
            }
            if (ModelState.IsValid
                && fromWeb.TipPercentage < 10)
            {
                ModelState.AddModelError("TipPercentage", "Please be kind to your waiter/waitress!");
            }
            if (ModelState.IsValid)
            {
                TipRepo.SetTip(fromWeb);
                fromWeb.TipTotalForMeal = fromWeb.MealCost * (fromWeb.TipPercentage / 100);
                string tipTotal = $"{fromWeb.TipTotalForMeal:c}";

                return View("GetTipCalculation", fromWeb);

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