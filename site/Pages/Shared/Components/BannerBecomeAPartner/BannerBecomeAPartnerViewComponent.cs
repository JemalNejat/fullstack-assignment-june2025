using Microsoft.AspNetCore.Mvc;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.BannerBecomeAPartner
{
    public class BannerBecomeAPartnerViewComponent : ViewComponent
    {
        public BannerBecomeAPartnerViewComponent() { }

        public IViewComponentResult Invoke(int pageid)
        {
            return View();
        }
    }
}
