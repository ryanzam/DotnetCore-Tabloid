using AutoMapper;
using Journal.Model;

namespace Journal.Repository.Model
{
    public class DefaultProfile: Profile
    {
        public DefaultProfile()
        {
            CreateMap<PostModel, Post>()
                .ForMember(m => m.CategoriesPost, opt => opt.Ignore())
                .ForMember(m => m.Comments, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<CategoryModel, Category>().ReverseMap();
            CreateMap<CommentModel, Comment>().ReverseMap();
        }
    }
}
