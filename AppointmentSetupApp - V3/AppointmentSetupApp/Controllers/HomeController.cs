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