using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class KhoiLopController : Controller
    {
        // GET: KhoiLop
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThemKhoiLop() 
            => View();

        public ActionResult XemKhoiLop()
            => View();

        public ActionResult ChinhSuaKhoiLop()
            => View();

        public ActionResult XoaKhoiLop()
            => View();
    }
}