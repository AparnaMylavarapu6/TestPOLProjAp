Feature: ThirdPartyPolicy


#Post ThirdParty policy method
@needtorunfordev
Scenario: Post ThirdParty Policy
	Given I have entered the ThirdParty policy information 
	| policyid | policystatus | policynumber      | policysource | effectivedate                     | expirydate                        | createdbyid | modifiedby | liabilitylimit | carrierid | isCorporate |
	| 0        | 0            | 1125dddThirdparty | 1            | 2018-07-02T11:47:05.8374812-05:00 | 2019-07-02T11:47:05.8374844-05:00 | -3          | -3         | 100000         | 65        | false       |
	
	When I send a Post request with the policy information
	Then A valid successful response should be generated with the policy information


#Put ThirdParty policy method
@needtorunfordev
Scenario: Put ThirdParty Policy
	Given I have entered the new or updated ThirdParty policy information 
	| policyid | policystatus | policynumber      | policysource | effectivedate                     | expirydate                        | createdbyid | modifiedby | liabilitylimit | carrierid | isCorporate |
	| 0        | 0            | 1125dddThirdparty | 1            | 2018-07-02T11:47:05.8374812-05:00 | 2019-07-02T11:47:05.8374844-05:00 | -3          | -3         | 100000         | 65        | false       |
	
	When I send a Put request with the policy information
	Then A valid successful response should be generated with the new or updated policy information

#Get ThirdParty policy by policyid
@needtorunfordev

Scenario: Fetch the ThirdParty policy information with the policy id as input

Given I have provided the policy id as an input to fetch the policy information
| policyid |
| 6130579  |

When I send a Get request with the policy id as input
Then A successful response should be generated with the third party policy information


#Delete ThirdParty policy by policyid
@needtorunfordev

Scenario: Delete the ThirdParty policy information with the policy id as input

Given I have provided the policy id as an input to delete the policy information
| policyid | thirdpartypolicyid |
| 1234     |                    |
| 2345     | 3456               |

When I send a Delete request with the policy id as input
Then A successful response should be generated with the delete operation being successfully done



