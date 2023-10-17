
using EaApplicationTest.Pages;
using EeSpectFlowTests.Models;
using TechTalk.SpecFlow.Assist;


namespace EeSpectFlowTests.StepDefinitions
{
    [Binding]
    public sealed class ProductStepDefinitions
    {
        private readonly ScenarioContext _scenarioContex;
        private readonly IHomePage _homePage;
        private readonly IProductPage _productPage;

        public ProductStepDefinitions(ScenarioContext scenarioContex, IHomePage homePage, IProductPage productPage) 
        {
            _scenarioContex = scenarioContex;
            _homePage = homePage;
            _productPage = productPage;
        }

        [Given(@"I click the Product menu")]
        public void GivenIClickTheProductMenu()
        {
            _homePage.ClickProduct();
        }

        [Given(@"I click the ""([^""]*)"" link")]
        public void GivenIClickTheLink(string create)
        {
            _productPage.ClickCreateButton();
        }

        [Given(@"I create product with folliwing details")]
        public void GivenICreateProductWithFolliwingDetails(Table table)
        {
            var product = table.CreateInstance<Product>();

            _productPage.CreateProduct(product);

            _scenarioContex.Set(product);
        }

        [When(@"I click the Details link of the newly cread product")]
        public void WhenIClickTheDetailsLinkOfTheNewlyCreadProduct()
        {
            var product = _scenarioContex.Get<Product>();
            _productPage.PerformClickOnSpecialValue(product.Name, operation: "Details");
        }

        [Then(@"I see all the product details are created as expected")]
        public void ThenISeeAllTheProductDetailsAreCreatedAsExpected()
        {
            var product = _scenarioContex.Get<Product>();
            _productPage.GetProductName().Should().BeEquivalentTo(product.Name.Trim());
        }
    }
}
