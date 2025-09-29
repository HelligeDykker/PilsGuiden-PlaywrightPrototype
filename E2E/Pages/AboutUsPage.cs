using Microsoft.Playwright;

namespace E2E.Pages
{
    internal class AboutUsPage
    {
        private readonly IPage _page;
        public AboutUsPage(IPage page)
        {
            _page = page;
        }

        public ILocator AboutUsHeader => _page.Locator("h2");
    }
}
