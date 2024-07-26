using CNPM_QLHocSinh.Models;
using CNPM_QLHocSinh.Models.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class GiaoVienController : Controller
    {
        private readonly CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();

        // GET: GiaoVien
        public ActionResult Index()
        {
            return View(db.GiaoVien.Include(s => s.ChucVu));
        }

        //ThemGiaoVien
        //GET: GiaoVien/Create
        public ActionResult Create()
        {
            var viewModel = new GVView
            {
                GiaoVien = new GiaoVien(),
                ChucVuList = db.ChucVu.ToList()
            };
            return View(viewModel);
        }
        //POST: GiaoVien/Create
        [HttpPost]
        public ActionResult Create(GVView _giaoVien)
        {
            _giaoVien.ChucVuList = db.ChucVu.ToList();
            if (ModelState.IsValid)
            {
                var age = DateTime.Now.Year - _giaoVien.GiaoVien.NgaySinh.Year;
                if (age < 18 || age > 80)
                    ModelState.AddModelError("NgaySinh", "Ngày sinh không hợp lệ");
                else
                {
                    try
                    {
                        //Tạo ID
                        _giaoVien.GiaoVien.MaGV = GenerateId();
                        db.GiaoVien.Add(_giaoVien.GiaoVien);
                        db.SaveChanges();
                    }
                    catch
                    {
                        ViewBag.Error = "Something went wrong, please try again later";
                        return View(_giaoVien);
                    }
                    return RedirectToAction(nameof(Details), new {id=_giaoVien.GiaoVien.MaGV});
                }
            }
            ViewBag.ModelError = "Biểu mẫu không đúng";
            return View(_giaoVien);
        }

        //XemThongTinGiaoVien
        //GET: GiaoVien/Details/1
        public ActionResult Details(string id)
            => View(db.GiaoVien.Where(s => s.MaGV == id).Include(s => s.ChucVu).FirstOrDefault());

        //ChinhSuaThongTinGiaoVien
        //GET: GiaoVien/Edit/1
        public ActionResult Edit(string id)
            => View(db.GiaoVien.Where(s => s.MaGV == id).Include(s => s.ChucVu).FirstOrDefault());
        //POST: GiaoVien/Edit/1
        [HttpPost]
        public ActionResult Edit(string id, GiaoVien _giaoVien)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(_giaoVien).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Error = "Something went wrong, please try again later";
                    ViewBag.ChucVuList = new SelectList(db.ChucVu, "MaCV", "TenCV");
                    return View(_giaoVien);
                }
                return RedirectToAction(nameof(Details) + "/" + id.ToString());
            }
            ViewBag.ModelError = "Biểu mẫu không đúng";
            ViewBag.ChucVuList = new SelectList(db.ChucVu, "MaCV", "TenCV");
            return View(_giaoVien);
        }

        //XoaGiaoVien
        //GET: GiaoVien/Delete/1
        public ActionResult Delete(string id)
            => View(db.GiaoVien.Where(s => s.MaGV == id).Include(s => s.ChucVu).FirstOrDefault());
        //POST: GiaoVien/Delete/1
        [HttpPost]
        public ActionResult Delete(string id, GiaoVien _giaoVien)
        {
            try
            {
                _giaoVien = db.GiaoVien.Where(s => s.MaGV == id).FirstOrDefault();
                db.GiaoVien.Remove(_giaoVien);
                db.SaveChanges();
            }
            catch
            {
                ViewBag.Error = "Something went wrong, please try again later";
                ViewBag.ChucVuList = new SelectList(db.ChucVu, "MaCV", "TenCV");
                return View(_giaoVien);
            }
            return RedirectToAction(nameof(Index));
        }

        private string GenerateId()
        {
            int maxId = 1;
            var latestStudent = db.GiaoVien.OrderByDescending(h => h.MaGV).FirstOrDefault();
            if (latestStudent != null)
            {
                int.TryParse(latestStudent.MaGV, out maxId);
                maxId++;
            }
            return maxId.ToString("D3");
        }
    }
}