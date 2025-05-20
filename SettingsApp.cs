namespace CDN.ITEGAMAX._4._0
{
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

        public static string? IMAGE_WWWROOT { get; set; }

    }
}
