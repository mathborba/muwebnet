using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuwebNET.Controllers
{
    public class CacheController : Controller
    {
        //
        // GET: /Cache/
        [Route("cache/limpar-cache")]
        public ActionResult Index()
        {
            CacheExtension.ClearCache();
            return RedirectToAction("Index", "Home");
        }
	}
}