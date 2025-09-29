namespace E2E.Tests
{
    internal class BaseTest : PageTest
    {
        public void NavigateToPage(string url)
        {
            Page.GotoAsync(url).GetAwaiter().GetResult();
        }
    }
}
