using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using TodoList.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoList.Repository;
using Microsoft.AspNetCore.Identity;
using TodoList.Models.Password;
using TodoList.Models.Password.Validator;
using System.Collections.Generic;

namespace TodoList
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApplicationContext")));

            services.AddIdentity<User, IdentityRole>(
                opts => {
                    opts.Password.RequiredLength = 8;
                    opts.Password.RequireNonAlphanumeric = true;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = true;
                }).AddEntityFrameworkStores<ApplicationContext>();
            services.AddTransient<IPasswordValidator<User>, UserPasswordValidator>(serv => new UserPasswordValidator(
                new List<IValidator>
                {
                    new MinTwoCapitalValidator(),
                    new NoWhitespaceValidator()
                }
            ));

            services.AddScoped<ITaskRepository, TaskRepository>();

            services.AddControllers();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}