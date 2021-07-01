using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Xero.BankFeeds.Contexts;

namespace Testing.Xero.BankFeeds.Base
{
    public class Browser
    {
        private readonly IWebDriver _driver;
        public Browser(DriverContext driverContext)
        {
            _driver = driverContext.Driver;
        }

        public enum BrowserType
        {
            FireFox,
            Chrome
        }
    }
}
