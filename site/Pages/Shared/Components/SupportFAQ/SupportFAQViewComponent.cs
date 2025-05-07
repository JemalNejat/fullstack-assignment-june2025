using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.App_Code;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.SupportFAQ
{
    public class SupportFAQViewComponent : ViewComponent
    {
        public SupportFAQViewComponent() { }

        public IViewComponentResult Invoke(int pageid, int faqarea)
        {
            modPageFAQ modPageFAQ = clDBMotor.GetSitePageAndFAQ(pageid,faqarea);

            return View(modPageFAQ);
        }
    }
}
