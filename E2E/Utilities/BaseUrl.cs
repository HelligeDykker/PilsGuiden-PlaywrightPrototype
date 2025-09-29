namespace E2E.Utilities
{
    public static class BaseUrl
    {
        public static string GetBaseUrl()
        {
            return TestContext.Parameters.Get("BaseUrl", "https://www.pilsguiden.no/");
        }     
    }
}
