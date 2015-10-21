using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuwebNET.Controllers
{
    public class NewsController : Controller
    {
        [Route("noticias/{id:int}/{date}/{title}")]
        public ActionResult Index(int id, string date, string title)
        {
            var noticia = Bll.WebContext.WebNews.Get(id);
            return View(noticia);
        }

        [Route("noticia/{id:int}")]
        public ActionResult NewsById(int id)
        {
            var noticia = Bll.WebContext.WebNews.Get(id);
            return View("Index", noticia);
        }
    }
}