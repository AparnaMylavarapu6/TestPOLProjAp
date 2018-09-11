Feature: POLPolicy

#Pol method with entitytype and entityid as parameters	
@needtorunfordev
Scenario: Get POL Policy by entity type and entity id
	Given I have entered the entity type and the entity id
	| entityid | entitytype |
	| 1234     | Property   |
	| 1234     | Company    |


	When I send a Get request to fetch the POL policies
	Then The POL policies should be fetched successfully

#GetDetails method with certificatenumber and residentid as parameters
@needtorunfordev
Scenario: Get POL policy by resident id and certificate number

Given I have entered the resident id and the certificate number of the pol policy
| certificatenumber | residentid |
| 1234              | 12343      |

When I send a Get request with the certificate number and the residentid
Then The policy, property, lease and ledger information tied up to the resident should be displayed


#GetPolicyDetails method with certificatenumber and residentid as parameters
@needtorunfordev
Scenario: Get Policy Details by resident id and certificate number

Given I have provided the resident id and certificate number for policy details
| certificatenumber | residentid |
| 1234              | 1234       |

When I send a Get request to the get policy details method
Then A successful response should be generated from the method with the resident id and certificate number


#GetPolicyDetails method with certificatenumber and locationid as parameters
@needtorunfordev
Scenario: Get Policy Details by location id and certificate number

Given I have provided the location id and the certificate number fo policy details
| certificatenumber | locationid |
| 1234              | 1234       |

When I send a Get request with the location id and certification number
Then A successful response should be generated from the method with the location id and certificate number


#GetLedgerMonthlyDetails method
@needtorunfordev
Scenario: Get the ledger monthly details by ledger info id

Given I have entered the ledger info id to fetch the ledger details
| ledgerinfoid |
| 1234         |

When I send a Get request to fetch the monthly ledger details
Then A successful response should be generated with the monthly ledger details


#GetLedgerInfo method
@needtorunfordev
Scenario: Get the ledger information by ledger info id
Given I have provided the ledger info id to fetch the ledger information
| ledgerinfoid |
| 1234         |

When I send a Get request to fetch the ledger information
Then A successful response should be generated with the ledger information


#GetResidentDetails method
@needtorunfordev
Scenario: Get Resident details by certificate number

Given I have entered the certificate number to fetch the resident details
| certificatenumber |
| 1234              |

When I send a Get request to fetch the resident details
Then A successful response should be generated with the resident details


#GetProductCoverageDetails method
@needtorunfordev

Scenario: Get the product coverage details with the certificate number and location id

Given I have entered the certificate number and location id to fetch the product coverage details
| certificatenumber | locationid |
| 1234              | 1234       |

When I send a Get request to fetch the product coverage details
Then A successful response should be generated with the product coverage details





 


