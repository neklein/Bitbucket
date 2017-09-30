using AppointmentSetupApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppointmentSetupApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View( new AppointmentRequest());
        }

        [HttpPost]
        public ActionResult Index(AppointmentRequest model)
        {
            if (string.IsNullOrEmpty(model.ClientName))
            {
                ModelState.AddModelError("ClientName", "Please enter your name");
            }

            if (ModelState.IsValidField("Date"))
            {
                if(model.Date < DateTime.Today.AddDays(1))
                {
                    ModelState.AddModelError("Date",
                        "Appointments must be made for a future date.");
                }
                else if(model.Date.DayOfWeek == DayOfWeek.Saturday 
                    || model.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    ModelState.AddModelError("Date", 
                        "We do not accept weekend appointments");
                }
            }
            else
            {
                ModelState.AddModelError("Date",
                    "Please enter a valid date for the appointment");
            }

            if (!model.TermsAccepted)
            {
                ModelState.AddModelError("TermsAccepted",
                    "You must accept the terms to book an appointment");
            }

            if(ModelState.IsValidField("ClientName") && ModelState.IsValidField("Date"))
            {
                if(model.ClientName.ToLower() == "garfield" && model.Date.DayOfWeek == DayOfWeek.Monday)
                {
                    ModelState.AddModelError("", "Garfield may not book on Mondays.");
                }
            }

            if (ModelState.IsValid)
            {
                return View("Confirmation", model);
            }
            else
            {
                return View("Index", model);
            }
        }
    }
}