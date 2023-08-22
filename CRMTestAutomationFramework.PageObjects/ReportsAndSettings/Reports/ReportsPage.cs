using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.ReportsAndSettings.Reports
{
    public class ReportsPage : BaseAppPage
    {
        public ReportsPage(IWebDriver driver) : base(driver)
        {
            _filter = new ReportsTableFilter(driver);
        }

        private ReportsTableFilter _filter { get; set; }

        public ReportPage OpenReport(string reportName)
        {
            var reportPage = _filter.SearchBySearchField<ReportPage>(reportName);
            reportPage.WaitForStatusMessageIsHidden();
            return reportPage;
        }
    }
}
