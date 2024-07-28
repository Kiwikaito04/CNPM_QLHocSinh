using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNPM_QLHocSinh.Models;

namespace CNPM_QLHocSinh.Controllers
{
    public class LichGiangDayController : Controller
    {
        private readonly CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();

        // GET: LichGiangDay
        public ActionResult Index(string MaLop, string MaMH, string MaGV, string MaCa)
        {
            var lichGiangDay = db.LichGiangDay
                .Include(l => l.CaHoc)
                .Include(l => l.GiaoVien)
                .Include(l => l.LopHoc)
                .Include(l => l.MonHoc);

            //Filter
            if (!string.IsNullOrEmpty(MaLop))
            {
                lichGiangDay = lichGiangDay.Where(l => l.MaLop == MaLop);
            }
            if (!string.IsNullOrEmpty(MaMH))
            {
                lichGiangDay = lichGiangDay.Where(l => l.MaMH == MaMH);
            }
            if (!string.IsNullOrEmpty(MaGV))
            {
                lichGiangDay = lichGiangDay.Where(l => l.MaGV == MaGV);
            }
            if (!string.IsNullOrEmpty(MaCa))
            {
                lichGiangDay = lichGiangDay.Where(l => l.MaCa == MaCa);
            }

            //Danh sách lọc
            ViewBag.MaLop = new SelectList(db.LopHoc, "MaLop", "TenLop");
            ViewBag.MaMH = new SelectList(db.MonHoc, "MaMH", "TenMH");
            ViewBag.MaGV = new SelectList(db.GiaoVien, "MaGV", "HoTen");
            ViewBag.MaCa = new SelectList(db.CaHoc, "MaCa", "MaCa");

            return View(lichGiangDay.ToList());
        }

        // GET: LichGiangDay/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichGiangDay lichGiangDay = db.LichGiangDay.Find(id);
            if (lichGiangDay == null)
            {
                return HttpNotFound();
            }
            return View(lichGiangDay);
        }

        // GET: LichGiangDay/Create
        public ActionResult Create()
        {
            ViewBag.MaCa = new SelectList(db.CaHoc, "MaCa", "MaCa");
            ViewBag.MaGV = new SelectList(db.GiaoVien, "MaGV", "HoTen");
            ViewBag.MaLop = new SelectList(db.LopHoc, "MaLop", "TenLop");
            ViewBag.MaMH = new SelectList(db.MonHoc, "MaMH", "TenMH");
            return View();
        }

        // POST: LichGiangDay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLop,MaMH,MaGV,MaCa")] LichGiangDay lichGiangDay)
        {
            if (ModelState.IsValid)
            {
                db.LichGiangDay.Add(lichGiangDay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCa = new SelectList(db.CaHoc, "MaCa", "MaCa", lichGiangDay.MaCa);
            ViewBag.MaGV = new SelectList(db.GiaoVien, "MaGV", "HoTen", lichGiangDay.MaGV);
            ViewBag.MaLop = new SelectList(db.LopHoc, "MaLop", "TenLop", lichGiangDay.MaLop);
            ViewBag.MaMH = new SelectList(db.MonHoc, "MaMH", "TenMH", lichGiangDay.MaMH);
            return View(lichGiangDay);
        }

        // GET: LichGiangDay/Edit
        public ActionResult Edit(string MaLop, string MaMH, string MaGV, string MaCa)
        {
            if (MaLop == null || MaMH == null || MaGV == null || MaCa == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichGiangDay lichGiangDay = db.LichGiangDay
                   .FirstOrDefault(l => l.MaLop == MaLop && l.MaMH == MaMH && l.MaGV == MaGV && l.MaCa == MaCa);
            if (lichGiangDay == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCa = new SelectList(db.CaHoc, "MaCa", "MaCa", lichGiangDay.MaCa);
            ViewBag.MaGV = new SelectList(db.GiaoVien, "MaGV", "HoTen", lichGiangDay.MaGV);
            ViewBag.MaLop = new SelectList(db.LopHoc, "MaLop", "TenLop", lichGiangDay.MaLop);
            ViewBag.MaMH = new SelectList(db.MonHoc, "MaMH", "TenMH", lichGiangDay.MaMH);
            return View(lichGiangDay);
        }

        // POST: LichGiangDay/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLop,MaMH,MaGV,MaCa")] LichGiangDay lichGiangDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichGiangDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCa = new SelectList(db.CaHoc, "MaCa", "MaCa", lichGiangDay.MaCa);
            ViewBag.MaGV = new SelectList(db.GiaoVien, "MaGV", "HoTen", lichGiangDay.MaGV);
            ViewBag.MaLop = new SelectList(db.LopHoc, "MaLop", "TenLop", lichGiangDay.MaLop);
            ViewBag.MaMH = new SelectList(db.MonHoc, "MaMH", "TenMH", lichGiangDay.MaMH);
            return View(lichGiangDay);
        }


        // GET: LichGiangDay/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichGiangDay lichGiangDay = db.LichGiangDay.Find(id);
            if (lichGiangDay == null)
            {
                return HttpNotFound();
            }
            return View(lichGiangDay);
        }

        // POST: LichGiangDay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LichGiangDay lichGiangDay = db.LichGiangDay.Find(id);
            db.LichGiangDay.Remove(lichGiangDay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
