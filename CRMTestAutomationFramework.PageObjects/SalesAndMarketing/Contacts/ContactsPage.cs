using CRMTestAutomationFramework.Core.BusinessObjects;
using CRMTestAutomationFramework.Core.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.PageObjects.SalesAndMarketing.Contacts
{
    public class ContactsPage : BasePage
    {
        public ContactsPage(IWebDriver driver) : base(driver)
        {
        }

        public ContactDetailsPage CreateContact(Contact contact)
        {
            var createContactPage = this.ClickOnShortcut<CreateContactPage>("Create Contact");
            createContactPage.WaitForStatusMessageIsHidden();
            createContactPage.FirstNameInput.SendKeys(contact.FirstName);
            createContactPage.LastNameInput.SendKeys(contact.LastName);
            createContactPage.SelectCategories(contact.Categories);
            return createContactPage.SaveButton.ClickAndGo<ContactDetailsPage>(_driver);
        }
    }
}
