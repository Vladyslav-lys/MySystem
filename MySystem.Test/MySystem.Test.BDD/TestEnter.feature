Feature: TestEnter
	In order to enter the page
	As a user
	I want to be entered

@mytag
Scenario: Enter to the system successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: z and password: pas through Client
	Then it will be successful
