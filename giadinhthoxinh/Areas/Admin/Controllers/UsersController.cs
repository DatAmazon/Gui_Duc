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
    public class UsersController : Controller
    {
        private giadinhthoxinhEntities1 db = new giadinhthoxinhEntities1();

        // GET: Admin/Users
        public ActionResult Index(string searchString)
        {

            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                var totalUser = from m in db.tblUsers
                                select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                    totalUser = totalUser.Where(s => s.sPhone.Contains(searchString));
                    var tblUsers = db.tblUsers.Include(t => t.tblPermission);
                }

                return View(totalUser.ToList());
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {

            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblUser tblUser = db.tblUsers.Find(id);
                if (tblUser == null)
                {
                    return HttpNotFound();
                }
                return View(tblUser);
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            if (Session["QuanLy"] != null)
            {
                //nội dung action cũ paste và đây
                ViewBag.FK_iPermissionID = new SelectList(db.tblPermissions, "PK_iPermissionID", "sPermissionName");
                return View();
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_iAccountID,FK_iPermissionID,sEmail,sPass,sUserName,sPhone,sAddress,iState")] tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                db.tblUsers.Add(tblUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_iPermissionID = new SelectList(db.tblPermissions, "PK_iPermissionID", "sPermissionName", tblUser.FK_iPermissionID);
            return View(tblUser);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["QuanLy"] != null)
            {
                //nội dung action cũ paste và đây
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblUser tblUser = db.tblUsers.Find(id);
                if (tblUser == null)
                {
                    return HttpNotFound();
                }
                ViewBag.FK_iPermissionID = new SelectList(db.tblPermissions, "PK_iPermissionID", "sPermissionName", tblUser.FK_iPermissionID);
                return View(tblUser);
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_iAccountID,FK_iPermissionID,sEmail,sPass,sUserName,sPhone,sAddress,iState")] tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_iPermissionID = new SelectList(db.tblPermissions, "PK_iPermissionID", "sPermissionName", tblUser.FK_iPermissionID);
            return View(tblUser);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["QuanLy"] != null)
            {
                //nội dung action cũ paste và đây
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblUser tblUser = db.tblUsers.Find(id);
                if (tblUser == null)
                {
                    return HttpNotFound();
                }
                return View(tblUser);
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUser tblUser = db.tblUsers.Find(id);
            db.tblUsers.Remove(tblUser);
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
        public ActionResult Logout1()
        {
            Session.Clear();//remove session
            return RedirectToAction("login", "user");

        }
    }
}
