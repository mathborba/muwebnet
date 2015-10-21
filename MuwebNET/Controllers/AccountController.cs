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
        [MUwebNET.Web.Framework.Filters.VerifyAuthOrPermission()]
        [Route("cliente/minha-conta")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("cliente/cadastro")]
        public ActionResult Create()
        {
            if(SessionManager.Current.Logged)
            {
                ViewBag.Message = "Você não pode criar uma nova conta, enquanto estiver logado!";
                return View("CreateDenied");
            }

            var model = new MuwebNET.Models.GameContext.Account();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MuwebNET.Models.GameContext.Account model)
        {
            var modelErrors = ModelState.Values.SelectMany(m => m.Errors)
                                    .Select(e => e.ErrorMessage)
                                    .ToList();

            if(ModelState.IsValid)
            {
                Bll.GameContext.Account.Create(model);
                return Json(new { sucesso = false, id = model.memb___id }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { sucesso = false, id = "", modelError = modelErrors }, JsonRequestBehavior.AllowGet);
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
                return Json(new { sucesso = false, mensagem = "Erro ao processar autenticação.", modelError = ex.Message }, JsonRequestBehavior.AllowGet);
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