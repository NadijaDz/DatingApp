using DatingApp.Infrastructure.EF;
using DatingApp.Infrastructure.Interfaces;
using DatingApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Infrastructure.Mapping;
using DatingApp.Infrastructure.Helpers;

namespace DatingApp.Infrastructure.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<LogUserActivity>();

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            services.AddDbContext<DatingAppDbContext>(options =>
             options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }

    }
}
