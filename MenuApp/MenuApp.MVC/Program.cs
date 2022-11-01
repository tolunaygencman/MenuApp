using MenuApp.DataAccess.Abstracts;
using MenuApp.DataAccess.EntityFrameWork.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger("app");
                try
                {
                    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var adminRepository = services.GetRequiredService<IAdminRepository>();
                    var memberRepository = services.GetRequiredService<IMemberRepository>();
                    await RoleSeed.SeedAsync(roleManager);
                    await AdminSeed.SeedAsync(userManager, adminRepository);
                    await MemberSeed.SeedAsync(userManager, memberRepository);
                    logger.LogInformation("Varsayýlan Veriler Sisteme Eklendi");
                    logger.LogInformation("Uygulama Baþlatýlýyor");
                }
                catch (Exception ex)
                {
                    logger.LogWarning(ex, "Varsayýlan veriler Veri Tabanýna aktarýlýrken bir sorun oluþtu");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
