using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Xero.BankFeeds.Contexts;
using Testing.Xero.BankFeeds.Helpers;

namespace Testing.Xero.BankFeeds.Base
{
    public abstract class BasePage
    {
        public DriverContext _driverContext;
        public CustomControlHelper _customControlHelper;

        public BasePage(DriverContext driverContext)
        {
            _driverContext = driverContext;
            _customControlHelper = new CustomControlHelper(_driverContext);
        }

        // Validate Current URL
        public bool ValidateURL(string expURL)
        {
            string currentURL = _driverContext.Driver.Url;
            return currentURL.Contains(expURL);
        }
    }
}
