using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Journal.Model;
using Journal.Model.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Journal.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<PostModel>> GetAllPost()
        {
            var posts = new List<PostModel>();
            using(var httpClient = new HttpClient())
            {
                using(var res = await httpClient.GetAsync("https://localhost:44395/api/Post"))
                {
                    string apiRes = await res.Content.ReadAsStringAsync();
                    posts = JsonConvert.DeserializeObject<List<PostModel>>(apiRes);
                }
            }
            return posts;
        }

        [HttpGet("{id}")]
        public async Task<PostModel> GetPostById(int id)
        {
            var post = new PostModel();
            using (var httpClient = new HttpClient())
            {
                using (var res = await httpClient.GetAsync("https://localhost:44395/api/Post/"+id))
                {
                    string apiRes = await res.Content.ReadAsStringAsync();
                    post = JsonConvert.DeserializeObject<PostModel>(apiRes);
                }
            }
            return post;
        }

        [HttpPost]
        public async Task<PostModel> CreateItemAsync(PostModel newPost)
        {
            var post = new PostModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newPost), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44395/api/Post", content))
                {
                    string apiRes = await response.Content.ReadAsStringAsync();
                    post = JsonConvert.DeserializeObject<PostModel>(apiRes);
                }
            }
            return post;
        }
    }
}
