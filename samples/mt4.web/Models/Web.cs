namespace rox.mt4.web
{
    using rox.mt4.rest;
    public class WebConfig
    {
        public string Url { get; set; } = "http://+:8000/";
        public string BaseRoute { get; set; } = "/api/mt4/";
        public TokenOption Auth { get; set; } = new TokenOption();
    }
}
