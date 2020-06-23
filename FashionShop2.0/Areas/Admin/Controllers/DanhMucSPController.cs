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
    public class DanhMucSPController : BaseController
    {
        // GET: Admin/DanhMucSP
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new ProductCategoryDAO();
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
            var dao = new ProductCategoryDAO();
            var product = dao.GetByID(id);
            var productID = dao.ViewDetail(id);
            SetViewBag(product.ID);
            return View(productID);
        }

        [HttpPost]
        public ActionResult Create(DanhMucSP productCategory)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDAO();
                long id = dao.Insert(productCategory);
                if (id > 0)
                {
                    SetAlert("Thêm danh mục thành công", "success");
                    return RedirectToAction("Index", "DanhMucSP");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm danh mục không thành công");
                }
            }
            SetViewBag();
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(DanhMucSP Product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDAO();
                var result = dao.Update(Product);
                if (result)
                {
                    SetAlert("Sửa danh mục thành công", "success");
                    return RedirectToAction("Index", "DanhMucSP");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa danh mục không thành công");
                }
            }
            SetViewBag();
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new ProductCategoryDAO().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductCategoryDAO().ChangeStatus(id);
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