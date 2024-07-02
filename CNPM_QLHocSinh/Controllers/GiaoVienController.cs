using CNPM_QLHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class GiaoVienController : Controller
    {
        CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();

        // GET: GiaoVien
        public ActionResult Index()
        {
            return View(db.GiaoVien.Include(s => s.ChucVu));
        }

        public ActionResult ThemGiaoVien()
            => View();

        public ActionResult XemThongTinGiaoVien()
            => View();

        public ActionResult ChinhSuaThongTinGiaoVien()
            => View();
        public ActionResult XoaGiaoVien()
            => View();

    }
}