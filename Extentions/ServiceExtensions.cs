using AutoMapper;
using Business.Interfaces;
using Business.Logic;
using Entities.DTO.Request.Person;
using Entities.Entity;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Interfaces.GenericRepository;
using Persistence.Interfaces;
using Persistence.Repository.GenericRepository;
using Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Entities;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Extentions
{
    public static class ServiceExtensions
    {
        
       

        public static void AddCustomControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
                options.Filters.Add(new ValidationFilterAttribute()));
        }

        public static void AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
            });
        }

        public static void AddCustomAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
