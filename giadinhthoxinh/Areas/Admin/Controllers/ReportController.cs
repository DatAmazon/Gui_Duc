using giadinhthoxinh.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace giadinhthoxinh.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        string str = @"Data Source=DESKTOP-C0C2AH8\SQLEXPRESS;Initial Catalog=giadinhthoxinh;Integrated Security=True";

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        // GET: Admin/Report
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
        public ActionResult TKNhapHang()
        {
            if (Session["QuanLy"] != null)
            {

                /* DataTable table1 = new DataTable();
                 connection = new SqlConnection(str);
                 connection.Open();
                 command = connection.CreateCommand();
                 command.CommandText = "select tblCheckinDetail.FK_iProductID,tblProduct.sProductName,tblProduct.sDescribe,tblCheckinDetail.fPrice,sum(tblCheckinDetail.iQuatity)as'soluong' from tblProduct, tblCheckinDetail where tblProduct.PK_iProductID = tblCheckinDetail.FK_iProductID group by tblCheckinDetail.FK_iProductID,tblProduct.sProductName,tblProduct.sDescribe,tblCheckinDetail.fPrice";
                 adapter.SelectCommand = command;
                 table1.Clear();
                 adapter.Fill(table1);
                 List<NhapHang> ds = new List<NhapHang>();
                 for (int i = 0; i < table1.Rows.Count; i++)
                 {
                     NhapHang kq = new NhapHang();

                     kq.ID = table1.Rows[i]["FK_iProductID"].ToString();
                     kq.Name = table1.Rows[i]["sProductName"].ToString();
                     kq.Description = table1.Rows[i]["sDescribe"].ToString();
                     kq.Price = table1.Rows[i]["fPrice"].ToString();
                     kq.Quatity = table1.Rows[i]["soluong"].ToString();
                     ds.Add(kq);
                 }
                 ViewBag.MyList = ds;
                 */
                giadinhthoxinhEntities1 db = new giadinhthoxinhEntities1();
                ViewBag.checkindetail = db.tblCheckinDetails.ToList();
                ViewBag.listImport = db.tblImportOrders.ToList();
                ViewBag.product = db.tblProducts.ToList();
                return View();
              

            }
            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }

        }
        [HttpPost]
        public ActionResult TKNhapHang(int?page)
        {
            if (Session["QuanLy"] != null)
            {

               
                DateTime from = DateTime.Parse(Request.Form["dtReviewTime_from"]);
                DateTime to = DateTime.Parse(Request.Form["dtReviewTime_to"]);
                giadinhthoxinhEntities1 db = new giadinhthoxinhEntities1();
                ViewBag.checkindetail = db.tblCheckinDetails.ToList();
                ViewBag.listImport = db.tblImportOrders.Where(x => x.dtDateAdded >= from && x.dtDateAdded <= to).ToList();
                ViewBag.product = db.tblProducts.ToList();
                return View();

            }
            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }

        }
        public ActionResult TKBanHang()
        {
            if (Session["QuanLy"] != null)
            {

                /* DataTable table1 = new DataTable();
                 connection = new SqlConnection(str);
                 connection.Open();
                 command = connection.CreateCommand();
                 command.CommandText = "select tblCheckoutDetail.FK_iProductID,tblProduct.sProductName,tblProduct.sDescribe,tblCheckoutDetail.fPrice,sum(tblCheckoutDetail.iQuantity)as'soluong' from tblProduct, tblCheckoutDetail where tblProduct.PK_iProductID = tblCheckoutDetail.FK_iProductID group by tblCheckoutDetail.FK_iProductID,tblProduct.sProductName,tblProduct.sDescribe,tblCheckoutDetail.fPrice";
                 adapter.SelectCommand = command;
                 table1.Clear();
                 adapter.Fill(table1);
                 List<NhapHang> ds = new List<NhapHang>();
                 for (int i = 0; i < table1.Rows.Count; i++)
                 {
                     NhapHang kq = new NhapHang();

                     kq.ID = table1.Rows[i]["FK_iProductID"].ToString();
                     kq.Name = table1.Rows[i]["sProductName"].ToString();
                     kq.Description = table1.Rows[i]["sDescribe"].ToString();
                     kq.Price = table1.Rows[i]["fPrice"].ToString();
                     kq.Quatity = table1.Rows[i]["soluong"].ToString();
                     ds.Add(kq);
                 }
                 ViewBag.MyList = ds;*/
                giadinhthoxinhEntities1 db = new giadinhthoxinhEntities1();
                ViewBag.MyList = db.tblOrders.ToList();
                return View();

            }
            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }

        }
        [HttpPost]
        public ActionResult TKBanHang(int? page)
        {
            if (Session["QuanLy"] != null)
            {
                DateTime from = DateTime.Parse(Request.Form["dtReviewTime_from"]);
                DateTime to = DateTime.Parse(Request.Form["dtReviewTime_to"]);

                giadinhthoxinhEntities1 db = new giadinhthoxinhEntities1();
                ViewBag.MyList = db.tblOrders.Where(x =>x.dInvoidDate>=from && x.dInvoidDate <= to).ToList();
                return View();
            }
            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }
        public ActionResult SanPhamBanChay()
        {
            if (Session["QuanLy"] != null)
            {

                DataTable table1 = new DataTable();
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "select top (5) tblCheckoutDetail.FK_iProductID,tblProduct.sProductName,tblProduct.sDescribe,tblCheckoutDetail.fPrice,sum(tblCheckoutDetail.iQuantity)as'soluong' from tblProduct, tblCheckoutDetail where tblProduct.PK_iProductID = tblCheckoutDetail.FK_iProductID group by tblCheckoutDetail.FK_iProductID,tblProduct.sProductName,tblProduct.sDescribe,tblCheckoutDetail.fPrice order by 'soluong' desc";
                adapter.SelectCommand = command;
                table1.Clear();
                adapter.Fill(table1);
                List<NhapHang> ds = new List<NhapHang>();
                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    NhapHang kq = new NhapHang();

                    kq.ID = table1.Rows[i]["FK_iProductID"].ToString();
                    kq.Name = table1.Rows[i]["sProductName"].ToString();
                    kq.Description = table1.Rows[i]["sDescribe"].ToString();
                    kq.Price = table1.Rows[i]["fPrice"].ToString();
                    kq.Quatity = table1.Rows[i]["soluong"].ToString();
                    ds.Add(kq);
                }
                ViewBag.MyList = ds;

                return View();

            }
            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }
        public ActionResult TKLoaiSanPham()
        {
            if (Session["QuanLy"] != null)
            {

                DataTable table1 = new DataTable();
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "   select tblProduct.sProductName,sum(tblCheckoutDetail.iQuantity) as'daban', tblProduct.iQuantity from tblProduct, tblCheckoutDetail where tblProduct.PK_iProductID = tblCheckoutDetail.FK_iProductID group by tblProduct.sProductName, tblProduct.iQuantity";
                adapter.SelectCommand = command;
                table1.Clear();
                adapter.Fill(table1);
                List<thongkesanpham> ds = new List<thongkesanpham>();
                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    thongkesanpham kq = new thongkesanpham();

                    kq.name = table1.Rows[i]["sProductName"].ToString();
                    kq.sell_out = table1.Rows[i]["daban"].ToString();
                    kq.avaiable = table1.Rows[i]["iQuantity"].ToString();
                    ds.Add(kq);
                }
                ViewBag.MyList = ds;

                return View();

            }
            else
            {
                return RedirectToAction("KhongDuThamQuyen", "PhanQuyen");
            }
        }
    }
}