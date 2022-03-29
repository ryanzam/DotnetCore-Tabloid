using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Journal.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Journal.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;

        public AuthController(ILogger<PostController> logger)
        {
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<RegisterModel> Register(RegisterModel newUser)
        {
            var user = new RegisterModel();
            using (var httpClient = new HttpClient())
            {
                using (var res = await httpClient.GetAsync("https://localhost:44395/api/Auth/register"))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");

                    string apiRes = await res.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<RegisterModel>(apiRes);
                }
            }
            return user;
        }

        [HttpPost("login")]
        public async Task<AuthData> Login(LoginModel newUser)
        {
            var user = new AuthData();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");

                using (var res = await httpClient.PostAsync("https://localhost:44395/api/Auth/login", content))
                {

                    string apiRes = await res.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<AuthData>(apiRes);
                }
            }
            return user;
        }
    }
}
