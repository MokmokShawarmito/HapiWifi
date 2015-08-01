using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HapiWifi.Core.DAL;
using HapiWifi.Core.Models;
using System.IO;
using System.Text.RegularExpressions;
using HapiWifi.Web.Models;

namespace HapiWifi.Web.Controllers
{
    [Authorize]
    public class CompaniesController : Controller
    {
        private HapiWifiDB db = new HapiWifiDB();
        private const string SERVERPATHBANNER = "~/images/uploads/banner/";
        private const string SERVERPATHLOGO = "~/images/uploads/logo/";


        // GET: Companies
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyViewModel companyVM)
        {
            if (ModelState.IsValid && this.ValidateFile(companyVM.Logo) && this.ValidateFile(companyVM.Banner))
            {
                Company company = new Company();
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                string filename = "";

                filename = string.Format("{0}-{1}{2}", companyVM.Name, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
                filename = rgx.Replace(filename, "");
                filename = filename.Replace(" ", "");
                filename = filename.ToLower();

                //save to image path
                company.BannerImagePath = this.SaveImage(companyVM.Banner, filename + companyVM.Banner.FileName.Substring(companyVM.Banner.FileName.LastIndexOf('.')));
                company.LogoImagePath = this.SaveImage(companyVM.Logo, filename + companyVM.Logo.FileName.Substring(companyVM.Logo.FileName.LastIndexOf('.')), true);

                //map data
                company.Description = companyVM.Description;
                company.Name = companyVM.Name;
                company.TagLine = companyVM.TagLine;
                company.Type = companyVM.Type;
                company.Website = companyVM.Website;
                //save to db
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyVM);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,TagLine,Description,Type,PicBanner,PicLogo,Website")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Expects validated image.
        /// </summary>
        private string SaveImage(HttpPostedFileBase file, string filename, bool isLogo = false)
        {
            string filePath = string.Empty;
            string serverPath = SERVERPATHLOGO;

            if (isLogo == false)
                serverPath = SERVERPATHBANNER;


            var test = Server.MapPath(serverPath);
            if (!Directory.Exists(Server.MapPath(serverPath)))
            {
                Directory.CreateDirectory(Server.MapPath(serverPath));
            }

            // Get the complete file path then save.
            string fileSavePath = Path.Combine(Server.MapPath(serverPath), filename);
            file.SaveAs(fileSavePath);
            filePath = String.Format("{0}{1}", serverPath, filename);

            return filePath;
        }

        //validates image.
        private bool ValidateFile(HttpPostedFileBase file)
        {
            int size = file.ContentLength;

            if (file == null)
                return false;

            if (size > 20000000)
                return false;

            if (!(file.FileName.ToLower().Contains(".jpg") || file.FileName.ToLower().Contains(".png") || file.FileName.ToLower().Contains(".jpeg")))
                return false;

            return true;
        }
    }
}
