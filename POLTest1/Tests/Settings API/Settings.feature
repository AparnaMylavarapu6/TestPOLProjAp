Feature: Settings

@happypath
Scenario: To Verify the GET request of Settings API using SettingsID

	Given Provided with the valid SettingsID.
	| SettingsID |
	| 1520     |
	When I send a GET request to fetch settings details.
	 Then The valid settings details should be displayed.
	
@happypath
Scenario: To Verify the Delete request of Settings API using SettingsID

	Given Provided with the valid SettingsID to be deleted.
	| SettingsID |
	| 1631     |
	When I send a DELETE request to Delete settings details.
	Then The settings details should be deleted.
	
@happypath
Scenario: To Verify the POST request of Settings API
	Given I have provided Entity Settings details.
	| EntityId | EntityType | EntityText     | Address			| city   | state | zip   | UserId | ModifiedById |
	| 605499   | 1			| Southern Elms | 4519 E 31st  Street     | Tulsa | OK    | 74135	|	   0  | 0       |
	And Provided with the new SettingsInfo details.
	| settingsID | settingType | settingValue   |
	| 260		 | HO4         | true |
	When I send a POST request to add new settings
	Then The valid settings details should be saved.

@happypath
Scenario: To Verify the PUT request of Settings API
	Given I have provided Entity Settings details for PUT Request.
	| EntityId | EntityType | EntityText     | Address			| city   | state | zip   | UserId | ModifiedById |
	| 601234   | 1			| BlueStone Lofts | 101 Summit St   | Duluth | CA	| 55803 |   -1   | 0       |
	And Provided with the new SettingsInfo details for PUT.
	| settingsID | settingType | settingValue   |
	| 291		 | POL         | true |
	When I send a PUT request to update new settings
	Then The valid settings details should be updated.

@happypath
Scenario: To Verify the GET request of Settings API using EntityID and EntityType

	Given Provided with the valid EntityID and EntityType.
	| EntityID | EntityType |
	| 9277  |  Property  |
	#| 611489  |  Company  |
	When I send a GET request to fetch settings details EntityID and EntityType.
	Then The valid settings details should be displayed based on EntityID and EntityType.

@happypath
Scenario: To Verify the GET request of Settings API using PropertyID and PropertyType

	Given Provided with the valid PropertyID and PropertyType.
	| PropertyID | PropertyType |
	| 609769  |  LeasingDesk  |
	| 2913444  |  Onesite  |
	| 6717648  |  Yardi  |
	When I send a GET request to fetch settings details PropertyID and PropertyType.
	Then The valid settings details should be displayed based on PropertyID and PropertyType.

