Feature: LeaseSignOptIn


@needtorunfordev
Scenario: Method to POST the lease signin option details

Given I have entered the lease and property integration details
| leaseId | isOptIn | entityType | entityId |
| 101     | 1       | onesite    | 609248   |
| 102     | 0       | onesite    | 609248   |

When I send a valid POST request
Then A valid response should be generated.

@needtorunfordev
Scenario: Method to PUT the lease signin option details

Given I have entered the lease and property integration details for PUT Request
| leaseId | isOptIn | entityType | entityId |
| 101     | 1       | onesite    | 609248   |

When I send a valid PUT request
Then A valid response should be generated.
