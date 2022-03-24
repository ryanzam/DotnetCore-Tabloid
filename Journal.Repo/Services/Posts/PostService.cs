using Journal.Repository.Model;
using Journal.Repository.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Journal.Repository.Services.Posts
{
    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(JournalContext context): base(context)
        {
        }

        //public async Task<Post> GetPostById(int id)
        //{
        //    return await _context.Set<Post>().FirstOrDefaultAsync(p => p.Id == id);
        //}
    }
}
