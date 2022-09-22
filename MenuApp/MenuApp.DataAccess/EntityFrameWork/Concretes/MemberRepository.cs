using MenuApp.Core.DataAccess.Concretes;
using MenuApp.DataAccess.Abstracts;
using MenuApp.DataAccess.EntityFrameWork.Context;
using MenuApp.Entity.Concretes;

namespace MenuApp.DataAccess.EntityFrameWork.Concretes
{
    public class MemberRepository : GenericRepository<Member, MenuAppDbContext>, IMemberRepository
    {
        public MemberRepository(MenuAppDbContext context) : base(context)
        {
        }
    }
}
