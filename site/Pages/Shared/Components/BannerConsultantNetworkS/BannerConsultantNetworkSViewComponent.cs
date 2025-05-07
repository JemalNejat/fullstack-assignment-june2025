using Microsoft.AspNetCore.Mvc;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.BannerConsultantNetworkS
{
    public class BannerConsultantNetworkSViewComponent : ViewComponent
    {
        public BannerConsultantNetworkSViewComponent() { }

        public IViewComponentResult Invoke(int pageid)
        {
            return View();
        }
    }
}
