using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MUwebNET.Web.Framework
{
    public static class CustomViewTheme
    {
        public static string themeLocation { get; set; }
    }

    public class MuWebCustomViewLocationRazorViewEngine : RazorViewEngine
    {
        private string templateLocation { get; set; }
        public MuWebCustomViewLocationRazorViewEngine()
        {
            templateLocation = ConfigurationManager.AppSettings["WebTemplateLocation"].ToString();
            CustomViewTheme.themeLocation = templateLocation;

            ViewLocationFormats = new[] 
            {
                "~/template/" + templateLocation + "/Views/{1}/{0}.cshtml", 
                "~/template/" + templateLocation + "/Views/{1}/{0}.vbhtml",
                "~/template/" + templateLocation + "/Views/_Common/{0}.cshtml", 
                "~/template/" + templateLocation + "/Views/_Common/{0}.vbhtml"
            };

            MasterLocationFormats = new[] 
            {
                "~/template/" + templateLocation + "/Views/{1}/{0}.cshtml", 
                "~/template/" + templateLocation + "/Views/{1}/{0}.vbhtml",
                "~/template/" + templateLocation + "/Views/_Common/{0}.cshtml", 
                "~/template/" + templateLocation + "/Views/_Common/{0}.vbhtml"
            };

            PartialViewLocationFormats = new[] 
            {
                "~/template/" + templateLocation + "/Views/{1}/{0}.cshtml", 
                "~/template/" + templateLocation + "/Views/{1}/{0}.vbhtml",
                "~/template/" + templateLocation + "/Views/_Common/{0}.cshtml", 
                "~/template/" + templateLocation + "/Views/_Common/{0}.vbhtml"
            };
        }
    }
}
