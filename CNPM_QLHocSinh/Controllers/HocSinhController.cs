﻿using System;
using System.Linq;
using System.Web.Mvc;
using CNPM_QLHocSinh.Models;
using CNPM_QLHocSinh.Models.ViewModels;

namespace CNPM_QLHocSinh.Controllers
{
    public class HocSinhController : Controller
    {
        private readonly CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();
        
        //ThemHocSinh
        //GET: HocSinh/Create
        public ActionResult Create()
        {
            var viewModel = new HSView
            {
                HocSinh = new HocSinh(),
                LopHocList = db.LopHoc.ToList()
            };
            return View(viewModel);
        }

        //POST: HocSinh/Create
        [HttpPost]
        public ActionResult Create(HSView _hocsinh)
        {
            _hocsinh.LopHocList = db.LopHoc.ToList();
            if (ModelState.IsValid)
            {
                var age = DateTime.Now.Year - _hocsinh.HocSinh.NgaySinh.Year;
                if (age < 6 || age > 80)
                    ModelState.AddModelError("NgaySinh", "Ngày sinh không hợp lệ");
                else
                {
                    try
                    {
                        //Tạo ID
                        _hocsinh.HocSinh.MaHS = GenerateId();
                        //Tạo trạng thái
                        if (_hocsinh.HocSinh.LopHoc == null)
                            _hocsinh.HocSinh.TrangThaiHS = db.TrangThaiHS.FirstOrDefault(s => s.TenTT == "Học sinh mới");
                        else _hocsinh.HocSinh.TrangThaiHS = db.TrangThaiHS.FirstOrDefault(s => s.TenTT == "Còn học");
                        db.HocSinh.Add(_hocsinh.HocSinh);
                        db.SaveChanges();
                    }
                    catch
                    {
                        ViewBag.Error = "Something went wrong, please try again later";
                        return View(_hocsinh);
                    }
                    return RedirectToAction(nameof(Details), new {id=_hocsinh.HocSinh.MaHS});
                }
            }
            ViewBag.ModelError = "Biểu mẫu không đúng";
            return View(_hocsinh);
        }

        //TimHocSinh
        //GET: HocSinh
        public ActionResult Index(string searchHS)
        {
            var hocsinh = from hsinh in db.HocSinh select hsinh;

            if (!String.IsNullOrEmpty(searchHS))
            {
                hocsinh = hocsinh.Where(hsinh => hsinh.MaHS.Contains(searchHS) || hsinh.HoTen.Contains(searchHS));
                ViewBag.SearchHS = searchHS;
            }

            return View(hocsinh.ToList());
        }

        //XemThongTinHocSinh
        //GET: HocSinh/Details/1
        public ActionResult Details(string id)
            => View(db.HocSinh.Where(s => s.MaHS == id).FirstOrDefault());

        //ChinhSuaThongTinHocSinh
        //GET: HocSinh/Edit/1
        public ActionResult Edit(string id)
        {
            if (id == null)
                return HttpNotFound();
            var hs = new HSView
            {
                HocSinh = db.HocSinh.Where(s => s.MaHS == id).FirstOrDefault()
            };
            if (hs.HocSinh == null)
                return HttpNotFound();

            return View(hs);
        }

        //POST: HocSinh/Edit/1
        [HttpPost]
        public ActionResult Edit(string id, HSView _hocsinh)
        {
            if (ModelState.IsValid)
            {
                var age = DateTime.Now.Year - _hocsinh.HocSinh.NgaySinh.Year;
                if (age < 6 && age > 80)
                    ModelState.AddModelError("NgaySinh", "Ngày sinh không hợp lệ");
                else
                {
                    try
                    {
                        db.Entry(_hocsinh.HocSinh).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch
                    {
                        ViewBag.Error = "Something went wrong, please try again later";
                        return View(_hocsinh);
                    }
                    return RedirectToAction(nameof(Details), new { id });
                }
            }
            ViewBag.ModelError = "Biểu mẫu không đúng";
            return View(_hocsinh);
        }


        public ActionResult DieuChinhTrangThaiHocSinh()
            => View();

        //XoaHocSinh
        //GET: HocSinh/Delete/1
        public ActionResult Delete(string id)
            => View(db.HocSinh.Where(s => s.MaHS == id).FirstOrDefault());
        //POST: HocSinh/Delete/1
        [HttpPost]
        public ActionResult Delete(string id, HocSinh _hocsinh)
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

        private string GenerateId()
        {
            int maxId = 1;
            var latestStudent = db.HocSinh.OrderByDescending(h => h.MaHS).FirstOrDefault();
            if (latestStudent != null)
            {
                int.TryParse(latestStudent.MaHS.Substring(2), out maxId);
                maxId++;
            }
            return "HS" + maxId.ToString("D8");
        }

    }
}