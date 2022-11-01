using MenuApp.Core.Enums;
using MenuApp.DataAccess.Abstracts;
using MenuApp.Entity.Concretes;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.DataAccess.EntityFrameWork.Seeds
{
    public static class MemberSeed
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, IMemberRepository memberRepository)
        {
            var defaultUser = new IdentityUser
            {
                UserName = "member@menuapp.com",
                Email = "member@menuapp.com",
                EmailConfirmed = true
            };
            if (userManager.Users.All(x => x.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "1234");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Member.ToString());
                }
                else
                {
                    defaultUser = await userManager.FindByEmailAsync("admin@menuapp.com");
                }
            }

            var memberExist = await memberRepository.AnyAsync();
            if (!memberExist)
            {
                var member = new Member()
                {
                    FirstName = "Menu",
                    LastName = "Owner",
                    Email = defaultUser.Email,
                    IdentityId = defaultUser.Id
                };
                await memberRepository.AddAsync(member);
            }
        }
    }
}
