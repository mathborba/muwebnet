using MuwebNET.Models.GameContext;
using MUwebNET.Web.Framework.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuwebNET.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration=10,Location=System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            var model = Bll.WebContext.WebNews.GetNewsHomepage();
            return View(model);
        }

        public PartialViewResult IndexSliders()
        {
            var model = Bll.WebContext.WebSlider.GetSlidersHomepage();
            return PartialView("Partials/SlidersPartial", model);
        }

        [VerifyAuthOrPermission]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}