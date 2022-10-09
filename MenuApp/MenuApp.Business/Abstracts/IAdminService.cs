using MenuApp.Business.DTOs.Admins;
using MenuApp.Core.Utilities.Results;
using System.Threading.Tasks;

namespace MenuApp.Business.Abstracts
{
    public interface IAdminService
    {
        Task<IDataResult<AdminDto>> GetByIdentityId(string identityId);
    }
}
