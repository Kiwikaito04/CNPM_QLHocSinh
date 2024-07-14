using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;
            Response.StatusCode = httpException?.GetHttpCode() ?? 500;
            return View("Error", new HandleErrorInfo(exception, "ControllerName", "ActionName"));
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}