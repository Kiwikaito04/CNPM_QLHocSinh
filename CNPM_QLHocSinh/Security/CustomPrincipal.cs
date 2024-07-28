using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CNPM_QLHocSinh.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity _identity;

        public CustomPrincipal(CustomIdentity identity)
        {
            _identity = identity;
        }

        public IIdentity Identity => _identity;

        public bool IsInRole(string role)
        {
            return _identity.Role.Equals(role, StringComparison.OrdinalIgnoreCase);
        }
    }

}