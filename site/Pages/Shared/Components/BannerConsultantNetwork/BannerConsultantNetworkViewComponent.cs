using Microsoft.AspNetCore.Mvc;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.BannerConsultantNetwork
{
    public class BannerConsultantNetworkViewComponent : ViewComponent
    {
        public BannerConsultantNetworkViewComponent() { }

        public IViewComponentResult Invoke(int pageid)
        {
            return View();
        }
    }
}
