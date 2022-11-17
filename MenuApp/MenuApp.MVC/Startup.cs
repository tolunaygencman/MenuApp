using AspNetCoreHero.ToastNotification.Extensions;
using MenuApp.DataAccess.EntityFrameWork.Context;
using MenuApp.MVC.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace MenuApp.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix,
                opt => opt.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    var assemblyName = new AssemblyName(typeof(SharedModelResource).GetTypeInfo().Assembly.FullName);
                    return factory.Create(nameof(SharedModelResource), assemblyName.Name);
                });

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddDbContext<MenuAppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MenuApp"));
                options.UseLazyLoadingProxies(true);
            });
            services.AddHttpContextAccessor();
            services.AddIdentityServices();
            services.AddDataAccessServices();
            services.AddBusinessServices();
            services.AddLocalizationServices();
            services.AddAutoMapperServices();
            services.AddNotyfServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            var cultures = new List<CultureInfo>
            {
                //new CultureInfo("en"),
                new CultureInfo("tr")
            };
            app.UseRequestLocalization(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("tr");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });

            app.UseNotyf();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
