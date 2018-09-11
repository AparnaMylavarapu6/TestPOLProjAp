Feature: PostWidgetSettings
	
@ignore
Scenario: Post the widget settings
	Given I have entered the settings information
	| settingsid | settingsType | settingValue |
	| 1234       | String       | Ture         |
	And I have entered the Entity Settings information
	| EntityId | EntityType | EntityText | Address | City   | State | Zip   | UserId | ModifiedById |
	| 1234     | Property   | Test       | Test    | Irvine | Texas | 75038 | 0      | 0            |
	When I send a post request to insert the settings information 
	Then A valid successful response should be generated with the data posted successfully

