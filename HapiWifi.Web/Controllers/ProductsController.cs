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

namespace HapiWifi.Web.Controllers
{
    public class ProductsController : Controller
    {
        private HapiWifiDB db = new HapiWifiDB();
        private const string SERVERPATH = "~/images/uploads/products/";

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Company);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,Order,isShow,isFeatured,CompanyId")] Product product)
        {
            string imagepath = "/images/default.png"; //TODO: change to default image 
            //grab image here
            if (Request.Files["ImagePath"] != null)
            {
                var image = Request.Files["ImagePath"];
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                string filename = "";
                filename = string.Format("{0}-{1}{2}", product.Name, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
                filename = rgx.Replace(filename, "");
                filename = filename.Replace(" ", "");
                filename = filename.ToLower();
                imagepath = this.SaveImage(image, filename + image.FileName.Substring(image.FileName.LastIndexOf('.')));
            }

            product.ImagePath = imagepath;

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", product.CompanyId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", product.CompanyId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,Order,isShow,isFeatured,CompanyId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", product.CompanyId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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



        //TODO: Move this chunk to action attribute
        #region IMAGE SAVING
        /// <summary>
        /// Expects validated image.
        /// </summary>
        private string SaveImage(HttpPostedFileBase file, string filename)
        {
            string filePath = string.Empty;
            var test = Server.MapPath(SERVERPATH);

            if (!Directory.Exists(Server.MapPath(SERVERPATH)))
            {
                Directory.CreateDirectory(Server.MapPath(SERVERPATH));
            }

            // Get the complete file path then save.
            string fileSavePath = Path.Combine(Server.MapPath(SERVERPATH), filename);
            file.SaveAs(fileSavePath);
            filePath = String.Format("{0}{1}", SERVERPATH, filename);

            filePath = filePath.Replace("~", "");

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
        #endregion
    }
}
