﻿using CNPM_QLHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class LopHocController : Controller
    {
        CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();

        public ActionResult XetDuyetLopMoi()
            => View();

        public ActionResult PhanBoLopMoi()
            => View();

        public ActionResult ChuyenLop()
            => View();

        //ThemLopHoc
        //GET: LopHoc/Create
        public ActionResult Create()
            => View();
        //POST: LopHoc/Create
        [HttpPost]
        public ActionResult Create(LopHoc _lopHoc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.LopHoc.Add(_lopHoc);
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Something went wrong, please try again later";
                    return View(_lopHoc);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ModelError = "Wrong";
            return View(_lopHoc);
        }


        //XemDanhSachLopHoc
        //GET: LopHoc
        public ActionResult Index() 
            => View(db.LopHoc.Include(s => s.KhoiLop).ToList());

        //ChinhSuaLopHoc
        //GET: LopHoc/Edit/1
        public ActionResult Edit(string id)
            => View(db.LopHoc.Where(s => s.MaLop == id).FirstOrDefault());
        //POST: LopHoc/Edit/1
        [HttpPost]
        public ActionResult Edit(string id, LopHoc _lopHoc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(_lopHoc).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Something went wrong, please try again later";
                    return View(_lopHoc);
                }
                return RedirectToAction(nameof(Details) + "/" + id.ToString());
            }
            ViewBag.ModelError = "Wrong";
            return View(_lopHoc);
        }

        //ChiTietLopHoc
        //GET: HocSinh/Details/1
        public ActionResult Details(string id)
            => View(db.LopHoc.Where(s => s.MaLop == id).FirstOrDefault());

        //XoaLopHoc
        //GET: HocSinh/Delete/1
        public ActionResult Delete(string id)
            => View(db.LopHoc.Where(s => s.MaLop == id).FirstOrDefault());
        //POST: HocSinh/Delete/1
        [HttpPost]
        public ActionResult Delete(string id, LopHoc _lopHoc)
        {
            try
            {
                _lopHoc = db.LopHoc.Where(s => s.MaLop == id).FirstOrDefault();
                db.LopHoc.Remove(_lopHoc);
                db.SaveChanges();
            }
            catch
            {
                ViewBag.Error = "Something went wrong, please try again later";
                return View(_lopHoc);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}