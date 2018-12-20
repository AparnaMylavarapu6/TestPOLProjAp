Feature: Residents
	

@mytag
Scenario: Get Resident details
	Given I have resident details
	| ResidentID |
	| 8522		 |
	When I pass the residentid for a get request
	Then the resident details should be displayed

@mytag
Scenario: Delete Resident details
	Given I have to Delete resident details
	| ResidentID |
	| 8521		 |
	When I pass the residnet id for a delete request
	Then the Delete resident details should be displayed

@mytag
Scenario: Post Resident details
	Given I have to Post new resident details
	| resType | locationID | leaseStartDate | leaseEndDate | createdDate |
	| 1           |      1      |2018-09-14T11:29:12.862Z | 2018-09-14T11:29:12.862Z  |2018-09-14T11:29:12.862Z|
	And I have provided Residents Information.
	| firstName | middleName | lastName |
	| 113       | true       | 1234     |
	And Provided additional Resident details          |
	| externalResID | residentID | isPrimaryResident | dateofBirth | email | mobileNumber |
	|               |            |                   |             |       |              |
	And I have provided Mailing Address Information.
	| addressLine1 | addressLine2 | city | state | zipCode |
	|              |              |      |       |         |
	When I pass the resident id for a post request
	Then the post resident details should be displayed

@mytag
Scenario: Put Resident details
	Given I have to update resident details
	| resType | locationID | leaseStartDate | leaseEndDate | createdDate |
	| 1           |      1      |2018-09-14T11:29:12.862Z | 2018-09-14T11:29:12.862Z  |2018-09-14T11:29:12.862Z|
	And I have provided Residents Information.
	| firstName | middleName | lastName |
	| 113       | true       | 1234     |
	And Provided additional Resident details          |
	| externalResID | residentID | isPrimaryResident | dateofBirth | email | mobileNumber |
	|               |            |                   |             |       |              |
	And I have provided Mailing Address Information.
	| addressLine1 | addressLine2 | city | state | zipCode |
	|              |              |      |       |         |
	When I send a Put request to insert the Occupancy details
	When I pass the resident id for a put request
	Then the put resident details should be displayed



