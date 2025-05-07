using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.PageHeroProduct
{
    public class PageHeroProductViewComponent : ViewComponent
    {
        public PageHeroProductViewComponent() { }

        public IViewComponentResult Invoke(modSitePage pageItem)
        {
            return View(pageItem);
        }

    }
}