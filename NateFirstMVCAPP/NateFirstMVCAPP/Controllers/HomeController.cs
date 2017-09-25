using NateFirstMVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NateFirstMVCAPP.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CurrentDateTime = DateTime.Now;
            return View();
        }

        [HttpGet]
        public ActionResult Weather()
        {
            CurrentWeather weather = new CurrentWeather();
            weather.Date = DateTime.Now;
            weather.High = 75;
            weather.Low = 60;
            weather.Description = "Sunny";

            return View(weather);
        }
    }
}