using Journal.Repository.Model;

namespace Journal.Repository.Services.Comments
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(JournalContext context): base(context)
        {
        }
    }
}
