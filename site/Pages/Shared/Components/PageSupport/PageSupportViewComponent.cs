using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.App_Code;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.PageSupport
{
    public class PageSupportViewComponent : ViewComponent
    {
        public PageSupportViewComponent() { }

        public IViewComponentResult Invoke(string pagelist)
        {
            string[] pageList = pagelist.Split(',');
            List<modSitePage> modSitePages = new List<modSitePage>();
            foreach (string pageid in pageList)
            {
                modSitePage modSitePage = clDBMotor.GetSitePageById(int.Parse(pageid));
                if (modSitePage != null)
                {
                    modSitePages.Add(modSitePage);
                }

            }
            return View(modSitePages);
        }
    }
}
