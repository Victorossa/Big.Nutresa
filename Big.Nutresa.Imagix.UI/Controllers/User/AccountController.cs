using Big.Nutresa.Imagix.Business.HttpWebRequestUser;
using Big.Nutresa.Imagix.UI.Common.Helpers;
using Big.Nutresa.Imagix.UI.Common.Models;
using Big.Nutresa.Imagix.UI.Common.Request;
using Big.Nutresa.Imagix.UI.Common.Response;
using Big.Nutresa.Imagix.UI.Filters;
using Big.Nutresa.Imagix.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Big.Nutresa.Imagix.UI.Controllers.User
{
    public class AccountController : CustomController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {   
            if (ModelState.IsValid)
            {
                //Consultar Service Nutresa.
                ParGetUserData par = new ParGetUserData
                {
                    Body = new ParGetUserDataBody
                    {
                        usuario = Convert.ToString(ConfigurationHelper.Get("ServNutresa.Usuario")),
                        clave = Convert.ToString(ConfigurationHelper.Get("ServNutresa.Clave")),
                        password = login.Password,
                        userName = login.Email
                    }
                };

                string serialize = SerializerXML.Serialize<ParGetUserData>(par);
                string action = Convert.ToString(ConfigurationHelper.Get("ServNutresa.GetUserData"));
                string service = Convert.ToString(ConfigurationHelper.Get("ServNutresa.UrlUserData"));
                UserData userData = new UserData();

                RespUser envelope = HttpWebRequestGeneric.ConsumeServiceUserByAction<RespUser>(action, serialize, service);
                userData = CastObjects.ConvertItemValueItemItem<UserData>(envelope.Body.getUserDataReturn);

                FormsAuthentication.SetAuthCookie("221ea0b2-6a56-450d-bcb7-7fa110ea0da1", true);

                //if (Url.IsLocalUrl(ReturnUrl))
                //    //return Redirect(ReturnUrl);
                //    return RedirectToAction("MyRedemptions", "Redemption");
                //else
                //    //return RedirectToAction("Index", "Profile");
                //    return RedirectToAction("MyRedemptions", "Redemption");    
                return RedirectToAction("MyRedemptions", "Redemption");
            }
            else
            {                    
                return View();
            }
            

        }
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.StartUpScript = TempData["StartUpScript"]?.ToString();
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

    }
}