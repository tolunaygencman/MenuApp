using MenuApp.Core.Enums;
using MenuApp.DataAccess.Abstracts;
using MenuApp.Entity.Concretes;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.DataAccess.EntityFrameWork.Seeds
{
    public class MemberSeed
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, IMemberRepository memberRepository)
        {
            var defaultMember = new IdentityUser
            {
                UserName = "member@menuapp.com",
                Email = "member@menuapp.com",
                EmailConfirmed = true
            };
            if (userManager.Users.All(x => x.Id != defaultMember.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultMember.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultMember, "1234");
                    await userManager.AddToRoleAsync(defaultMember, Roles.Member.ToString());
                }
                else
                {
                    defaultMember = await userManager.FindByEmailAsync("member@menuapp.com");
                }
            }

            var memberExist = await memberRepository.AnyAsync();
            if (!memberExist)
            {
                var member = new Member()
                {
                    FirstName = "Menu",
                    LastName = "Owner",
                    Email = defaultMember.Email,
                    IdentityId = defaultMember.Id,
                    RestourantName ="Acme"
                };
                await memberRepository.AddAsync(member);
            }
        }
    }
}
