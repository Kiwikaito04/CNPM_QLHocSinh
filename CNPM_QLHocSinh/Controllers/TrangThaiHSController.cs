﻿using CNPM_QLHocSinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class TrangThaiHSController : Controller
    {
        CNPM_QLHocSinhEntities db = new CNPM_QLHocSinhEntities();
        // GET: TrangThaiHS
        public ActionResult Index()
        {
            return View(db.TrangThaiHS);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

    }
}