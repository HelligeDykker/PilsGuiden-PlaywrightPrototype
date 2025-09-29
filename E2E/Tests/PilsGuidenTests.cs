using E2E.Pages;

namespace E2E.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    internal class PilsGuidenTests : BaseTest
    {
        private PilsGuidenMainPage pilsGuidenMainPage;

        [SetUp]
        public void Setup()
        {
            pilsGuidenMainPage = new PilsGuidenMainPage(Page);
        }

        [Test]
        public async Task SelectOslo()
        {
            await NavigateToPage("PilsGuidenMainPage");
            await pilsGuidenMainPage.SelectLocation("Oslo");
            await Expect(Page).ToHaveURLAsync("https://www.pilsguiden.no/oslo");
        }

        [Test]
        [TestCase ("B54 Oslo")]
        [TestCase ("Casablanca Oslo")]
        public async Task SearchForPub(string pubName)
        {
            await NavigateToPage("PilsGuidenMainPage");
            await pilsGuidenMainPage.SelectLocation("Oslo");
            await pilsGuidenMainPage.SearchForPub(pubName);
            await Expect(pilsGuidenMainPage.GetPubBox(pubName)).ToContainTextAsync(pubName);
        }

    }
}
