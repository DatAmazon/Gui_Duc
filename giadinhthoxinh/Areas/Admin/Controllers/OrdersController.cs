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
    public class OrdersController : Controller
    {
        private giadinhthoxinhEntities1 db = new giadinhthoxinhEntities1();

        // GET: Admin/Orders
        public ActionResult Index()
        {

            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                return View();
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }
        /* public ActionResult Search()
         {
             IOrderedQueryable<tblOrder> model = (IOrderedQueryable<tblOrder>)db.tblOrders.OrderByDescending(x => x.dInvoidDate);
             return View(model);
         }    
         [HttpGet]*/
        public ActionResult SearchDonHang(string searchString)
        {
            // string searchString = Request.Form["searchString"];

            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                Session["SearchDonHang"] = searchString;
                IOrderedQueryable<tblOrder> model = (IOrderedQueryable<tblOrder>)db.tblOrders.OrderByDescending(x => x.dInvoidDate);
                if (!String.IsNullOrEmpty(searchString))
                {
                    model = (IOrderedQueryable<tblOrder>)model.Where(x => x.sCustomerPhone.Contains(searchString));
                }
                return View(model);
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }
        public ActionResult DuyetDonHang(int id)// duyet don hang tao luon hoa don cho don hang do
        {//phai kiem tra xem co du so luong san pham ko

            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                var item = db.tblOrders.Find(id);
                if (Session["NhanVien"] != null)
                {
                    tblUser nv = (tblUser)Session["NhanVien"];
                    item.sBiller = nv.sUserName;
                    item.sState = "Đang giao hàng";
                    //item.iTotal = (int)item.fSurcharge + item.iTotal;
                    db.SaveChanges();

                }
                else
                {
                    return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
                }
                return RedirectToAction("Index");
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }
        public ActionResult HoanThanhDonHang(int id)//hoan thanh don
        {
            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                var item = db.tblOrders.Find(id);
                if (Session["NhanVien"] != null)
                {
                    tblUser nv = (tblUser)Session["NhanVien"];
                    item.sBiller = nv.sUserName;
                    item.sState = "Hoàn thành";
                    item.iPaid = 1;
                    db.SaveChanges();
                    List<tblProduct> ProcductInOrder = new List<tblProduct>();
                    List<tblCheckoutDetail> listcheckout = db.tblCheckoutDetails.Where(x => x.FK_iOrderID == id).ToList();// lấy ra danh sách những chi tiết đơn hàng của đơn hàng đã hoàn thành
                    foreach (tblCheckoutDetail it in listcheckout)
                    {
                        tblProduct tmp = db.tblProducts.Find(it.FK_iProductID);// lấy ra sản phẩm trong chi tiết hóa đơn
                        tmp.iQuantity = tmp.iQuantity - it.iQuantity;//trừ đi sản phẩm trong đơn hàng
                        db.SaveChanges();

                    }

                }
                else
                {
                    return RedirectToAction("YeuCauDangNhap", "Login");
                }
                return RedirectToAction("Index");
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }

        }
        public ActionResult HuyDonHang(int id)//huy don hang
        {
            var item = db.tblOrders.Find(id);
            if (Session["NhanVien"] != null)
            {
                tblUser nv = (tblUser)Session["NhanVien"];
                item.sBiller = nv.sUserName;
                item.sState = "Đã hủy";
                db.SaveChanges();
                //  TaoHoaDon(item.ma_DH);
            }
            else
            {
                return RedirectToAction("YeuCauDangNhap", "Login");
            }
            return RedirectToAction("Index");
        }
        public ActionResult DonHangChuaXuLy_Partial()
        {

            //var item = db.DonHangs.Where(n => n.ma_NV == null).ToList();
            var it = db.tblOrders.Where(n => n.sState == "Chờ xác nhận").OrderByDescending(x => x.dInvoidDate);
            return PartialView(it);
        }
        public ActionResult DonHangDangGiao_Partial()
        {
            // var item = db.DonHangs.Where(n => n.ma_NV != null).ToList();
            var it = db.tblOrders.Where(n => n.sState == "Đang giao hàng").OrderByDescending(x => x.dInvoidDate);
            return PartialView(it);

        }
        public ActionResult DonHangDaXuLy_Partial()
        {
            // var item = db.DonHangs.Where(n => n.ma_NV != null).ToList();
            var it = db.tblOrders.Where(n => n.sState == "Hoàn thành" || n.sState == "Đã hủy").OrderByDescending(x => x.dInvoidDate);
            return PartialView(it);

        }
        // GET: Admin/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblOrder tblOrder = db.tblOrders.Find(id);
                ViewBag.ListProduct = db.tblCheckoutDetails.Where(x => x.FK_iOrderID == id).ToList();
                if (tblOrder == null)
                {
                    return HttpNotFound();
                }
                return View(tblOrder);
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // GET: Admin/Orders/Create
        public ActionResult Create()
        {
            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                ViewBag.FK_iAccountID = new SelectList(db.tblUsers.Where(x => x.FK_iPermissionID > 1), "PK_iAccountID", "sEmail");
                return View();
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_iOrderID,FK_iAccountID,sCustomerName,sCustomerPhone,sDeliveryAddress,dInvoidDate,sBiller,iDeliveryMethod,fSurcharge,iPaid,iState")] tblOrder tblOrder)
        {
            if (ModelState.IsValid)
            {
                db.tblOrders.Add(tblOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_iAccountID = new SelectList(db.tblUsers, "PK_iAccountID", "sEmail", tblOrder.FK_iAccountID);
            return View(tblOrder);
        }

        // GET: Admin/Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["NhanVien"] != null)
            {
                //nội dung action cũ paste và đây
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblOrder tblOrder = db.tblOrders.Find(id);
                if (tblOrder == null)
                {
                    return HttpNotFound();
                }
                ViewBag.FK_iAccountID = new SelectList(db.tblUsers.Where(x => x.FK_iPermissionID > 1), "PK_iAccountID", "sEmail", tblOrder.FK_iAccountID);
                return View(tblOrder);
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_iOrderID,FK_iAccountID,sCustomerName,sCustomerPhone,sDeliveryAddress,dInvoidDate,sBiller,iDeliveryMethod,fSurcharge,iPaid,iState")] tblOrder tblOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_iAccountID = new SelectList(db.tblUsers, "PK_iAccountID", "sEmail", tblOrder.FK_iAccountID);
            return View(tblOrder);
        }

        // GET: Admin/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["QuanLy"] != null)
            {
                //nội dung action cũ paste và đây
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblOrder tblOrder = db.tblOrders.Find(id);
                if (tblOrder == null)
                {
                    return HttpNotFound();
                }
                return View(tblOrder);
            }

            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }

        // POST: Admin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOrder tblOrder = db.tblOrders.Find(id);
            db.tblOrders.Remove(tblOrder);
            
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
