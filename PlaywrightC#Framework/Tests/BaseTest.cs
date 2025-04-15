using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace SauceDemo.Tests
{
    public class BaseTest
    {
        protected IPage Page;

        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions 
            { 
                Headless = true 
            });
            var context = await browser.NewContextAsync();
            Page = await context.NewPageAsync();

            // Navigate to the base URL
            await Page.GotoAsync("https://www.saucedemo.com/");
        }

        [TearDown]
        public async Task Teardown()
        {
            // Close the browser after each test
            await Page.CloseAsync();
        }
    }
}
