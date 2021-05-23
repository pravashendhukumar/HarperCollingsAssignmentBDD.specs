Feature: AmazonPOC
	In order to buy a mobile in Amazon
	As a consumer I will search for a mobile 
	And I want to add that mobile to my basket

Background:
	Given  I am navigating to amazon hoomepage

Scenario: As a consumer I want to change the shoping language
	Given I should be on amazon homepage
	When I waits until the page or element loads
	When I change my shoping language as per my native language
	And I waits until the page or element loads
	Then I am able to see my shoping language as per choosen language
	When I waits until the page or element loads
	And I again rechange my shoping language to English
	And I waits until the page or element loads
	Then I should be on amazon homepage

Scenario Outline: As a consumer I want to search for a Mobile and add it to the cart
	Given I should be on amazon homepage
	When I waits until the page or element loads
	When I enter "<ItemName>" into the search field and hit enter
	And I waits until the page or element loads
	Then I should see my searched item "<ItemName>" in the results list

	Examples:
		| ItemName      |
		| The Fisherman |
		| OnePlus       |

Scenario Outline: consumer add the book to the basket
	Given I have nothing in my basket, it displays a total of "0"
	When I search for a "<ItemName>" in Amazon
	And I waits until the page or element loads
	And I see the details page of the "<ItemName>"
	And I waits until the page or element loads
	And I should see the book is "In stock."
	And I add the book to the basket
	Then my basket should dispaly a total of "1"

	Examples:
		| ItemName      |
		| The Fisherman |
		