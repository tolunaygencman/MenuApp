using MenuApp.Core.DataAccess.Concretes;
using MenuApp.DataAccess.Abstracts;
using MenuApp.DataAccess.EntityFrameWork.Context;
using MenuApp.Entity.Concretes;

namespace MenuApp.DataAccess.EntityFrameWork.Concretes
{
    public class AdminRepository : GenericRepository<Admin, MenuAppDbContext> , IAdminRepository
    {
        public AdminRepository(MenuAppDbContext context) : base(context)
        {
        }
    }
}
