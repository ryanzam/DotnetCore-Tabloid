using AutoMapper;
using Journal.Model;

namespace Journal.Repository.Model
{
    public class DefaultProfile: Profile
    {
        public DefaultProfile()
        {
            CreateMap<PostModel, Post>().ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<CommentModel, Comment>().ReverseMap();
        }
    }
}
