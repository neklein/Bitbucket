using SchedulePrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchedulePrototype.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult TractorCheckBoxes()
        {
            var model = new TractorClassPickerViewModel();

            model.TClassCheckboxes = (from tClass in TractorClassRepository.GetAll()
                                      select new TractorClassCheckboxItem
                                      {
                                          TClass = tClass,
                                          IsSelected = false
                                      }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult TractorCheckBoxes(TractorClassPickerViewModel model)
        {
            var selectedIDs =
                model.TClassCheckboxes.Where(c => c.IsSelected).Select(c => c.TClass.TClassID);

            return View("PickResults", selectedIDs);
        }

        [HttpGet]
        public ActionResult PullSchedule()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PullSchedule( PullDetails model)
        {
            return View("ShowPull", model);
        }
    }
}