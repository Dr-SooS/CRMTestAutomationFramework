using CRMTestAutomationFramework.Core.BusinessObjects;
using CRMTestAutomationFramework.PageObjects.SalesAndMarketing.Contacts;
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

        [Given(@"Contact with following parameters")]
        public void GivenContactWithFollowingParameters(Table table)
        {
            _contact = new Contact(table); 
        }

        [When(@"I navigate to (.*) > (.*) page")]
        public void WhenINavigateToSalesMarketingContactsPage(string firstLevel, string secondLevel)
        {
            HomeDashboardPage.NavigateTo(firstLevel, secondLevel);
            _contactsPage = new ContactsPage(WebDriver);
        }

        [When(@"Create contact with given parameters")]
        public void WhenCreateContactWithGivenParameters()
        {
            throw new PendingStepException();
        }

        [When(@"I open contact details")]
        public void WhenIOpenContactDetails()
        {
            throw new PendingStepException();
        }

        [Then(@"Contact details should be correct")]
        public void ThenContactDetailsShouldBeCorrect()
        {
            throw new PendingStepException();
        }

    }
}
