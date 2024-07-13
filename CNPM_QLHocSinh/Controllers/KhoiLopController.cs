﻿using System;
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

        //ThemKhoiLop
        //GET: KhoiLop/Create
        public ActionResult Create() 
            => View();
        //POST: KhoiLop/Create
        [HttpPost]
        public ActionResult Create(KhoiLop _khoiLop)
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
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ModelError = "Wrong";
            return View(_khoiLop);
        }

        //XemKhoiLop
        public ActionResult Index()
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
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}