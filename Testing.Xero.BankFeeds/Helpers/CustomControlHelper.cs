using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Xero.BankFeeds.Base;
using Testing.Xero.BankFeeds.Contexts;

namespace Testing.Xero.BankFeeds.Helpers
{
    public class CustomControlHelper : BaseHelper
    {
        public CustomControlHelper(DriverContext driverContext) : base(driverContext)
        {
        }

        // Enter text on a given ControlName and attribute
        public void InputText(string ControlName, string attribute, string Value)
        {
            IWebElement InputControl = _driverContext.Driver.FindElement(By.XPath($"//input[@{attribute} = '{ControlName}']"));
            InputControl.SendKeys(Value);
        }

        // Click buttons under span
        public void ClickButton(string CotrolName, string node)
        {
            IWebElement ButtonControl = _driverContext.Driver.FindElement(By.XPath($"//{node}[contains(text(),'{CotrolName}')]"));
            
            ButtonControl.Click();
        }

        // Navigate to Menu>SubMenu
        public void NavigateToMenuSubmenu(string menu, string submenu)
        {
            _driverContext.Driver.FindElement(By.XPath($"//div[@class = 'xnav-header--main']//button[text() = '{menu}']")).Click();
            _driverContext.Driver.FindElement(By.XPath($"//div[@class = 'xnav-header--main']//button[text() = '{menu}']/following-sibling::div//a[text()='{submenu}']")).Click();
        }

        // Return true if given attribute and text displayed
        public bool IsElementDisplayed(string node, string text)
        {
            try
            {
                return _driverContext.Driver.FindElement(By.XPath($"//{node}[contains(text(),'{text}')]")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // Return true if given xpath is displayed
        public bool IsXpathDisplayed(string xpath)
        {
            try
            {
                return _driverContext.Driver.FindElement(By.XPath($"{xpath}")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
