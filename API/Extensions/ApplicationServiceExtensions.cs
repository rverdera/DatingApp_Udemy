﻿using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });


            services.AddCors(options => options.AddPolicy(name: "DatingApp",
               policy =>
               {
                   policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
               })
            );

            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
