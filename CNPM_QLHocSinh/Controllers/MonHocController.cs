using CNPM_QLHocSinh.Models.ViewModels;
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
        // GET: MonHoc
        public ActionResult Index() => View(db.MonHoc);

        //Add
        public ActionResult ThemDanhMucMonHoc()
           => View();
        [HttpPost]
        public ActionResult ThemDanhMucMonHoc(MonHoc _monHoc)
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




        //Edit
        public ActionResult ChinhSuaDanhMucMonHoc(string id)
            => View(db.MonHoc.Where(s => s.MaMH == id).FirstOrDefault());
        [HttpPost]

        public ActionResult ChinhSuaDanhMucMonHoc(string id, MonHoc _monHoc)
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



        //Delete
        public ActionResult XoaDanhMucMonHoc(string id)
            => View(db.MonHoc.Where(s => s.MaMH == id).FirstOrDefault());
        [HttpPost]
        public ActionResult XoaDanhMucMonHoc(string id, MonHoc _monHoc)
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