using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Journal.Model;
using Journal.Repository.Services.Comments;
using Journal.Repository.Model;

namespace Journal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _repository;
        private readonly IMapper _mapper;

        public CommentController(ICommentService repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetComments()
        {
            var categories = await _repository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CommentModel>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetComment(int id)
        {
            var comment = await _repository.GetByIdAsync(id);
            if (comment != null)
            {
                return Ok(_mapper.Map<IEnumerable<CommentModel>>(comment));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CommentModel>> CreateComment([FromBody] CommentModel newComment)
        {
            if (newComment == null)
            {
                return BadRequest();
            }
            var cmt = _mapper.Map<Comment>(newComment);
            await _repository.CreateAsync(cmt);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateComment(int id, [FromBody] CommentModel cmtModel)
        {
            if (cmtModel == null)
            {
                return BadRequest();
            }
            var cmt = _mapper.Map<Comment>(cmtModel);
            await _repository.UpdateAsync(cmt);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}
