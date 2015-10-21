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
        public ActionResult Index()
        {
            string cacheName = "muNet_webNewsHome";

            List<Models.WebContext.WebNews> model = new List<Models.WebContext.WebNews>();
            if (!cacheName.HasCache())
            {
                model = Bll.WebContext.WebNews.GetNewsHomepage();
                model.AddCache(cacheName, DateTime.Now.AddMinutes(30));
            }
            else
                model = model.GetCache(cacheName);

            return View(model);
        }

        public PartialViewResult IndexSliders()
        {
            string cacheName = "muNet_webSlidersHome";

            List<Models.WebContext.WebSlider> model = new List<Models.WebContext.WebSlider>();
            if (!cacheName.HasCache())
            {
                model = Bll.WebContext.WebSlider.GetSlidersHomepage();
                model.AddCache(cacheName, DateTime.Now.AddMinutes(30));
            }
            else
                model = model.GetCache(cacheName);

            return PartialView("Partials/SlidersPartial", model);
        }
    }
}