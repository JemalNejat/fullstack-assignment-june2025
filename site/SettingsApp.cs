namespace SITE.ITEGAMAX._4._0._2
{
    public class CLCompanySettings
    {
        private static readonly CLCompanySettings _instance;

        static CLCompanySettings()
        {
            _instance = new CLCompanySettings();
        }

        private CLCompanySettings() { }

        public static CLCompanySettings Instance
        {
            get { return _instance; }
        }

        public static string? COMPANY_NAME { get; set; }
        public static string? COMPANY_SHORT_NAME { get; set; }
        public static string? COMPANY_WEB { get; set; }
        public static string? FOLLOWUS_FACEBOOK { get; set; }
        public static string? FOLLOWUS_XTWITTER { get; set; }
        public static string? FOLLOWUS_LINKEDIN { get; set; }
        public static string? FOLLOWUS_GOOGLE { get; set; }
        public static string? COMPANY_POST_OFFICE { get; set; }
        public static string? COMPANY_POSTAL_CODE { get; set; }
        public static string? COMPANY_CITY { get; set; }
        public static string? COMPANY_LOCALITY { get; set; }
        public static string? COMPANY_MUNICIPALITY { get; set; }
        public static string? COMPANY_COUNTRY { get; set; }
        public static string? COMPANY_PHONE { get; set; }
        public static string? COMPANY_OPENINGHOURS_WEEKDAYS { get; set; }
        public static string? COMPANY_OPENINGHOURS_HOLIDAYS { get; set; }
        public static string? COMPANY_EMAIL_INFO { get; set; }
        public static string? COMPANY_EMAIL_ECONOMY { get; set; }
        public static string? COMPANY_EMAIL_SALES { get; set; }
        public static string? COMPANY_EMAIL_SUPPORT { get; set; }
        public static string? COMPANY_EMAIL_ORDER { get; set; }
        public static string? COMPANY_EMAIL_CONTACT { get; set; }
        public static string? COMPANY_EMAIL_JOBS { get; set; }

    }


    public class CLConnectionStrings
    {
        private static readonly CLConnectionStrings _instance;

        static CLConnectionStrings()
        {
            _instance = new CLConnectionStrings();
        }

        private CLConnectionStrings() { }

        public static CLConnectionStrings Instance
        {
            get { return _instance; }
        }
        public static string? MariaDbConnectionString { get; set; }

    }

    public class CLCustAppsettings
    {
        private static readonly CLCustAppsettings _instance;

        static CLCustAppsettings()
        {
            _instance = new CLCustAppsettings();
        }

        private CLCustAppsettings() { }

        public static CLCustAppsettings Instance
        {
            get { return _instance; }
        }

        public static int? SITE_ID { get; set; }
        public static string? IMAGE_PAGES_PATH { get; set; }
        public static int ? SERVICE_START_PAGEID { get; set; }
        public static int ? INFO_START_PAGEID { get; set; }
        public static int ? COMPANY_START_PAGEID { get; set; }
        public static int ? SUPPORT_START_PAGEID { get; set; }
        public static int ? SUPPLIER_START_PAGEID { get; set; }
        public static int ? PARTNER_START_PAGEID { get; set; }
        public static int? SIPTEMAP_START_PAGEID { get; set; }
        public static int? PRODUCT_START_PAGEID { get; set; }   
        public static int? TECHNOGIES_START_PAGEID { get; set; }   
        public static int? WORKINGPROCESS_START_PAGEID { get; set; }    
        public static int? JOBB_START_PAGEID { get; set; }
        public static int? ITEGAMAX_NETWORK_PAGEID { get; set; }
        public static int? CONSULTING_NETWORK_PAGEID { get; set; }
        public static int? FORM_SERVICES_PAGEID {  get; set; }
        public static int? FORM_PRODUCTS_PAGEID {  get; set; }
        public static string? NOT_COMPANYNAME_TILTE { get; set; }
        public static string? PAGES_CORE_SUPPORT { get; set; }
        public static string? PAGE_PRODUCT_UNDER {  get; set; }
        public static int? CORE_PRODUCT_GROUP { get; set; }


    }

    #region CLASS TEMPLATE

    //public class Singleton
    //{
    //    private static readonly Singleton _instance;

    //    static Singleton()
    //    {
    //        _instance = new Singleton();
    //    }

    //    private Singleton() { }

    //    public static Singleton Instance
    //    {
    //        get { return _instance; }
    //    }
    //    //Set class properties here

    //}

    #endregion
}