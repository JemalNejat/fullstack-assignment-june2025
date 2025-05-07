using Microsoft.AspNetCore.Mvc;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.BePartner
{
    public class BePartnerViewComponent : ViewComponent
    {
        public BePartnerViewComponent() { }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}