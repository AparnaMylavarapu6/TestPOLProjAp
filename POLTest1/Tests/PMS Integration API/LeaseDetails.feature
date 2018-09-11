Feature: LeaseDetails
	

@happypath
Scenario: Fetch the lease details from PMS System
	Given I have entered the property type request to fetch the lease details
	| entityType | entityId |
	| onesite    | 609248   |
	And I have entered the Resident and Unit ID's to get the lease details
	| extResidentId | extUnitId | leaseEffectiveDate |
	| 170           | 10        | 2018-01-10         |
	When I send a Post request to the PMS System to fetch the lease details
	Then A valid success response should be genrated and the lease details should be returned
	| leaseId |
	|         |
