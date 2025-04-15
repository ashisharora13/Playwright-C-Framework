using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace SauceDemo
{
    public class PlaywrightConfig
    {
        public static async Task<IPage> SetupPlaywrightAsync()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 50, Timeout = 20000 });
            var page = await browser.NewPageAsync();
            return page;
        }
    }
}
