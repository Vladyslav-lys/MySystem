Feature: GetUsersFromDatabaseWrongConnection
	In order to get users from database
    As a user
    I want to get users from database

@mytag
Scenario: Get false users connection from database
    Given Set false unit Of work for wrong connection
    When Try to get users from database
    Then Get the false result
