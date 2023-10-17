using AutoFixture.Xunit2;
using EaApplicationTest.Models;
using EaApplicationTest.Pages;



namespace EaApplicationTest
{
    public class UnitTest1
    {
        private readonly IHomePage _homePage;
        private readonly IProductPage _productPage;

        public UnitTest1(IDriverFixture driverFixture, IHomePage homePage, IProductPage productPage)
        {
            _homePage = homePage;
            _productPage = productPage;
        }

        [Theory]
        [AutoData]
        public void Test1(Product product)
        {

            //Click the create link
            _homePage.ClickProduct();

            //create product
            _productPage.ClickCreateButton();
            _productPage.CreateProduct(product);

            //Table
            _productPage.PerformClickOnSpecialValue(product.Name, operation: "Details");
        }


    }
}