using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SauceDemo.PageObjects
{
    public class CheckoutOverviewPage
    {
        private readonly IPage _page;

        public CheckoutOverviewPage(IPage page)
        {
            _page = page;
        }

        private ILocator FinishButton => _page.Locator("#finish");

        public async Task<CheckoutCompletePage> CompleteCheckoutAsync()
        {
            await FinishButton.ClickAsync();
            return new CheckoutCompletePage(_page);
        }
    }
}

