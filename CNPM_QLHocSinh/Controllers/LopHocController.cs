using CNPM_QLHocSinh.Models;
using CNPM_QLHocSinh.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class LopHocController : Controller
    {
        CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();

        

        // GET: LopHoc
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult XetDuyetLopMoi()
            => View();

        public ActionResult PhanBoLopMoi()
            => View();

        public ActionResult ChuyenLop()
            => View();

        public ActionResult ThemLopHoc()
            => View();

        public ActionResult XemDanhSachLopHoc()
        {
            List<LopHoc> lopHoc = db.LopHoc.ToList();
            List<ViewLopHoc> viewLopHoc = lopHoc.Select(
                    x => new ViewLopHoc
                    {
                        MaLop = x.MaLop,
                        TenLop = x.TenLop,
                        MoTa = x.MoTa,
                        //MaKL = x.KhoiLop.MaKL,
                        TenKL = x.KhoiLop.TenKL
                    }
                ).ToList();
            return View(viewLopHoc);
        }

        public ActionResult ChinhSuaLopHoc()
            => View();

        public ActionResult XoaLopHoc()
            => View();
    }
}