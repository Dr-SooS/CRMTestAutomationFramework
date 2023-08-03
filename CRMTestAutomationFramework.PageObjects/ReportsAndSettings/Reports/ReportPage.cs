using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.ReportsAndSettings.Reports
{
    public class ReportPage : BasePage
    {
        public ReportPage(IWebDriver driver) : base(driver)
        {
            ReportResultsTable = new ReportResultsTable(driver);
        }

        public ReportResultsTable ReportResultsTable { get; set; }

        public IWebElement RunReportButton => _driver.FindElement(By.Name("FilterForm_applyButton"));
    }
}
