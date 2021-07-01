using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Xero.BankFeeds.Base;
using Testing.Xero.BankFeeds.Contexts;

namespace Testing.Xero.BankFeeds.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(DriverContext driverContext) : base(driverContext)
        {

        }

        IWebElement dropdownOrganisation => _driverContext.Driver.FindElement(By.XPath("//div[@class = 'xnav-header--main']/div/button"));
        IWebElement textCurrentOrg => _driverContext.Driver.FindElement(By.XPath("//span[@class = 'xnav-appbutton--text']"));
        IWebElement buttonChangeOrg => _driverContext.Driver.FindElement(By.XPath("//button[text()='Change organisation']"));
        IWebElement btnUsert => _driverContext.Driver.FindElement(By.XPath("//abbr[text() = 'KU']"));
        IWebElement btnLogout => _driverContext.Driver.FindElement(By.XPath("//li/a[text() = 'Log out']"));
        IWebElement btnLogoutConfirm => _driverContext.Driver.FindElement(By.XPath("//button[text() = 'Log out']"));


        // Verify HomePage(Dashboard menu) is displayed
        public bool VerifyHomePage()
        {
            return _customControlHelper.IsElementDisplayed("a", "Dashboard");
        }

        // Select Organisation
        public bool SelectAndVerifyOrg(string organisation)
        {
            // select expected org
            if (!textCurrentOrg.Text.Equals(organisation))
            {
                // select organisation
                dropdownOrganisation.Click();
                buttonChangeOrg.Click();
                _driverContext.Driver.FindElement(By.XPath($"//ol[@class = 'xnav-verticalmenu']/li/a[contains(text(),'{organisation}')]")).Click();
            }
         
            // return true if current org is displayed correctly
            return _customControlHelper.IsElementDisplayed("a", organisation);
        }

        // Navigate to Menu>Submenu
        public bool NavigateToMenuSubmenuAndVerify(string menu, string submenu)
        {
            _customControlHelper.NavigateToMenuSubmenu(menu, submenu);
            return _customControlHelper.IsElementDisplayed("span", submenu);
        }

        // Logout 
        public bool Logout()
        {
            btnUsert.Click();
            btnLogout.Click();
            //if(btnLogoutConfirm.Displayed)
            //{
            //    btnLogoutConfirm.Click();
            //}

            return _customControlHelper.IsElementDisplayed("h2", "Log in to Xero");
        }
    }
}
