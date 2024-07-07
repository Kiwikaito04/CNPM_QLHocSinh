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
        {
            ViewBag.ChucVuList = new SelectList(db.ChucVu, "MaCV", "TenCV");
            //return View();
            return View();
        }
        [HttpPost]
        public ActionResult ThemGiaoVien(GiaoVien _giaoVien)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.GiaoVien.Add(_giaoVien);
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Something went wrong, please try again later";
                    ViewBag.ChucVuList = new SelectList(db.ChucVu, "MaCV", "TenCV");
                    return View(_giaoVien);
                }
                return RedirectToAction("Index");
            }
            ViewBag.ModelError = "Biểu mẫu không đúng";
            ViewBag.ChucVuList = new SelectList(db.ChucVu, "MaCV", "TenCV");
            return View(_giaoVien);
        }


        public ActionResult XemThongTinGiaoVien(string id)
            => View(db.GiaoVien.Where(s => s.MaGV == id).Include(s => s.ChucVu).FirstOrDefault());

        public ActionResult ChinhSuaThongTinGiaoVien(string id)
            => View(db.GiaoVien.Where(s => s.MaGV == id).Include(s => s.ChucVu).FirstOrDefault());
        [HttpPost]
        public ActionResult ChinhSuaThongTinGiaoVien(string id, GiaoVien _giaoVien)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(_giaoVien).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Something went wrong, please try again later";
                    ViewBag.ChucVuList = new SelectList(db.ChucVu, "MaCV", "TenCV");
                    return View(_giaoVien);
                }
                return RedirectToAction("Index");
            }
            ViewBag.ModelError = "Biểu mẫu không đúng";
            ViewBag.ChucVuList = new SelectList(db.ChucVu, "MaCV", "TenCV");
            return View(_giaoVien);
        }
        public ActionResult XoaGiaoVien(string id)
            => View(db.GiaoVien.Where(s => s.MaGV == id).Include(s => s.ChucVu).FirstOrDefault());
        [HttpPost]
        public ActionResult XoaGiaoVien(string id, GiaoVien _giaoVien)
        {
            try
            {
                _giaoVien = db.GiaoVien.Where(s => s.MaGV == id).FirstOrDefault();
                db.GiaoVien.Remove(_giaoVien);
                db.SaveChanges();
            }
            catch
            {
                ViewBag.Error = "Something went wrong, please try again later";
                ViewBag.ChucVuList = new SelectList(db.ChucVu, "MaCV", "TenCV");
                return View(_giaoVien);
            }
            return RedirectToAction("Index");
        }

    }
}