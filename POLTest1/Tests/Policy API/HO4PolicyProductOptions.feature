Feature: HO4PolicyProductOptions


@happypath
Scenario: Get Policy Product Options
	Given I have provided the policy id to fetch Policy Product Options
	| policyid |
	| 123456   |
	
	When I send a Get request to fetch the product options
	Then A successful response code should be generated with the product option information

@happypath
Scenario: Delete Policy Product Options
	Given I have provided the policy id to delete Policy Product Options
	| policyid |
	| 123456   |
	
	When I send a Delete request to delete the product options
	Then A successful response code should be generated with the delete option being successful

@needtoupdate
Scenario: Post Policy Product Options
	Given I have provided the Product Options List to post the product options
	| policyid | paoid | effdate | expdate | noOfIncrements |
	| 1234     | 0     |         |         | 0              |
	| 1234     | 1     |         |         | 0              |
	| 1234     | 2     |         |         | 0              |
	| 3456     | 0     |         |         | 0              |
	| 3456     | 1     |         |         | 0              |

	
	When I send a Post request with the product options list and the policy id
	Then  A successful response code should be generated with the product option information successfully posted

@needtoupdate
Scenario: Put Policy Product Options
	Given I have provided the Product Options List to insert or update the product options
	| policyid | paoid | effdate | expdate | noOfIncrements |
	| 1234     | 0     |         |         | 0              |
	| 1234     | 1     |         |         | 0              |
	| 1234     | 2     |         |         | 0              |
	| 3456     | 0     |         |         | 0              |
	| 3456     | 1     |         |         | 0              |

	When I send a Put request with the product options list and the policy id
	Then  A successful response code should be generated with the product option information successfully inserted or updated