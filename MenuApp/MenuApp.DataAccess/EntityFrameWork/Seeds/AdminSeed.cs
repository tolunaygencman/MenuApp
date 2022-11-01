using MenuApp.Core.Enums;
using MenuApp.DataAccess.Abstracts;
using MenuApp.Entity.Concretes;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.DataAccess.EntityFrameWork.Seeds
{
    public class AdminSeed
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, IAdminRepository adminRepository)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "admin@menuapp.com",
                Email = "admin@menuapp.com",
                EmailConfirmed = true
            };
            if (userManager.Users.All(x => x.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "1234");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                }
                else 
                { 
                    defaultUser = await userManager.FindByEmailAsync("admin@menuapp.com");
                }
            }

            var adminExist = await adminRepository.AnyAsync();
            if (!adminExist)
            {
                var admin = new Admin()
                {
                    FirstName = "Menu App",
                    LastName = "Admin",
                    Email = defaultUser.Email,                     
                    IdentityId = defaultUser.Id
                };
                await adminRepository.AddAsync(admin);
            }
        }
    }
}
