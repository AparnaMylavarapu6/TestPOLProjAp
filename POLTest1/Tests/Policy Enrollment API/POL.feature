Feature: POL


@needtorunfordev
Scenario: Post POL Product Opt-in
	Given I have provided the property information to post the  pol product opt-in
	| propertyIdType | propertyID |
	| LeasingDesk    | 156        |
	And I have provided the quoteid and the productrateid
	| quoteid | productrateid |
	| 2864963 | 183           |
	
	When I send a Post request to fetch the certificate number
	Then A valid certificate number should be generated


@removedscenario
Scenario: Lease Approved - Activate POL Policy based on Lease Approval coming from Widget Parnet application

Given I have provided the authentication information for POL policy activation
| userid                  | password |
| webservice@realpage.com | hgC2HfBd |

And I have provided the property information for POL policy activation
| propertyIdType | propertyID |
| LeasingDesk    | 156        |

And I have provided the quote information for POL policy activation
| quoteRequestSource | extLeaseID | extUnitID | extResidentID |
| OLL Integration    | 234567     | 453256    | 1324556       |

When I send a Post request for POL Policy Activation
Then A valid success response should be generated

 

