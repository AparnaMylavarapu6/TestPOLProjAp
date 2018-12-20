Feature: Occupancy

@happypath
Scenario: Get Occupancy details
	Given I have OccupancyID details
	| OccupancyID |
	| 336539      |
	When I pass the OccupancyID for a get request
	Then the Occupant details should be displayed

@happypath
Scenario: Delete Occupancy details
	Given I have request to delete Occupancy details
	| OccupancyID |
	| 336613      |
	When I pass the OccupancyID for a Delete request
	Then the Occupant details will be deleted

@happypath
Scenario: Post Occupancy details
	Given I have request to Post Occupancy details
	| occupancyGroupId | locationID | leaseStartDate | leaseEndDate | createdDate |
	| 1           |      1      |2018-09-14T11:29:12.862Z | 2018-12-14T11:29:12.862Z  |2018-09-14T11:29:12.862Z|
	And I have provided Residents Information.
	| residentId | isPrimary | occupancyID |
	|  113       |   true    |    1234    |
	When I send a Post request to insert the Occupancy details
	Then the Occupant details will be added

@happypath
Scenario: Put Occupancy details
	Given I have request to PUT Occupancy details
	| occupancyGroupId | locationID | leaseStartDate | leaseEndDate | createdDate |
	| 1           |      1      |2018-09-14T11:29:12.862Z | 2018-09-14T11:29:12.862Z  |2018-09-14T11:29:12.862Z|
	And I have provided Residents Information for PUT Request.
	| residentId | isPrimary | occupancyID |
	|  113       |   true    |    1234    |
	When I send a Put request to insert the Occupancy details
	Then the Occupant details will be updated