Feature: Login Functionality

Background:
	Given Navigate to the application "https://practicetestautomation.com/practice-test-login/"

Scenario: Successful Login
	When I enter my valid creds
		| User    | Password    |
		| student | Password123 |
	And I click the login button
	Then Verify that the new url contains url "practicetestautomation.com/logged-in-successfully/"
	Then Verify that the new page contains text "Congratulations" or "successfully"
	Then Verify the logout button displayed on the new page


Scenario Outline: Validating login scenario with invalid credentials
	When User enter "<UserName>" and "<Password>"
	And I click the login button
	Then Verify error message displayed
	Then Verify error message text is "Your username is invalid!"

Examples:

	| UserName       | Password    |
	| incorrectUser  | Password123 |
	| incorrectUser2 | Password123 |
	| incorrectUser3 | Password123 |


Scenario: Invalid Password
	When I enter my valid creds
		| User    | Password    |
		| student | invalidPass |
	And I click the login button
	Then Verify error message displayed
	Then Verify error message text is "Your password is invalid!"
