using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URLShortner.Services;

namespace URLShortner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class URLController : ControllerBase
    {
        private readonly URLService urlservice;
        public URLController(URLService _url)
        {
            urlservice = _url;
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody]string originalurl)
        {
            string shortenurl = urlservice.AddUrl(originalurl);
            return Ok(shortenurl);
        }
        [HttpGet("getUrl")]
        public IActionResult Redirect(string shortenurl)
        {
            string originalurl = urlservice.GetOriginalUrl(shortenurl);
            if (originalurl != null)
            {
                return Ok(originalurl);
            }
            return NotFound("url not found");
        }
    }
}
