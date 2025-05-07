using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.Models;
using SITE.ITEGAMAX._4._0._2.App_Code;
namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.ServicesList
{
    public class ServicesListViewComponent : ViewComponent
    {
        public ServicesListViewComponent() { }

        public IViewComponentResult Invoke(int pageare)
        {

            List<modSitePage> pageslist = clDBMotor.GetSitePageListByArea(pageare);

            return View(pageslist);


        }
    }
}

