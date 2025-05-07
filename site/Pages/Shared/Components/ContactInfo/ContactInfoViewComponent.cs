using Microsoft.AspNetCore.Mvc;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.ContactInfo
{
    public class ContactInfoViewComponent : ViewComponent
    {
        public ContactInfoViewComponent() { }

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
