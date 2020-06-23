using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop2._0.Areas.Admin.Controllers
{
    public class AboutController : BaseController
    {
        //
        // GET: /Admin/About/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
	}
}