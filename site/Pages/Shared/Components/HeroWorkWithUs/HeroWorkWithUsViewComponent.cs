using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.HeroWorkWithUs
{
    public class HeroWorkWithUsViewComponent : ViewComponent
    {
        public HeroWorkWithUsViewComponent() { }

        public IViewComponentResult Invoke(modSitePage pageitem)
        {
            return View(pageitem);
        }
    }
}