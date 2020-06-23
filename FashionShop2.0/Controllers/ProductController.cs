using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop2._0.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDAO().ListAllNu();
            return PartialView(model);
        }
        public PartialViewResult ProductCategoryNam()
        {
            var model = new ProductCategoryDAO().ListAllNam();
            return PartialView(model);
        }
        public ActionResult Category(long id, int page = 1, int pageSize = 3)
        {
            var category = new ProductCategoryDAO().ViewDetail(id);
            ViewBag.category = category;
            int totalRecord = 0;
            var model = new ProductDAO().ListByCategoryID(id, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 3;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)((double)totalRecord / pageSize));
            
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1; 
            
            return View(model);
        }
        public ActionResult Detail(long ID)
        {
            var product = new ProductDAO().ViewDetail(ID);
            return View(product);
        }
    }
}