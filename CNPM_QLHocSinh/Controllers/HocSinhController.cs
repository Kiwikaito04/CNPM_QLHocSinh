using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNPM_QLHocSinh.Models;
using Microsoft.Ajax.Utilities;

namespace CNPM_QLHocSinh.Controllers
{
    public class HocSinhController : Controller
    {
        CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();
        
        // GET: HocSinh
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThemHocSinh()
            => View();

        public ActionResult TimHocSinh()
            => View(db.HocSinh);

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