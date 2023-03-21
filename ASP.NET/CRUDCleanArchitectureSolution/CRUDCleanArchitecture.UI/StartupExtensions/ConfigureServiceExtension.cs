using CRUDCleanArchitecture.Core.Domain.IdentityEntities;
using CrudExample.Filters.ActionFilters;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories;
using RepositoryContracts;
using ServiceContracts;
using Services;

namespace CrudExample
{
    // static method in a static class can be used as extension method
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews(options => {
                // can not supply argument values with this syntax
                // options.Filters.Add<ResponseHeaderActionFilter>();

                // add ILogger
                var logger = services.BuildServiceProvider().GetRequiredService<ILogger<ResponseHeaderActionFilter>>();
                options.Filters.Add(new ResponseHeaderActionFilter("My-Key-From-Global", "My-Value-From-Global", 2));
            });

            // add servicos into IOC
            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped<IPersonsService, PersonsService>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IPersonsRepository, PersonsRepository>();

            // DbContext as a service - EFC
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // supply connection string
                // should save in configuration
                // scoped service as default ! cannot add into a singleton
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            // Enable Identity in the project
            services
                .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    options.Password.RequiredLength = 5; // default is 6
                    options.Password.RequireNonAlphanumeric = false; // default is true
                    options.Password.RequireUppercase = false; // default is true
                })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>() // repository layer level
                .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();

            return services;
        }
    }
}
