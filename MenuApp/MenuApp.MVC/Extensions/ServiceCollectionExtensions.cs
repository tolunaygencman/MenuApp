using AspNetCoreHero.ToastNotification;
using MenuApp.Business.Abstracts;
using MenuApp.Business.Concretes;
using MenuApp.Business.Profiles;
using MenuApp.DataAccess.Abstracts;
using MenuApp.DataAccess.EntityFrameWork.Concretes;
using MenuApp.DataAccess.EntityFrameWork.Context;
using MenuApp.MVC.Profiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MenuApp.MVC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuSettingRepository, MenuSettingRepository>();

        }
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAdminService, AdminManager>();
            /*
            services.AddScoped<IMemberService, MemberManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IFoodService, FoodManager>();
            services.AddScoped<IMenuService, MenuManager>();
            services.AddScoped<IMenuSettingService, MenuSettingManager>();
            */

        }
        public static void AddLocalizationServices(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
        }
        public static void AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                /* TODO: Login girişleri kolaylaştırmak için şifre gereksinimleri basitleştirildi. Gereksinimler değiştirilecek.
                 options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 1;
                 */
                options.Password.RequiredLength = 4;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
            })
                .AddEntityFrameworkStores<MenuAppDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Login/Index");
                options.LogoutPath = new PathString("/Login/SignOut");
                options.Cookie = new CookieBuilder
                {
                    Name = "MenuAppCookie",
                    HttpOnly = false,
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.Always
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.AccessDeniedPath = new PathString("/AccessDenied");
            });
        }

        public static void AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IProfile), typeof(AdminAreaProfiles));
            services.AddAutoMapper(typeof(IProfile), typeof(MemberAreaProfiles));
        }
        public static void AddNotyfServices(this IServiceCollection services)
        {
            services.AddNotyf(options =>
            {
                options.DurationInSeconds = 7;
                options.IsDismissable = true;
                options.HasRippleEffect = true;
                options.Position = NotyfPosition.BottomCenter;
            });
        }
    }
}
