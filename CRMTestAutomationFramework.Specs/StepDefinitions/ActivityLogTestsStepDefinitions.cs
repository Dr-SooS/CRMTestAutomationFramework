using CRMTestAutomationFramework.Core.Constants;
using CRMTestAutomationFramework.PageObjects.ReportsAndSettings.ActivityLog;
using CRMTestAutomationFramework.PageObjects.ReportsAndSettings.Reports;
using System;
using TechTalk.SpecFlow;

namespace CRMTestAutomationFramework.Specs.StepDefinitions
{
    [Binding]
    public class ActivityLogTestsStepDefinitions : BaseStepDefenition
    {
        private ActivityLogPage _activityLogPage;
        private List<string> _activitiesToDelete = new List<string>();

        [When(@"I open Activity Log page")]
        public void WhenIOpenActivityLogPage()
        {
            _activityLogPage = HomeDashboardPage.NavigateTo<ActivityLogPage>(MenuItems.ReportsAndSettings, MenuItems.ActivityLog);
            _activityLogPage.WaitForStatusMessageIsHidden();
        }

        [When(@"I select first (.*) records")]
        public void WhenISelectFirstRecords(int recordsCountToSelect)
        {
            for (int i = 0; i < recordsCountToSelect; i++)
            {
                _activityLogPage.ActivityLogTable.SelectRow(i);
                _activitiesToDelete.Add(_activityLogPage.ActivityLogTable.GetCellValue(i + 1, 2));
            }
        }

        [When(@"I Delete selected records")]
        public void WhenIDeleteSelectedRecords()
        {
            _activityLogPage.ClickAction(Actions.Delete);
            WebDriver.SwitchTo().Alert().Accept();
            _activityLogPage.WaitForStatusMessageIsHidden();
        }

        [Then(@"Records should not be present in table")]
        public void ThenRecordsShouldNotBePresentInTable()
        {
            _activitiesToDelete.ForEach(activity => { _activityLogPage.ActivityLogTable.IsRowContainingFollowingTextExists(activity).Should().BeFalse(); });
        }
    }
}
