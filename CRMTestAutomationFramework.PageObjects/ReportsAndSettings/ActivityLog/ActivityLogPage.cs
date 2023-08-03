using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.ReportsAndSettings.ActivityLog
{
    public class ActivityLogPage : BasePage
    {
        public ActivityLogPage(IWebDriver driver) : base(driver)
        {
            ActivityLogTable = new ActivityLogTable(driver);
        }

        public ActivityLogTable ActivityLogTable;
    }
}
