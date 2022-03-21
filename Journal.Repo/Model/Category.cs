using System.Collections.Generic;

namespace Journal.Repository.Model
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Post> RelatedPosts { get; set; }
    }
}
