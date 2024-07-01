using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class GiaoVienController : Controller
    {
        // GET: GiaoVien
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThemGiaoVien()
            => View();

        public ActionResult XemTHongTinGiaoVien()
            => View();

        public ActionResult ChinhSuaThongTinGiaoVien()
            => View();
    }
}