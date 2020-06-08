Feature: GetUsersFromDatabaseWrongTable
	In order to get users from database
    As a user
    I want to get error

@mytag
Scenario: Get false users table from database
    Given Set false unit Of work for wrong table
    When Try to get users from database
    Then Get the false result
