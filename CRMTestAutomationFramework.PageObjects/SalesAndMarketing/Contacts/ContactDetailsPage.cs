using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.SalesAndMarketing.Contacts
{
    public class ContactDetailsPage : BaseAppPage
    {
        public ContactDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement _editButton => _driver.FindElement(By.Id("DetailForm_edit"));
        private IWebElement _summaryHeader => _driver.FindElement(By.Id("_form_header"));
        private IWebElement _category => _driver.FindElement(By.XPath("//li[./p[.='Category']]"));

        public string SummaryHeaderText => _summaryHeader.Text;
        public string CategoryText => _category.Text;

        public void WaitEditIsAvailable()
        {
            Wait().Until(WebDriver => _editButton.Displayed);
        }
    }
}
