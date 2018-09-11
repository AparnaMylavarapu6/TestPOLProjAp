Feature: BillPayment


@happypath
Scenario: Fetch Bill Payment by paymentid
	Given I have entered the payment id to fetch the bill payment information
	| paymentid |
	| 1234      |
	When I send a Get request to fetch the bill payment information with the payment id
	Then A successful response code should be generated with the bill payment information



@notimplementedindev
Scenario: Delete Bill Payment by paymentid
	Given I have entered the payment id to delete the bill payment information
	| paymentid |
	| 1234      |
	When I send a Delete request to fetch the bill payment information with the payment id
	Then A successful response code should be generated with the bill payment information deleted successfully

@happypath
Scenario: Post Bill Payment information
	Given I have entered the bill payment information to be posted
	| paymentid | paymentMethod | paymentFrequency | paymentTransactionType | residentid | policyid | paymentStatus | paymentDueDate           | amount | feeCharged | agreementid | paymentTermBeginDate     | paymentTermEndDate       | processingSource | userid | CustomTermFeeCharge |
	| 1234      | CC            | Monthly          | 0                      | 1234       | 1234     | 1             | 2018-08-21T14:33:43.090Z | 0      | 0          | 0           | 2018-08-21T14:33:43.090Z | 2018-08-21T14:33:43.090Z |                  | 0      | 0                   |

	When I send a Post request to insert the bill payment information
	Then A successful response code should be generated with the bill payment information posted successfully


@happypath
Scenario: Put Bill Payment information
	Given I have entered the bill payment information to be inserted or updated
	| paymentid | paymentMethod | paymentFrequency | paymentTransactionType | residentid | policyid | paymentStatus | paymentDueDate           | amount | feeCharged | agreementid | paymentTermBeginDate     | paymentTermEndDate       | processingSource | userid | CustomTermFeeCharge |
	| 1234      | CC            | Monthly          | 0                      | 1234       | 1234     | 1             | 2018-08-21T14:33:43.090Z | 0      | 0          | 0           | 2018-08-21T14:33:43.090Z | 2018-08-21T14:33:43.090Z |                  | 0      | 0                   |

	When I send a Put request to insert or update the bill payment information
	Then A successful response code should be generated with the bill payment information inserted or updated successfully

