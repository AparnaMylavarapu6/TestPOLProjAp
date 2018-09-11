Feature: PropertyInfo


@needtorunfordev
Scenario: Get Property Status
	Given I have entered the property type information
	| propertyIdType | propertyID |
	| LeasingDesk    | 156        |
	When I send a POST request with the property type information input
	Then A successful property status response should be generated


@needtorunfordev
Scenario: Get property addresses
Given I have entered the property type information to the GetPropertyAddress method as input
| propertyIDType | propertyID |
| LeasingDesk    | 156        |
| OneSite        | 120        |
| Yardi          | 120        |
| MRI            | 120        |

When I send a POST request to the GetPropertyAddress method
Then A Valid Property Addresses response should be generated

@needtorunfordev
Scenario: Get Widget Settings
Given I have entered the authentication information
| userId                  | password |
| webservice@realpage.com | hgC2HfBd |

And I have entered the property information
| propertyIdType | propertyID |
| LeasingDesk    | 156        |

And I have entered the unit information
| UnitIDType  | UnitID |
| Leasingdesk |        |

And I have entered the Resident details
| firstName | middleName | lastName     |
| Insurance |            | PolicyEnroll |

And I have entered the resident personal information
| externalResID | isPrimaryResident | dateofBirth | email   | mobileNumber |
|               | true              | 1998-01-01  | a@a.com | 0000000000   |

And I have entered the error code information
| code | message |
| 0    |         |

And  I have entered other lease information
| quoteRequestSource | leaseID | isRenewal | coverageDate |
| OLL Integration    | 234567  | false     | 2018-04-27   |

When I send a POST request to fetch the widget settings
Then A valid settings response should be generated

