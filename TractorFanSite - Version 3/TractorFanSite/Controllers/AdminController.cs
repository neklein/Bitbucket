using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TractorFanSite.Models;

namespace TractorFanSite.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult AddTractor(Tractor fromWeb)
        {
            //Tractor fromWeb = new Tractor();
            //fromWeb.Name = Request.QueryString["Name"];
            //fromWeb.Driver = Request.QueryString["Driver"];
            //fromWeb.TractorClass = Request.QueryString["TractorClass"];
            TractorRepo.SetTractor(fromWeb);
            return RedirectToAction("TractorDetails", "Home");
        }

        //GET: AddTractor using Path Variables
        public ActionResult PathAddTractor(Tractor fromWeb)
        {
            TractorRepo.SetTractor(fromWeb);
            return RedirectToAction("TractorDetails", "Home");
        }

        //GET: Add Tractor using Form
        [HttpGet]
        public ActionResult FormAddTractor()
        {
            Tractor tractorToAdd = new Tractor();
            return View(tractorToAdd);
        }

        //POST: Add tractor using form
        [HttpPost]
        public ActionResult FormAddTractor(Tractor fromWeb)
        {
            TractorRepo.SetTractor(fromWeb);
            return RedirectToAction("TractorDetails", "Home");
        }
    }
}