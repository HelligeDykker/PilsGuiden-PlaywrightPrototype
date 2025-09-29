namespace E2E.Utilities
{
    internal class BaseUrl
    {
        public static string GetBaseUrl()
        {
            return TestContext.Parameters.Get("BaseUrl", "https://www.pilsguiden.no/");
        }
    }
}
