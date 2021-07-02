using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Testing.Xero.BankFeeds.Base;
using Testing.Xero.BankFeeds.Contexts;

namespace Testing.Xero.BankFeeds.Pages
{
    public class BankAccountsPage:BasePage
    {
        public BankAccountsPage(DriverContext driverContext) : base(driverContext)
        {
        }

        IWebElement btnAddBankAccnt => _driverContext.Driver.FindElement(By.XPath("//a/span[text() = 'Add Bank Account']"));
        IWebElement inputFindBank => _driverContext.Driver.FindElement(By.XPath("//div[@data-automationid = 'bankSearch']//input"));
        IWebElement input1stAcctName => _driverContext.Driver.FindElement(By.XPath("//label/span[text() = 'Account Name']/../..//input"));
        IWebElement input1stAcctType => _driverContext.Driver.FindElement(By.XPath("//label/span[text() = 'Account Type']/../..//input"));
        IWebElement input1stAcctNum => _driverContext.Driver.FindElement(By.XPath("(//label[text() = 'Account Number']/..//input[contains(@id,'accountnumber')])[last()]"));
        IWebElement input1stCreditCardNum => _driverContext.Driver.FindElement(By.XPath("(//label[text() = 'Credit Card Number']/..//input[contains(@id,'accountnumber')])[last()]"));
        IWebElement input1stCurrency => _driverContext.Driver.FindElement(By.XPath("//input[@id = 'currencyCombo-1057-inputEl']"));
        IWebElement btnContinue => _driverContext.Driver.FindElement(By.XPath("//span[text() = 'Continue']"));
        IWebElement btnDoLater => _driverContext.Driver.FindElement(By.XPath("//span[contains(text(),'do it later')]"));
        IWebElement btnGoToDashboard => _driverContext.Driver.FindElement(By.XPath("//span[text() = 'Go to dashboard']"));



        // Select Bank
        public bool AddAndSelectBank(string bank)
        {
            WebDriverWait _wait = new WebDriverWait(_driverContext.Driver, new TimeSpan(0, 1, 0));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(btnAddBankAccnt)).Click();
            Thread.Sleep(1000);

            inputFindBank.SendKeys(bank);
            try
            {
                _driverContext.Driver.FindElement(By.XPath($"(//ul/li[text() = '{bank}'])[last()]")).Click();
            }
            catch (Exception)
            {
                _driverContext.Driver.FindElement(By.XPath($"//span[text() = '{bank}']")).Click();
            }
            

            return _customControlHelper.IsElementDisplayed("h1", "Enter your " + bank + "account details");
        }

        // Enter Account Name and Account Type
        public void EnterAccntDetails(string accountName, string accountType, string accountNum, string currency)
        {
            // enter account name
            input1stAcctName.SendKeys(accountName);
            
            // select account type
            input1stAcctType.Click();
            _driverContext.Driver.FindElement(By.XPath($"//ul/li[text() = '{accountType}']")).Click();

            //enter credit card num
            if(accountType.Equals("Credit Card"))
            {
                input1stCreditCardNum.SendKeys(accountNum);
            }
            else
            {
                // enter account number
                input1stAcctNum.SendKeys(accountNum);
            }

            // click Continue
            btnContinue.Click();
        }

        // Skip upload form
        public void SkipUploadForm()
        {
            _customControlHelper.ClickButton("got a form", "span");
            
            btnDoLater.Click();
       
            Actions actions = new Actions(_driverContext.Driver);
            IWebElement element = _driverContext.Driver.FindElement(By.XPath("//span[text() = 'Go to dashboard']"));
            actions.MoveToElement(element).Click().Perform();
            //btnGoToDashboard.Click();
            //}
        }

        // Verify newly added accout
        public bool VerifyAccount(string accountName, string accountNum)
        {
            return _customControlHelper.IsXpathDisplayed($"//a[@class = 'bank-name global' and text() = '{accountName}']/span[contains(text(),'{accountNum}')]");              
        }

    }
}
