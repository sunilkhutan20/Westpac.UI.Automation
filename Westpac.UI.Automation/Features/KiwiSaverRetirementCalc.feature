@KSRetirementCalc
Feature: KiwiSaverRetirementCalc

US1
As a Product Owner 
I want that while using the KiwiSaver Retirement Calculator all fields in the calculator have got the information icon present
So that 
The user is able to get a clear understanding of what needs to be entered in the field .

Acceptance Criteria
Scenario 1 
Given User Clicks information icon besides Current age the message “This calculator has an age limit of 64 years old as you need to be under the age of 65 to join KiwiSaver.” is displayed below the current age field.

US2
As a Product Owner 
I want that the KiwiSaver Retirement Calculator users are able to calculate what their KiwiSaver projected balance would be at retirement
So that 
The users are able to plan their investments better.

Acceptance Criteria

•	User whose Current age is 30 is Employed @ a Salary 82000 p/a and contributes to KiwiSaver @ 4% has a PIR 17.5% and chooses a high risk profile is able to calculate his projected balances at retirement.

•	User whose current aged 45 is Self-employed, has a PIR 10.5%, current KiwiSaver balance is $100000, voluntary contributes $90 fortnightly and chooses medium risk profile with saving goals requirement of $290000 is able to calculate his projected balances at retirement.

•	User whose current aged 55 is not employed, has a PIR 10.5%, current KiwiSaver balance is $140000, voluntary contributes $10 annually and chooses medium risk profile with saving goals requirement of $200000 is able to calculate his projected balances at retirement.



@UserStory1Scenario1
Scenario: Navigate to Retirement Calc
	Given I open the westpac home page
		And I navigate to the Retirement Calculator
	When I click the Current Age Helper Icon
	Then I can verify the Current Age information helper message is NOT "This calculator has an age limit of 64 years old as you need to be under the age of 65 to join KiwiSaver."

@UserStory2Scenario1
Scenario: High Risk Employed Profile
Given I open the westpac home page
	And I navigate to the Retirement Calculator
	And I my current age is "30"
	And my Emploment Status is "Employed"
	And my Salary Contribution is "80000"
	And my KiwiSaver Contribution is "4%"
	And my PIR is "17.5"
	And I have chosen a "High Risk" profile
When I Click on the KiwiSaver Retirement Projections button
Then I can confirm my predicted Kiwisaver Balance is available

@UserStory2Scenario2
Scenario: Medium Risk Self Employed Profile
Given I open the westpac home page
	And I navigate to the Retirement Calculator
	And I my current age is "45"
	And my Emploment Status is "self-employed"
	And my PIR is "10.5%"
	And my Current KiwiSaver Balance is 100000"
	And my Voluntary KiwiSaver Contribution is "90" "fortnightly"
	And I have chosen a "Medium Risk" profile
	And I have a savings goal of "290000"
When I Click on the KiwiSaver Retirement Projections button
Then I can confirm my predicted Kiwisaver Balance is available

@UserStory2Scenario3
Scenario: Medium Risk Unemployed Profile
Given I open the westpac home page
	And I navigate to the Retirement Calculator
	And I my current age is "55"
	And my Emploment Status is "not-employed"
	And my PIR is "10.5%"
	And my Current KiwiSaver Balance is "140000"
	And my Voluntary KiwiSaver Contribution is "10" "annually"
	And I have chosen a "Medium Risk" profile
	And I have a savings goal of "200000"
When I Click on the KiwiSaver Retirement Projections button
Then I can confirm my predicted Kiwisaver Balance is available

