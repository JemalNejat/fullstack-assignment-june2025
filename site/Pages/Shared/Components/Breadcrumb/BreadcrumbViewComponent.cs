using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.Breadcrumb
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        public BreadcrumbViewComponent() { }

        public IViewComponentResult Invoke(modSitePage _controlpageItem)
        {
            return View(_controlpageItem);
        }

    }
}
