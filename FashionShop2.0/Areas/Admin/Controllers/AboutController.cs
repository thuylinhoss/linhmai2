﻿using FashionShop2._0.Common;
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
    public class AboutController : BaseController
    {
        //
        // GET: /Admin/About/
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new AboutDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }

        //public ActionResult Index1(string searchString, int page = 1, int pageSize = 5)
        //{
        //    var dao1 = new AdminDAO();
        //    var model1 = dao1.ListAllPaging(searchString, page, pageSize);
        //    ViewBag.searchString = searchString;
        //    return View(model1);
        //}
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var user = new AboutDAO().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(About user)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDAO();

                var encrypedMd5Pass = Encryptor.MD5Hash(user.Name);
                user.Name = encrypedMd5Pass;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm giới thiệu thành công", "success");
                    return RedirectToAction("Index", "About");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm giới thiệu không thành công");
                }
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(About user)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDAO();

                if (!string.IsNullOrEmpty(user.Name))
                {
                    var encrypedMd5Pass = Encryptor.MD5Hash(user.Name);
                    user.Name = encrypedMd5Pass;
                }

                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Cập nhật giới thiệu thành công", "success");
                    return RedirectToAction("Index", "About");
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
            new AboutDAO().Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}