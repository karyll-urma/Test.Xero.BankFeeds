using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Testing.Xero.BankFeeds.Base.Browser;

namespace Testing.Xero.BankFeeds.Contexts
{
    public class SettingsContext
    {
        public static string BaseUrl { get; set; }

        public static BrowserType Browser { get; set; }

        public static bool IsHeadless { get; set; }

        public static int ImplicitWait { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string SecAns1 { get; set; }
        public static string SecAns2 { get; set; }
        public static string SecAns3 { get; set; }
    }
}
