Feature: ReportsTests

Scenario: Run Report
	When I navigate to Reports page
	And Look for report 'Project Profitability'
	And I run report
	Then There should be results
