using Model.DAO;
using FashionShop2._0.Common;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace FashionShop2._0.Areas.Admin.Controllers
{
    public class FeedbackController : BaseController
    {
        // GET: Admin/Feedback
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao1 = new FeedbackDAO();
            var model = dao1.ListAllPaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var user = new FeedbackDAO().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(Feedback user)
        {
            if (ModelState.IsValid)
            {
                var dao = new FeedbackDAO();

                var encrypedMd5Pass = Encryptor.MD5Hash(user.Name);
                user.Name = encrypedMd5Pass;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm liên hệ thành công", "success");
                    return RedirectToAction("Index", "Feedback");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm liên hệ không thành công");
                }
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(Feedback user)
        {
            if (ModelState.IsValid)
            {
                var dao = new FeedbackDAO();

                if (!string.IsNullOrEmpty(user.Name))
                {
                    var encrypedMd5Pass = Encryptor.MD5Hash(user.Name);
                    user.Name = encrypedMd5Pass;
                }

                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Cập nhật liên hệ thành công", "success");
                    return RedirectToAction("Index", "Feedback");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật liên hệ không thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new FeedbackDAO().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new FeedbackDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        
    }
}