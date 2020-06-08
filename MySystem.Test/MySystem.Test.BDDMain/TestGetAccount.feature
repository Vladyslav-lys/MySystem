Feature: TestGetAccount
	In order to get account
	As a user
	I want to get account info

@mytag
Scenario: Get according account successful
	Given User try to connect the server
	When it will be successful
	When User try to enter by login: z and password: pas through Client
	When it will be successful
	When User try to get account by IdUser: 10
	Then it will be successful
