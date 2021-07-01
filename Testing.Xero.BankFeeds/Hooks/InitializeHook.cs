using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Testing.Xero.BankFeeds.Base;
using Testing.Xero.BankFeeds.Contexts;
using Testing.Xero.BankFeeds.Helpers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static Testing.Xero.BankFeeds.Base.Browser;

namespace Testing.Xero.BankFeeds.Hooks
{
    [Binding]
    public sealed class InitializeHook
    {
        private DriverContext _driverContext;

        public InitializeHook(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }

        //Initialize
        public static void InitializeSettings()
        {
            // Read settings file
            SettingsReaderHelper.SetFrameworkSettings();

            //Set Log
            LogHelper.CreateLogFile();
            LogHelper.Write("Initialized framework");
        }

        // Select Browser and configurations
        public void OpenBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.FireFox:
                    FirefoxOptions optionff = new FirefoxOptions();
                    optionff.AddArguments("start-maximized");
                    optionff.AddArguments("--disable-gpu");
                    if (SettingsContext.IsHeadless)
                    {
                        optionff.AddArguments("--headless");
                    }

                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    _driverContext.Driver = new FirefoxDriver(optionff);
                    _driverContext.browser = new Browser(_driverContext);
                    _driverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SettingsContext.ImplicitWait);
                    break;
                case BrowserType.Chrome:
                    ChromeOptions optionc = new ChromeOptions();
                    optionc.AddArguments("start-maximized");
                    optionc.AddArguments("--disable-gpu");
                    if (SettingsContext.IsHeadless)
                    {
                        optionc.AddArguments("--headless");
                    }

                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _driverContext.Driver = new ChromeDriver(optionc);
                    _driverContext.browser = new Browser(_driverContext);
                    _driverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(SettingsContext.ImplicitWait);
                    break;
            }
        }

        [BeforeTestRun]
        public static void TestInitalize()
        {
            InitializeSettings();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            OpenBrowser(SettingsContext.Browser);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverContext.Driver.Quit();
        }
    }
}
