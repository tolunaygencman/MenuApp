using MenuApp.Core.DataAccess.Concretes;
using MenuApp.DataAccess.Abstracts;
using MenuApp.DataAccess.EntityFrameWork.Context;
using MenuApp.Entity.Concretes;

namespace MenuApp.DataAccess.EntityFrameWork.Concretes
{
    public class FoodRepository : GenericRepository<Food, MenuAppDbContext>, IFoodRepository
    {
        public FoodRepository(MenuAppDbContext context) : base(context)
        {
        }
    }
}
