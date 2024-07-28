using CNPM_QLHocSinh.Models;
using CNPM_QLHocSinh.Models.ViewModels;
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
        private readonly CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();

        public ActionResult XetDuyetLopMoi()
            => View();

        public ActionResult PhanBoLopMoi()
            => View();

        public ActionResult ChuyenLop()
            => View();

        private string GenerateMaLop(int selectedNumber, string selectedMaKL)
        {
            var lastLopHoc = db.LopHoc
                .Where(l => l.MaKL == selectedMaKL)
                .OrderByDescending(l => l.MaLop)
                .FirstOrDefault();

            int newNumber = 1;
            if (lastLopHoc != null)
            {
                int.TryParse(lastLopHoc.MaLop.Substring(1), out newNumber);
                newNumber++;
            }

            return $"{selectedNumber}{newNumber}";
        }
        private LHView getLHView()
        {
            return new LHView
            {
                AvailableNumbers = Enumerable.Range(1, 20),
                DSKhoiLop = db.KhoiLop.ToList()
            };
        }

        //ThemLopHoc
        //GET: LopHoc/Create
        public ActionResult Create()
        {
            LHView viewModel = getLHView();
            return View(viewModel);
        }

        //POST: LopHoc/Create
        [HttpPost]
        public ActionResult Create(LHView _lopHoc)
        {
            if (!ModelState.IsValid)
            {
                _lopHoc = getLHView();
                return View(_lopHoc);
            }

            var tenLop = $"{_lopHoc.SelectedMaKL.Remove(0, 1)}A{_lopHoc.SelectedNumber}";
            if (db.LopHoc.Any(s => s.TenLop == tenLop))
            {
                ViewBag.ModelError = "Lớp đã tồn tại";
                _lopHoc = getLHView();
                return View(_lopHoc);
            }

            var lopHoc = new LopHoc
            {
                MaLop = GenerateMaLop(_lopHoc.SelectedNumber, _lopHoc.SelectedMaKL),
                TenLop = $"{_lopHoc.SelectedMaKL.Remove(0,1)}A{_lopHoc.SelectedNumber}",
                MoTa = $"Khối {_lopHoc.SelectedMaKL.Remove(0, 1)}, Lớp số {_lopHoc.SelectedNumber}",
                MaKL = _lopHoc.SelectedMaKL
            };

            try
            {
                db.LopHoc.Add(lopHoc);
                db.SaveChanges();
            }
            catch
            {
                _lopHoc = getLHView();
                ViewBag.Error = "Something went wrong, please try again later";
                return View(_lopHoc);
            }
            return RedirectToAction(nameof(Index));
        }

        //XemDanhSachLopHoc
        //GET: LopHoc
        public ActionResult Index() 
            => View(db.LopHoc.Include(s => s.KhoiLop).ToList());

        //ChiTietLopHoc
        //GET: HocSinh/Details/1
        public ActionResult Details(string id)
            => View(db.LopHoc.Where(s => s.MaLop == id).FirstOrDefault());

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
                    db.Entry(_lopHoc).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Something went wrong, please try again later";
                    return View(_lopHoc);
                }
                return RedirectToAction(nameof(Details), new {id});
            }
            ViewBag.ModelError = "Biểu mẫu không đúng";
            return View(_lopHoc);
        }

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