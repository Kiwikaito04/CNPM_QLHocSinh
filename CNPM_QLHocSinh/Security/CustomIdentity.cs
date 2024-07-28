using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CNPM_QLHocSinh.Security
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(string name, string role)
        {
            Name = name;
            Role = role;
        }

        public string Name { get; private set; }
        public string Role { get; private set; }

        public string AuthenticationType => "Custom";
        public bool IsAuthenticated => !string.IsNullOrEmpty(Name);
    }

}