using Hangfire.Dashboard;
using Microsoft.Owin;
using MUwebNET.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MuwebNET
{
    public class HangFireAuthorizationFilter : IAuthorizationFilter
    {
        public bool Authorize(IDictionary<string, object> owinEnvironment)
        {
            bool authorized = false;
            var user = SessionManager.Current;

            if (user != null)
            {
                if (user.Logged && user.CtlCode >= 8)
                    authorized = true;
            }
            return authorized;
        }
    }
}
