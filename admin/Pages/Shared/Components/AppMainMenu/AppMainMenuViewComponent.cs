using Microsoft.AspNetCore.Mvc;

namespace ADMIN.ITEGAMAX._4._0.Pages.Shared.Components.AppMainMenu
{
    public class AppMainMenuViewComponent : ViewComponent
    {
        public AppMainMenuViewComponent() { }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}