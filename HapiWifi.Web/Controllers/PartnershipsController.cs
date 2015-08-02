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

namespace HapiWifi.Web.Controllers
{
    public class PartnershipsController : Controller
    {
        private HapiWifiDB db = new HapiWifiDB();

        // GET: Partnerships
        public ActionResult Index()
        {
            return View(db.Partnerships.ToList());
        }

        // GET: Partnerships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partnership partnership = db.Partnerships.Find(id);
            if (partnership == null)
            {
                return HttpNotFound();
            }
            return View(partnership);
        }

        // GET: Partnerships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partnerships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,companyID,partnerID,partnerOrder,isShow,isFeatured")] Partnership partnership)
        {
            if (ModelState.IsValid)
            {
                db.Partnerships.Add(partnership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partnership);
        }

        // GET: Partnerships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partnership partnership = db.Partnerships.Find(id);
            if (partnership == null)
            {
                return HttpNotFound();
            }
            return View(partnership);
        }

        // POST: Partnerships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,companyID,partnerID,partnerOrder,isShow,isFeatured")] Partnership partnership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partnership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partnership);
        }

        // GET: Partnerships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partnership partnership = db.Partnerships.Find(id);
            if (partnership == null)
            {
                return HttpNotFound();
            }
            return View(partnership);
        }

        // POST: Partnerships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partnership partnership = db.Partnerships.Find(id);
            db.Partnerships.Remove(partnership);
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
    }
}
