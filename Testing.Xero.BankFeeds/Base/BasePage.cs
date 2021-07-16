using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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

        // Move to Element
        public void MoveToElement(IWebElement element)
        {
            try
            {
                Actions actions = new Actions(_driverContext.Driver);
                actions.MoveToElement(element).Perform();
            }
            catch (Exception)
            {
                Console.WriteLine("Element: " + element + " not found.");
            }
            
        }

        // Click Element
        public void ClickElement(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(_driverContext.Driver, TimeSpan.FromSeconds(SettingsContext.ImplicitWait));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

            Actions actions = new Actions(_driverContext.Driver);
            actions.MoveToElement(element).Click().Perform();
        }
    }
}
