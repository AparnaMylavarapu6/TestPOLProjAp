Feature: HO4PolicyLocation
	

@happypath
Scenario: Get Policy Location by PolicyId
	Given I have entered the policyid to fetch the policy locations
	| policyid |
	| 6130581  |

	When I send a Get request to getpolicylocation method
	Then The policy location should be fetched successfully 

@notimplementedindev
Scenario: Delete Policy Location by policyid
	Given I have entered the policyid to delete the policy locations
	| policyid |
	| 6130588  |

	When I send a Delete request to deletepolicylocation method
	Then The policy location should be deleted successfully

@happypath
Scenario: Get Policy Location by locationid
	Given I have entered the locationid to fetch the policy locations
	| locationid |
	|   222994   |

	When I send a Get request with the locationid to fetch policies 
	Then The policies should be fetched successfully 


@notimplementedindev
Scenario: Delete Policy Location by locationid
	Given I have entered the locationid to delete the policy locations
	| locationid |
	|     5322151       |

	When I send a Delete request with the locationid to delete policies 
	Then The policies should be deleted successfully 

@happypath
Scenario: Post Policy Location
Given I have entered the Policy Location information
| policyId | locationID | TransferEffectiveDate | makeVaccant | active |
| 0        | 0          |                       | true        | true   |

When I send a Post request to insert the policy location information
Then The policy location information should be inserted successfully

@happypath
Scenario: Put Policy Location
Given I have provided the Policy Location information 
| policyId | locationID | TransferEffectiveDate | makeVaccant | active |
| 0        | 0          |                       | true        | true   |

When I send a Put request to insert or update the policy location information
Then The policy location information should be updated successfully


