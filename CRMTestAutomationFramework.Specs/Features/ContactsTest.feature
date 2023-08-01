Feature: ContactsTest


Scenario: Create contact
	Given Contact with following parameters
		| First Name | Last Name  | Categories           |
		| Test       | Test       | Customers, Suppliers |
	When I navigate to Sales & Marketing > Contacts page
	And Create contact with given parameters
	And I open contact details
	Then Contact details should be correct
