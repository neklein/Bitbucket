using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TractorFanSite.Models;

namespace TractorFanSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.MyTractorName = TractorRepo.GetTractor().Name;
            return View();
        }

        //Action for Tractor details
        [HttpGet]
        public ActionResult TractorDetails()
        {
            Tractor webTractor = TractorRepo.GetTractor();
            //webTractor.Name = "Big Chief";
            //webTractor.TractorClass = "Hot Rod Tractor";
            //webTractor.Driver = "Jeff";
            //webTractor.TractorImage = "Finish";

            return View(webTractor);
        }
    }
}