Feature: SettingsTest



@needtorunfordev
Scenario: Get Unit information based on the propertytype and propertyid

Given I have entered a valid Property type and Property id
| PropertyType | PropertyId |
| OneSite      | 120        |
| Yardi        | 120        |

When I send a valid GET request to fetch the unit information
Then List of valid locations should be displayed
