Feature: PMSPolicies

@needtorunfordev

Scenario: Get PMS Policy by PolicyId

Given I have entered a valid PolicyId
| policyid |
| 1234     |

When I send a valid GET request
Then The policy details should be displayed successfully.

# New Scenario 

@notimplementedindev

Scenario: Delete Policy by PolicyId

Given I have entered a valid policyid for Delete

| policyid | thirdpartypolicyid |
| 2345     | 3456               |
| 1234     |                    |
               
When I send a DELETE request
Then the policy information should be deleted successfully


#New Scenario

@needtorunfordev

Scenario: Post Policy Information
Given I have provided the Policy information
| policyID | policyStatus | policyNumber | policyTitle      | effectiveDate           | expiryDate              | cancelDate | PolicyLiabilityLimit | isCorporate | policyActionType |
| 1234     | Active       | 87666666     | RentersInsurance | 2018-01-18 22:54:54.803 | 2019-01-18 22:54:54.803 |            | 100000               | false       | New              |

And I have provided the lease information
| leaseId | leaseStartDate          | leaseEndDate            | actualMoveIn            | actualMoveOut           |
| 123445  | 2018-01-18 22:54:54.803 | 2019-01-18 22:54:54.803 | 2018-01-18 22:54:54.803 | 2019-01-18 22:54:54.803 |

And  I have provided the Carrier information
| carrierId | carrierName              |
| 233       | LeasingDesk(eRenterPlan) |

And I have provided the resident information
| residentHOHID | residentMemberID | residentHOHFirstNa - me | residentHOHLastName |
| t2344444      | r8776666         | Sailaja                 | S                   |

And  I have provided the unit information
| externalUnitId |
| 45645232343    |

When I send a POST request
Then A valid response should be generated for POST
When  I send a PUT request
Then A valid response should be generated for PUT


#New Scenario

@needtorunfordev
Scenario: Return Policy Details List

Given I have entered the valid PropertyType and PropertyId

| PropertyType | PropertyId |
| OneSite      | 120        |
| LeasingDesk  | 120        |
| Yardi        | 120        |  
When I send a valid GET request with PropertyType and PropertyId
Then List of policies in the property should be returned

#New Scenario


@needtorunfordev
Scenario: Return Occupancy Details

Given I have entered the valid PropertyType and PropertyId to fetch the occupancy details

| PropertyType | PropertyId |
| OneSite      | 120        |
| Yardi        | 120        |


When I send a valid GET request to fetch the occupancy details
Then The occupancy details should be returned