using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Journal.Model;
using Journal.Repository.Model;
using Journal.Repository.Services.Posts;
using Microsoft.AspNetCore.Mvc;

namespace Journal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _repository;
        private readonly IMapper _mapper;

        public PostController(IPostService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostModel>>> GetPosts()
        {
            var posts = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PostModel>>(posts));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostModel>> GetPost(int id)
        {
            var post = await _repository.GetByIdAsync(id);
            if(post != null)
            {
                return Ok(_mapper.Map<PostModel>(post));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PostModel>> CreatePost([FromBody] PostModel postModel)
        {
            var p =  _mapper.Map<Post>(postModel);
            await _repository.CreateAsync(p);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(int id,[FromBody] PostModel postModel)
        {
           var p = _mapper.Map<Post>(postModel);
           await _repository.UpdateAsync(p);
           return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}
