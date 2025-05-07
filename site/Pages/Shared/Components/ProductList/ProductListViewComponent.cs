using Microsoft.AspNetCore.Mvc;
using SITE.ITEGAMAX._4._0._2.App_Code;
using SITE.ITEGAMAX._4._0._2.Models;

namespace SITE.ITEGAMAX._4._0._2.Pages.Shared.Components.ProductList
{
    public class ProductListViewComponent : ViewComponent
    {
        public ProductListViewComponent() { }

        public IViewComponentResult Invoke(int productgroupid)
        {
            List<modProduct> products = clDBMotor.GetProductListByGroup(productgroupid);
            
            return View(products);
        }
    }
}
