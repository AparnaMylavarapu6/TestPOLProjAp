Feature: Billing


@happypath
Scenario: Get Billing information by billing id
	Given I have entered the billing id to fetch the billing information
	| billingid |
	| 4197178   |
	
	When I send a Get request to fetch the billing information
	Then A successful response code should be generated with the billing information
	| billingID | policyID | residentID | paymentMethod | paymentFrequency | billingDate         | nextBillingDate     | annualPremium | statementCount |
	| 4197178   | 6130671  | 79049094   | 1             | 4                | 2018-09-07T00:00:00 | 2019-09-02T00:00:00 | 198.101       | 1              |

@notimplementedindev
Scenario: Delete Billing information by billing id
	Given I have entered the billing id to delete the billing information
	| billingid |
	| 1234      |
	
	When I send a Delete request to delete the billing information
	Then A successful response code should be generated with the billing information deleted successfully

@happypath
Scenario: Post Billing information
	Given I have entered the billing information to be posted
	| billingid | residentid | policyid | paymentmethod | paymentfrequency | billingdate              | nextbillingdate          | annualpremium | statementcount |
	| 4197178   | 79049094   | 6130671  | 1            | 4         | 2018-09-07T14:33:33.679Z | 2019-09-02T14:33:33.679Z | 198.00           | 1              |
	
	When I send a Post request to insert the billing information
	Then A successful response code should be generated with the billing information inserted successfully
	| billingid |
	| 4197186   |

@happypath
Scenario: Put Billing information
	Given I have entered the billing information to be inserted or updated
| billingid | residentid | policyid | paymentmethod | paymentfrequency | billingdate              | nextbillingdate          | annualpremium | statementcount |
| 4199136   | 78851183   | 6099770  | 1            | 2        | 2018-09-06T14:33:33.679Z | 2018-09-21T14:33:33.679Z | 180           | 1              |
	
	When I send a Put request to insert or update the billing information
	Then A successful response code should be generated with the billing information inserted or updated successfully




