using AssetManagementSystem.EntityModel;
using AssetManagementSystem.EntityModel.Partial;
using AssetManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetManagementSystem.Controllers
{
    public class AssetAssignController : Controller
    {
        private AssetManagementSystemEntities db = new AssetManagementSystemEntities();
        // GET: AssetAssign
        [HttpGet]
        public ActionResult Index(int? id,string name="")
        {
            AssetAssignVM assetAssignVM = new AssetAssignVM();
      

            assetAssignVM.assetList = db.Assets.ToList();

            if (id == null)
                assetAssignVM.assetAssignsList = db.AssetAssigns.ToList();
            else
                assetAssignVM.assetAssignsList = db.AssetAssigns.Where(m => m.FK_EmployeeInformation == id).ToList();


            ViewBag.FK_EmployeeInformation = new SelectList(db.EmployeeInformations, "Id", "Name");
            ViewBag.FK_Asset = new SelectList(db.Assets, "Id", "Name");

            return View(new AssetAssignVM { assetList = assetAssignVM.assetList, assetAssignsList = assetAssignVM.assetAssignsList });

        }

        // GET: AssetAssign/Details/5

        [HttpPost]
        public ActionResult Index(int? id)
        {
            AssetAssignVM assetAssignVM = new AssetAssignVM();
            List<AssetAssign> assetAssignsList = new List<AssetAssign>();

            assetAssignVM.assetList = db.Assets.ToList();
            // assetAssignVM.assetAssignsList = db.AssetAssigns.ToList();

            assetAssignsList = db.AssetAssigns.Where(m => m.FK_EmployeeInformation == id).ToList();


            foreach (var assetAssignsItem in assetAssignsList)
            {
        
                var AssetAssignObj = new AssetAssign
                {
                    Id = assetAssignsItem.Id,
                    FK_Asset = assetAssignsItem.FK_Asset,
                    FK_EmployeeInformation = assetAssignsItem.FK_EmployeeInformation,
                    Description = assetAssignsItem.Description,
                    CreatedDate = assetAssignsItem.CreatedOn.ToString("yyyy-MM-dd"),
                    IsActive = assetAssignsItem.IsActive,             
                    ModifiedOn = assetAssignsItem.ModifiedOn,

                };
                assetAssignVM.assetAssignsList.Add(AssetAssignObj);
            }



            ViewBag.FK_EmployeeInformation = new SelectList(db.EmployeeInformations, "Id", "Name");
            ViewBag.FK_Asset = new SelectList(db.Assets, "Id", "Name");

            //return View(new AssetAssignVM { assetList = assetAssignVM.assetList, assetAssignsList = assetAssignVM.assetAssignsList });
            return Json(new AssetAssignVM { assetList = assetAssignVM.assetList, assetAssignsList = assetAssignVM.assetAssignsList });
        }

        // GET: AssetAssign/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetAssign/Create
        [HttpPost]
        public ActionResult AddEdit(List<AssetAssign> assetAssignsList)
        {
            try
            {
                foreach (var assetitem in assetAssignsList)
                {
                
                        var assetAssign = new AssetAssign
                        {
                            Id = assetitem.Id,
                            FK_EmployeeInformation = assetitem.FK_EmployeeInformation,
                            FK_Asset = assetitem.FK_Asset,
                            Description = assetitem.Description,
                            CreatedOn = assetitem.CreatedOn,
                            IsActive = assetitem.IsActive,
                        };

                        db.Entry(assetAssign).State =assetitem.Id==0? EntityState.Added:EntityState.Modified;
                        db.SaveChanges();

                }

                return Json(new Response { isSuccess = true, message = "Record has been inserted" });


            }
            catch (Exception ex)
            {
                return Json(new Response { message=ex.Message.ToString()});
            }
        }

        // GET: AssetAssign/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssetAssign/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetAssign/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssetAssign/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
