using Journal.Repository.Model;
using Journal.Repository.Services;

namespace Journal.Repository.Services.Posts
{
    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(JournalContext context): base(context)
        {
        }
    }
}
