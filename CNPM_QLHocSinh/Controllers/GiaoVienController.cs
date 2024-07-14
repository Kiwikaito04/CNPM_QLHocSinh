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

        //ThemGiaoVien
        //GET: GiaoVien/Create
        public ActionResult Create()
        {
            ViewBag.ChucVuList = new SelectList(db.ChucVu, "MaCV", "TenCV");
            return View();
        }
        //POST: GiaoVien/Create
        [HttpPost]
        public ActionResult Create(GiaoVien _giaoVien)
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
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ModelError = "Biểu mẫu không đúng";
            ViewBag.ChucVuList = new SelectList(db.ChucVu, "MaCV", "TenCV");
            return View(_giaoVien);
        }

        //XemThongTinGiaoVien
        //GET: GiaoVien/Details/1
        public ActionResult Details(string id)
            => View(db.GiaoVien.Where(s => s.MaGV == id).Include(s => s.ChucVu).FirstOrDefault());

        //ChinhSuaThongTinGiaoVien
        //GET: GiaoVien/Edit/1
        public ActionResult Edit(string id)
            => View(db.GiaoVien.Where(s => s.MaGV == id).Include(s => s.ChucVu).FirstOrDefault());
        //POST: GiaoVien/Edit/1
        [HttpPost]
        public ActionResult Edit(string id, GiaoVien _giaoVien)
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
                return RedirectToAction(nameof(Details) + "/" + id.ToString());
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
            return RedirectToAction(nameof(Index));
        }

    }
}