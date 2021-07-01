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
    public class LoginPage : BasePage
    {
        public LoginPage(DriverContext driverContext) : base(driverContext)
        {

        }

        IWebElement btnLogin => _driverContext.Driver.FindElement(By.XPath("//button[text() = 'Log in']"));
        IWebElement linkUseBackUp => _driverContext.Driver.FindElement(By.XPath("//button[text() = 'Use a backup method instead']"));
        IWebElement btnSecurityQuestions => _driverContext.Driver.FindElement(By.XPath("//button[text() = 'Security questions']"));
        IWebElement txt1stSecQuest => _driverContext.Driver.FindElement(By.XPath("//h1[text() = 'Answer your security questions to authenticate']/parent::div/form/div[1]/label"));
        IWebElement txt2ndSecQuest => _driverContext.Driver.FindElement(By.XPath("//h1[text() = 'Answer your security questions to authenticate']/parent::div/form/div[2]/label"));
        IWebElement input1stSecQuest => _driverContext.Driver.FindElement(By.XPath("//h1[text() = 'Answer your security questions to authenticate']/parent::div/form/div[1]/label/../div/input"));
        IWebElement input2ndSecQuest => _driverContext.Driver.FindElement(By.XPath("//h1[text() = 'Answer your security questions to authenticate']/parent::div/form/div[2]/label/../div/input"));
        IWebElement btnConfirm => _driverContext.Driver.FindElement(By.XPath("//button[text() = 'Confirm']"));

        // Enter UserName and Password
        public void LoginWithUserNameAndPassword(string username, string password)
        {
            _customControlHelper.InputText("Username", "name", username);
            _customControlHelper.InputText("Password", "name", password);
            btnLogin.Click();
        }

        // Select backup method and select 'Security Questions'
        public void SelBackUpSecurityQuestions()
        {
            linkUseBackUp.Click();
            btnSecurityQuestions.Click();
        }

        // Answer SecurityQuestions
        public void AnsSecurityQuestionsAndConfirm()
        {
            // get security quest text
            string secQuest1 = txt1stSecQuest.Text;
            string secQuest2 = txt2ndSecQuest.Text;

            // answer 1st security question
            if (secQuest1.Contains("What was the name of your first girlfriend / boyfriend?"))
            {
                input1stSecQuest.SendKeys(SettingsContext.SecAns1);
            }
            else if (secQuest1.Contains("What was the name of your first pet?"))
            {
                input1stSecQuest.SendKeys(SettingsContext.SecAns2);
            }
            else if (secQuest1.Contains("What road did you live on when you first started school?"))
            {
                input1stSecQuest.SendKeys(SettingsContext.SecAns3);
            }

            // answer 2nd security question
            if (secQuest2.Contains("What was the name of your first girlfriend / boyfriend?"))
            {
                input2ndSecQuest.SendKeys(SettingsContext.SecAns1);
            }
            else if (secQuest2.Contains("What was the name of your first pet?"))
            {
                input2ndSecQuest.SendKeys(SettingsContext.SecAns2);
            }
            else if (secQuest2.Contains("What road did you live on when you first started school?"))
            {
                input2ndSecQuest.SendKeys(SettingsContext.SecAns3);
            }

            // Click Confirm
            btnConfirm.Click();
        }
    }
}

