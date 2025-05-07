using Microsoft.AspNetCore.Mvc;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.ContactForm
{
    public class ContactFormViewComponent : ViewComponent
    {
        public ContactFormViewComponent() { }

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
