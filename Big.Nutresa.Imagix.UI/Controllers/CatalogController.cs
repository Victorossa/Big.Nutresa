namespace Big.Nutresa.Imagix.UI.Controllers
{
    using System.Web.Mvc;
    using System;
    using Common.Helpers;
    using Common.Models;
    using Filters;
    using System.Collections.Generic;

    public class CatalogController : CustomController
    {
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult Index(string id="0")
        {
            Request<CatalogFilter> request = new Request<CatalogFilter>
            {
                ObjectRequest = new CatalogFilter
                {
                    ProgramId = Convert.ToInt32(ConfigurationHelper
                        .Get("NetCommerce.Program")),
                    PageSize = Convert.ToInt32(ConfigurationHelper
                        .Get("NetCommerce.GetCatalogGenericFilterV2.PageSize")),
                    ShowProductsWithInventory = Convert.ToBoolean(ConfigurationHelper
                        .Get("NetCommerce.GetCatalogGenericFilterV2.ShowProductsWithInventory")),
                    PageIndex = Convert.ToInt32(ConfigurationHelper
                        .Get("NetCommerce.GetCatalogGenericFilterV2.PageIndex")),
                    Recommended = false,
                    
                }
            };
            if (id != "0")
            {
                request.ObjectRequest.CategoryId = Convert.ToInt32(id);
            }
            Response<CatalogFilterListResponse> response = ApiService
                .Post<CatalogFilterListResponse>(ConfigurationHelper.Get("Proxy.Base"),
                        ConfigurationHelper.Get("Proxy.GetCatalogFilter"), null, request);

            return View(response.ObjectResponse);
        }
        

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public ActionResult ProductDetails(string id)
        {

            ViewBag.StartUpScript = TempData["StartUpScript"]?.ToString();
            return View();

        }

        
        #region Partials
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public PartialViewResult GetProductDetails(string id)
        {
            
            Request<CatalogFilter> request = new Request<CatalogFilter>
            {
                ObjectRequest = new CatalogFilter
                {
                    ProgramId = Convert.ToInt32(ConfigurationHelper
                      .Get("NetCommerce.Program")),
                    PageSize = Convert.ToInt32(ConfigurationHelper
                      .Get("NetCommerce.GetCatalogGenericFilterV2.PageSize")),
                    ShowProductsWithInventory = Convert.ToBoolean(ConfigurationHelper
                      .Get("NetCommerce.GetCatalogGenericFilterV2.ShowProductsWithInventory")),
                    PageIndex = Convert.ToInt32(ConfigurationHelper
                      .Get("NetCommerce.GetCatalogGenericFilterV2.PageIndex")),
                    Recommended = false,
                    ProductGuid = id
                }
            };
            Response<CatalogFilterListResponse> response = ApiService
               .Post<CatalogFilterListResponse>(ConfigurationHelper.Get("Proxy.Base"),
                       ConfigurationHelper.Get("Proxy.GetCatalogFilter"), null, request);

            return PartialView("~/Views/Catalog/Partials/_ProductDetail.cshtml", response.ObjectResponse);

        }


        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None)]
        public PartialViewResult ProductRecommendeds()
        {
            Request<CatalogFilter> request = new Request<CatalogFilter>
            {
                ObjectRequest = new CatalogFilter
                {
                    ProgramId = Convert.ToInt32(ConfigurationHelper.Get("NetCommerce.Program")),
                    PageSize = Convert.ToInt32(ConfigurationHelper.Get("NetCommerce.GetCatalogGenericFilterV2.PageSize")),
                    ShowProductsWithInventory = Convert.ToBoolean(ConfigurationHelper.Get("NetCommerce.GetCatalogGenericFilterV2.ShowProductsWithInventory")),
                    PageIndex = Convert.ToInt32(ConfigurationHelper.Get("NetCommerce.GetCatalogGenericFilterV2.PageIndex")),
                    Recommended = true
                }
            };
            Response<CatalogFilterListResponse> response = ApiService
                .Post<CatalogFilterListResponse>(ConfigurationHelper.Get("Proxy.Base"),
                        ConfigurationHelper.Get("Proxy.GetCatalogFilter"), null, request);
            return PartialView("~/Views/Catalog/Partials/_Recommendeds.cshtml", response.ObjectResponse);
        }


        public PartialViewResult PrincipalCategories()
        {
            Request<CategoryResquest> request = new Request<CategoryResquest>
            {
                ObjectRequest = new CategoryResquest
                {
                    ProgramId = Convert.ToInt32(ConfigurationHelper.Get("NetCommerce.Program")),                    
                }
            };
            Response<List<CategoryResponse>> response = ApiService
                .Post<List<CategoryResponse>>(ConfigurationHelper.Get("Proxy.BaseCategory"),
                        ConfigurationHelper.Get("Proxy.GetPrincipalCategoies"), null, request);
            return PartialView("~/Views/Catalog/Partials/_PrincipalCategory.cshtml", response.ObjectResponse);
        }
        public PartialViewResult CategoriesByParent(int ParentCategory)
        {
            Request<CategoryResquest> request = new Request<CategoryResquest>
            {
                ObjectRequest = new CategoryResquest
                {
                    ProgramId = Convert.ToInt32(ConfigurationHelper.Get("NetCommerce.Program")),
                    
                }
            };
            if (ParentCategory != 0)
            {
                request.ObjectRequest.ParentCategory = ParentCategory;
            }
            Response<List<CategoryResponse>> response = ApiService
                .Post<List<CategoryResponse>>(ConfigurationHelper.Get("Proxy.BaseCategory"),
                        ConfigurationHelper.Get("Proxy.GetCategoiesByParent"), null, request);
            return PartialView("~/Views/Catalog/Partials/_PrincipalCategory.cshtml", response.ObjectResponse);
        }
        #endregion
    }
}