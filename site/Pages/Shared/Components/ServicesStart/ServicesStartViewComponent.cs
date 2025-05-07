using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.App_Code;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.ServicesStart
{
    public class ServicesStartViewComponent : ViewComponent
    {
        public ServicesStartViewComponent() { }

        public IViewComponentResult Invoke(modSitePage pageitem)
        {
            return View(pageitem);
        }
    }
}