Feature: LedgerMonthly
	

@happypath
Scenario: Fetch monthly ledger data when ledgerMonthlyid is provided
	Given I have provided the ledgerMonthlyid to fetch the monthly ledger data
	| ledgermonthlyid |
	| 12345           |
	When I send a Get request to fetch the montly ledger information
	Then A success response should be generated and the monthly ledger information should be returned

	
@notimplementedindev
Scenario: Delete monthly ledger data when ledgerMonthlyid is provided
	Given I have provided the ledgerMonthlyid to delete the monthly ledger data
	| ledgermonthlyid |
	| 12345           |
	When I send a Delete request to delete the montly ledger information
	Then A success response should be generated and the monthly ledger information should be deleted successfully

@happypath
Scenario: Post Monthly ledger data
	Given I have provided the monthly ledger data to post the data
	| ledgerMonthlyID | ledgerID | premium | ledgerStartDate          | ledgerEndDate            | excludeLedger | commission | carrierCommunicationSent | ledgerGeneratedDate      | excludeReason | serviceFee |
	| 0               | 0        | 0       | 2018-08-28T12:13:31.087Z | 2018-08-28T12:13:31.087Z | true          | 0          | 2018-08-28T12:13:31.087Z | 2018-08-28T12:13:31.087Z | 0             | 0          |
	When I send a Post request to insert the monthly ledger data
	Then A success response code should be generated and the monthly ledger data should be successfully inserted

@happypath
Scenario: Insert or Update Monthly ledger data
	Given I have provided the monthly ledger data to insert or update the data
	| ledgerMonthlyID | ledgerID | premium | ledgerStartDate          | ledgerEndDate            | excludeLedger | commission | carrierCommunicationSent | ledgerGeneratedDate      | excludeReason | serviceFee |
	| 0               | 0        | 0       | 2018-08-28T12:13:31.087Z | 2018-08-28T12:13:31.087Z | true          | 0          | 2018-08-28T12:13:31.087Z | 2018-08-28T12:13:31.087Z | 0             | 0          |
	When I send a Put request to insert or update the monthly ledger data
	Then A success response code should be generated and the monthly ledger data should be successfully inserted or updated



