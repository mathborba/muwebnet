using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuwebNET.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("cliente/cadastro")]
        public ActionResult Create()
        {
            var model = new MuwebNET.Models.GameContext.Account();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MuwebNET.Models.GameContext.Account model)
        {
            if(ModelState.IsValid)
            {
                Bll.GameContext.Account.Create(model);
                return Json(new { sucesso = false, id = model.memb___id }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { sucesso = false, id = "" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("cliente/doacao")]
        public ActionResult Donate()
        {
            return View();
        }
    }
}