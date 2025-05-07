using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.PageHeroTop
{
    public class PageHeroTopViewComponent : ViewComponent
    {
        public PageHeroTopViewComponent() { }

        public IViewComponentResult Invoke(modSitePage sitepage)
        {

            return View(sitepage);

        }
    }
}
