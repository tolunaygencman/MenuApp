using MenuApp.Core.DataAccess.Concretes;
using MenuApp.DataAccess.Abstracts;
using MenuApp.DataAccess.EntityFrameWork.Context;
using MenuApp.Entity.Concretes;

namespace MenuApp.DataAccess.EntityFrameWork.Concretes
{
    public class MenuRepository : GenericRepository<Menu, MenuAppDbContext>, IMenuRepository
    {
        public MenuRepository(MenuAppDbContext context) : base(context)
        {
        }
    }
}
