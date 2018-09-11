Feature: HO4Policy

@needtorunfordev

Scenario: Get Policy Details

Given I have provided a policyid to fetch the policy details 
| policyid |
|          |

When I send a Get request to the web API 
Then The policy information should be fetched successfully

@notimplementedindev

Scenario: Delete Policy Details

Given I have provided a valid policyid to delete the policy details
| policyid |
|          |

When I send a valid Delete request with the policyid to the web API
Then The policy information should be removed successfully


@needtorunfordev

Scenario: Post Policy Information

Given I have provided the policy details to post the information

| policyId | quoteId | policyNumber | policySource | policyStatus | effectiveDate | expiryDate | createdById | modifiedBy | carrier | productID |
| 0        | 123546  | 0236265244   | 1            | 1            | 2018-06-25T16:25:43.0017085-05:00 | 2019-06-25T16:25:43.0017099-05:00 | 0           | 2          | AMIG    | 104       |

When I send a valid Post Request to the Web API
Then The policy information should be posted successfully


@needtorunfordev

Scenario: Put Policy Information

Given I have provided the policy details to update the policy information 

| policyId | quoteId | policyNumber | policySource | policyStatus | effectiveDate | expiryDate | createdById | modifiedBy | carrier | productID |
| 0        | 123546  | 0236265244   | 1            | 1            | 2018-06-25T16:25:43.0017085-05:00 | 2019-06-25T16:25:43.0017099-05:00 | 0           | 2          | AMIG    | 104       |

When I send a valid Put Request to the Web API
Then The policy information should be updated successfully
