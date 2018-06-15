
using AutoMapper;
using Data.Conector;
using Dominio.Interfaces;
using Dominio.Interfaces.Services;
using Dominio.Interfaces.Servicos;
using Dominio.Servicos;
using Dominio.Servicos.BancosExec;
using Identity.Data;
using Identity.Models;
using InjecaoDependencia;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkDB, UnitOfWorkDB>();
            //services.AddScoped<IContextSqlServer, ContextoSqlServer>();

            services.AddTransient(typeof(SqlServerService));
            services.AddTransient<IConsultaService, ConsultaService>();
            services.AddTransient<IParametrosService, ParametrosServices>();

            services.AddSingleton(new MapperConfiguration(cfg => {
                cfg.AddProfile(new Mapeamento());
            }).CreateMapper());

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddDbContext<IdentityContexto>(options =>
                options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\99003731\\Desktop\\Projeto-Sistema-de-Consultas-OnDemand-master\\database.mdf;Integrated Security=True;Connect Timeout=30"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContexto>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            return services;
        }
    }
}
