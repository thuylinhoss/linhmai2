using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FashionShop2._0.Common;
using Model.DAO;
using Model.EF;
using PagedList;

namespace FashionShop2._0.Areas.Admin.Controllers
{
    public class SlideController : BaseController
    {
       
            // GET: Admin/DanhMucSP
            public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
            {
                var dao = new SlideDAO();
                var model = dao.ListAllPaging(searchString, page, pageSize);
                ViewBag.searchString = searchString;
                return View(model);
            }


            [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        //public ActionResult Edit(long id)
        //{
        //    var product = new ProductDAO().ViewDetail(id);
        //    return View(product);
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new SlideDAO().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(Slide user)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDAO();

                var encrypedMd5Pass = Encryptor.MD5Hash(user.Image);
                user.Image = encrypedMd5Pass;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm giới thiệu thành công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm giới thiệu không thành công");
                }
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(Slide user)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDAO();

                if (!string.IsNullOrEmpty(user.Image))
                {
                    var encrypedMd5Pass = Encryptor.MD5Hash(user.Image);
                    user.Image = encrypedMd5Pass;
                }

                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Cập nhật giới thiệu thành công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật giới thiệu không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SlideDAO().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
            public JsonResult ChangeStatus(long id)
            {
                var result = new SlideDAO().ChangeStatus(id);
                return Json(new
                {
                    status = result
                });
            }
        
    }
}