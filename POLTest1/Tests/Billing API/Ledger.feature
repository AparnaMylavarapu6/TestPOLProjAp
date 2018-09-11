Feature: Ledger


@happypath
Scenario: Fetch ledger information when ledgerid is provided
	Given I have provided the ledgerid to fetch the ledger information
	| ledgerid |
	| 12345    |
	When I send a Get request to fetch the ledger information for the provided ledgerid
	Then A success response code should be generated and the ledger information should be returned



@notimplementedindev
Scenario: Delete ledger information when ledgerid is provided
	Given I have provided the ledgerid to delete the ledger information
	| ledgerid |
	| 12345    |
	When I send a Delete request to delete the ledger information for the provided ledgerid
	Then A success response code should be generated and the ledger information should be deleted successfully

@happypath
Scenario: Post the ledger information 
	Given I have provided the ledger information to post the data
	| ledgerID | groupPolicyID | groupPolicyNumber | certificateNumber | locationID | AnnualPremium | ledgerEffectiveDate      | ledgerEndDate            | policyStatusID | productRateID | quoteID |
	| 12345    | 0             |                   |                   | 0          | 0             | 2018-08-28T12:12:08.041Z | 2018-08-28T12:12:08.041Z | 0              | 0             | 0       |
	When I send a Post request to insert the ledger information
	Then  A success response should be generated and the ledger information should be inserted successfully


@happypath
Scenario: Insert or update the ledger information 
	Given I have provided the ledger information to insert or update the data
	| ledgerID | groupPolicyID | groupPolicyNumber | certificateNumber | locationID | AnnualPremium | ledgerEffectiveDate      | ledgerEndDate            | policyStatusID | productRateID | quoteID |
	| 12345    | 0             |                   |                   | 0          | 0             | 2018-08-28T12:12:08.041Z | 2018-08-28T12:12:08.041Z | 0              | 0             | 0       |
	When I send a Put request to insert or update the ledger information
	Then  A success response should be generated and the ledger information should be inserted or updated successfully



