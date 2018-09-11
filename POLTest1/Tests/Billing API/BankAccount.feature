Feature: BankAccount

#Get Bank Account Details when accountid is provided
@happypath
Scenario: Fetch Bank Account details when account id is provided
	Given I have provided the account id to fetch the bank account details
	| accountid |
	| 186650    |
	When I send a Get request to fetch the bank account details for the provided account id
	Then A valid success response should be generated with the bank account information


#Delete Bank Account Details when accountid is provided
@happypath
Scenario: Delete Bank Account details when account id is provided
	Given I have provided the account id to delete the bank account details
	| accountid |
	| 186649    |
	When I send a Delete request to fetch the bank account details for the provided account id
	Then A valid success response should be generated and the bank account details should be succdessfully deleted

#Post Bank Account Details when bank details are provided
@happypath
Scenario: Post Bank Account Details 

	Given I have provided the bank account details to post the information
	| routingNumber | accountNumber | checkNumber | customerReferenceID | accountReferenceID | isPrimary |
	| 390349534095  | 0938453489    | 133         | 0820483AGJHSADJKL   | 9889989DFFGGS4885  | true      |

	When I send a post request to insert the bank account details
	Then A valid success response should be generated and the details should be inserted successfully

#Put method when bank details are provided
@happypath
Scenario: Insert or update Bank Account Details 

	Given I have provided the bank account details to insert or update the information
	| routingNumber | accountNumber | checkNumber | customerReferenceID | accountReferenceID | isPrimary |
	| 390349534095  | 0938453489    | 133         | 0820483AGJHSADJKL   | 9889989DFFGGS4885  | true      |

	When I send a put request to insert or update the bank account details
	Then A valid success response should be generated and the details should be inserted or updated successfully