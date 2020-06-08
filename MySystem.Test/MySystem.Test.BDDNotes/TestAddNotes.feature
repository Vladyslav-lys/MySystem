Feature: TestAddNotes
    In order to add notes
    As a user
    I want to add notes info

Scenario: Add according notes successful
    Given User try to connect the server
    When it will be successful
    When User try to enter by login: z and password: pas through Client
    When it will be successful
    When User try to get account by IdUser: 10
	When it will be successful
    When User try to get notes by IdAccount: 2
	When it will be successful
    When User try to add notes by Topic: tref and Text: df and DateTime: new DateTime(2019,11,11) and Image: new byte[0] and IdAccount: 2
	Then it will be successful