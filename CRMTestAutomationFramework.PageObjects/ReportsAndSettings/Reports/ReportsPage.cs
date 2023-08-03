using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.ReportsAndSettings.Reports
{
    public class ReportsPage : BasePage
    {
        public ReportsPage(IWebDriver driver) : base(driver)
        {
            Filter = new ReportsTableFilter(driver);
        }

        public ReportsTableFilter Filter { get; set; }

        public ReportPage OpenReport(string reportName)
        {
            var reportPage = Filter.SearchBySearchField<ReportPage>(reportName);
            reportPage.WaitForStatusMessageIsHidden();
            return reportPage;
        }
    }
}
