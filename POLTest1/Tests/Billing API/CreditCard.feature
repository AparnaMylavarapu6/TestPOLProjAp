Feature: CreditCard


@happypath
Scenario: Fetch the credit card information with the card id
	Given I have entered the card id to fetch the credit card information
	| cardid  |
	| 2913598 |
	
	When I send a Get request to fetch the credit card information
	Then A valid response code should be generated with the credit card information
	| residentID |
	| 79048976   |

@notimplementedindev
Scenario: Delete the credit card information with the card id
	Given I have entered the card id to delete the credit card information
	| cardid  |
	| 2913598 |
	
	When I send a Delete request to delete the credit card information
	Then A valid response code should be generated with the credit card information being deleted successfully


@happypath
Scenario: Post the credit crad information
Given I have entered the credit card information to post the data
| cardType | name | cardNumber | expMonth | expYear | residentID | paymentMethod | customerReferenceID | accountReferenceID |
| Visa     | Test Test | 41111111111 | 09       | 2020    | 0          | Monthly       | 3234233ASSAAS       | 0980989fDDDASD     |
| 1        | Test Test | 41111111111 | 09       | 2020    | 0          | Monthly       | 3234233ASSAAS       | 0980989fDDDASD     |

When I send a post request with the credit card information
Then The CC information should be inserted successfully


@happypath
Scenario: Insert or update the credit crad information
Given I have entered the credit card information to insert or update the data
| cardType | name | cardNumber | expMonth | expYear | residentID | paymentMethod | customerReferenceID | accountReferenceID |
| Visa     | Test Test | 41111111111 | 09       | 2020    | 0          | Monthly       | 3234233ASSAAS       | 0980989fDDDASD     |
| 1        | Test Test | 41111111111 | 09       | 2020    | 0          | Monthly       | 3234233ASSAAS       | 0980989fDDDASD     |
When I send a put request with the credit card information
Then The CC information should be inserted or updated successfully