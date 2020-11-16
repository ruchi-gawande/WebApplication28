using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication28.Models;

namespace WebApplication28.Controllers
{
    public class MembershipPlansController : Controller
    {
        private gymEntities6 db = new gymEntities6();

        // GET: MembershipPlans
        public ActionResult Index()
        {
            return View(db.MembershipPlans.ToList());
        }

        // GET: MembershipPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipPlan membershipPlan = db.MembershipPlans.Find(id);
            if (membershipPlan == null)
            {
                return HttpNotFound();
            }
            return View(membershipPlan);
        }

        // GET: MembershipPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembershipPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Plan_Id,Plan_Name,Plan_Duration,Plan_Fees,Plan_Description")] MembershipPlan membershipPlan)
        {
            if (ModelState.IsValid)
            {
                db.MembershipPlans.Add(membershipPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membershipPlan);
        }

        // GET: MembershipPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipPlan membershipPlan = db.MembershipPlans.Find(id);
            if (membershipPlan == null)
            {
                return HttpNotFound();
            }
            return View(membershipPlan);
        }

        // POST: MembershipPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Plan_Id,Plan_Name,Plan_Duration,Plan_Fees,Plan_Description")] MembershipPlan membershipPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membershipPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membershipPlan);
        }

        // GET: MembershipPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MembershipPlan membershipPlan = db.MembershipPlans.Find(id);
            if (membershipPlan == null)
            {
                return HttpNotFound();
            }
            return View(membershipPlan);
        }

        // POST: MembershipPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MembershipPlan membershipPlan = db.MembershipPlans.Find(id);
            db.MembershipPlans.Remove(membershipPlan);
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
