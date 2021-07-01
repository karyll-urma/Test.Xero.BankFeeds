using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Testing.Xero.BankFeeds.Base;
using Testing.Xero.BankFeeds.Contexts;

namespace Testing.Xero.BankFeeds.Steps
{
    [Binding]
    public class AddBankAccountToOrganisationSteps : BaseStep
    {
        public AddBankAccountToOrganisationSteps(DriverContext driverContext, ScenarioContext scenarioContext, TestContext testContext) : base(driverContext, scenarioContext, testContext)
        {

        }


        [Given(@"User navigate to application")]
        public void GivenUserNavigateToApplication()
        {
            // Navigate to application URL
            _driverContext.Driver.Navigate().GoToUrl(SettingsContext.BaseUrl);
        }

        [Given(@"User login using valid credentials")]
        public void GivenUserLoginUsingValidCredentials()
        {
            // Enter Login and Password, then Click login.
            _loginPage.LoginWithUserNameAndPassword(SettingsContext.UserName, SettingsContext.Password);

            // Answer security questions
            _loginPage.SelBackUpSecurityQuestions();
            _loginPage.AnsSecurityQuestionsAndConfirm();

            // Validate HomePage is displayed
            Assert.IsTrue(_homePage.VerifyHomePage(), "=====> Login was not successful.");

            // Validate Current URL
            Assert.IsTrue(_homePage.ValidateURL("https://go.xero.com/Dashboard/"));
        }

        [When(@"User select '(.*)' as organisation")]
        public void WhenUserSelectAsOrganisation(string organisation)
        {
            _homePage.SelectAndVerifyOrg(organisation);
        }

        [When(@"User add bank account with details below")]
        public void WhenUserAddBankAccountWithDetailsBelow(Table table)
        {
            dynamic data = table.CreateDynamicInstance();

            // navigate to menu
            Assert.IsTrue(_homePage.NavigateToMenuSubmenuAndVerify("Accounting", "Bank accounts"), "=====> Unable to navigate to Accounting>Bank accounts");

            // Get accountname/accountnum data - generate random string if string contains "RandomString-"
            string accountNameOverride = _codeHelper.GetDataInput(data.AccountName, "AlphaNumeric");
            string accountNumOverride = _codeHelper.GetDataInput(data.AccountName, "Numeric");

            // add bank account
            _bankAcountsPage.AddAndSelectBank(data.Bank);
            _bankAcountsPage.EnterAccntDetails(accountNameOverride, data.AccountType, accountNumOverride, data.Currency);
            // store data to scenarioContext
            _scenarioContext.Set(data.Bank, "bank");
            _scenarioContext.Set(accountNameOverride, "accountname");
            _scenarioContext.Set(data.AccountType, "accounttype");
            _scenarioContext.Set(accountNumOverride, "accountnumber");
            _scenarioContext.Set(data.Currency, "currency");

            // skip upload form
            if (data.AccountType.ToString() != "Other")
            {
                _bankAcountsPage.SkipUploadForm();
            }
        }

        [Then(@"User can see bank account was successfully added to oraganisation")]
        public void ThenUserCanSeeBankAccountWasSuccessfullyAddedToOraganisation()
        {
            // navigate to menu
            _homePage.NavigateToMenuSubmenuAndVerify("Accounting", "Bank accounts");

            //verify Account
            Assert.IsTrue(_bankAcountsPage.VerifyAccount(_scenarioContext.Get<string>("accountname"), _scenarioContext.Get<string>("accountnumber")), "=====> Account Name: " + _scenarioContext.Get<string>("accountname") + " with Account number: " + _scenarioContext.Get<string>("accountnumber") + " was not displayed in the list.");

        }

        [Then(@"User logout from the application")]
        public void ThenUserLogoutFromTheApplication()
        {
            Assert.IsTrue(_homePage.Logout(), "=====> User was not logged out successfully");
        }
    }
}
