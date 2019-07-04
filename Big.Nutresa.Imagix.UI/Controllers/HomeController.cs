namespace Big.Nutresa.Imagix.UI.Controllers
{
    using System.Web.Mvc;
    using Filters;
    using Helpers;
    public class HomeController : CustomController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ChangeLanguage(string lang,string ReturnUrl)
        {
            new LanguageMang().SetLanguage(lang);
            if (Url.IsLocalUrl(ReturnUrl))
                return Redirect(ReturnUrl);
                
            else
                
                return RedirectToAction("Index", "Home");


        }
    }
}