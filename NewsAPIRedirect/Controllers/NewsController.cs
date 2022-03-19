using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAPIRedirect.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NewsController : Controller
    {
        IConfiguration Configuration { get; set; }
        public NewsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public ActionResult GetTopHeadlines(string country, string category)
        {
            var requestUri = "https://newsapi.org/v2/top-headlines?country=de&category=business&apiKey=" + Configuration.GetValue<string>("NewsApiKey");
            return Ok();
        }
    }
}
