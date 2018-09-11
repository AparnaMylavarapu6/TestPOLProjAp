Feature: Get Policy Confirmation Document
	

@needtorunfordev
Scenario: Get Policy Confirmation Document by residentid
	Given I have provided the residentid to get policy confirmation document
	| residentid |
	|            |
	When I send a Post  request to fetch the confirmation document
	Then A valid policy confirmation document response should be generated



