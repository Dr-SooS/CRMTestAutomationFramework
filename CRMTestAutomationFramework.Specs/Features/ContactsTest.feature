Feature: ContactsTest


Scenario: Create contact
	Given Contact with following parameters
		| First Name | Last Name  | Categories          |
		| Test       | Test       | Customers,Suppliers |
	When I navigate to Contacts page
	And Create contact with given parameters
	Then I am on contact details
	And Contact details should be correct
