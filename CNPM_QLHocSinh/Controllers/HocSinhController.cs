using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class HocSinhController : Controller
    {
        // GET: HocSinh
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThemHocSinh()
            => View();

        public ActionResult TimHocSinh()
            => View();

        public ActionResult XemThongTinHocSinh()
            => View();

        public ActionResult ChinhSuaThongTinHocSinh()
            => View();
    
        public ActionResult DieuChinhTrangThaiHocSinh()
            => View();

        public ActionResult XoaHocSinh()
            => View();

    }
}