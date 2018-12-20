Feature: ResidentOccupancy


@mytag
Scenario: Post ResidentOccupancy details
	Given I have to Post ResidentOccupancy details
	| resType | locationID | leaseStartDate | leaseEndDate |
	| 1       | 2484631    |9/20/2018 12:00:00 AM | 9/20/2019 12:00:00 AM  |
	And I have provided Residents Name Information.
	| firstName | middleName | lastName |
	| John      | kennith    | roy      |    
	And Provided additional Resident details
	| externalResID | residentID | isPrimaryResident | dateofBirth              | email				| mobileNumber |
	|       170     | 0			| true				 | 1976-06-25T00:00:00		|   John@roy.com    | 5896568741   |
	And I have provided Mailing Address Information.
	| addressLine1      | addressLine2 | city     | state    | zipCode |
	| 1126 Orchid Cir # |              | Bellport | NY | 11713  |   
	When I send a Post request to insert the ResidentOccupancy details
	Then The ResidentOccupancy details should be posted