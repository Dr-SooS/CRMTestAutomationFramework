Feature: ActivityLogTests


Scenario: Remove events from activity log
	When I open Activity Log page
	And I select first 3 records
	And I Delete selected records
	Then Records should not be present in table
