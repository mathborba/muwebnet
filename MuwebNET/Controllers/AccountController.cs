using MUwebNET.Web.Framework;
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

        [HttpPost]
        public ActionResult Login(string usuario, string senha)
        {
            try
            {
                SessionManager.Logon(usuario, senha);

                if (SessionManager.Current.Logged)
                {
                    return Json(new { sucesso = true, mensagem = "Bem-vindo(a) " + SessionManager.Current.Name }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { sucesso = false, mensagem = "Dados de autenticação incorretos ou usuário inexistente." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { sucesso = false, mensagem = "Erro ao processar autenticação." }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("cliente/sair")]
        public ActionResult LogOut()
        {
            SessionManager.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}