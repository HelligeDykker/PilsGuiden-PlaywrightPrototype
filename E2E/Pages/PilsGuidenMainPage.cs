using Microsoft.Playwright;

namespace E2E.Pages
{
    internal class PilsGuidenMainPage
    {
        private readonly IPage _page;
        public PilsGuidenMainPage(IPage page)
        {
            _page = page;
        }
        private ILocator LocationList => _page.Locator("[class=\"flex gap-2 font-semibold flex-wrap\"] li");
        
        public ILocator PubFilterButton => _page.Locator("[id='filter-button']");
        private ILocator PubFilterDialog => _page.Locator("fieldset");
        private ILocator PubFilterSearchInput => PubFilterDialog.Locator("[type='text']");
        private ILocator PubFilterUseFilterButton => PubFilterDialog.GetByRole(AriaRole.Button, new() { Name = "Bruk filter" });

        public ILocator GetPubBox(string pubName)
        {
            return _page.GetByRole(AriaRole.Button, new() { Name = pubName });
        }

        private async Task<ILocator> GetLocation(string locationFilter)
        {
            var locations = await LocationList.AllAsync();
            foreach (var location in locations)
            {
                if ((await location.InnerTextAsync()).Equals(locationFilter, StringComparison.OrdinalIgnoreCase))
                {
                    return location;
                }
            }
            throw new Exception($"Location '{locationFilter}' not found.");
        }
        public async Task SelectLocation(string selectLocation)
        {
            await (await GetLocation(selectLocation)).ClickAsync();
        }

        public async Task SearchForPub(string pubName)
        {
            await PubFilterButton.ClickAsync();
            await PubFilterSearchInput.FillAsync(pubName);
            await PubFilterUseFilterButton.ClickAsync();
        }
    }
}
