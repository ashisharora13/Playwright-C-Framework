using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SauceDemo.PageObjects
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public ILocator UsernameInput => _page.Locator("#user-name");
        public ILocator PasswordInput => _page.Locator("#password");
        public ILocator LoginButton => _page.Locator("#login-button");
        public ILocator ErrorMessage => _page.Locator(".error-message-container");

        public async Task<InventoryPage> LoginAsync(string username, string password)
        {
            await UsernameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();

            //await _page.WaitForNavigationAsync();
            return new InventoryPage(_page);
        }

        public async Task<string?> GetErrorMessageAsync()
        {
            return await ErrorMessage.TextContentAsync();
        }
    }
}
