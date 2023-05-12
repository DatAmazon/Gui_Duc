using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using giadinhthoxinh.Models;

namespace giadinhthoxinh.Areas.Admin.Controllers
{
    public class MaterSizesController : Controller
    {
        private giadinhthoxinhEntities1 db = new giadinhthoxinhEntities1();

        // GET: Admin/MaterSizes
        public ActionResult Index()
        {


            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                var tblMaterSizes = db.tblMaterSizes.Include(t => t.tblMaterial);
                return View(tblMaterSizes.ToList());
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // GET: Admin/MaterSizes/Details/5
        public ActionResult Details(int? id)
        {


            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblMaterSize tblMaterSize = db.tblMaterSizes.Find(id);
                if (tblMaterSize == null)
                {
                    return HttpNotFound();
                }
                return View(tblMaterSize);
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // GET: Admin/MaterSizes/Create
        public ActionResult Create()
        {
            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                ViewBag.FK_iMaterialID = new SelectList(db.tblMaterials, "PK_iMaterialID", "sMaterialName");
                return View();
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // POST: Admin/MaterSizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_iMaterSizeID,FK_iMaterialID,sMaterSize")] tblMaterSize tblMaterSize)
        {
            if (ModelState.IsValid)
            {
                db.tblMaterSizes.Add(tblMaterSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_iMaterialID = new SelectList(db.tblMaterials, "PK_iMaterialID", "sMaterialName", tblMaterSize.FK_iMaterialID);
            return View(tblMaterSize);
        }

        // GET: Admin/MaterSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblMaterSize tblMaterSize = db.tblMaterSizes.Find(id);
                if (tblMaterSize == null)
                {
                    return HttpNotFound();
                }
                ViewBag.FK_iMaterialID = new SelectList(db.tblMaterials, "PK_iMaterialID", "sMaterialName", tblMaterSize.FK_iMaterialID);
                return View(tblMaterSize);
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // POST: Admin/MaterSizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_iMaterSizeID,FK_iMaterialID,sMaterSize")] tblMaterSize tblMaterSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMaterSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_iMaterialID = new SelectList(db.tblMaterials, "PK_iMaterialID", "sMaterialName", tblMaterSize.FK_iMaterialID);
            return View(tblMaterSize);
        }

        // GET: Admin/MaterSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblMaterSize tblMaterSize = db.tblMaterSizes.Find(id);
                if (tblMaterSize == null)
                {
                    return HttpNotFound();
                }
                return View(tblMaterSize);
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // POST: Admin/MaterSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMaterSize tblMaterSize = db.tblMaterSizes.Find(id);
            db.tblMaterSizes.Remove(tblMaterSize);
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
