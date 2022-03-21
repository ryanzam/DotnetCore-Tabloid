using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Journal.Model;
using Journal.Repository.Model;
using Journal.Repository.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Journal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _repository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategories()
        {
            var categories = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryModel>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategory(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category != null)
            {
                return Ok(_mapper.Map<CategoryModel>(category));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryModel>> CreateCategory([FromBody] CategoryModel newCat)
        {
            if(newCat == null)
            {
                return BadRequest();
            }
            var cat = _mapper.Map<Category>(newCat);
            await _repository.CreateAsync(cat);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] CategoryModel catModel)
        {
            if (catModel == null)
            {
                return BadRequest();
            }
            var cat = _mapper.Map<Category>(catModel);
            await _repository.UpdateAsync(cat);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}
