using Journal.Repository.Model;
using Journal.Repository.Services.Categories;

namespace Journal.Repository.Services.Categories
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(JournalContext context) : base(context)
        {
        }
    }
}
