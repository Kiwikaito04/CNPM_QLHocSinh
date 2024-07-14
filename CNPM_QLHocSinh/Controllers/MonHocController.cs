using CNPM_QLHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CNPM_QLHocSinh.Controllers
{
    public class MonHocController : Controller
    {
        CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();

        //XemDanhMucMonHoc
        //GET: MonHoc
        public ActionResult Index() => View(db.MonHoc);

        //ThemDanhMucMonHoc
        //GET: MonHoc/Create
        public ActionResult Create()
           => View();
        //POST: MonHoc/Create
        [HttpPost]
        public ActionResult Create(MonHoc _monHoc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.MonHoc.Add(_monHoc);
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Something went wrong, please try again later";
                    return View(_monHoc);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ModelError = "Wrong";
            return View(_monHoc);
        }

        //ChinhSuaDanhMucMonHoc
        //GET: MonHoc/Edit/1
        public ActionResult Edit(string id)
            => View(db.MonHoc.Where(s => s.MaMH == id).FirstOrDefault());
        //POST: MonHoc/Edit/1
        [HttpPost]
        public ActionResult Edit(string id, MonHoc _monHoc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(_monHoc).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Something went wrong, please try again later";
                    return View(_monHoc);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ModelError = "Wrong";
            return View(_monHoc);
        }

        //XoaDanhMucMonHoc 
        //GET: MonHoc/Delete/1
        public ActionResult Delete(string id)
            => View(db.MonHoc.Where(s => s.MaMH == id).FirstOrDefault());
        //POST: MonHoc/Delete/1
        [HttpPost]
        public ActionResult Delete(string id, MonHoc _monHoc)
        {
            try
            {
                _monHoc = db.MonHoc.Where(s => s.MaMH == id).FirstOrDefault();
                db.MonHoc.Remove(_monHoc);
                db.SaveChanges();
            }
            catch
            {
                ViewBag.Error = "Something went wrong, please try again later";
                return View(_monHoc);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}