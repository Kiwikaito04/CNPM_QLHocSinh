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
        
        //ThemHocSinh
        //GET: HocSinh/Create
        public ActionResult Create()
            => View();
        //POST: HocSinh/Create
        [HttpPost]
        public ActionResult Create(HocSinh _hocsinh)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.HocSinh.Add(_hocsinh);
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Something went wrong, please try again later";
                    return View(_hocsinh);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ModelError = "Wrong";
            return View(_hocsinh);
        }

        //TimHocSinh
        //GET: HocSinh
        public ActionResult Index()
            => View(db.HocSinh.ToList());

        //XemThongTinHocSinh
        //GET: HocSinh/Details/1
        public ActionResult Details(string id)
            => View(db.HocSinh.Where(s => s.MaHS == id).FirstOrDefault());

        //ChinhSuaThongTinHocSinh
        //GET: HocSinh/Edit/1
        public ActionResult Edit(string id)
            => View(db.HocSinh.Where(s => s.MaHS == id).FirstOrDefault());
        //POST: HocSinh/Edit/1
        [HttpPost]
        public ActionResult Edit(string id, HocSinh _hocsinh)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(_hocsinh).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Something went wrong, please try again later";
                    return View(_hocsinh);
                }
               return RedirectToAction(nameof(Details) + "/" + id.ToString());
            }
            ViewBag.ModelError = "Biểu mẫu không đúng";
            return View(_hocsinh);
        }


        public ActionResult DieuChinhTrangThaiHocSinh()
            => View();

        public ActionResult XoaHocSinh(string id)
            => View(db.HocSinh.Where(s => s.MaHS == id).FirstOrDefault());
        [HttpPost]
        public ActionResult XoaHocSinh(string id, HocSinh _hocsinh)
        {
            try
            {
                _hocsinh = db.HocSinh.Where(s => s.MaHS == id).FirstOrDefault();
                db.HocSinh.Remove(_hocsinh);
                db.SaveChanges();
            }
            catch
            {
                ViewBag.Error = "Something went wrong, please try again later";
                return View(_hocsinh);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}