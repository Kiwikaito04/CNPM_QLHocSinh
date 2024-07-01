using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class MonHocController : Controller
    {
        // GET: MonHoc
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThemDanhMucMonHoc() 
            => View();

        public ActionResult XemDanhMucMonHoc()
            => View();

        public ActionResult ChinhSuaDanhMucMonHoc()
            => View();  

        public ActionResult XoaDanhMucMonHoc()
            => View();
    }
}