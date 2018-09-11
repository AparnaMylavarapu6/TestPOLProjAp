Feature: Carrier


@happypath
Scenario: Post HO4 Rates

Given I have entered the property details to post the rates

| propertyID | propertyName           | propertyAddress     | state | quoteSource     | zipcode | quoteEffdDate       |
| 156        | Meadow Bay LeasingDesk | 5555 South Paradise | CA    | OLL Integration | 0       | 2018-08-25T00:00:00 |

When I send a valid POST Request with the input
Then A valid product package information should be generated


@happypath
Scenario: Post POL Rates

Given I have entered the property details to post POL Rates

| propertyID | propertyName           | propertyAddress     | state | quoteSource     | zipcode | quoteEffdDate       |
| 156        | Meadow Bay LeasingDesk | 5555 South Paradise | CA    | OLL Integration | 0       | 2018-08-25T00:00:00 |

When I send a valid POST Request with the POL input data
Then A valid product package information should be generated
          