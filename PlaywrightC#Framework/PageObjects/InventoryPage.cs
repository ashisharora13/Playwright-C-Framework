using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SauceDemo.PageObjects
{
    public class InventoryPage
    {
        private readonly IPage _page;

        public InventoryPage(IPage page)
        {
            _page = page;
        }

        private ILocator GetAddToCartButton(string itemName) =>
            _page.Locator($"text={itemName} >> .. >> button.text=ADD TO CART");

        private ILocator CartIcon => _page.Locator(".shopping_cart_link");

        public async Task AddItemToCartAsync(string itemName)
        {
            var addToCartButton = GetAddToCartButton(itemName);
            await addToCartButton.ClickAsync();
        }

        public async Task<CartPage> GoToCartPageAsync()
        {
            await CartIcon.ClickAsync();
            return new CartPage(_page);
        }

        public async Task<string> GetPageTitleAsync()
        {
            return await _page.TitleAsync();
        }
    }
}
