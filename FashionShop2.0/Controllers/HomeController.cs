using FashionShop2._0.Common;
using FashionShop2._0.Models;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop2._0.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.Slides1 = new SlideDAO().ListAll(1);
            var productDAO = new ProductDAO();
            ViewBag.NewProducts = productDAO.ListNewProduct(6);
            ViewBag.FeatureProducts = productDAO.ListFeatureProduct(6);
            ViewBag.SaleProducts = productDAO.ListSaleProducts(6);
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

        [ChildActionOnly]
        public ActionResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
	}
}