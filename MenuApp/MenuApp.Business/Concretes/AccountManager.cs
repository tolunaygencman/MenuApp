using MenuApp.Business.Abstracts;
using MenuApp.Business.Constants;
using MenuApp.Core.Utilities.Results;
using MenuApp.Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MenuApp.Business.Concretes
{
    public class AccountManager : IAccountService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountManager(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public Guid GetUserId()
        {
            return new Guid(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        }

        public async Task<IDataResult<IdentityResult>> ChangePasswordAsync(string oldPassword, string newPassword)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(GetUserId().ToString());
                    var passwordResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
                    if (!passwordResult.Succeeded)
                    {
                        scope.Dispose();

                        var errorMessage = ConcatErrors(passwordResult);

                        return new ErrorDataResult<IdentityResult>(errorMessage);
                    }
                    scope.Complete();
                    return new SuccessDataResult<IdentityResult>(Messages.PasswordChangeSuccess);


                }
                catch (Exception)
                {
                    scope.Dispose();
                    throw;
                }
            }
        }
        private string ConcatErrors(IdentityResult identityResult)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var error in identityResult.Errors)
            {
                stringBuilder.Append("**");
                stringBuilder.Append(error.Code);
                stringBuilder.Append(" - ");
                stringBuilder.Append(error.Description);
            }

            return stringBuilder.ToString();
        }
    }
}
