using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNPM_QLHocSinh.Models;
using CNPM_QLHocSinh.Models.ViewModels;

namespace CNPM_QLHocSinh.Controllers
{
    public class KhoiLopController : Controller
    {
        CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();

        private void getAvailableKL()
        {
            var listKhoiLop = db.KhoiLop.Select(k => k.CapBac).ToList();
            var availableNumbers = Enumerable.Range(1, 9).Except(listKhoiLop).ToList();
            ViewBag.AvailableNumbers = availableNumbers;
        }

        //ThemKhoiLop
        //GET: KhoiLop/Create
        public ActionResult Create()
        {
            getAvailableKL();
            var model = new KLView();
            return View(model);
        }

        //POST: KhoiLop/Create
        [HttpPost]
        public ActionResult Create(KLView model)
        {
            getAvailableKL();

            if (model.SelectedNumber == null || model.SelectedNumber < 1 || model.SelectedNumber > 9)
            {
                ModelState.AddModelError("SelectedNumber", "Vui lòng chọn số khả dụng.");
                return View(model);
            }

            var _khoiLop = new KhoiLop
            {
                MaKL = "K" + model.SelectedNumber,
                TenKL = "Khối " + model.SelectedNumber,
                MoTa = "Danh mục khối lớp " + model.SelectedNumber,
                CapBac = model.SelectedNumber.Value
            };

            try
            {
                db.KhoiLop.Add(_khoiLop);
                db.SaveChanges();
            }
            catch 
            {
                ViewBag.Error = "Something went wrong, please try again later";
                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        //XemKhoiLop
        //GET: KhoiLop
        public ActionResult Index()
            => View(db.KhoiLop);

        //XemThongTinKhoi
        //GET: KhoiLop/Details/1
        public ActionResult Details(string id)
            => View(db.KhoiLop.Where(s => s.MaKL == id).FirstOrDefault());

        //ChinhSuaKhoiLop
        //GET: KhoiLop/Edit/1
        public ActionResult Edit(string id)
            => View(db.KhoiLop.Where(s => s.MaKL == id).FirstOrDefault());
        //POST: KhoiLop/Edit/1
        [HttpPost]
        public ActionResult Edit(string id, KhoiLop _khoiLop)
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
                return RedirectToAction(nameof(Details) + "/" + id.ToString());
            }
            ViewBag.ModelError = "Biểu mẫu không đúng";
            return View(_khoiLop);
        }

        //XoaKhoiLop
        //GET: KhoiLop/Delete/1
        public ActionResult Delete(string id)
            => View(db.KhoiLop.Where(s => s.MaKL == id).FirstOrDefault());
        //POST: KhoiLop/Delete/1
        [HttpPost]
        public ActionResult Delete(string id, KhoiLop _khoiLop)
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
            return RedirectToAction(nameof(Index));
        }
    }
}