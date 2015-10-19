using System;
using System.Web.Mvc;

namespace MUwebNET.Web.Framework
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString UrlTemplateHelper(string value)
        {
            if (String.IsNullOrEmpty(CustomViewTheme.themeLocation))
            {
                CustomViewTheme.themeLocation = System.Configuration.ConfigurationManager.AppSettings["WebTemplateLocation"].ToString();
            }
            return new MvcHtmlString("/template/" + CustomViewTheme.themeLocation + value);
        }
    }
}