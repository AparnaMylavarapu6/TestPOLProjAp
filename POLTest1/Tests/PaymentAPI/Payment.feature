Feature: Payment

@mytag
Scenario: Post CustomerRegistration
	Given I have a request to register a customer
	| CarrierName | PolicyNumber | ResidentID | propertyID | firstName | lastName | email                     | phoneNumber |
	| AMIG        | 0023262524   | 45678945   | 156        | Register  | Customer | registercustomer@test.com | 585695532   | 

	And  I have provided the location details
	| addressLine1        | addressLine2 | city       | state | zipCode |
	| 1214 E Algonquin Rd | 2C           | Schaumburg | IL    | 60173   |
	When I have entered the customer details 
	Then the customer should be registered


@mytag
Scenario: Post AccountRegistration
	Given I have a request to register a account
	| carrierName | policyNumber | paymentMethod | customerNumber |
	| AMIG        | 0023262524   | CC            | 12345656       | 

    And I have provided the accountinformation
	| nameOnAccount | accountNumber | routingNumber | accountType | checkNumber |  
	| Test Name     | 123456789654  | 0021000021    | savings     | 12564       |   

	And I aslo provide the Account Location Details
	| addressLine1        | addressLine2 | city       | state | zipCode |
	| 1214 E Algonquin Rd | 2C           | Schaumburg | IL    | 60173   |

	When I have entered the account details 
	Then the account should be registered


@mytag
Scenario: Post ProcessPayment
	Given I have tp process a payment
	| transactionAmount | transactionFee | propertyID | residentID | policyNumber | carrierName | customerReferenceID | accountReferenceID | checkNumber | isCreditCard | transType | cvv |
	| 235.25            | 3              | 156        | 123456858  | 0032125867   | AMIG        | 3434343             | 3333               | 12343       | true         | 1         | 123 |
	When I have entered the payment details 
	Then the payment should be successfull

@mytag
Scenario: Post ProcessPaymentSubmission
	Given I have to process a paymentSubmission
	| CarrierName | PolicyNumber | paymentMethod |  residentID | propertyID | firstName | lastName | email                | phoneNumber | transactionAmount | transactionFee |
	| AMIG        | 0023262524   | CC           | 45678945   | 156        | viswa  | Customer | chj@test.com | 585695532   |       235.25      | 3              |

	And I have provided payment location address
	| addressLine1        | addressLine2 | city       | state | zipCode |  
	| 1214 E Algonquin Rd | 2C           | Schaumburg | IL    | 60173   |      
	
	And I have provided creditcard information
	| nameOnCard | ccNumber  | cvv | expirationMonth | expirationYear | cardType |
	| Test CC    | 4111111111111111 | 584 | 08            | 2028       | 1        |
	And i have also provided payment achInfo
	| nameOnAccount | accountNumber | routingNumber | accountType | checkNumber |
	| Test Name     | 123456789654  | 0021000021    | savings     | 23232       |

	When I have entered the ProcessPaymentSubmission details 
	Then the paymentsubmission should be successfull