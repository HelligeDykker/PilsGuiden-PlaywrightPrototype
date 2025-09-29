using E2E.Utilities;

namespace E2E.Tests
{
    internal class BaseTest : PageTest
    {
        public async Task NavigateToPage(string PageUrl)
        {
            var baseUrl = BaseUrl.GetBaseUrl();
            if (new ApplicationPages().Pages.TryGetValue(PageUrl, out var targetUrl))
            {
                await Page.GotoAsync(baseUrl + targetUrl);
            }
            else throw new ArgumentException($"{PageUrl} was not found, please check the page dictionary");
            
        }
    }
}
