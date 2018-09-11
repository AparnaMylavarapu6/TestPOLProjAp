Feature: PropertyIntegrationSettings
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@needtorunfordev
Scenario: Get Property Integration Settings based on PropertyId and PropertyType

Given I have entered a valid property type and propertyid

| PropertyType | PropertyId |
| OneSite      | 120        |
| Yardi        | 120        |
| MRI          | 120        |

When I send a valid GET request to fetch the Integration information
Then Valid Integration settings should be displayed