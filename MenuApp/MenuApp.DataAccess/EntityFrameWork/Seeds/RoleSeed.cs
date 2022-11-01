using MenuApp.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MenuApp.DataAccess.EntityFrameWork.Seeds
{
    public static class RoleSeed
    {
        public async static Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Member.ToString()));
        }
    }
}
