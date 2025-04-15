using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SauceDemo.PageObjects
{
    public class CheckoutPage
    {
        private readonly IPage _page;

        public CheckoutPage(IPage page)
        {
            _page = page;
        }

        private ILocator FirstNameInput => _page.Locator("#first-name");
        private ILocator LastNameInput => _page.Locator("#last-name");
        private ILocator ZipCodeInput => _page.Locator("#postal-code");
        private ILocator ContinueButton => _page.Locator("#continue");

        public async Task<CheckoutOverviewPage> FillCheckoutInfoAsync(string firstName, string lastName, string zipCode)
        {
            await FirstNameInput.FillAsync(firstName);
            await LastNameInput.FillAsync(lastName);
            await ZipCodeInput.FillAsync(zipCode);
            await ContinueButton.ClickAsync();

            return new CheckoutOverviewPage(_page);
        }
    }
}
