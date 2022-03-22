using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Journal.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Journal.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        public readonly ILogger<CategoriesController> _logger;
        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            var cats = new List<CategoryModel>();
            using (var httpClient = new HttpClient())
            {
                using(var res = await httpClient.GetAsync("https://localhost:44395/api/Category"))
                {
                    string apiRes = await res.Content.ReadAsStringAsync();
                    cats = JsonConvert.DeserializeObject<List<CategoryModel>>(apiRes);
                }
            }
            return cats;
        }
    }
}
