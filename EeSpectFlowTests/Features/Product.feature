Feature: Product
    Create a new product

Scenario: Create product a verify the details
	Given I click the Product menu
	And I click the "Create" link
	And I create product with folliwing details
	 | Name       | Description       | Price | ProductType |
	 | Headphones | Noise canceletion | 300   | PERIPHARALS |
	When I click the Details link of the newly cread product
	Then I see all the product details are created as expected