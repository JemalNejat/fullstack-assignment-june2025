namespace SITE.ITEGAMAX._4._0._2.App_Code
{
    public class LogManager
    {
        public static bool LogServerError(string errormessage, string systemerror)
        {


            return true;
        }
    }

    public class Logger
    {
        private static readonly string _logFilePath;

        static Logger()
        {
            _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.log");
            if (!File.Exists(_logFilePath))
            {
                File.Create(_logFilePath).Dispose();
            }
        }

        public static void Log(string message)
        {
            File.AppendAllText(_logFilePath, message + Environment.NewLine);
        }
    }
}
