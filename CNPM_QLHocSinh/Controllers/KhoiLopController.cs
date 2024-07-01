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
        [HttpPost]
        public ActionResult ThemKhoiLop(KhoiLop _khoiLop)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    db.KhoiLop.Add(_khoiLop);
                    db.SaveChanges();
                }
                catch 
                {
                    ViewBag.Error = "Something went wrong, please try again later";
                    return View(_khoiLop);
                }
                return RedirectToAction("XemKhoiLop");
            }
            ViewBag.ModelError = "Biểu mẫu không đúng";
            return View(_khoiLop);
        }

        public ActionResult XemKhoiLop()
            => View(db.KhoiLop);

        public ActionResult ChinhSuaKhoiLop(string id)
            => View(db.KhoiLop.Where(s => s.MaKL == id).FirstOrDefault());
        [HttpPost]
        public ActionResult ChinhSuaKhoiLop(string id, KhoiLop _khoiLop)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(_khoiLop).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Something went wrong, please try again later";
                    return View(_khoiLop);
                }
                return RedirectToAction("XemKhoiLop");
            }
            ViewBag.ModelError = "Biểu mẫu không đúng";
            return View(_khoiLop);
        }

        public ActionResult XoaKhoiLop()
            => View();
    }
}