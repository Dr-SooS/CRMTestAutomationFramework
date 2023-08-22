using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.ReportsAndSettings.ActivityLog
{
    public class ActivityLogPage : BaseAppPage
    {
        public ActivityLogPage(IWebDriver driver) : base(driver)
        {
            _activityLogTable = new ActivityLogTable(driver);
        }

        private ActivityLogTable _activityLogTable;
        public ActivityLogTable ActivityLogTable => _activityLogTable;
    }
}
