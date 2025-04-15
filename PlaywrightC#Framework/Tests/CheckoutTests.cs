using NUnit.Framework;
using SauceDemo.PageObjects;
using SauceDemo.TestData;
using System.Linq;
using System.Threading.Tasks;

namespace SauceDemo.Tests
{
    [TestFixture]
    public class CheckoutTests : BaseTest
    {
        private readonly TestDataProvider _testDataProvider;

        public CheckoutTests()
        {
            _testDataProvider = new TestDataProvider("TestData/testdata.db");
        }

        [Test]
        public async Task Checkout_WithValidInformation_ShouldCompleteSuccessfully()
        {
            var user = _testDataProvider.GetTestUsers().FirstOrDefault(u => u.Username == "standard_user");
            var customerInfo = _testDataProvider.GetCustomerInfo().FirstOrDefault();

            if (user == null || customerInfo == null)
                Assert.Fail("Test data not found.");

            var loginPage = new LoginPage(Page);
            await loginPage.LoginAsync(user.Username, user.Password);

            var inventoryPage = new InventoryPage(Page);
            await inventoryPage.AddItemToCartAsync("Sauce Labs Backpack"); // Example item name
            var cartPage = await inventoryPage.GoToCartPageAsync();
            var checkoutPage = await cartPage.ProceedToCheckoutAsync();
            var checkoutOverviewPage = await checkoutPage.FillCheckoutInfoAsync(customerInfo.FirstName, customerInfo.LastName, customerInfo.ZipCode);
            var checkoutCompletePage = await checkoutOverviewPage.CompleteCheckoutAsync();

            var completionMessage = await checkoutCompletePage.GetCompletionMessageAsync();
            //Assert.AreEqual("THANK YOU FOR YOUR ORDER", completionMessage);
            Assert.That(completionMessage, Is.EqualTo("THANK YOU FOR YOUR ORDER"));
        }
    }
}
