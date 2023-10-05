Feature: Testing ecom application
Scenario: Registration on practice website
	Given User launch registration Url "https://rahulshettyacademy.com/client"
	And I click on Register link
	When Enter required details
		| FirstName | LastName | Email    | PhoneNumber | Occupation | Password   | Gender |
		| Vinee  | Jos   | vj41@t.com | 9562896543  | Student    | Master@123 | Male   |
	And I click on Register button
	Then Verify that the new page contains text "Account Created Successfully"
	Then Verify the Login button displayed on the new page



Scenario: Validate required field error message
	Given User launch registration Url "https://rahulshettyacademy.com/client"
	And I click on Register link
	When I click on Register button
	Then Verify error message displayed for all required field


