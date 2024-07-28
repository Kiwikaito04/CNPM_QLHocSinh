using System;
using System.Web;
using System.Web.Mvc;

namespace CNPM_QLHocSinh.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedRoles;

        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedRoles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            if (allowedRoles == null || allowedRoles.Length == 0)
            {
                // If no roles are specified, allow any authenticated user
                return httpContext.User.Identity.IsAuthenticated;
            }

            var user = httpContext.User as CustomPrincipal;
            if (user != null)
            {
                foreach (var role in allowedRoles)
                {
                    if (user.IsInRole(role))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary(
                    new { controller = "Account", action = "AccessDenied" }
                )
            );
        }
    }
}
