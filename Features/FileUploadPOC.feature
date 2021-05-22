Feature: FileUploadPOC

Scenario: Verify file upload in Google Drive
	Given I naviagte to the GoogleDrive Sign page
	When I waits until the page or element loads
	When I sign in with the below details
		| Key      | Value                        |
		| Username | pravashendhu.kumar@gmail.com |
		| Password | Pravash!990                  |
	#Then I shoud be on GoogleDrive homepage
	#When I upload a file
	#Then File should be uploaded