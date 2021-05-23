Feature: FileUploadPOC

Scenario: Verify file upload in Google Drive
	Given I naviagte to the Google Image upload page
	When I waits until the page or element loads
	Then I shoud be on GoogleImage upload page
	When I upload a file "0_sss.jpg"
	And I waits until the page or element loads
	Then Image should be uploaded