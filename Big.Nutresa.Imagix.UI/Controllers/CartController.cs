namespace Big.Nutresa.Imagix.UI.Controllers
{
    using Big.Nutresa.Imagix.UI.Common.Helpers;
    using Big.Nutresa.Imagix.UI.Common.Models;
    using Big.Nutresa.Imagix.UI.Filters;
    using Big.Nutresa.Imagix.UI.Models;
    using System;
    using System.Web.Mvc;
    public class CartController : CustomController
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetCart()
        {
            //string customerId = User.Identity.Name;
            string customerId = "221ea0b2-6a56-450d-bcb7-7fa110ea0da1";
            int programId = Convert.ToInt32(ConfigurationHelper.Get("NetCommerce.Program"));

            Response<CatalogFilterListResponse> response = ApiService
                .Post<CatalogFilterListResponse>(ConfigurationHelper.Get("Proxy.Base"),
                string.Format(
                        ConfigurationHelper.Get("Proxy.ShowCartV2"),programId,customerId), null, null);

            return PartialView(response.ObjectResponse);
        }

        [HttpPost]
        public ActionResult AddToCart(CartModel model)
        {
            if (ModelState.IsValid)
            {
                //string customerId = User.Identity.Name;
                string customerId = "221ea0b2-6a56-450d-bcb7-7fa110ea0da1";
                model.CustomerId = customerId;
                int programId = Convert.ToInt32(ConfigurationHelper.Get("NetCommerce.Program"));

                Response<CatalogFilterListResponse> response = ApiService
                    .Post<CatalogFilterListResponse>(ConfigurationHelper.Get("Proxy.Base"),
                    string.Format(
                            ConfigurationHelper.Get("Proxy.ShowCartV2"), programId,model.ProductGuid,customerId,model.ProductReference,model.Quantity,model.SelectedPaymentRule), null, null);

                TempData["StartUpScript"] = string.Format("jQuery(showMask('Error','Prueba'))");

                return PartialView(response.ObjectResponse);
            }
            //string customerId = User.Identity.Name;
            TempData["StartUpScript"] = string.Format("jQuery(showMask('Error','Prueba'))");
            return RedirectToAction("ProductDetails", "Catalog", new { id = model.ProductGuid });

        }
    }
}