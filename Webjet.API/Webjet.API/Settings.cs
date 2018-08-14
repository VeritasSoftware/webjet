namespace Webjet.API
{
    public class Settings
    {
        public string Token { get; set; }
        public int NoOfRetries { get; set; }
        public string BaseProviderUrl { get; set; }
        public Provider[] Providers { get; set; }
    }

    public class Provider
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
