Feature: ThirdPartyPolicy
	

@needtorunfordev
Scenario: Post PolicyUpload
	Given I have entered the policy information
	| policyNumber | effectiveDate | expiryDate | carrierName | liabilityAmount | docData |
	|              |               |            |             |                 |         |
	When I send a Post Request to post the policy doc data
	Then A valid policy upload response should be generated
