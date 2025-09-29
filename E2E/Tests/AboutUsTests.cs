using E2E.Pages;

namespace E2E.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    internal class AboutUsTests : BaseTest
    {
        AboutUsPage AboutUsPage;
        [SetUp]
        public void Setup()
        {
            AboutUsPage = new AboutUsPage(Page);
        }

        [Test]
        public async Task NavigateToAboutUs()
        {
            await NavigateToPage("AboutUsPage");
            await Expect(AboutUsPage.AboutUsHeader).ToHaveTextAsync("Om Pilsguiden");
        }
    }
}
