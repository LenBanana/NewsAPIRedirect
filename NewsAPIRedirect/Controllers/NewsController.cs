using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NewsAPIRedirect.Helper;
using NewsAPIRedirect.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NewsAPIRedirect.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NewsController : Controller
    {
        IConfiguration Configuration { get; set; }
        string newsApikey => Configuration.GetValue<string>("NewsApiKey");
        public NewsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult> GetNewsByCategory(string country, string category)
        {
            var requestUri = $"https://newsapi.org/v2/top-headlines?country={country}&category={category}&pageSize=100&apiKey=" + newsApikey;
            var news = await WebRequests.GetAsync(requestUri);
            var newsObj = JsonConvert.DeserializeObject<NewsApi>(news);
            return Ok(newsObj);
        }

        [HttpGet]
        public async Task<ActionResult> GetNewsByKeyword(string country, string keyword)
        {
            var requestUri = $"https://newsapi.org/v2/top-headlines?country={country}&q={keyword}&pageSize=100&apiKey=" + newsApikey;
            var news = await WebRequests.GetAsync(requestUri);
            var newsObj = JsonConvert.DeserializeObject<NewsApi>(news);
            return Ok(newsObj);
        }

        [HttpGet]
        public async Task<ActionResult> GetEverythingByKeyword(string language, string keyword, string page)
        {
            var requestUri = $"https://newsapi.org/v2/everything?language={language}&q={keyword}&pageSize=100&page={page}&sortBy=relevancy&apiKey=" + newsApikey;
            var news = await WebRequests.GetAsync(requestUri);
            var newsObj = JsonConvert.DeserializeObject<NewsApi>(news);
            return Ok(newsObj);
        }
    }
}
