using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.App_Code;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.SiteMap
{
    public class SiteMapViewComponent : ViewComponent
    {
        public SiteMapViewComponent() { }

        public IViewComponentResult Invoke()
        {
            List<modSiteMap> sitemappages = clDBMotor.GetSiteMapPages();
            return View(sitemappages);
        }
    }
}
