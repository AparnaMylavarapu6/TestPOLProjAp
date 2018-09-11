Feature: HO4
	

@needtorunfordev
Scenario: Get Quote
	Given I have entered the authentication information to fetch the Quote Product Package Details
	| userId                  | password |
	| webservice@realpage.com | hgC2HfBd |
	And I have entered the property information to fetch the Quote Product Package Details 
	| propertyIdType | propertyID |
	| LeasingDesk    | 156        |
	And I have entered the unit information to fetch the Quote Product Package Details
	| UnitIDType  | UnitID |
	| Leasingdesk |        |
	And I have entered the resident name to fetch the Quote Product Package Details
	| firstName | middleName | lastName     |
	| Insurance |            | PolicyEnroll |
	And I have entered the resident information to fetch the Quote Product Package Details
	| externalResID | isPrimaryResident | dateofBirth | email   | mobileNumber |
	|               | true              | 1998-01-01  | a@a.com | 0000000000   | 
	And  I have entered the lease information to fetch the Quote Product Package Details
	| coverageDate | quoteRequestSource | leaseID | isRenewal |
	| 2018-04-27   | OLL Integration    | 234567  | false     |
	When I Send a Post request to fetch the Quote Product Package Details
	Then A valid Quote Product Package Details should be returned

@needtorunfordev
Scenario: Send Decline Notices

	Given I have entered the property information to send decline notices
	| propertyIdType | propertyID |
	| LeasingDesk    | 156        |
	And  I have entered the quote and decline notice information
	| quoteId | firstName | lastName | email | address | address2 | city | state | zipcode | notifyByEmail | notifyByPost |
	|         |           |          |       |         |          |      |       |         |               |              |

	And I have entered the decline reason id

	| declineReasonId |
	|                 |  

	And I have entered the decline reason
	| declineReason |
	|               |

	When I send a post request to send the decline reasons
	Then A valid response should be generated from the system

@needtorunfordev
Scenario: Quote Submission
	Given I have entered the authentication information for quote submission
	| userId                  | password |
	| webservice@realpage.com | hgC2HfBd |

	And I have entered the Deductible Information
	| pOAID |
	|       |

	And I have entered the Endorsement Information
	| pOAID |
	|       |

	And I have entered the resident name for quote submission
	| firstName | middleName | lastName |
	| test      |            | Test2    |

	And I have entered the other resident information for quote submission
	| residentID | externalResID | mobileNumber | email   | isPrimaryResident | dateOfBirth |
	| 13444      | 34566         | 999999999    | a@a.com | true              | 04/04/2000  |

	And I have entered the Mailing Address Information for Quote Submission
	| addressLine1   | addressLine2 | city      | state | zipCode |
	| 123 Test Drive |              | Test City | CA    |         |

	And I have entered the Quote Information
	| quoteID | productGroupID | locationID | isMailingAddressAsUnitAddress | underwritingQuestionsAcceptance | quoteRequestSource |
	| 1234    | 1              | 12345      | true                          | true                            | OLL                |

	When I send a Post request for quote submission
	Then The quote should be successfully posted

@needtorunfordev
Scenario: Payment Submission
	Given I have entered the authentication information for payment submission
	| userId                  | password |
	| webservice@realpage.com | hgC2HfBd |

	And  I have entered the credit card information for payment submission
	| nameOnCard | cardType | cardNumber | cVV | cCExpDateMonth | cCExpDateFourDigitYear |
	|            |          |            |     |                |                        |

	And I have entered the ACH information for payment submission
	| name | accountName | routingNumber | accountNumber | checkNumber |
	|      |             |               |               |             |

	And I have entered the payment type information for payment submission
	| paymentTypesInfo | paymentFrequency |
	| CreditCard       | Monthly          |

	And I have entered the quote and premium information
	| quoteID | annualPremium | modalFeePremium | termFeePremium | termPremium | noticeofPrivacyPolicyPracticesAcceptance | noticeofFraudWarningAcceptance | termsandConditionsAcceptance | isPaperLess | isSameDayDisclaimer |
	|         |               |                 |                |             |                                          |                                |                              |             |                     |

	When I send a Post request for payment submission
	Then A valid response should be generated for the payment submission method


@needtorunfordev
Scenario: Get Policy Confirmation Document

Given I have provided the policy id to fetch the confirmation document
| policyid |
| 12345    |

When I send a Get Request to fetch the confirmation document
Then A valid confirmation document response should be generated



	

