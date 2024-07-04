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

        //Thêm khối lớp
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
            ViewBag.ModelError = "Wrong";
            return View(_khoiLop);
        }

        //Xem khối lớp aka Index
        public ActionResult XemKhoiLop()
            => View(db.KhoiLop);

        //Chỉnh sửa khối lớp
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

        //Xoá khối lớp
        public ActionResult XoaKhoiLop(string id)
            => View(db.KhoiLop.Where(s => s.MaKL == id).FirstOrDefault());
        [HttpPost]
        public ActionResult XoaKhoiLop(string id, KhoiLop _khoiLop)
        {
            try
            {
                _khoiLop = db.KhoiLop.Where(s => s.MaKL == id).FirstOrDefault();
                db.KhoiLop.Remove(_khoiLop);
                db.SaveChanges();
            }
            catch
            {
                ViewBag.Error = "Something went wrong, please try again later";
                return View(_khoiLop);
            }
            return RedirectToAction("XemKhoiLop");
        }
    }
}