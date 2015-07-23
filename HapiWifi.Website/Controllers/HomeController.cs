using HapiWifi.Core.Factories;
using HapiWifi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HapiWifi.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var companycontoller = ControllerFactory.CreateCompanyController();

            IEnumerable<Company> companies = companycontoller.GetAll();

            return View(companies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Partners()
        {
            var companycontoller = ControllerFactory.CreateCompanyController();

            IEnumerable<Company> companies = companycontoller.GetAll();

            //ViewBag.Message = "Your contact page.";

            return View(companies);
        }

        public ActionResult Locations()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}