using Microsoft.AspNetCore.Mvc;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.BeMember
{
    public class BeMemberViewComponent : ViewComponent
    {
        public BeMemberViewComponent() { }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
