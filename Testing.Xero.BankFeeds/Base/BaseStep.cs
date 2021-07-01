using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Testing.Xero.BankFeeds.Contexts;
using Testing.Xero.BankFeeds.Helpers;
using Testing.Xero.BankFeeds.Pages;

namespace Testing.Xero.BankFeeds.Base
{
    public abstract class BaseStep
    {
        public DriverContext _driverContext;
        public LoginPage _loginPage;
        public HomePage _homePage;
        public CodeHelper _codeHelper;
        public BankAccountsPage _bankAcountsPage;
        public ScenarioContext _scenarioContext;

        public BaseStep(DriverContext driverContext, ScenarioContext scenarioContext, TestContext testContext)
        {
            _driverContext = driverContext;
            _loginPage = new LoginPage(_driverContext);
            _homePage = new HomePage(_driverContext);
            _codeHelper = new CodeHelper(_driverContext);
            _bankAcountsPage = new BankAccountsPage(_driverContext);
            _scenarioContext = scenarioContext;
        }
    }
}
