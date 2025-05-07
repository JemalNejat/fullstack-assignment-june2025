using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.App_Code;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.PageOnlyDescription
{
    public class PageOnlyDescriptionViewComponent : ViewComponent
    {
        public PageOnlyDescriptionViewComponent() { }

        public IViewComponentResult Invoke(int pageid)
        {
            modSitePage shortpage = clDBMotor.GetSitePageById(pageid);

            return View(shortpage);
        }
    }
}
