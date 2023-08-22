using CRMTestAutomationFramework.Core.BusinessObjects;
using CRMTestAutomationFramework.Core.Constants;
using CRMTestAutomationFramework.PageObjects.SalesAndMarketing.Contacts;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMTestAutomationFramework.Specs.StepDefinitions
{
    [Binding]
    public class ContactsStepDefenitions : BaseStepDefenition
    {
        private Contact _contact;
        private ContactsPage _contactsPage;
        private ContactDetailsPage _contactDetailsPage;

        [Given(@"Contact with following parameters")]
        public void GivenContactWithFollowingParameters(Table table)
        {
            _contact = new Contact(table); 
        }

        [When(@"I navigate to Contacts page")]
        public void WhenINavigateToSalesMarketingContactsPage()
        {
            _contactsPage = HomeDashboardPage.NavigateTo<ContactsPage>(MenuItems.SalesAndMarketing, MenuItems.Contacts);
        }

        [When(@"Create contact with given parameters")]
        public void WhenCreateContactWithGivenParameters()
        {
            _contactDetailsPage = _contactsPage.CreateContact(_contact);
        }

        [Then(@"I am on contact details")]
        public void WhenIOpenContactDetails()
        {
            _contactDetailsPage.WaitEditIsAvailable();
            _contactDetailsPage.WaitForStatusMessageIsHidden();
            _contactDetailsPage.PageTitleText.Should().Contain($"Contacts: {_contact.FirstName} {_contact.LastName}".ToUpper());
        }

        [Then(@"Contact details should be correct")]
        public void ThenContactDetailsShouldBeCorrect()
        {
            _contactDetailsPage.SummaryHeaderText.Should().Contain($"{_contact.FirstName} {_contact.LastName}");
            _contactDetailsPage.CategoryText.Should().Contain(String.Join(", ", _contact.Categories));
        }

    }
}
