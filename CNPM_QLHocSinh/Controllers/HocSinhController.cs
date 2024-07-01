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
        

        public ActionResult ThemHocSinh()
            => View();

        public ActionResult TimHocSinh()
            => View(db.HocSinh.ToList());

        public ActionResult XemThongTinHocSinh()
            => View();

        public ActionResult ChinhSuaThongTinHocSinh(string id)
            => View(db.HocSinh.Where(s => s.MaHS == id).FirstOrDefault());
    
        public ActionResult DieuChinhTrangThaiHocSinh()
            => View();

        public ActionResult XoaHocSinh()
            => View();

    }
}