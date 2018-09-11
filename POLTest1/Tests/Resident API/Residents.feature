Feature: Residents


@ignore

Scenario: Get Resident Information

Given I have a valid residentid to fetch the resident information
| residentid |
|            |
When I send a valid Get Request to fetch the resident information 
Then A valid resident information response should be generated


@ignore
Scenario: Delete Resident Information

Given I have a valid residentid to delete the resident information
| residentid |
|            |
When I send a valid Delete Request to delete the resident information
Then A valid response for the delete operation should be generated


@ignore

Scenario: Post Resident Information

Given I have the resident details for Post operation

| residentType | fristName | middleName | lastName | email   | mobileNumber  | extResidentID | dateOfBirth | mailingAddressValidated |
| LeasingDesk  | Chris     | S          | Thomas   | a@a.com | 9877666555555 | t123456       | 03/03/1980  | true                    |

And  I have the mailing address details

| addressLine1 | addressLine2 | city | state | postalCode |
|              |              |      |       |            |

When I Send a Post Request to the system
Then The success response should be generated for the post operation