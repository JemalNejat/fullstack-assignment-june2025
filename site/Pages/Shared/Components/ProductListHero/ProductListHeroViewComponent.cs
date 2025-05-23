﻿using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.App_Code;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.ProductListHero
{
    public class ProductListHeroViewComponent : ViewComponent
    {
        public ProductListHeroViewComponent() { }

        public IViewComponentResult Invoke(int pageare)
        {

            List<modSitePage> pageslist = clDBMotor.GetSitePageListByArea(pageare);

            return View(pageslist);


        }
    }
}