using CRMTestAutomationFramework.Core.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.SalesAndMarketing.Contacts
{
    public class CreateContactPage : BaseAppPage
    {
        public CreateContactPage(IWebDriver driver) : base(driver)
        {
            _categoriesInput = new ContactCategoriesInput(driver);
        }

        private IWebElement _firstNameInput => _driver.FindElement(By.Name("first_name"));
        private IWebElement _lastNameInput => _driver.FindElement(By.Name("last_name"));
        private IWebElement _saveButton => _driver.FindElement(By.Id("DetailForm_save"));

        private ContactCategoriesInput _categoriesInput { get; set; }

        public CreateContactPage FillDetails(Core.BusinessObjects.Contact contact)
        {
            WaitForStatusMessageIsHidden();
            _firstNameInput.SendKeys(contact.FirstName);
            _lastNameInput.SendKeys(contact.LastName);
            SelectCategories(contact.Categories);
            return this;
        }

        public CreateContactPage SelectCategories(List<string> categories)
        {
            _categoriesInput.SelectCategories(categories);
            return this;
        }

        public ContactDetailsPage Save()
        {
            return _saveButton.ClickAndGo<ContactDetailsPage>(_driver);
        }
    }
}
