using Microsoft.AspNetCore.Mvc;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.BannerBecomeAPartnerS
{
    public class BannerBecomeAPartnerSViewComponent : ViewComponent
    {
        public BannerBecomeAPartnerSViewComponent() { }

        public IViewComponentResult Invoke(int pageid)
        {
            return View();
        }
    }
}
