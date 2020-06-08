Feature: GetUsersFromDatabase
    In order to get users from database
    As a user
    I want to get error

@mytag
Scenario: Get right users from database
    Given Set right unit of work
    When I try to get users from database
    Then Get the right result
