using HapiWifi.Core.Factories;
using HapiWifi.Core.Models;
using HapiWifi.Web.app_code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HapiWifi.Web.Controllers
{
    [RequestLogger]
    public class HomeController : Controller
    {
        //list down all company(specified on company query string value) partners
        public ActionResult Index()
        {
            string companyName = "";
            string companyID = "";
            int temp = 0;
            var companycontoller = ControllerFactory.CreateCompanyController();

            if (Request.QueryString["companyname"] != null)
            {
                companyName = Request.QueryString["companyname"];
                Session["companyname"] = companyName;
            }

            if (Request.QueryString["companyid"] != null)
            {
                companyID = Request.QueryString["companyid"];
            }

            //apply filter based on company query string.
            IEnumerable<Company> companies = new List<Company>();

            if (Int32.TryParse(companyID, out temp))
            {
                companies = companycontoller.GetAllCompanyPartners(temp);
            }
            else
            {
                companies = companycontoller.GetAll();
            }

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
            var companycontoller = ControllerFactory.CreateCompanyController();

            IEnumerable<Company> companies = companycontoller.GetAll();

            //ViewBag.Message = "Your contact page.";

            return View(companies);
        }

        public ActionResult Products()
        {
            var companycontoller = ControllerFactory.CreateCompanyController();

            IEnumerable<Company> companies = companycontoller.GetAll();

            //ViewBag.Message = "Your contact page.";

            return View(companies);
        }
    }
}