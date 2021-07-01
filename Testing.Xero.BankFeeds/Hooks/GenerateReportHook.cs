using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Testing.Xero.BankFeeds.Contexts;

namespace Testing.Xero.BankFeeds.Hooks
{
    [Binding]
    public class GenerateReportHook
    {
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private readonly TestContext _testContext;
        private readonly ExtentReportContext _extent;
        private static ExtentTest _featureNode;
        private ExtentTest _scenarioNode;

        public GenerateReportHook(FeatureContext featureContext, ScenarioContext scenarioContext, TestContext testContext, ExtentReportContext extent)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _testContext = testContext;
            _extent = extent;
        }

        [BeforeTestRun]
        public static void TestSetup(ExtentReportContext extent)
        {
            // Initialize Extent Report
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\net5.0", "");
            string time = DateTime.Now.ToString("HHmmss-ddMMyyyy");//timeStamp

            Directory.CreateDirectory(@"C:\Temp\Test Reports\" + time);
            var htmlReporter = new ExtentHtmlReporter(@"C:\Temp\Test Reports\" + time + "\\");
            extent.report.AddSystemInfo("Tester", "Karyll Hardy Urma");
            htmlReporter.LoadConfig(dir + "\\extent-config.xml");
            extent.report.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TestTearDown(ExtentReportContext extent)
        {
            extent.report.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext, ExtentReportContext extent)
        {
            _featureNode = extent.report.CreateTest<Feature>("FEATURE: " + featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {

            string scenarioName = TestContext.CurrentContext.Test.Name;
            scenarioName = scenarioName.Replace(",null", "");
            _scenarioNode = _featureNode.CreateNode<Scenario>("SCENARIO: " + scenarioName);
        }

        [AfterStep]
        public void AfterStep()
        {
            var errorMessage = "Unknown Error!";
            try
            {
                errorMessage = _scenarioContext.TestError.Message;
            }
            catch (Exception ex) { Console.WriteLine($"Exception caught {ex}"); }

            switch (ScenarioStepContext.Current.StepInfo.StepDefinitionType)
            {
                case TechTalk.SpecFlow.Bindings.StepDefinitionType.Given:
                    if (_scenarioContext.TestError == null)
                        _scenarioNode.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                    else
                        _scenarioNode.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(errorMessage);
                    break;

                case TechTalk.SpecFlow.Bindings.StepDefinitionType.When:
                    if (_scenarioContext.TestError == null)
                        _scenarioNode.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                    else
                        _scenarioNode.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(errorMessage);
                    break;

                case TechTalk.SpecFlow.Bindings.StepDefinitionType.Then:
                    if (_scenarioContext.TestError == null)
                        _scenarioNode.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                    else
                        _scenarioNode.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(errorMessage);
                    break;
            }
        }
    }
}
