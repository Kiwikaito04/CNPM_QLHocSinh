using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class HocSinhController : Controller
    {
        // GET: HocSinh
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TimHocSinh()
            => View();

    }
}