using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PortalLivros.Model;
using PortalLivros.Model.Repositories;

namespace PortalLivros.Web.Controllers
{
    public class LoginController : Controller
    {
        RepositoryUsuario repositoryUsuario = new RepositoryUsuario();
        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult RealizaLogin(USUARIO oUsuario, string returnUrl)
        {
            var dadosLogin = repositoryUsuario.VerificaLogin(oUsuario.Usuario, oUsuario.Senha);
            if (dadosLogin != null)
            {
                FormsAuthentication.SetAuthCookie(dadosLogin.Usuario, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Signin");
                }
            }
            else
            {
                ModelState.AddModelError("", "Usuario ou Senha inválidos!!");
                
            }
            return View();
         }


    }
}
