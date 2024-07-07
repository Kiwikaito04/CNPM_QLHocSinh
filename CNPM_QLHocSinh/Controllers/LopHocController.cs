using CNPM_QLHocSinh.Models;
using CNPM_QLHocSinh.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class LopHocController : Controller
    {
        CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();

        

        // GET: LopHoc


        public ActionResult XetDuyetLopMoi()
            => View();

        public ActionResult PhanBoLopMoi()
            => View();

        public ActionResult ChuyenLop()
            => View();
        


        //Thêm lớp học
        public ActionResult ThemLopHoc()
            => View();
        [HttpPost]
        public ActionResult ThemLopHoc(LopHoc _lopHoc)
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
                return RedirectToAction("XemDanhSachLopHoc");
            }
            ViewBag.ModelError = "Wrong";
            return View(_lopHoc);
        }



        public ActionResult XemDanhSachLopHoc()
        {
            List<LopHoc> lopHoc = db.LopHoc.ToList();
            List<ViewLopHoc> viewLopHoc = lopHoc.Select(
                    x => new ViewLopHoc
                    {
                        MaLop = x.MaLop,
                        TenLop = x.TenLop,
                        MoTa = x.MoTa,
                        MaKL = x.KhoiLop.MaKL,
                        //TenKL = x.KhoiLop.TenKL
                    }
                ).ToList();
            return View(viewLopHoc);
        }

        public ActionResult ChinhSuaLopHoc(string id)
            => View(db.LopHoc.Where(s => s.MaLop == id).FirstOrDefault());
        [HttpPost]
        public ActionResult ChinhSuaLopHoc(string id, LopHoc _lopHoc)
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
                return RedirectToAction("XemDanhSachLopHoc");
            }
            ViewBag.ModelError = "Wrong";
            return View(_lopHoc);
        }



        public ActionResult XoaLopHoc(string id)
            => View(db.LopHoc.Where(s => s.MaLop == id).FirstOrDefault());
        [HttpPost]
        public ActionResult XoaLopHoc(string id, LopHoc _lopHoc)
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
            return RedirectToAction("XemDanhSachLopHoc");
        }
    }
}