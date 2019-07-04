using Big.Nutresa.Imagix.UI.Common.Helpers;
using Big.Nutresa.Imagix.UI.Common.Models;
using Big.Nutresa.Imagix.UI.Filters;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Big.Nutresa.Imagix.UI.Controllers.User
{
    public class ProfileController : CustomController
    {
        // GET: Profile
        public ActionResult Index()
        {
            ViewBag.StartUpScript = TempData["StartUpScript"]?.ToString();
            return View();
        }
        public ActionResult ModifyShippingInfo(string id)
        {
            ViewBag.StartUpScript = TempData["StartUpScript"]?.ToString();
            return View();
        }


        #region Method Post 
        [HttpPost]
        public ActionResult DeleteShippingInfo(string id)
        {
            //Shipping Info GUID
            if (string.IsNullOrEmpty(id))
            {
                TempData["StartUpScript"] = string.Format("jQuery(showMask('Pendiente','Error multiLeng'))");
                return RedirectToAction("Index", "Profile");
            }

            Request<string> request = new Request<string>
            {
                ObjectRequest = id
            };
            Response<List<ShippingInfoResponse>> response = ApiService
               .Post<List<ShippingInfoResponse>>(ConfigurationHelper.Get("Proxy.Base"),
                       ConfigurationHelper.Get("Proxy.DeleteShippingInformation"), null, request);

            return RedirectToAction("Index", "Profile");

        } 
        #endregion

   

        #region Partials
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public PartialViewResult GetAllShippingInfo()
        {
            //Current Customer ID.
            Request<string> request = new Request<string>
            {
                ObjectRequest = "221ea0b2-6a56-450d-bcb7-7fa110ea0da1"
            };
            Response<List<ShippingInfoResponse>> response = ApiService
               .Post<List<ShippingInfoResponse>>(ConfigurationHelper.Get("Proxy.Base"),
                       ConfigurationHelper.Get("Proxy.GetAllShippingInformation"), null, request);

            return PartialView("~/Views/Profile/Partials/_ShippingInfo.cshtml", response.ObjectResponse);

        }

        public PartialViewResult PartialModifyShippingInfo(string id)
        {
            //Current Customer ID.
            Request<string> request = new Request<string>
            {
                ObjectRequest = id
            };
            Response<ShippingInfoResponse> response = ApiService
               .Post<ShippingInfoResponse>(ConfigurationHelper.Get("Proxy.Base"),
                       ConfigurationHelper.Get("Proxy.GetShippingInformation"), null, request);

            return PartialView("~/Views/Profile/Partials/_ModifyShippingInfo.cshtml", response.ObjectResponse);

        }

        #endregion
    }
}