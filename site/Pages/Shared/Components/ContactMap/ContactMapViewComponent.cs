using Microsoft.AspNetCore.Mvc;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.ContactMap
{
    public class ContactMapViewComponent : ViewComponent
    {
        public ContactMapViewComponent() { }

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}