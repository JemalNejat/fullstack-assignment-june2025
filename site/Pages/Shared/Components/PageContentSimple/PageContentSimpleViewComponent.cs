using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.PageContentSimple
{
    public class PageContentSimpleViewComponent : ViewComponent
    {
        public PageContentSimpleViewComponent() { }

        public IViewComponentResult Invoke(List<modSitePageArticle> pagearticles)
        {

            return View(pagearticles);

        }
    }
}