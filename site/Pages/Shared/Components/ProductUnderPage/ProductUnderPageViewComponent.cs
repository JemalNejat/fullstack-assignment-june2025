using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.App_Code;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.ProductUnderPage
{
    public class ProductUnderPageViewComponent : ViewComponent
    {
        public ProductUnderPageViewComponent() { }

        public IViewComponentResult Invoke()
        {
            int currentProductPageId = int.Parse(ViewData["CurrentPageProductId"]!.ToString()!);
            string[] prodPagesProdUnderPages = CLCustAppsettings.PAGE_PRODUCT_UNDER!.Split(",");
            modSitePage? prodUnderPage = null;

            foreach (var item in prodPagesProdUnderPages)
            {
                string[] pagesids = item.Split(":");
                if (pagesids.Length > 0) 
                { 
                    if (int.Parse(pagesids[0]) == currentProductPageId)
                    {
                        prodUnderPage = clDBMotor.GetSitePageById(int.Parse(pagesids[1]));
                    }
                }
            }
            return View(prodUnderPage);
        }
    }
}

