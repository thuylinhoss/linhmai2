using FashionShop2._0.Common;
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
    public class UserController : BaseController
    {
        //
        // GET: /Admin/User/
        public ActionResult Index(string searchString, int page =1,int pageSize = 5)
        {
            var dao = new UserDAO();
            var model = dao.ListAllPaging(searchString,page, pageSize);
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
            var user = new UserDAO().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();

                var encrypedMd5Pass = Encryptor.MD5Hash(user.Password);
                user.Password = encrypedMd5Pass;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm người dùng không thành công");
                }
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();

                if(!string.IsNullOrEmpty(user.Password))
                {
                    var encrypedMd5Pass = Encryptor.MD5Hash(user.Password);
                    user.Password = encrypedMd5Pass;
                }

                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Cập nhật người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật người không thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDAO().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
	}
}