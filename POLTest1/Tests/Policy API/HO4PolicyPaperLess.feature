Feature: HO4PolicyPaperLess
	
#Post PolicyPaperLess method
@needtoupdate
Scenario: Post the Policy PaperLess information
	Given I have entered the policy information for the post paperless operation
	| policyid | isPaperLess | vendorSentDate |
	| 0        | true        |                |

	When I send a Post request with the given inputs to the post paperless method
	Then A successful response should be generated for the post operation

#Put PolicyPaperLess method
@needtoupdate
Scenario: Post or Update the Policy PaperLess information
	Given I have entered the policy information for the put paperless operation
	| policyid | isPaperLess | vendorSentDate |
	| 0        | true        |                |

	When I send a Put request with the given inputs to the put paperless method
	Then A successful response should be generated for the put operation and the information should be updated or inserted successfully


#Fetch PolicyPaperLess method
@happypath

Scenario: Fetch the policy paperless information with the policyid as input

Given I have provided the policy id as input for fetching the policy paperless information
| policyid | policyPaperLessPolicyid |
| 123123   | 234234                  |
| 131415   |                         |

When I send a Get request to fetch the policy paperless information
Then A successful response should be generated with the policy paperless information


#Delete PolicyPaperLess method
@happypath

Scenario: Delete the policy paperless information with the policyid as input

Given I have provided the policy id as input for deleting the policy paperless information
| policyid | policyPaperLessPolicyid |
| 123123   | 234234                  |
| 131415   |                         |

When I send a Delete request to delete the policy paperless information
Then A successful response should be generated for the delete policy paperless method



