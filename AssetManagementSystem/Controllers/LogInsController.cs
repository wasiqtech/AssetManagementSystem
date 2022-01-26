using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetManagementSystem.EntityModel;

namespace AssetManagementSystem.Controllers
{
    public class LogInsController : Controller
    {
        private AssetManagementSystemEntities db = new AssetManagementSystemEntities();

        // GET: LogIns
        public ActionResult Index()
        {
            return View(db.LogIns.ToList());
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogIn logIn)
        {
           var data= db.LogIns.Where(a => a.EmailId == logIn.EmailId && a.Password == logIn.Password && a.IsActive==true).FirstOrDefault();
            
            if(data!=null)
            {
                return RedirectToAction("Index","Home");
            }else
            {
                return View();
            }
        }

        // GET: LogIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogIn logIn = db.LogIns.Find(id);
            if (logIn == null)
            {
                return HttpNotFound();
            }
            return View(logIn);
        }

        // GET: LogIns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailId,Password,IsActive,CreatedOn,ModifiedOn")] LogIn logIn)
        {
            if (ModelState.IsValid)
            {
                db.LogIns.Add(logIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logIn);
        }

        // GET: LogIns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogIn logIn = db.LogIns.Find(id);
            if (logIn == null)
            {
                return HttpNotFound();
            }
            return View(logIn);
        }

        // POST: LogIns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailId,Password,IsActive,CreatedOn,ModifiedOn")] LogIn logIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logIn);
        }

        // GET: LogIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogIn logIn = db.LogIns.Find(id);
            if (logIn == null)
            {
                return HttpNotFound();
            }
            return View(logIn);
        }

        // POST: LogIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogIn logIn = db.LogIns.Find(id);
            db.LogIns.Remove(logIn);
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
