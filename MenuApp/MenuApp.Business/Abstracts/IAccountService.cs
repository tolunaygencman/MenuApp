using MenuApp.Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace MenuApp.Business.Abstracts
{
    public interface IAccountService
    {
        Guid GetUserId();
        Task<IDataResult<IdentityResult>> ChangePasswordAsync(string oldPassword, string newPassword);
    }
}
