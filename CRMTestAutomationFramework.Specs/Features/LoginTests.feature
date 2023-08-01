Feature: LoginTests

A short summary of the feature

@tag1
Scenario: Login Test
	Given I'm on the LoginPage
	When I try to login with admin username and admin password
	Then I should be logged in successfully
