﻿using System;
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
        [HttpPost]
        public ActionResult ThemHocSinh(HocSinh _hocsinh)
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
                return RedirectToAction("TimHocSinh");
            }
            ViewBag.ModelError = "Wrong";
            return View(_hocsinh);
        }

        public ActionResult TimHocSinh()
            => View(db.HocSinh.ToList());

        public ActionResult XemThongTinHocSinh(string id)
            => View(db.HocSinh.Where(s => s.MaHS == id).FirstOrDefault());

        public ActionResult ChinhSuaThongTinHocSinh(string id)
            => View(db.HocSinh.Where(s => s.MaHS == id).FirstOrDefault());
        [HttpPost]
        public ActionResult ChinhSuaThongTinHocSinh(string id, HocSinh _hocsinh)
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
                return RedirectToAction("TimHocSinh");
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
            return RedirectToAction("TimHocSinh");
        }

    }
}