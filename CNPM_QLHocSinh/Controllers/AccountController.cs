using CNPM_QLHocSinh.Security;
using System.Data.Entity;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using System.Web;
using CNPM_QLHocSinh.Controllers;
using CNPM_QLHocSinh.Models;
using CNPM_QLHocSinh.Models.ViewModels;
using System.Linq;
using System.Data;

namespace CNPM_QLHocSinh.Controllers
{
    public class AccountController : Controller
    {
        private readonly CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();

        // GET: Account/StudentLogin
        [HttpGet]
        public ActionResult StudentLogin() 
            => View();

        // POST: Account/StudentLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentLogin(StudentLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = db.HocSinh.FirstOrDefault(h => h.MaHS == model.MaHS && h.Pass == model.Password);
                if (student != null)
                {
                    // Perform login logic, e.g., setting authentication cookie
                    SetAuthCookie(student.MaHS, "Student");
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid MaHS or Password.");
            }
            return View(model);
        }

        // GET: Account/TeacherLogin
        [HttpGet]
        public ActionResult TeacherLogin()
        {
            return View();
        }

        // POST: Account/TeacherLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeacherLogin(TeacherLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var teacher = db.GiaoVien.FirstOrDefault(g => g.Email == model.Email && g.Pass == model.Password);
                if (teacher != null)
                {
                    // Perform login logic, e.g., setting authentication cookie
                    var role = db.ChucVu.Where(c => c.MaCV == teacher.MaCV).Select(c => c.TenCV).FirstOrDefault();
                    SetAuthCookie(teacher.Email, role);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Email or Password.");
            }
            return View(model);
        }
        //[HttpGet]
        //public ActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Login(string email, string password)
        //{
        //    // Kiểm tra thông tin đăng nhập trong bảng HocSinh
        //    var student = db.HocSinh.FirstOrDefault(h => h.Email == email && h.Pass == password);
        //    if (student != null)
        //    {
        //        SetAuthCookie(student.Email, student.HoTen, "Student");
        //        return RedirectToAction("Index", "Home");
        //    }

        //    // Kiểm tra thông tin đăng nhập trong bảng GiaoVien
        //    var teacher = db.GiaoVien.FirstOrDefault(g => g.Email == email && g.Pass == password);
        //    if (teacher != null)
        //    {
        //        SetAuthCookie(teacher.Email, teacher.HoTen, "Teacher");
        //        return RedirectToAction("Index", "Home");
        //    }

        //    // Đăng nhập không thành công
        //    ViewBag.Error = "Email hoặc mật khẩu không đúng.";
        //    return View();
        //    }

        private void SetAuthCookie(string name, string role)
        {
            var identity = new CustomIdentity(name, role);
            var principal = new CustomPrincipal(identity);

            Thread.CurrentPrincipal = principal;
            HttpContext.User = principal;

            FormsAuthentication.SetAuthCookie(name, false);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        // GET: Account/AccessDenied
        [HttpGet]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}