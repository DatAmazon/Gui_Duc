using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using giadinhthoxinh.Models;
using PagedList;

namespace giadinhthoxinh.Controllers
{
    public class HomeController : Controller
    {
        public giadinhthoxinhEntities1 db = new giadinhthoxinhEntities1();
        //public ActionResult Index(int? page)
        //{

        //    Session["Search"] = "";
        //    int productInPage = 10;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    giadinhthoxinhEntities1 db = new giadinhthoxinhEntities1();

        //    List<tblProduct> ketQua = db.tblProducts.ToList();

        //    IPagedList<tblProduct> ketQuaFinal = null;
        //    ketQuaFinal = ketQua.ToPagedList(pageNumber, productInPage);
        //   // var ketQua = db.tblProducts.ToList();
        //   //  PagedList<tblProduct> ketQuaFinal = new PagedList<tblProduct>(ketQua, pageNumber, productInPage);
        //    return View(ketQuaFinal);
        //}

        [HttpGet]
        public ActionResult Index(int? cate_id, int? page)
        {
            int productInPage = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            giadinhthoxinhEntities1 db = new giadinhthoxinhEntities1();
            IPagedList<tblProduct> ketQuaFinal = null;
            if (cate_id == null)
            {
                List<tblProduct> ketQua = db.tblProducts.ToList();
                ViewBag.cate_id = null;
                ketQuaFinal = ketQua.ToPagedList(pageNumber, productInPage);
            }
            else
            {
                ViewBag.cate_id = cate_id;
                List<tblProduct> ketQua = db.tblProducts.Where(s => s.FK_iCategoryID == cate_id).ToList();

                ketQuaFinal = ketQua.ToPagedList(pageNumber, productInPage);
                // var ketQua = db.tblProducts.ToList();
                //  PagedList<tblProduct> ketQuaFinal = new PagedList<tblProduct>(ketQua, pageNumber, productInPage);
            }
            return View(ketQuaFinal);

        }

        public ActionResult Search(string searchString, int? page)
        {
            Session["Search"] = searchString;
            int productInPage = 10;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            giadinhthoxinhEntities1 db = new giadinhthoxinhEntities1();

            List<tblProduct> ketQua = db.tblProducts.ToList();
            IOrderedQueryable<tblProduct> model = (IOrderedQueryable<tblProduct>)db.tblProducts.OrderByDescending(x => x.PK_iProductID);
            if (!String.IsNullOrEmpty(searchString))
            {
                //model = (IOrderedQueryable<tblProduct>)model.Where(x => x.sProductName.Contains(searchString));
                model = (IOrderedQueryable<tblProduct>)model.Where(x => x.sProductName.Contains(searchString));
                IPagedList<tblProduct> timkiem = null;
                timkiem = model.ToPagedList(pageNumber, productInPage);
                return View(timkiem);
            }
            IPagedList<tblProduct> ketQuaFinal = null;
            ketQuaFinal = ketQua.ToPagedList(pageNumber, productInPage);
            // var ketQua = db.tblProducts.ToList();
            //  PagedList<tblProduct> ketQuaFinal = new PagedList<tblProduct>(ketQua, pageNumber, productInPage);
            return View(ketQuaFinal);
        }

            public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ProductDetail(int id)
        {
            var item = db.tblProducts.Find(id);

            return View(item);
        }
       // [HttpPost]
       // [ValidateAntiForgeryToken]
      /*  public ActionResult ProductDetail(int product_id, int quantity_value)
        {
            //xu ly them vao gio
                Cart giohang = (Cart)Session["giohang"];
                ProductInCart sanpham = new ProductInCart();
                sanpham.ProductID = product_id;
                sanpham.Quatity = quantity_value;
                int check = 0;
                if (giohang.lstproduct != null && giohang.lstproduct.Count > 0)
                    foreach (ProductInCart a in giohang.lstproduct)
                    {
                        if (a.ProductID == sanpham.ProductID)
                        {
                            a.Quatity++;
                            check = 1;
                            break;
                        }
                    }
                if (check == 0)
                {
                    giohang.lstproduct.Add(sanpham);
                }


            return RedirectToAction("ProductDetail", new { id = product_id });
        //    var item = db.tblProducts.Find(product_id);
         //   return View(item);
        }*/
        public ActionResult Checkout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Promote()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}