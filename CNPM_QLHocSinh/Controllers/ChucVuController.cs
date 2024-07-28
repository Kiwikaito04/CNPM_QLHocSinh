using CNPM_QLHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class ChucVuController : Controller
    {
        private readonly CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();
        // GET: ChucVu
        public ActionResult Index()
        {
            return View(db.ChucVu);
        }
    }
}