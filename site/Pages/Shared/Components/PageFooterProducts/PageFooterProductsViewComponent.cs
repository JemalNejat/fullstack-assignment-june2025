using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.App_Code;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.PageFooterProducts
{
    public class PageFooterProductsViewComponent : ViewComponent
    {
        public PageFooterProductsViewComponent() { }


        public IViewComponentResult Invoke(int menuarea)
        {
            List<modMenuItem> list = clDBMotor.GetPageUnderMenuByArea(menuarea);

            return View(list);
        }

    }
}
