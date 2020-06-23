using FashionShop2._0.Models;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Model.EF;
using Model.ViewModel;
using FashionShop2._0.Common;

namespace FashionShop2._0.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        //private const string USER_SESSION = "USER_SESSION";
        //
        // GET: /Cart/
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;

            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(long productID, int quantity)
        {
            var product = new ProductDAO().ViewDetail(productID);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;

            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string Address, string Phone, string Email)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if(session!=null)
            {
                var order = new OrderViewModel();
                order.CreatedDate = DateTime.Now;
                order.UserID = session.UserID;
                order.Name = shipName;
                order.Address = Address;
                order.Phone = Phone;
                order.Email = Email;

                try
                {
                    var id = new OrderDAO().Insert(order);
                    var cart = (List<CartItem>)Session[CartSession];
                    var detailDao = new OrderDetailDAO();
                    foreach (var item in cart)
                    {
                        var orderDetail = new OrderDetailViewModel();
                        orderDetail.ProductID = item.Product.ID;
                        orderDetail.OrderID = id;
                        orderDetail.Quantity = item.Quantity;
                        orderDetail.Price = item.Product.Price;
                        detailDao.Insert(orderDetail);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return Redirect("/hoan-thanh");
            }
            else
            {
                return Redirect("/dang-nhap");
            }
            
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}