using URLShortner.Models;

namespace URLShortner.Services
{
    public class URLService
    {
        private readonly URLContext context;
        private const string BaseUrl = "http://localhost:5000/";
        public URLService(URLContext _context)
        {
            context = _context;
        }
        public string AddUrl(string originalurl)
        {
            string  ShortCode = Guid.NewGuid().ToString().Substring(0, 8);
            string ShortenUrl = BaseUrl + ShortCode;
            URL one = new URL()
            {
                OriginalUrl = originalurl,
                ShortUrl = ShortenUrl
            };
            context.URLs.Add(one);
            context.SaveChanges();
            return ShortenUrl;
        }
        public string GetOriginalUrl(string shortenurl)
        {
            URL one = context.URLs.FirstOrDefault(x => x.ShortUrl == shortenurl);
            return one.OriginalUrl;
        }
    }
}
