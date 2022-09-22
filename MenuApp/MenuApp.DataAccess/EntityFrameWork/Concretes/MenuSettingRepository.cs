using MenuApp.Core.DataAccess.Concretes;
using MenuApp.DataAccess.Abstracts;
using MenuApp.DataAccess.EntityFrameWork.Context;
using MenuApp.Entity.Concretes;

namespace MenuApp.DataAccess.EntityFrameWork.Concretes
{
    public class MenuSettingRepository : GenericRepository<MenuSetting, MenuAppDbContext>, IMenuSettingRepository
    {
        public MenuSettingRepository(MenuAppDbContext context) : base(context)
        {
        }
    }
}
