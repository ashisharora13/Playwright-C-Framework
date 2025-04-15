using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SauceDemo.PageObjects
{
    public class AboutPage
    {
        private readonly IPage _page;

        public AboutPage(IPage page)
        {
            _page = page;
        }

        public async Task<string> GetAboutTextAsync()
        {
            var element = await _page.QuerySelectorAsync("#about-text");
            if (element == null)
            {
                throw new InvalidOperationException("The about text element was not found.");
            }
            var aboutText = await element.InnerTextAsync();
        return aboutText ?? throw new InvalidOperationException("The about text was empty.");

        }
    }
}
