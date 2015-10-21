using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuwebNET.Controllers
{
    public class DownloadsController : Controller
    {
        [Route("downloads")]
        // GET: Downloads
        public ActionResult Index()
        {
            string cacheName = "muNet_webDownloads";

            List<Models.WebContext.WebDownloads> model = new List<Models.WebContext.WebDownloads>();
            if (!cacheName.HasCache())
            {
                model = Bll.WebContext.WebDownloads.GetDownloads();
                model.AddCache(cacheName, DateTime.Now.AddHours(2));
            }
            else
                model = model.GetCache(cacheName);

            return View(model);
        }
    }
}