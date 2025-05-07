using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.Models;
using SITE.ITEGAMAX._4._0._2.App_Code;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.PageSimpleMenu
{
    public class PageSimpleMenuViewComponent : ViewComponent
    {
        public PageSimpleMenuViewComponent() { }


        public IViewComponentResult Invoke(int menuarea)
        {
            List<modMenuItem> list = clDBMotor.GetPageUnderMenuByArea(menuarea);

            return View(list);
        }

    }
}