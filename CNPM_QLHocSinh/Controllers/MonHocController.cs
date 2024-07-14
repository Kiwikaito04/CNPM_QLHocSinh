using CNPM_QLHocSinh.Models;
using CNPM_QLHocSinh.Models.ViewModels;
using Microsoft.Ajax.Utilities;
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

        private string GenerateMaMH()
        {
            var lastMonHoc = db.MonHoc
                .OrderByDescending(mh => mh.MaMH)
                .FirstOrDefault();

            int newNumber = 1;
            if (lastMonHoc != null)
            {
                int.TryParse(lastMonHoc.MaMH, out newNumber);
                newNumber++;
            }

            return newNumber.ToString("D2");
        }

        //ThemDanhMucMonHoc
        //GET: MonHoc/Create
        public ActionResult Create()
           => View();
        //POST: MonHoc/Create
        [HttpPost]
        public ActionResult Create(MHView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.MoTa.IsNullOrWhiteSpace())
            {
                model.MoTa = $"Môn học {model.TenMH}";
            }
            
            var _monHoc = new MonHoc
            {
                MaMH = GenerateMaMH(),
                TenMH = model.TenMH,
                MoTa = model.MoTa
            };

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

        //XemThongTinMon
        //GET: MonHoc/Details/1
        public ActionResult Details(string id)
            => View(db.MonHoc.Where(s => s.MaMH == id).FirstOrDefault());

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
                return RedirectToAction(nameof(Details) + "/" + id.ToString());
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