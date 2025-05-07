namespace SITE.ITEGAMAX._4._0._2.Models
{
    public class modPageSimpleMenu
    {
        public int MenuId { get; set; }
        public int MenuType { get; set; }
        public int MenuParentId { get; set; }
        public string? MenuTitle { get; set; }
        public string? MenuNavLink { get; set; }
        public string? MenuNavTarget { get; set; }
        public bool MenuHasChildNodes { get; set; }
        public bool AreaId { get; set; }
        public bool ViewTop { get; set; }
        public bool ViewFooter { get; set; }
        public bool ViewPage { get; set; }
        public bool ViewSiteMap { get; set; }
        public bool ViewMobileTop { get; set; }
        public bool ViewSocialaMedia { get; set; }
        public bool ViewUsefulPages { get; set; }
        public bool ViewServicesAreas { get; set; }
        public bool ViewUsefulLinksAd { get; set; }
    }
}
