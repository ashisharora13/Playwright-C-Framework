using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SauceDemo.PageObjects
{
    public class CartPage
    {
        private readonly IPage _page;

        public CartPage(IPage page)
        {
            _page = page;
        }

        private ILocator CheckoutButton => _page.Locator("#checkout");

        public async Task<CheckoutPage> ProceedToCheckoutAsync()
        {
            await CheckoutButton.ClickAsync();
            return new CheckoutPage(_page);
        }
    }
}
