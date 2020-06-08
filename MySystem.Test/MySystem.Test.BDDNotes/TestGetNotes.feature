Feature: TestGetNotes
    In order to get notes
    As a user
    I want to get notes info

Scenario: Get according notes successful
    Given User try to connect the server
    When it will be successful
    When User try to enter by login: z and password: pas through Client
    When it will be successful
    When User try to get account by IdUser: 10
	When it will be successful
    When User try to get notes by IdAccount: 2
	Then it will be successful