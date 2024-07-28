using CNPM_QLHocSinh.Models;
using CNPM_QLHocSinh.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CNPM_QLHocSinh
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var userID = HttpContext.Current.User.Identity.Name;

                    using (var db = new CNPM_QLHocSinhEntities())
                    {
                        var student = db.HocSinh.FirstOrDefault(h => h.MaHS == userID);
                        if (student != null)
                        {
                            HttpContext.Current.User = new CustomPrincipal(new CustomIdentity(student.MaHS, "Student"));
                            return;
                        }

                        var teacher = db.GiaoVien.FirstOrDefault(g => g.Email == userID);
                        if (teacher != null)
                        {
                            HttpContext.Current.User = new CustomPrincipal(new CustomIdentity(teacher.Email, "Teacher"));
                        }
                    }
                }
            }
        }

    }
}
