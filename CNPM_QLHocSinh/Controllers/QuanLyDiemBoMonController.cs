using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class QuanLyDiemBoMonController : Controller
    {
        // GET: QuanLyDiemBoMon
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NhapDiem()
            => View();

        public ActionResult ChinhSuaDiem()
            => View();
    }
}