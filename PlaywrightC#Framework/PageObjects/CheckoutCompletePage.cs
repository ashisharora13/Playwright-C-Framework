using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SauceDemo.PageObjects
{
    public class CheckoutCompletePage
    {
        private readonly IPage _page;

        public CheckoutCompletePage(IPage page)
        {
            _page = page;
        }

        private ILocator CompletionMessage => _page.Locator(".complete-header");

        public async Task<string?> GetCompletionMessageAsync()
        {
            return await CompletionMessage.TextContentAsync();
        }
    }
}
