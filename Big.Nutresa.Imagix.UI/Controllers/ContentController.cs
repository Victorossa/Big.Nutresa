using Big.Nutresa.Imagix.Business.BLL;
using Big.Nutresa.Imagix.UI.Common.Helpers;
using Big.Nutresa.Imagix.UI.Common.Models;
using Big.Nutresa.Imagix.UI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Big.Nutresa.Imagix.UI.Controllers
{
    public class ContentController : CustomController
    {
         ConfigurationGroupBLL configurationGroupBLL;
        
        public ContentController()
        {
            configurationGroupBLL = new ConfigurationGroupBLL();
            configurationGroupBLL.ProgramId = Convert.ToInt32(ConfigurationHelper.Get("Program"));
        }
        public ActionResult FAQS()
        {
            return View();
        }

        public ActionResult TyC()
        {
            //HttpCookie langCookie = Request.Cookies["culture"];
            return View();
        }
        public PartialViewResult GetTyC()
        {          
            return PartialView("~/Views/Content/Partials/_TyC.cshtml", "");
        }
        public PartialViewResult GetFAQS()
        {
            configurationGroupBLL.Path = "FAQS";
            configurationGroupBLL.Idiom = Request.Cookies["culture"].Value;
            ContentProviderSettingModel result = (ContentProviderSettingModel)configurationGroupBLL.GetContent();
            List<FAQ> content = result.Content.Cast<FAQ>().ToList();


            return PartialView(result.StandarContent.viewNameUrl,content);
        }

    }
}

