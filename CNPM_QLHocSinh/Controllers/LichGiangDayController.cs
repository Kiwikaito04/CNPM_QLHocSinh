using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class LichGiangDayController : Controller
    {
        // GET: LichGiangDay
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ThemLichGiangDay() 
            => View();   

        public ActionResult XemLichGiangDay()
            => View();

        public ActionResult ChinhSuaLichGiangDay()
            => View();

        public ActionResult InLichGiangDay()
            => View();

        public ActionResult XoaLichGiangDay()
            => View();
    
    }
}