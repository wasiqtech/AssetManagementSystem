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
    public class EmployeeInformationsController : Controller
    {
        private AssetManagementSystemEntities db = new AssetManagementSystemEntities();

        // GET: EmployeeInformations
        public ActionResult Index()
        {
            List<EmployeeInformationVM> employeeInformationVMList = new List<EmployeeInformationVM>();

            var employeeList = db.EmployeeInformations.ToList();

            foreach (var Employeeitem in employeeList)
            {
                var tblDesignation = db.Designations.Where(d => d.Id == Employeeitem.FK_Designation).FirstOrDefault();
                var tblDepartment = db.Departments.Where(d => d.Id == Employeeitem.FK_Department).FirstOrDefault();

                var employeeVMObj = new EmployeeInformationVM
                {
                    Id = Employeeitem.Id,
                    Name = Employeeitem.Name,
                    FatherName = Employeeitem.FatherName,
                    EmployeCode = Employeeitem.EmployeCode,
                    CNICNo = Employeeitem.CNICNo,
                    Address = Employeeitem.Address,
                    PhoneNo = Employeeitem.PhoneNo,
                    CellNo = Employeeitem.CellNo,
                    Department = tblDepartment.Name,
                    Designation = tblDesignation.Name,
                    IsActive = Employeeitem.IsActive,
                    CreatedOn = Employeeitem.CreatedOn,
                    ModifiedOn= Employeeitem.ModifiedOn,

                };
                employeeInformationVMList.Add(employeeVMObj);
            }
           

            return View(employeeInformationVMList);
        }

        // GET: EmployeeInformations/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            EmployeeInformation employeeInfor = db.EmployeeInformations.Find(id);
            var tblDesignation = db.Designations.Where(d => d.Id == employeeInfor.FK_Designation).FirstOrDefault();
            var tblDepartment = db.Departments.Where(d => d.Id == employeeInfor.FK_Department).FirstOrDefault();

            var employeeInformationVMList = new EmployeeInformationVM
            {
                Id = employeeInfor.Id,
                Name = employeeInfor.Name,
                FatherName = employeeInfor.FatherName,
                EmployeCode = employeeInfor.EmployeCode,
                CNICNo = employeeInfor.CNICNo,
                Address = employeeInfor.Address,
                PhoneNo = employeeInfor.PhoneNo,
                CellNo = employeeInfor.CellNo,
                Department = tblDepartment.Name,
                Designation = tblDesignation.Name,
                IsActive = employeeInfor.IsActive,
                CreatedOn = employeeInfor.CreatedOn,
                ModifiedOn = employeeInfor.ModifiedOn,
            };

            if (employeeInfor == null)
            {
                return HttpNotFound();
            }

            return View(employeeInformationVMList);
        }

        // GET: EmployeeInformations/Create
        public ActionResult Create()
        {
            ViewBag.FK_Designation = new SelectList(db.Designations, "Id", "Name");
            ViewBag.FK_Department = new SelectList(db.Departments, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FatherName,EmployeCode,CNICNo,Address,PhoneNo,CellNo,FK_Department,FK_Designation,IsActive,CreatedOn,ModifiedOn")] EmployeeInformation employeeInformation)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeInformations.Add(employeeInformation);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.FK_Designation = new SelectList(db.Designations, "Id", "Name", employeeInformation.FK_Designation);
            ViewBag.FK_Department = new SelectList(db.Departments, "Id", "Name", employeeInformation.FK_Designation);

            return View(employeeInformation);
        }

        // GET: EmployeeInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInformation employeeInformation = db.EmployeeInformations.Find(id);
            if (employeeInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Designation = new SelectList(db.Designations, "Id", "Name", employeeInformation.FK_Designation);
            ViewBag.FK_Department = new SelectList(db.Departments, "Id", "Name", employeeInformation.FK_Department);

            return View(employeeInformation);
        }

        // POST: EmployeeInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FatherName,EmployeCode,CNICNo,Address,PhoneNo,CellNo,FK_Department,FK_Designation,IsActive,CreatedOn,ModifiedOn")] EmployeeInformation employeeInformation)
        {
            if (ModelState.IsValid)
            {
                employeeInformation.ModifiedOn = DateTime.Now;
                db.Entry(employeeInformation).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.FK_Designation = new SelectList(db.Designations, "Id", "Name", employeeInformation.FK_Designation);
            ViewBag.FK_Department = new SelectList(db.Departments, "Id", "Name", employeeInformation.FK_Designation);

            return View(employeeInformation);
        }

        // GET: EmployeeInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInformation employeeInformation = db.EmployeeInformations.Find(id);
            if (employeeInformation == null)
            {
                return HttpNotFound();
            }
            return View(employeeInformation);
        }

        // POST: EmployeeInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeInformation employeeInformation = db.EmployeeInformations.Find(id);
            db.EmployeeInformations.Remove(employeeInformation);
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
