using Microsoft.Playwright;

namespace E2E.Pages
{
    internal class PilsGuidenMainPage
    {
        private IPage _page;

        public PilsGuidenMainPage(IPage page)
        {
            _page = page;
        }

        private ILocator LocationBoxes => _page.Locator("[class='flex gap-2 font-semibold flex-wrap'] li");

        private async Task<ILocator> GetLocation(string LocationName)
        {
            var allAreas = await LocationBoxes.AllAsync();
            foreach (var area in allAreas)
            {
                if ((await area.InnerTextAsync()).Equals(LocationName, StringComparison.OrdinalIgnoreCase))
                {
                    return area;
                }
            }
            throw new Exception($"Location '{LocationName}' not found.");
        }

        public async Task SelectLocation(string locationName)
        {
            await (await GetLocation(locationName)).ClickAsync();
        }
    }
}
