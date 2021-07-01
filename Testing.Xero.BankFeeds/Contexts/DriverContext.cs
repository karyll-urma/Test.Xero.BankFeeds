using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Xero.BankFeeds.Base;

namespace Testing.Xero.BankFeeds.Contexts
{
    public class DriverContext
    {
        public IWebDriver Driver { get; set; }
        public Browser browser { get; set; } 
    }
}
