using MenuApp.Core.DataAccess.Concretes;
using MenuApp.DataAccess.Abstracts;
using MenuApp.DataAccess.EntityFrameWork.Context;
using MenuApp.Entity.Concretes;

namespace MenuApp.DataAccess.EntityFrameWork.Concretes
{
    public class CategoryRepository : GenericRepository<Category, MenuAppDbContext>, ICategoryRepository
    {
        public CategoryRepository(MenuAppDbContext context) : base(context)
        {
        }
    }
}
