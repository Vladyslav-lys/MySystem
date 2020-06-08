Feature: TestEditAccount
	In order to edit account
	As a user
	I want to edit account info

@mytag
Scenario: Edit according account successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: z and password: pas through Client
	When it will be successful
	When User try to get account by IdUser: 10
	When it will be successful
	When User try to edit account by Id: 2 and lastName: Lysenko and firstName: Vlad and secondName: Urievich and IdUser: 10
	Then it will be successful
