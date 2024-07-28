using CNPM_QLHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class QuanLyDiemBoMonController : Controller
    {
        CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();
        // GET: QuanLyDiemBoMon
        public ActionResult Index()
        {
            return View(db.BangDiem);
        }

        public ActionResult NhapDiem()
            => View();

        public ActionResult ChinhSuaDiem()
            => View();
    }
}