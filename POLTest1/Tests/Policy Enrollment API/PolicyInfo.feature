Feature: PolicyInfo

@needtorunfordev
Scenario: Get Policy Details
	Given I have entered the unit information to fetch the policy details
	| externalResidentID | unitType | unitID |
	| 12345              | External | 45678  |

	When I send a Post request to fetch the policy details
	Then The Policy details should be displayed

