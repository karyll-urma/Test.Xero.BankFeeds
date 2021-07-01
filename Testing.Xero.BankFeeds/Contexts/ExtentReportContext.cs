using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Xero.BankFeeds.Contexts
{
    public class ExtentReportContext
    {
        public ExtentReports report;

        public ExtentReportContext()
        {
            report = new ExtentReports();
        }
    }
}
