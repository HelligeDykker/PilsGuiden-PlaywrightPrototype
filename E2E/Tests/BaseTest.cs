using E2E.Utilities;

namespace E2E.Tests
{
    public class BaseTest : PageTest
    {
        public async Task NavigateToPage(string page)
        {
            var baseUrl = BaseUrl.GetBaseUrl();
            if (!new ApplicationPages().Pages.TryGetValue(page, out var url))
            {
                throw new ArgumentException($"Page '{page}' not found in Urlpages.");
            }

            await Page.GotoAsync(baseUrl + url);
        }
    }
}
