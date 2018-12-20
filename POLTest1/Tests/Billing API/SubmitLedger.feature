Feature: SubmitLedger

@mytag
Scenario: SubmitLedger Information
	Given I have provided Ledger Information.
	| ledgerID | groupPolicyID | groupPolicyNumber | certificateNumber | locationID | policyStatusID | productRateID | quoteID | ledgerMonthlyID | residentIDs | annualBillingEffDate | annualBillingEndDate | excludeLedger | commission | carrierCommunicationSent | ledgerGeneratedDate | excludeReason | serviceFeeId |
	| 20       | 1             | ANC611489CA1234   | 04AN000DS         | 19761      | 1              | 2             | 27      |  0              |   80155883   | 2018-08-01 00:00:00.000  | 2019-08-21 00:00:00.000 |    0     |    0        | 2018-08-02 00:00:00.000    |  2018-07-30 00:00:00.000 |1         |    0          |
	When I send a post request to insert the Ledger information 
	Then A valid successful response should be generated with the Ledger data posted successfully
