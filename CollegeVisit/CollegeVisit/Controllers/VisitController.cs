using CollegeVisit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CollegeVisit.Controllers
{
    public class VisitController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            VisitRequest model = new VisitRequest();

            model.Majors = new List<SelectListItem>
            {
                new SelectListItem{Text = "Computer Science", Value = "CS"},
                new SelectListItem{Text = "Business", Value = "BUS"},
                new SelectListItem{Text = "Language Arts", Value = "LA"},
                new SelectListItem{Text = "Chemistry", Value = "CHEM"},
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(VisitRequest model)
        {
            //validate the data
            //save to database
            //return a response

            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }
    }
}