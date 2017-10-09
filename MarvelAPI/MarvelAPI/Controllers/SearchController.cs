using MarvelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelAPI.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult SearchByName(MarvelResultVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("../home/index", model);
            }

            else
            {
                model.SearchResults = MarvelWebCaller.DoGetChars(model.SearchName);
                return View(model);
            }
        }
    }
}