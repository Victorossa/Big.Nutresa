namespace Big.Nutresa.Imagix.UI.Controllers
{
    using Big.Nutresa.Imagix.UI.Common.Helpers;
    using Big.Nutresa.Imagix.UI.Common.Models;
    using Filters;
    using System;
    using System.Web.Mvc;
    public class RedemptionController : CustomController
    {
        // GET: Redemption
        public ActionResult MyRedemptions()
        {
            return View();
        }


        public PartialViewResult GetMyRedemptions()
        {
            Request<MyRedemptionRequest> request = new Request<MyRedemptionRequest>
            {
                ObjectRequest = new MyRedemptionRequest
                {
                    ProgramId = Convert.ToInt32(ConfigurationHelper.Get("NetCommerce.Program")),
                    PageSize = Convert.ToInt32(ConfigurationHelper.Get("NetCommerce.GetCatalogGenericFilterV2.PageSize")),
                    PageIndex = Convert.ToInt32(ConfigurationHelper.Get("NetCommerce.GetCatalogGenericFilterV2.PageIndex")),
                    CustomerId = User.Identity.Name
                }
            };
            Response<MyRedemptionResponse> response = ApiService
                .Post<MyRedemptionResponse>(ConfigurationHelper.Get("Proxy.Base"),
                        ConfigurationHelper.Get("Proxy.GetRedemptionByCustomerID"), null, request);

            
            return PartialView("~/Views/Redemption/Partials/_MyRedemptionsData.cshtml", response.ObjectResponse);
        }

    }
}