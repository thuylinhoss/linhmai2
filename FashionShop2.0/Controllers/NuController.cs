using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop2._0.Controllers
{
    public class NuController : Controller
    {
        //
        // GET: /Nu/
        public ActionResult Index()
        {
            var productDao = new ProductDAO();
            ViewBag.top1Product = productDao.ListTop1NuProduct(3);
            ViewBag.top2Product = productDao.ListTop2NuProduct(3);
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDAO().ListByTypeID(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult TopLeftMenu()
        {
            var model = new MenuDAO().ListByTypeID(2);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult TopRightMenu()
        {
            var model = new MenuDAO().ListByTypeID(3);
            return PartialView(model);
        }

	}
}