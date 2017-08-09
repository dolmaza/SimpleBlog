using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleBlog.Data;
using SimpleBlog.Data.Entities;
using SimpleBlog.Data.Repositories;
using SimpleBlog.Services;

namespace SimpleBlog
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



            services.AddIdentity<User, Role>(options =>
                {
                    options.Cookies.ApplicationCookie.LoginPath = "/admin/login";
                })
                .AddEntityFrameworkStores<DataContext, int>()
                .AddDefaultTokenProviders();

            services.AddSingleton<DbContext, DataContext>();
            services.AddSingleton<IRepository<User>, Repository<User>>();
            services.AddSingleton<IRepository<Role>, Repository<Role>>();
            services.AddSingleton<IUserService, UsersService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddSingleton(provider => Configuration);

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc(routes =>
            {

                #region Admin Routes

                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "adminDashboard",
                    template: "{area:exists}/dashboard",
                    defaults: new { controller = "Home", action = "Dashboard" });

                routes.MapRoute(
                    name: "adminUsers",
                    template: "{area:exists}/users",
                    defaults: new { controller = "Users", action = "UsersList" });

                routes.MapRoute(
                    name: "adminUsersCreate",
                    template: "{area:exists}/users/create",
                    defaults: new { controller = "Users", action = "Create" });

                routes.MapRoute(
                    name: "adminUsersEdit",
                    template: "{area:exists}/users/{id}/edit",
                    defaults: new { controller = "Users", action = "Edit" });

                routes.MapRoute(
                    name: "adminUsersDelete",
                    template: "{area:exists}/users/{id}/delete",
                    defaults: new { controller = "Users", action = "Delete" });

                routes.MapRoute(
                    name: "adminLogin",
                    template: "{area:exists}/login",
                    defaults: new { controller = "Auth", action = "Login" });
                routes.MapRoute(
                    name: "adminLogout",
                    template: "{area:exists}/logout",
                    defaults: new { controller = "Auth", action = "Logout" });

                #endregion

                #region Web Routes

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                #endregion

            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
