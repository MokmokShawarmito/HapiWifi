using HapiWifi.Core.Factories;
using HapiWifi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HapiWifi.Web.Controllers
{
    public class HomeController : Controller
    {
        //list down all company(specified on company query string value) partners
        public ActionResult Index()
        {
            string company = "";
            int temp = 0;
            var companycontoller = ControllerFactory.CreateCompanyController();
            
            if(Request.QueryString["company"] != null)
            {
                company = Request.QueryString["company"];
            }

            //apply filter based on company query string.
            IEnumerable<Company> companies = new List<Company>();

            if (Int32.TryParse(company, out temp))
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