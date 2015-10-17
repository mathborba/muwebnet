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
            var downloads = Bll.WebContext.WebDownloads.GetDownloads();
            return View(downloads);
        }
    }
}