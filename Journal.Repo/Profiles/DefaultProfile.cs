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
            CreateMap<CategoriesPost, CategoryModel>()
                .ForMember(m => m.Title, opt => opt.MapFrom(p => p.Category.Title))
                .ReverseMap();

            CreateMap<CommentModel, Comment>().ReverseMap();
        }
    }
}
