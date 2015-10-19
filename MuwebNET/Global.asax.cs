using MUwebNET.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MuwebNET
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Register Areas
            AreaRegistration.RegisterAllAreas();

            // Custom Views Folder to create template System
            ViewEngines.Engines.Clear();

            var muViewEngine = new MuWebCustomViewLocationRazorViewEngine();
            ViewEngines.Engines.Add(muViewEngine);

            // Register Routes, Filters and Bundles
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
