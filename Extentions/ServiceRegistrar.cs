using Business.Interfaces;
using Business.Logic;
using Entities.DTO.Request.Person;
using Entities.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Interfaces.GenericRepository;
using Persistence.Interfaces;
using Persistence.Repository.GenericRepository;
using Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Extentions
{
    public static class ServiceRegistrar
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            #region register Repository here
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPersonRepository, PersonRepository>();

            #endregion

            #region register Logic Here
            services.AddScoped<ILogic<PersonDto, Person>, PersonLogic>();
            services.AddScoped<ValidationFilterAttribute>();

            #endregion
        }
    }
}
