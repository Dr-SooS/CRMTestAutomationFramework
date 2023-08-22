using CRMTestAutomationFramework.Core.Constants;
using CRMTestAutomationFramework.PageObjects.ReportsAndSettings.Reports;
using CRMTestAutomationFramework.PageObjects.SalesAndMarketing.Contacts;
using CRMTestAutomationFramework.PageObjects.TodayActivities.HomeDashboard;
using System;
using TechTalk.SpecFlow;

namespace CRMTestAutomationFramework.Specs.StepDefinitions
{
    [Binding]
    public class ReportsTestsStepDefinitions : BaseStepDefenition
    {
        private ReportsPage _reportsPage;
        private ReportPage _reportPage;

        [When(@"I navigate to Reports page")]
        public void WhenINavigateToReportsPage()
        {
            _reportsPage = HomeDashboardPage.NavigateTo<ReportsPage>(MenuItems.ReportsAndSettings, MenuItems.Reports);
            _reportsPage.WaitForStatusMessageIsHidden();
        }

        [When(@"Look for report '([^']*)'")]
        public void WhenLookForReport(string reportName)
        {
            _reportPage = _reportsPage.OpenReport(reportName);
        }

        [When(@"I run report")]
        public void WhenIRunReport()
        {
            _reportPage.RunReport();
            _reportPage.WaitForStatusMessageIsHidden();
        }

        [Then(@"There should be results")]
        public void ThenThereShouldBeResults()
        {
            _reportPage.ResultsCount.Should().BeGreaterThan(0);
        }
    }
}
