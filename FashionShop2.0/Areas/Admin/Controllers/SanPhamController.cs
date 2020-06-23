using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace FashionShop2._0.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
        //
        // GET: /Admin/SanPham/
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new ProductDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        //public ActionResult Edit(long id)
        //{
        //    var product = new ProductDAO().ViewDetail(id);
        //    return View(product);
        //}

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ProductDAO();
            var product = dao.GetByID(id);
            var productID = dao.ViewDetail(id);
            SetViewBag(product.ID_DanhMuc);
            return View(productID);
        }

        [HttpPost]
        public ActionResult Create(SanPham Product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                long id = dao.Insert(Product);
                if(id>0)
                {
                    SetAlert("Thêm sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Sanpham");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm không thành công");
                }
            }
            SetViewBag();
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(SanPham Product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                var result = dao.Update(Product);
                if (result)
                {
                    SetAlert("Sửa sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Sanpham");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa sản phẩm không thành công");
                }
            }
            SetViewBag();
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new ProductDAO().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        [HttpPost]
        public JsonResult ChangeTop(long id)
        {
            var result = new ProductDAO().ChangeTop(id);
            return Json(new
            {
                status = result
            });
        }
        public void SetViewBag(long? selectedID = null)
        {
           var dao = new ProductCategoryDAO();
           ViewBag.ID_DanhMuc = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }

	}
}