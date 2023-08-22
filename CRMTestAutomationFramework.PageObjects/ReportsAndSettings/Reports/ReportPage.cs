using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.ReportsAndSettings.Reports
{
    public class ReportPage : BaseAppPage
    {
        public ReportPage(IWebDriver driver) : base(driver)
        {
            _reportResultsTable = new ReportResultsTable(driver);
        }

        private ReportResultsTable _reportResultsTable { get; set; }

        private IWebElement _runReportButton => _driver.FindElement(By.Name("FilterForm_applyButton"));

        public int ResultsCount => _reportResultsTable.RowsCount;

        public void RunReport()
        {
            _runReportButton.Click();
        }
    }
}
