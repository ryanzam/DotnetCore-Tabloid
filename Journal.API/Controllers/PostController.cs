using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Journal.Model;
using Journal.Repository.Model;
using Journal.Repository.Services.Categories;
using Journal.Repository.Services.Posts;
using Microsoft.AspNetCore.Mvc;

namespace Journal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _repository;
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        public PostController(IPostService repository, IMapper mapper, ICategoryService categoryService)
        {
            _repository = repository;
            _mapper = mapper;
            _categoryService = categoryService;
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
                var cats = await _categoryService.GetByIdAsync(post.CategoryId);
                
                var catPost = new CategoriesPost();
                var categoriesPost = new List<CategoriesPost>();

                catPost.Category = cats;
                categoriesPost.Add(catPost);

                post.CategoriesPost = categoriesPost;

                return Ok(_mapper.Map<PostModel>(post));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PostModel>> CreatePost([FromBody] PostModel newPost)
        {
            var post =  _mapper.Map<Post>(newPost);
            post.CategoriesPost = new List<CategoriesPost>();
            foreach(var cat in newPost.CategoriesPost)
            {
                post.CategoriesPost.Add(new CategoriesPost()
                {
                    CategoryId = cat.Id,
                    Post = post
                });
            }
            await _repository.CreateAsync(post);

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
