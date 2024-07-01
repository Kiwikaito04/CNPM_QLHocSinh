using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNPM_QLHocSinh.Models;

namespace CNPM_QLHocSinh.Controllers
{
    public class KhoiLopController : Controller
    {
        CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();
        // GET: KhoiLop
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThemKhoiLop() 
            => View();

        public ActionResult XemKhoiLop()
            => View(db.KhoiLop);

        public ActionResult ChinhSuaKhoiLop()
            => View();

        public ActionResult XoaKhoiLop()
            => View();
    }
}