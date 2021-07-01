using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Xero.BankFeeds.Contexts;
using static Testing.Xero.BankFeeds.Base.Browser;

namespace Testing.Xero.BankFeeds.Helpers
{
    public static class SettingsReaderHelper
    {
        // Set parameter values to Settings context
        public static void SetFrameworkSettings()
        {
            SettingsContext.BaseUrl = TestContext.Parameters["baseUrl"].ToString();
            SettingsContext.Browser = (BrowserType)Enum.Parse(typeof(BrowserType), TestContext.Parameters["browser"]);
            SettingsContext.IsHeadless = bool.Parse(TestContext.Parameters["isHeadless"]);
            SettingsContext.ImplicitWait = Int32.Parse(TestContext.Parameters["implicitWait"]);
            SettingsContext.UserName = TestContext.Parameters["UserName"].ToString();
            SettingsContext.Password = TestContext.Parameters["Password"].ToString();
            SettingsContext.SecAns1 = TestContext.Parameters["SecAns1"].ToString();
            SettingsContext.SecAns2 = TestContext.Parameters["SecAns2"].ToString();
            SettingsContext.SecAns3 = TestContext.Parameters["SecAns3"].ToString();
        }
    }
}
