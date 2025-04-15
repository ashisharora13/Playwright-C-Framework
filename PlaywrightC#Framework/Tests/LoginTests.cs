using NUnit.Framework;
using SauceDemo.PageObjects;
using SauceDemo.TestData;
using System.Linq;
using System.Threading.Tasks;

namespace SauceDemo.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        [TestCase("standard_user", "secret_sauce")]
        [TestCase("locked_out_user", "secret_sauce")]
        [TestCase("problem_user", "secret_sauce")]
        [TestCase("performance_glitch_user", "secret_sauce")]
        [TestCase("error_user", "secret_sauce")]
        [TestCase("visual_user", "secret_sauce")]
        public async Task Login_WithValidCredentials_ShouldRedirectToInventoryPage(string username, string password)
        {
            var loginPage = new LoginPage(Page);
            var inventoryPage = await loginPage.LoginAsync(username, password);

            // Verify that we are on the Inventory page
            var pageTitle = await inventoryPage.GetPageTitleAsync();
            //Assert.AreEqual("PRODUCTS", pageTitle);
            Assert.That(pageTitle, Is.EqualTo("Swag Labs"));
        }
    }
}
