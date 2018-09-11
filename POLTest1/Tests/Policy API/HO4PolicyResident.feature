Feature: HO4PolicyResident
	

@happypath
Scenario: Fetch Resident and policy information by policyid
	Given I have entered the policy id to fetch the policy and resident information
	| policyid |
	| 1234     |

	
	When I send a Get request to fetch the policy and resident information
	Then A successful response code should be generated with the policy and resident information
	
@happypath
Scenario: Delete resident and policy information by policyid	 
Given I have entered the policy id to delete the policy and resident information
	| policyid |
	| 1234     |

	
	When I send a Delete request to delete the policy and resident information
	Then A successful response code should be generated with the delete operation being successful

@happypath
Scenario: Fetch Resident and policy information by residentid
	Given I have entered the resident id to fetch the policy and resident information
	| residentid |
	| 1234       |

	
	When I send a Get request to fetch the policy and resident information by residentid
	Then A successful response code should be generated with the policy and resident information

@happypath
Scenario: Delete resident and policy information by residentid	 
Given I have entered the residentid id to delete the policy and resident information
	| residentid |
	| 1234       |

	
	When I send a Delete request to delete the policy and resident information by residentid
	Then A successful response code should be generated with the delete operation being successful
	
