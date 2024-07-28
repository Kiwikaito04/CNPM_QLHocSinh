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
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    LichGiangDay lichGiangDay = db.LichGiangDay.Find(id);
        //    if (lichGiangDay == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(lichGiangDay);
        //}

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLop,MaMH,MaGV,MaCa")] LichGiangDay lichGiangDay)
        {
            ViewBag.MaCa = new SelectList(db.CaHoc, "MaCa", "MaCa", lichGiangDay.MaCa);
            ViewBag.MaGV = new SelectList(db.GiaoVien, "MaGV", "HoTen", lichGiangDay.MaGV);
            ViewBag.MaLop = new SelectList(db.LopHoc, "MaLop", "TenLop", lichGiangDay.MaLop);
            ViewBag.MaMH = new SelectList(db.MonHoc, "MaMH", "TenMH", lichGiangDay.MaMH);
            
            if (ModelState.IsValid)
            {
                var existingEntry = db.LichGiangDay.FirstOrDefault(
                    l => l.MaLop == lichGiangDay.MaLop &&
                         l.MaMH == lichGiangDay.MaMH &&
                         l.MaGV == lichGiangDay.MaGV &&
                         l.MaCa == lichGiangDay.MaCa);

                if (existingEntry != null)
                {
                    ViewBag.ModelError = "Lịch bị trùng!";
                }
                else
                {
                    var teacherConflict = db.LichGiangDay.Any(l => l.MaGV == lichGiangDay.MaGV && l.MaCa == lichGiangDay.MaCa &&
                                                        !(l.MaLop == lichGiangDay.MaLop && l.MaMH == lichGiangDay.MaMH && l.MaGV == lichGiangDay.MaGV && l.MaCa == lichGiangDay.MaCa));

                    var classConflict = db.LichGiangDay.Any(l => l.MaLop == lichGiangDay.MaLop && l.MaCa == lichGiangDay.MaCa &&
                                                                  !(l.MaLop == lichGiangDay.MaLop && l.MaMH == lichGiangDay.MaMH && l.MaGV == lichGiangDay.MaGV && l.MaCa == lichGiangDay.MaCa));

                    if (teacherConflict)
                    {
                        ViewBag.ModelError = "Giáo viên không thể dạy hai lớp trong cùng một ca!";
                    }
                    else if (classConflict)
                    {
                        ViewBag.ModelError = "Một lớp chỉ có thể học một môn trong một ca!";
                    }
                    else
                    try
                    {
                        db.LichGiangDay.Add(lichGiangDay);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        ViewBag.Error = "Something went wrong, please try again later";
                    }
                }
            }
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
            ViewBag.MaCa = new SelectList(db.CaHoc, "MaCa", "MaCa", lichGiangDay.MaCa);
            ViewBag.MaGV = new SelectList(db.GiaoVien, "MaGV", "HoTen", lichGiangDay.MaGV);
            ViewBag.MaLop = new SelectList(db.LopHoc, "MaLop", "TenLop", lichGiangDay.MaLop);
            ViewBag.MaMH = new SelectList(db.MonHoc, "MaMH", "TenMH", lichGiangDay.MaMH);

            if (ModelState.IsValid)
            {
                var existingEntry = db.LichGiangDay.AsNoTracking().FirstOrDefault(
                    l => l.MaLop == lichGiangDay.MaLop &&
                            l.MaMH == lichGiangDay.MaMH &&
                            l.MaGV == lichGiangDay.MaGV);

                if (existingEntry != null)
                {
                    //Nếu tồn tại lịch
                    var teacherConflict = db.LichGiangDay.Any(l => l.MaGV == lichGiangDay.MaGV && l.MaCa == lichGiangDay.MaCa &&
                                                        !(l.MaLop == lichGiangDay.MaLop && l.MaMH == lichGiangDay.MaMH && l.MaGV == lichGiangDay.MaGV && l.MaCa == lichGiangDay.MaCa));

                    var classConflict = db.LichGiangDay.Any(l => l.MaLop == lichGiangDay.MaLop && l.MaCa == lichGiangDay.MaCa &&
                                                                  !(l.MaLop == lichGiangDay.MaLop && l.MaMH == lichGiangDay.MaMH && l.MaGV == lichGiangDay.MaGV && l.MaCa == lichGiangDay.MaCa));

                    if (teacherConflict)
                    {
                        ViewBag.ModelError = "Giáo viên không thể dạy hai lớp trong cùng một ca!";
                    }
                    else if (classConflict)
                    {
                        ViewBag.ModelError = "Một lớp chỉ có thể học một môn trong một ca!";
                    }
                    else
                    {
                        try
                        {
                            db.Entry(lichGiangDay).State = EntityState.Modified;
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        catch
                        {
                            ViewBag.Error = "Something went wrong, please try again later";
                        }
                    }
                }
                else
                {
                    //Nếu không tồn tại lịch, tạo lịch mới
                    return RedirectToAction(nameof(Create), new { lichGiangDay });
                }
            }
            return View(lichGiangDay);
        }

        // GET: LichGiangDay/Delete/5
        public ActionResult Delete(string MaLop, string MaMH, string MaGV, string MaCa)
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
            return View(lichGiangDay);
        }

        // POST: LichGiangDay/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string MaLop, string MaMH, string MaGV, string MaCa, LichGiangDay lichGiangDay)
        {
            try
            {
                lichGiangDay = db.LichGiangDay
                    .Where(s => s.MaLop == MaLop && s.MaMH == MaMH && s.MaGV == MaGV && s.MaCa == MaCa)
                    .FirstOrDefault();
                db.LichGiangDay.Remove(lichGiangDay);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Error = "Something went wrong, please try again later";
            }
            return View(lichGiangDay);
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
