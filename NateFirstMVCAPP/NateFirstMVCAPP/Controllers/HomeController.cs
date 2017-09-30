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

        [HttpGet]
        public ActionResult Temperature()
        {
            WeatherLastWeek weather = new WeatherLastWeek();
            weather.Date = DateTime.Today.AddDays(-10);
            weather.Description = "Cool for this time of year!";

            return View(weather);
        }

        [HttpGet]
        public ActionResult QueryString1()
        {
            ProductSearch productSearch = new ProductSearch();
            productSearch.Category = Request.QueryString["category"];
            productSearch.Subcategory = Request.QueryString["subcategory"];

            return View("SearchResult", productSearch);
        }

        [HttpGet]
        public ActionResult QueryString2(string category, string subcategory)
        {
            ProductSearch productSearch = new ProductSearch();
            productSearch.Category = category;
            productSearch.Subcategory = subcategory;

            return View("SearchResult", productSearch);
        }

        [HttpGet]
        public ActionResult QueryString3(ProductSearch productSearch)
        {
            return View("SearchResult", productSearch);
        }

        [HttpGet]
        public ActionResult Path1()
        {
            var model = new ProductSearch();
            model.Category = RouteData.Values["category"].ToString();
            model.Subcategory = RouteData.Values["subcategory"].ToString();

            return View("QueryString1", model);
        }

        [HttpGet]
        public ActionResult Path2(string category, string subcategory)
        {
            ProductSearch productSearch = new ProductSearch();
            productSearch.Category = category;
            productSearch.Subcategory = subcategory;

            return View("Index", "Home");

        }

        [HttpGet]
        public ActionResult Path3(ProductSearch productSearch)
        {
            return View("SearchResult", productSearch);

        }

        [HttpPost]
        public ActionResult Form2(string category, string subcategory)
        {
            var model = new ProductSearch();

            model.Category = category;
            model.Subcategory = subcategory;

            return View("QueryString1", "Home");
        }
    }
}