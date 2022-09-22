using MenuApp.Core.DataAccess.Abstracts;
using MenuApp.Entity.Concretes;

namespace MenuApp.DataAccess.Abstracts
{
    public interface IMemberRepository : IRepository<Member>
    {
    }
}
